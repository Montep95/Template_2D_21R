using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G_field : MonoBehaviour
{

    /* test
    public GameObject star;
    public float maxGravity;
    public float maxGravityDist;
    float lookAngle;
    Vector3 lookDirection;
    */
    #region Singleton class: G_field

    // test
    public static G_field G;
    //public static gameManager Instance;

    #endregion

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector]
    public Vector3 pos



    {
        get
        {
            return transform.position;
        }
    }

    /*
    // star 오브젝트 사용
    int p_type = star.s.type;
    */

    private void Awake()
    {
        G = this; //test

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
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


    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.5f * 1 * Time.deltaTime,
                                            transform.localScale.y + 0.5f * 1 * Time.deltaTime, 0);
    }

    public void Growing_field()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.5f * 1 * Time.deltaTime,
                                            transform.localScale.y + 0.5f * 1 * Time.deltaTime, 0);
    }
    


    void Update()
    {
       
    }
}

