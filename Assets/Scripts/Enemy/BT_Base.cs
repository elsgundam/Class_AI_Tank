using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
///  노드의 기본이 될 추상 클래스
/// </summary>
public abstract class Node
{
    /// <summary>
    /// 노드의 자식 클래스들에서 공통적으로 사용할 호출 함수
    /// </summary>
    /// <returns></returns>
    public abstract bool Invoke();
}

/// <summary>
/// 
/// </summary>
public class CompositeNode : Node
{
    /// <summary>
    ///  아직 구현되지 않아서 호출시 throw
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override bool Invoke()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 자식 노드 추가 함수
    /// </summary>
    /// <param name="node">자식노드</param>
    public void AddChild(Node node)
    {
        childrens.Push(node);
    }

    /// <summary>
    /// 자식 노드들을 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public Stack<Node> GetChildrens()
    {
        return childrens;
    }
    private Stack<Node> childrens = new Stack<Node>();

}


public class Selector : CompositeNode
{
    public override bool Invoke()
    {
        foreach(var node in GetChildrens())
        {
            if (node.Invoke())
            {
                return true;
            }
        }
        return false;
    }
}

public class Sequence : CompositeNode
{
    public override bool Invoke()
    {
        bool p = false;
        foreach(var node in GetChildrens())
        {
            if(node.Invoke()== false) { 
                p = true;
            }
        }
        return !p;
    }
}

public class MoveFollowTarget : Node
{
    private EnemyMove _Enemy;
    public EnemyMove Enemy
    {
        set { _Enemy = value; }
    }

    public override bool Invoke()
    {
        return _Enemy.MoveFollowTarget();
    }
}

public class MoveBackollowTarget : Node
{
    private EnemyMove _Enemy;
    public EnemyMove Enemy
    {
        set { _Enemy = value; }
    }

    public override bool Invoke()
    {
        return _Enemy.MoveBackollowTarget();
    }
}

public class IsDead : Node
{ 
    private EnemyMove _Enemy;
    public EnemyMove Enemy
    {
        set { _Enemy = value; }
    }

    public override bool Invoke()
    {
        return _Enemy.IsDead();
    }
}

public class OnAttack : Node
{
    private EnemyMove _Enemy;
    public EnemyMove Enemy
    {
        set { _Enemy = value; }
    }

    public override bool Invoke()
    {
        return _Enemy.AddBullet();
    }
}