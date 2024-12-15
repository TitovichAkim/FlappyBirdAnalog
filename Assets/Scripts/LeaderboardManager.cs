using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Структура для хранения одного рекорда
[System.Serializable]

public class LeaderboardManager:MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text gameScore;
    public TMP_Text bestScore;
    public List<string[]> scoreBoardList = new List<string[]>();
    // Список рекордов

    // Максимальное количество записей в таблице лидеров
    public const int MaxRecords = 10;

    void Awake ()
    {
        //PlayerPrefs.DeleteAll();
        LoadRecords();
    }

    // Загружаем записи из файла
    private void LoadRecords ()
    {
        if(!PlayerPrefs.HasKey("Leaderboard"))
        {
            Debug.LogWarning($"Ключ 'Leaderboard' не найден в PlayerPrefs.");
            return;
        }

        string data = PlayerPrefs.GetString("Leaderboard");

        string[] recordsArray = data.Split('|');

        foreach(string record in recordsArray)
        {
            string[] parts = record.Split(',');

            if(parts.Length == 2)
            {
                string name = parts[0];
                int score = int.Parse(parts[1]);
                scoreBoardList.Add(parts);
            }
        }
    }

    // Сохраняем записи в файл
    private void SaveRecords ()
    {
        string data = "";

        foreach(string[] record in scoreBoardList)
        {
            data += record[0] + "," + record[1] + "|";
        }

        PlayerPrefs.SetString("Leaderboard", data.Substring(0, data.Length - 1));
        PlayerPrefs.Save();
    }

    // Добавляем новый рекорд
    public void AddNewRecord (string name, int score)
    {
        // Создаем новый рекорд
        var newRecord = new string[] { name, score.ToString() };

        // Находим позицию для вставки
        for(int i = 0; i < scoreBoardList.Count; ++i)
        {
            if(score >= int.Parse(scoreBoardList[i][1]))
            {
                Debug.Log("Место " + i + ", значение " + int.Parse(scoreBoardList[i][1]));
                scoreBoardList.Insert(i, newRecord);
                break;
            }
            if(i == scoreBoardList.Count)
            {
                // Если список неполный, добавляем в конец
                if(scoreBoardList.Count < MaxRecords)
                {
                }
            }
        }
        if (scoreBoardList.Count == 0)
        {
            scoreBoardList.Add(newRecord);
        } else if (scoreBoardList.Count < 10 && score < int.Parse(scoreBoardList[scoreBoardList.Count - 1][1]))
        {
            scoreBoardList.Add(newRecord);
        }




        // Ограничиваем длину списка до 10 элементов
        while(scoreBoardList.Count > MaxRecords)
        {
            scoreBoardList.RemoveAt(MaxRecords);
        }

        gameOverPanel.SetActive(true);
        if(scoreBoardList.Count > 0)
        {
            bestScore.text = scoreBoardList[0][1].ToString(); // Вписать самый лучший результат в поле
        }
        else
        {
            bestScore.text = "0"; // Вписать самый лучший результат в поле
        }
        gameScore.text = score.ToString(); // Выписать на табло текущий результат

        // Сохраняем новые данные
        SaveRecords();
    }

    // Отображаем таблицу лидеров в TMPText
    public void DisplayLeaderboard (TMP_Text leaderboardText)
    {
        leaderboardText.text = "";

        for(int i = 0; i < scoreBoardList.Count; ++i)
        {
            leaderboardText.text += $"{i + 1}. \"{scoreBoardList[i][0]}\".............{scoreBoardList[i][1]}\n";
        }
    }
}