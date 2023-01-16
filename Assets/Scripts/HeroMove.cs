using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    public static int gHeroHp = 100;
    public static int gEnemyHp = 100;
    public static Vector3 gHeroPos;

    public GameObject mPrefab_Bullet;


    float mDirR = 0;


    // Start is called before the first frame update
    void Start()
    {
        gHeroHp = 100;
        gEnemyHp = 100;
        gHeroPos = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 tDir = new Vector3(Mathf.Sin(mDirR / 180.0f * 3.14f), 0, Mathf.Cos(mDirR / 180.0f * 3.14f));
        float tSpeed = 1f;
        float fixedDeltaTime =Time.fixedDeltaTime;


        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += tDir*tSpeed*fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position -= tDir * tSpeed*fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mDirR -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mDirR += 1.0f;
        }

        gameObject.transform.rotation = Quaternion.Euler(0, mDirR, 0);
        gHeroPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(mPrefab_Bullet != null)
            {
                GameObject tBullet = GameObject.Instantiate(mPrefab_Bullet) as GameObject;
                if(tBullet.GetComponent<Bullet>() != null)
                {
                    tBullet.GetComponent<Bullet>().mDir = tDir;
                    tBullet.transform.parent = null;
                    tBullet.gameObject.layer = LayerMask.NameToLayer("Hero");
                    tBullet.transform.position = gameObject.transform.position;
                }
            }

        }


    }

    private void OnGUI()//소스로 GUI 표시
    {
        GUIStyle style;
        Rect rect;

        int w = Screen.width , h = Screen.height ;
        rect = new Rect(0, 0, w, h*4/100);
        style= new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = Color.black;

        string text = "Hero HP :" + gHeroHp + "% \n Enemy HP :" + gEnemyHp + "%";
        GUI.Label(rect, text, style);
    }
}
