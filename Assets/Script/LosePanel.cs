using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
