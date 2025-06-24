using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressEvents : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
