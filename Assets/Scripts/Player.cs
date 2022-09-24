using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector] public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }

    // star 오브젝트 사용
    int p_type = star.s.type;


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


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTrigger Active!");
        transform.localScale = new Vector3(transform.localScale.x + 1f * p_type * Time.deltaTime,
                                            transform.localScale.y + 1f * p_type * Time.deltaTime, 0);

    }

    // Update is called once per frame
    void Update()
    {
           
    }

    
}
