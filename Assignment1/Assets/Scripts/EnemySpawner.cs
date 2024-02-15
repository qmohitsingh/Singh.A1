using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the inspector
    public int totalEnemies = 4; // Total number of enemies to spawn per row
    public float rangeBetweenWalls = 40f; // Total available range (width) between walls
    public float rowSpacing = 5f; // Spacing between rows

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
{
    Vector3 centerPosition = this.transform.position; // Center point to start spawning from

    // First row will have 5 enemies, second row will have 4
    int[] enemiesPerRow = new int[] {5, 4};

    // Loop for two rows
    for (int row = 0; row < 2; row++)
    {
        // Update totalEnemies for the current row
        totalEnemies = enemiesPerRow[row];
        
        // Recalculate spacing for the current row
        float spacing = rangeBetweenWalls / (totalEnemies + 1);

        for (int i = 0; i < totalEnemies; i++)
        {
            // Calculate the position for each enemy
            Vector3 spawnPosition = centerPosition 
                                    + (Vector3.right * ((i + 1) - (totalEnemies / 2f)) * spacing)
                                    - (Vector3.right * spacing / 2) // Adjust centering for even counts
                                    + (Vector3.forward * row * rowSpacing); // Adjust position for rows

            // Instantiate the enemy at the calculated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

}
