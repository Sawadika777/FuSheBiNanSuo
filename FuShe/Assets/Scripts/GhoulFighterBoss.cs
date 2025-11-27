using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulFighterBoss : MonoBehaviour
{
    private Animation anim;
    public AnimationClip clips; // 拖入动画剪辑
    void Start()
    {
/*        Animator animator = GetComponent<Animator>();
        //animator.runtimeAnimatorController = null; // 确保没有Controller
        animator.Play("DeathClow_Attack_03");*/

        var anim =this.GetComponent<Animation>();
        // 播放默认动画（列表中第一个）
        anim.Play("DeathClow_Attack_03");

    }
}

