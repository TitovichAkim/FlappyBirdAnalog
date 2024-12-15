using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{
    public GameObject inputNameDialog;
    public GameObject gameOverPanel;
    public GameObject upButtonGO;
    public ScoreCounter scoreCounter;
    public SoundManager soundManager;
    public LeaderboardManager leaderboardManager;

    public void Start ()
    {
        Time.timeScale = 1.0f;
    }
    public void GameOver ()
    {
        soundManager.BreackPlay();
        Time.timeScale = 0f;
        if(leaderboardManager.scoreBoardList.Count >= 10 && int.Parse(leaderboardManager.scoreBoardList[9][1]) > scoreCounter.score)
        {
            leaderboardManager.AddNewRecord("HER", scoreCounter.score);
        }
        else
        {
            inputNameDialog.SetActive(true);
        }
        upButtonGO.SetActive(false);
    }
    public void RestartLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагрузка сцены
    }
    public void StartTargetScene (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}