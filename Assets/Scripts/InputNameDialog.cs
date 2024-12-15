using UnityEngine;
using TMPro;
public class InputNameDialog:MonoBehaviour
{
    public TMP_InputField inputField;
    public LeaderboardManager leaderboardManager;

    public void SubmitNameAndScore ()
    {
        var name = inputField.text;
        leaderboardManager.AddNewRecord(name, GameObject.FindFirstObjectByType<ScoreCounter>().score);
        gameObject.SetActive(false);
    }
}