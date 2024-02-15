using System.Collections;
using UnityEngine;

public class EnemyBulletShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform aimPosition;
    // Increase these values to make enemies wait longer before they shoot
    public float minTimeBetweenShots = 2f; // Increased minimum time between shots
    public float maxTimeBetweenShots = 10f; // Increased maximum time for even more randomness

    void Start()
    {
        StartCoroutine(ShootAtRandomIntervals());
    }

    IEnumerator ShootAtRandomIntervals()
    {
        while (true)
        {
            // Wait for a random interval between shots
            yield return new WaitForSeconds(Random.Range(minTimeBetweenShots, maxTimeBetweenShots));
            
            // After waiting, shoot
            Shooting();
        }
    }

    void Shooting()
    {
        Instantiate(bullet, aimPosition.position, Quaternion.identity); // Ensure bullets face the correct direction
    }
}
