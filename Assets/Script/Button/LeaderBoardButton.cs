using UnityEngine;

public class LeaderBoardButton : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;

    public void ShowScorePanel()
    {
        scorePanel.SetActive(true);
    }

    public void CloseScorePanel()
    {
        scorePanel.SetActive(false);
    }
}
