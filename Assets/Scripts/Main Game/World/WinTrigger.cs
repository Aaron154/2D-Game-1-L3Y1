using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            
            // Show The Win Screen
            if (winScreen != null)
            {
                winScreen.SetActive(true);
            }
            
            Debug.Log("Player has won the game!");
        }
    }
}
