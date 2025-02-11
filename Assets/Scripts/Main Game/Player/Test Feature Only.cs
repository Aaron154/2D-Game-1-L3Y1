using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFeatureOnly : MonoBehaviour
{

    private bool isGodMode;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            isGodMode = true;
            Debug.Log("God Mode Enabled");
        }
        else
        {
            isGodMode = false;
            Debug.Log("God Mode Disabled");
        }

        if (isGodMode)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            currentHealth == playerMaxHealth;
        }
    }
}
