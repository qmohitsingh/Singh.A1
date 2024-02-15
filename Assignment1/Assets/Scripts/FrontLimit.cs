using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontLimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter frontLine "+ other);
        if (other.CompareTag("Enemy")) // Make sure your enemies are tagged as "Enemy"
        {
            GameManager.instance.EndGame(); // Call the EndGame method on your GameManager
        }
    }
}
