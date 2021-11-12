using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<CapsuleCollider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EBulletHoming>() != null)
        {
            other.GetComponent<EBulletHoming>().DamageProjectile(damage);
            Destroy(gameObject);
            return;
        }
        if (other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
