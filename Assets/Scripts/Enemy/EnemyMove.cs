using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject mPrefab_Bullet;
    float mDirR = 180.0f;
    Vector3 mDir;
    [SerializeField]float mSpeed = 1f;
    int nTime = 0;

    public bool MoveFollowTarget()
    {
        if(HeroMove.gEnemyHp >= 50)
        {
            mDir = HeroMove.gHeroPos - gameObject.transform.position;
            mDir.Normalize();
            Quaternion tRot = Quaternion.LookRotation(mDir, new Vector3(0, 1, 0));
            mDirR = tRot.eulerAngles.y;
            gameObject.transform.localRotation = tRot;
            gameObject.transform.position += mDir * mSpeed *Time.deltaTime ;
            return true;
        }
        return false;
    }
    public bool MoveBackollowTarget()
    {
        if(HeroMove.gEnemyHp< 50 && HeroMove.gEnemyHp > 0)
        {
            mDir = HeroMove.gHeroPos - gameObject.transform.position;
            mDir.Normalize();
            Quaternion tRot = Quaternion.LookRotation(mDir, new Vector3(0, 1, 0));
            mDirR = tRot.eulerAngles.y;
            gameObject.transform.localRotation = tRot;
            gameObject.transform.position -= mDir * mSpeed * Time.deltaTime;
            return true;
        }
        return false;
    }
    void Update()
    {
        nTime++;
    }
    
    public bool IsDead()
    {
        if(HeroMove.gEnemyHp <= 0)
        {
            //Destroy(gameObject,0.0f)
            return false;
        }
        return true;
    }

    public bool AddBullet()
    {
        if (HeroMove.gEnemyHp > 0)
        {
            if (nTime % 100 == 0)
            {
                if (mPrefab_Bullet != null)
                {
                    GameObject tBullet = GameObject.Instantiate(mPrefab_Bullet) as GameObject;
                    if (tBullet.GetComponent<Bullet>() != null)
                    {
                        tBullet.GetComponent<Bullet>().mDir = mDir;
                        tBullet.transform.parent = null;
                        tBullet.gameObject.layer = LayerMask.NameToLayer("Enemy");
                        tBullet.transform.position = gameObject.transform.position;
                    }
                }

            }
            return true;
        }
        return false;
    }


}
