using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitAnim : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool isParticleEffect = false;

    private void Start()
    {
        anim.SetBool("particleSys", isParticleEffect);
    }

    public void PlayEffect()
    {
        anim.SetTrigger("gotshot");
    }
}
