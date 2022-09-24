using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    /* test
    public GameObject star;
    public float maxGravity;
    public float maxGravityDist;
    float lookAngle;
    Vector3 lookDirection;
    */


    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector] public Vector3 pos



    {
        get
        {
            return transform.position;
        }
    }

    /*
    // star 오브젝트 사용
    int p_type = Star.s.type;
    */

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
        transform.localScale = new Vector3(transform.localScale.x + 0.5f * 2 * Time.deltaTime,
                                            transform.localScale.y + 0.5f * 2 * Time.deltaTime, 0);
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }


    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.5f * 1 * Time.deltaTime,
                                            transform.localScale.y + 0.5f * 1 * Time.deltaTime, 0);
    }
    */



    void Update()
    {
        /*
        float dist = Vector2.Distance(star.transform.position, transform.position);
        Vector3 v = star.transform.position - transform.position;
        //rb.AddForce(v.normalized * (1.0f - dist / maxGravityDist) * maxGravity);
        lookDirection = star.transform.position - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        */
    }
}

