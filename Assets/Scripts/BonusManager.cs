using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BonusManager : MonoBehaviour
{
    [Header("SetInInspector")]
    public Sprite[] bonusNumberSpriteArray;
    public int[] bonusMultiplier;
    public SpriteRenderer bonusRenderer;

    [Header("SetDynamically")]
    private SoundManager _soundManager;
    private int _bonusNumber;

    private void Start ()
    {
        _soundManager = GameObject.FindAnyObjectByType<SoundManager>();
    }
    public void ActivateBonus (int bonusIndex)
    {
        _bonusNumber = bonusIndex-1;
        bonusRenderer.sprite = bonusNumberSpriteArray[_bonusNumber];
    }

    public void GetBonus (ScoreCounter scoreCounter)
    {
        scoreCounter.score += bonusMultiplier[_bonusNumber];
        _soundManager.AmPlay();
        Destroy(gameObject);
    }

}
