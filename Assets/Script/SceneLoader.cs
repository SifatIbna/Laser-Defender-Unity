using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene()
    {
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx + 1);
    }

    public void BackToStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();

    }

    public void LoadGameOverScene()
    {
        StartCoroutine(DelayGameOverScene());
    }

    IEnumerator DelayGameOverScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game Over");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
