using UnityEngine;

using UnityEngine.SceneManagement;

public class Play: MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitar()
    {
        Application.Quit();
    }
}

