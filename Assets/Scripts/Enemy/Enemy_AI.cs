using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovineAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private MoveFollowTarget moveFollowTarget = new MoveFollowTarget();
    private MoveBackollowTarget moveBackollow = new MoveBackollowTarget();
    private OnAttack m_OnAttack = new OnAttack();
    private IsDead m_IsDead = new IsDead();

    void Start()
    {
        
    }
}
