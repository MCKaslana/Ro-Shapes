using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressEvents : MonoBehaviour
{
    public static ButtonPressEvents instance;
    [SerializeField] private int _nextLevelIndex;

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

    public void GoToGame()
    {
        SceneManager.LoadScene(_nextLevelIndex);
        Time.timeScale = 1f;
    }
}
