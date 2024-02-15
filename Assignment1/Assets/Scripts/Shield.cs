using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet") || other.CompareTag("EnemyBullet") || other.CompareTag("Enemy")) // Ensure your bullet prefab is tagged as "PlayerBullet"
        {
            Destroy(gameObject); // Destroy the shield
            Destroy(other.gameObject); // Optionally, destroy the bullet as well
        }
    }
}
