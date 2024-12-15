using UnityEngine;

public class ColumnGenerator:MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public GameObject lowerColumnPrefab;
    public GameObject upperColumnPrefab;

    public float spawnRate; // частота появления труб
    public float xPos; // Начальная позиция по x
    public float yMinLowerColumn;     // минимальная высота трубы
    public float yMaxLowerColumn;      // максимальная высота трубы
    public float yMinUpperColumn;     // минимальная высота трубы
    public float yMaxUpperColumn;      // максимальная высота трубы

    private int difficultyIndex;

    void Start ()
    {
        InvokeRepeating("ColumnGenerate", 0f, spawnRate);
    }

    void ColumnGenerate ()
    {
        if(scoreCounter.score < 25)
        {
            difficultyIndex = 0;
        }
        else if(scoreCounter.score > 25 && scoreCounter.score < 50)
        {
            difficultyIndex = 1;
        }
        else
        {
            difficultyIndex = 2;
        }

        int randomDifficultyIndex = Random.Range(0, difficultyIndex + 1);


        switch(randomDifficultyIndex)
        {
            case 0:
                Generate(yMinLowerColumn, yMaxLowerColumn, lowerColumnPrefab);
                break;
            case 1:
                Generate(yMinUpperColumn, yMaxUpperColumn, upperColumnPrefab);
                break;
            case 2:
                TwoColumnsGenerate();
                break;
        }
    }
    void Generate (float yMinPos, float yMaxPos, GameObject columnPrefab)
    {
        float yPos = Random.Range(yMinPos, yMaxPos);
        Instantiate (columnPrefab, new Vector2(xPos, yPos), Quaternion.identity);
    }

    void TwoColumnsGenerate ()
    {
        float randomYPos = Random.Range(yMinLowerColumn, yMaxLowerColumn - 1);
        Generate(yMinLowerColumn, randomYPos, lowerColumnPrefab);
        randomYPos = yMinLowerColumn - randomYPos - 1f;
        Generate(yMinUpperColumn - randomYPos, yMaxUpperColumn, upperColumnPrefab);

    }
}
