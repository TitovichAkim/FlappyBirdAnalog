using UnityEngine;

public class ColumnMovement : MonoBehaviour
{
    public GameObject bonusGO;
    public GameObject portalGO;
    public float speed = 5f;

    private int[] arrayOfBonuses = new int[100];
    public void Start ()
    {
        for(int i = 0; i < arrayOfBonuses.Length; i += 5)
        {
            arrayOfBonuses[i] = 1;
        }

        for(int i = 1; i < arrayOfBonuses.Length; i += 24)
        {
            arrayOfBonuses[i] = 2;
        }
        for(int i = 49; i < arrayOfBonuses.Length; i += 50)
        {
            arrayOfBonuses[i] = 3;
        }
        for(int i = 49; i < arrayOfBonuses.Length; i += 19)
        {
            arrayOfBonuses[i] = 4;
        }
        int randInt = Random.Range(0, 100);
        if(arrayOfBonuses[randInt] > 0 && arrayOfBonuses[randInt] != 4)
        {
            bonusGO.SetActive(true);
            bonusGO.GetComponent<BonusManager>().ActivateBonus(arrayOfBonuses[randInt]);
        }
        else if (arrayOfBonuses[randInt] == 4)
        {
             portalGO.SetActive(true);
        }
    }

    void Update ()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= -20f)
        {
            Destroy(this.gameObject);
        }
    }
}
