using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            
            if (winScreen != null)
            {
                winScreen.SetActive(true);
            }
            
            Debug.Log("Player Has Finished The Game");
        }
    }
}
