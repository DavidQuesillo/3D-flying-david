using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletHoming : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int hp = 5;
    private Transform player;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private EnemyHitAnim anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(Quaternion.LookRotation(player.position - transform.position).normalized);
        rb.MovePosition(Vector3.MoveTowards(transform.position, player.position, speed));
    }

    public void DamageProjectile(int ouch)
    {
        hp -= ouch;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        anim.PlayEffect();
    }
}
