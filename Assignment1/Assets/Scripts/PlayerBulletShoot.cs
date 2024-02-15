using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform aimPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Shooting();
        }
        
    }

    void Shooting() {
        Instantiate(bullet, aimPosition.position, aimPosition.rotation);
        
        // Simple recoil effect
        StartCoroutine(ApplyRecoil(aimPosition, 0.5f, 2f)); // Adjust these values as needed
    }

    IEnumerator ApplyRecoil(Transform aimTransform, float recoilAmount, float speed)
    {
        // Initial aim position
        Quaternion initialRotation = aimTransform.localRotation;
        
        // Apply recoil by rotating the aim position
        aimTransform.Rotate(Vector3.left * recoilAmount); // Adjust the direction and amount of recoil here
        
        // Return to initial position smoothly
        float elapsed = 0f;
        while (elapsed < speed)
        {
            aimTransform.localRotation = Quaternion.Lerp(aimTransform.localRotation, initialRotation, elapsed / speed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        aimTransform.localRotation = initialRotation; // Ensure it ends exactly at the initial position
    }
}
