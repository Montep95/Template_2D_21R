using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public GameObject g_field;// 중력장(가시성) 키우기
    public GameObject MagnetCollider; // 중력장 키우기

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

        }

        if (collision.gameObject.tag == "b_starColl")
        {
            panel.SetActive(true);
            Time.timeScale = 0.0f; // Unity 모든 시간 Stop
            gameManager.I.retry();
        }
    }

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
