using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioListener listener;
    public GameObject soundOnGO;
    public GameObject soundOffGO;
    public int soundType = 1; // 1 - звук включен, 0 - звук выкулючен

    public void Start ()
    {
        if(PlayerPrefs.HasKey("SoundType"))
        {
            soundType = PlayerPrefs.GetInt("SoundType");
        }
        else
        {
            soundType = 1;
            Debug.Log("Нет сохранения");
        }
        AudioManage(soundType);
    }
    public void AudioManage (int typeValue) // выполняет управление звуком и кнопками
    {
        if(typeValue == 1) 
        {
            soundOnGO.SetActive(true);
            soundOffGO.SetActive(false);
            listener.enabled = true;
        }
        else
        {
            soundOnGO.SetActive(false);
            soundOffGO.SetActive(true);
            listener.enabled = false;
        }
        PlayerPrefs.SetInt("SoundType", typeValue);
    }
}
