using TMPro;
using UnityEngine;

public class MenuController:MonoBehaviour
{
    public LeaderboardManager leaderboardManager;
    public TMP_Text leaderboardText;
    private void Start ()
    {
        ShowLeaderboard();
    }
    public void ShowLeaderboard ()
    {
        leaderboardManager.DisplayLeaderboard(leaderboardText);
    }
}