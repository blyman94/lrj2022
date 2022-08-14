using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu]
public class ApplicationManager : ScriptableObject
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

    public void LoadMainScene()
    {
        Debug.Log("Called");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
