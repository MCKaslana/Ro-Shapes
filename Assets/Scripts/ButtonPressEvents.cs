using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressEvents : MonoBehaviour
{
    public static ButtonPressEvents instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    int levelIndex = 0;
    public void GoToGame()
    {
        levelIndex++;
        SceneManager.LoadScene(levelIndex);
    }
}
