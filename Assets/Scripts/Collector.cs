using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    
    //test (2022-09-29 20:57)
    public GameObject Player;
    public GameObject g_field; // 중력장(가시성) 키우기
    public GameObject MagnetCollider; // 실 중력장 키우기
    //private vector3 originscale; // 중력장 그래픽 원래 크기
    //private vector3 originscale2; // 중력장 원래 크기
    public float x;
    public float y;
    public float z;

    //test
    public GameObject panel;
    public GameObject star;
    public GameObject b_star;
    public GameObject b_starCollider;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    // test (2022-09-29 14:25)
    private Vector3 gf;

    [HideInInspector]
    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }



    private void awake()
    {
        x = g_field.transform.localScale.x;
        y = g_field.transform.localScale.y;
        z = g_field.transform.localScale.z;
        //rb = GetComponent<Rigidbody2D>();
        //originscale = g_field.transform.localscale;
        //originscale2 = magnetcollider.transform.localscale;

    }


    /*
    // Awake(), Start()와 달리 활성화 될때마다 호출
    private void OnEnable()
    {

    }
    */

    // private -> public 변경 (2022-09-29 13:41)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }

        if (collision.gameObject.tag == "star")
        {
            Debug.Log("테스트중");

            
            //g_field.transform.localScale = new Vector3(transform.localScale.x + 0.5f * 2 * Time.deltaTime,
            //                                    transform.localScale.y + 0.5f * 2 * Time.deltaTime, 0);
            
            /*
            MagnetCollider.transform.localScale = new Vector3(transform.localScale.x + 0.5f * 2 * Time.deltaTime,
                                                transform.localScale.y + 0.5f * 2 * Time.deltaTime, 0);
            */
            /*
            MagnetCollider.transform.localScale = new Vector3(transform.localScale.x + 0.15f * 1 * Time.deltaTime,
                                                transform.localScale.y + 0.15f * 1 * Time.deltaTime, 0);
            */
        }

        if (collision.gameObject.tag == "b_starColl")
        {
            panel.SetActive(true);
            Time.timeScale = 0.0f; // Unity 모든 시간 Stop
            gameManager.I.retry();
        }
    }

    /*

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "star")
        {
            Debug.Log("버그");
            // test (2022-09-29 14:25)
            g_field.transform.localScale = new Vector3(transform.localScale.x + 0.15f * 1 * Time.deltaTime,
                                                transform.localScale.y + 0.15f * 1 * Time.deltaTime, 0);
            MagnetCollider.transform.localScale = new Vector3(transform.localScale.x + 0.15f * 1 * Time.deltaTime,
                                                transform.localScale.y + 0.15f * 1 * Time.deltaTime, 0);
        }
    }
    */

    /*
    public void OnCollisionEnter2D(Collider2D collision)
    {
        
    }
    */


 


    /*

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "star")
        {
            g_field.transform.localScale = new Vector3(transform.localScale.x - 0.15f * 1 * Time.deltaTime,
                                            transform.localScale.y - 0.15f * 1 * Time.deltaTime, 0);
        }
    }
    */

}
