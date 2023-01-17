using Newtonsoft.Json.Bson;
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
    private MoveBackollowTarget moveBackollowTarget = new MoveBackollowTarget();
    private OnAttack m_OnAttack = new OnAttack();
    private IsDead m_IsDead = new IsDead();

    EnemyMove m_Enemy;
    IEnumerator behaviorProcess;

    private void Start()
    {
        Debug.Log("Start Tree");
        Init();

    }
    public void Init()
    {

        m_Enemy = gameObject.GetComponent<EnemyMove>();
        root.AddChild(selector);

        selector.AddChild(seqDead);
        selector.AddChild(seqMovineAttack);

        moveFollowTarget.Enemy = m_Enemy;
        moveBackollowTarget.Enemy = m_Enemy;
        m_OnAttack.Enemy = m_Enemy;
        m_IsDead.Enemy = m_Enemy;

        seqMovineAttack.AddChild(moveFollowTarget);
        seqMovineAttack.AddChild(m_OnAttack);
        seqMovineAttack.AddChild(moveBackollowTarget);
        seqDead.AddChild(m_IsDead);

        behaviorProcess = BehaviorProcess();
        StartCoroutine(behaviorProcess);

    }

    public IEnumerator BehaviorProcess() 
    {
        while (root.Invoke())
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject, 0.0f);
        Debug.Log("behavior process exit");

    }

    private void OnApplicationQuit()
    {
        Debug.Log("End Tree");
    }

}
