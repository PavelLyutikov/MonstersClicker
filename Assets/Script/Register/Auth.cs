using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using System.Linq;
using Firebase.Database;

public class Auth : MonoBehaviour
{
    DatabaseReference databaseReference;
    FirebaseAuth auth;

    [Header("Links")]

    [SerializeField] public InputField email;
    [SerializeField] public InputField password;

    [SerializeField] private GameObject leaderBoard;
    [SerializeField] private GameObject registerBoard;

    [SerializeField] Text TextLeaders;

    public void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        auth.StateChanged += Auth_StateChanged;

        StartCoroutine(GetLeaders());
    }

    public void LoginButton()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text);
    }

    public void RegisterButton()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text);
    }

    public void LeaveButton()
    {
        PlayerPrefs.DeleteKey("Score");
        auth.SignOut();
    }

    public IEnumerator GetLeaders()
    {
        var leaders = databaseReference.Child("LeaderBoard").OrderByChild("Score").GetValueAsync();

        yield return new WaitUntil(predicate: () => leaders.IsCompleted);

        if (leaders.Exception != null)
        {
            Debug.Log("Error:" + leaders.Exception);
        }
        else if (leaders.Result.Value == null)
        {
            Debug.Log("Result.Value == null");
        }
        else
        {
            DataSnapshot snapshot = leaders.Result;

            int num = 1;
            foreach (DataSnapshot dataChildSnapshot in snapshot.Children.Reverse())
            {
                TextLeaders.text += "\n"+ num + ") " + dataChildSnapshot.Child("Email").Value.ToString() + " : " + dataChildSnapshot.Child("Score").Value.ToString();
                num++;
            }
        }
    }

    private void Auth_StateChanged(object sender, System.EventArgs e)
    {
        if (auth.CurrentUser != null)
        {
            leaderBoard.SetActive(true);
            registerBoard.SetActive(false);
        }
        else if (auth.CurrentUser == null)
        {
            leaderBoard.SetActive(false);
            registerBoard.SetActive(true);
        }
    }
}
