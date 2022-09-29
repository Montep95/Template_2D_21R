using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random 모호한 참조 해결

public class B_Star : MonoBehaviour
{
    public GameObject star;

    //test
    [HideInInspector] public CircleCollider2D col;
    [HideInInspector]
    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }
    // test
    public Transform b_star;
    Rigidbody2D b_starBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    // Vector2 pullForce;

    //Not used
    //public static event Action OnStarCollected;
    
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 1.0f;

    // 크기 지정
    public int type; // 크기 유형
    float size;

    // star 사용 공유 (싱글톤)
    #region Singleton class: B_Star

    public static B_Star bs;
    //public static gameManager Instance;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // test - 별 중력장
        b_starBody = b_star.GetComponent<Rigidbody2D>();
        //

        float x = Random.Range(-6.0f, 6.0f);
        float y = Random.Range(-9.0f, 9.0f);

        transform.position = new Vector3(x, y, 0);

        // 점수 UI
        type = Random.Range(1, 4);
        if (type == 1)
        {
            size = 0.8f;

            GetComponent<SpriteRenderer>().color = new Color(200.0f / 255.0f, 35.0f / 255.0f, 35.0f / 255.0f, 255.0f / 255.0f);
        }
        else if (type == 2)
        {
            size = 1.2f;

            GetComponent<SpriteRenderer>().color = new Color(200.0f / 255.0f, 35.0f / 255.0f, 35.0f / 255.0f, 255.0f / 255.0f);
        }
        else
        {
            size = 1.7f;

            GetComponent<SpriteRenderer>().color = new Color(200.0f / 255.0f, 35.0f / 255.0f, 35.0f / 255.0f, 255.0f / 255.0f);
        }
        transform.localScale = new Vector3(size, size, 0);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bs = this;
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed;
        }

    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }

    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "star")
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.3f * 1 * Time.deltaTime,
                                            transform.localScale.y + 0.3f * 1 * Time.deltaTime, 0);
            Destroy(star);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "star")
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.3f * 1 * Time.deltaTime,
                                            transform.localScale.y - 0.3f * 1 * Time.deltaTime, 0);
        }
    }
}
