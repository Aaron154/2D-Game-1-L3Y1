using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLose : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);

        Debug.Log("Player Has Died");
    }
}
