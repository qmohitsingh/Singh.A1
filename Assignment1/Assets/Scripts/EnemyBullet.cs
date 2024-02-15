using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletspeed;
    Rigidbody rb;
    // Start is called before the first frame update

    private void Awake() {
        Destroy(gameObject, 8f);
    }
    void Start()
    {
        bulletspeed = 20f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * bulletspeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector3 direction) {
        rb.velocity = direction.normalized * bulletspeed;
    }

}
