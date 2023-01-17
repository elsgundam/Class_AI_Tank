using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    public Vector3 mDir;
    public float mSpeed = 1;

    private void Start()
    {
        Destroy(gameObject,5.0f);
    }

    private void Update()
    {
        gameObject.transform.position += mDir * Time.fixedDeltaTime * mSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if( other.gameObject.layer == LayerMask.NameToLayer("Enemy")&&  gameObject.layer ==  LayerMask.NameToLayer("Hero"))
        {
            HeroMove.gEnemyHp -= 5;
            Destroy(gameObject,0.0f);
        }

        if( other.gameObject.layer == LayerMask.NameToLayer("Hero") &&   gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HeroMove.gHeroHp -= 5;
            Destroy(gameObject,0.0f);
        }

    }
}
