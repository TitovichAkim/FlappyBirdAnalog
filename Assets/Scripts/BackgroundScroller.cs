using Unity.Android.Gradle;
using UnityEngine;

public class BackgroundScroller:MonoBehaviour
{
    public Sprite[] buildingsArray;
    public float moveSpeed = 5f;
    public float width;

    private SpriteRenderer _spriteRenderer;

    private void Start ()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update ()
    {
        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);

        if(transform.localPosition.x <= -width)
        {
            Vector3 pos = transform.localPosition;
            pos.x += width * 2;
            transform.localPosition = pos;

            if(buildingsArray.Length != 0)
            {
                int randInt = Random.Range(0, buildingsArray.Length);
                _spriteRenderer.sprite = buildingsArray[randInt];
            }
        }

    }
}