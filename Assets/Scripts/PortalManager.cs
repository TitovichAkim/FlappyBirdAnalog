using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public void ActivatePortal ()
    {
        GameObject.FindFirstObjectByType<CameraMovement>().RotateTheCamera();
        GameObject.FindFirstObjectByType<ScoreCounter>().scoreMultiplier++;
        Destroy(gameObject);
    }
}
