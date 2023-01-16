using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
///  ����� �⺻�� �� �߻� Ŭ����
/// </summary>
public abstract class Node
{
    /// <summary>
    /// ����� �ڽ� Ŭ�����鿡�� ���������� ����� ȣ�� �Լ�
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
    ///  ���� �������� �ʾƼ� ȣ��� throw
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override bool Invoke()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// �ڽ� ��� �߰� �Լ�
    /// </summary>
    /// <param name="node">�ڽĳ��</param>
    public void AddChild(Node node)
    {
        childrens.Push(node);
    }

    /// <summary>
    /// �ڽ� ������ �������� �Լ�
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