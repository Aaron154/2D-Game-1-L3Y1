using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float endTime = 60.0f;

    void Start()
    {
        currentTime = 0.0f;
        StartCoroutine(TimerCoroutine()); // Start the timer coroutine
    }

    IEnumerator TimerCoroutine()
    {
        while (currentTime < endTime)
        {
            Debug.Log("Timer Is At " + currentTime);
            yield return new WaitForSeconds(1.0f); // Wait for 1 second
            currentTime += 1.0f; // Increment time after waiting
        }
        // else
        // {
            // Open a scene if the currentTime is = or > than 
        // }
    }

}
