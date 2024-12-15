using UnityEngine;

public class SoundManager: MonoBehaviour
{
    public AudioSource gameSource;
    public AudioSource amSource;
    public AudioSource clickSource;
    public AudioSource brakeSource;

    public void AmPlay ()
    {
        amSource.Play ();
    }
    public void BreackPlay ()
    {
        brakeSource.Play ();
    }
}
