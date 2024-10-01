using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    public GameObject doorWall;

    void OnTriggerEnter2D(Collider2D collider)

    {
        if(collider.gameObject.CompareTag("Player"))
        {
            doorWall.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            doorWall.SetActive(true);
        }
    }
    
}