using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
    }

    public void OnMultiplayerButtonClick()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
