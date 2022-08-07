using UnityEngine;
using Firebase.Database;
using Firebase.Auth;

public class GameManager : MonoBehaviour
{
    DatabaseReference databaseReference;
    FirebaseAuth auth;

    [SerializeField] private GameObject losePanel;

    private void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    void Update()
    {

        GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
        int untagged = 0;
        for (int i = 0; i < array.Length; i++)
        {
            GameObject go = array[i];
            if (go != null && go.tag == "Enemy")
            {
                untagged++;
                if (untagged >= 10)
                {
                    //Debug.Log(untagged);
                    EngGame();
                }

            }
        }
    }

    public void EngGame()
    {
        int lastRunScore = ClickCount.Click;
        int recordScore = PlayerPrefs.GetInt("Score");

        if (lastRunScore > recordScore)
        {
            recordScore = lastRunScore;
            PlayerPrefs.SetInt("Score", recordScore);

            databaseReference.Child("LeaderBoard").Child(auth.CurrentUser.Email.Replace(".", "")).Child("Score").SetValueAsync(ClickCount.Click);
            databaseReference.Child("LeaderBoard").Child(auth.CurrentUser.Email.Replace(".", "")).Child("Email").SetValueAsync(auth.CurrentUser.Email);
        }

        DifficultyIncrease.time = 0;

        losePanel.SetActive(true);
        Time.timeScale = 0;

        
    }
}
