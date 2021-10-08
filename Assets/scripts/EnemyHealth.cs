using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int hp = 10;
    [SerializeField]
    private EnemyHitAnim anim;

    public void TakeDamage(int ouch)
    {
        hp -= ouch;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        anim.PlayEffect();
    }
}
