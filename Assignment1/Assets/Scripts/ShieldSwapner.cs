using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab; // Assign your shield prefab in the inspector
    public int totalShields = 3; // Total number of shields to spawn
    public float rangeBetweenWalls = 40f; // Total available range (width) between walls

    void Start()
    {
        SpawnShields();
    }

    void SpawnShields()
    {
        Vector3 centerPosition = this.transform.position; // Center point to start spawning from

        // Assuming each shield is 2 units wide and you want 1 unit of space between them
        float shieldWidth = 2f;
        float spaceBetweenShields = 4f;
        float totalSpaceNeeded = (totalShields * shieldWidth) + ((totalShields - 1) * spaceBetweenShields);

        // Adjust the starting position based on the total space needed
        Vector3 startPosition = centerPosition - Vector3.right * (totalSpaceNeeded / 2);

        // Spawn shields in a single row
        for (int i = 0; i < totalShields; i++)
        {
            // Calculate the position for each shield, accounting for the width and space
            Vector3 spawnPosition = startPosition + Vector3.right * (i * (shieldWidth + spaceBetweenShields));

            // Instantiate the shield at the calculated position
            Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
