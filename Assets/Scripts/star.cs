using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random 모호한 참조 해결

public class Star : MonoBehaviour, ICollectible
{
    /* test
    public GameObject Player;
    public float maxGravity;
    public float maxGravityDist;
    float lookAngle;
    Vector3 lookDirection;
    */

    // test
    public Transform Player;
    Rigidbody2D playerBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    Vector2 pullForce;

    public static event Action OnStarCollected;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 2.3f;

    // 점수 UI
    int score;
    public int type; // 점수 배점
    float size;

    // star 사용 공유 (싱글톤)
    #region Singleton class: Star

    public static Star s;
    //public static gameManager Instance;


    #endregion

    void Start()
    {
        // test - 별 중력장
        playerBody = Player.GetComponent<Rigidbody2D>();
        //

        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(-4.5f, 4.5f);

        transform.position = new Vector3(x, y, 0);
        

        //float size = Random.Range(0.15f, 0.7f);
        
        
        // 점수 UI
        type = Random.Range(1, 4);
        if(type == 1)
        {
            size = 0.5f;
            score = 3;

            GetComponent<SpriteRenderer>().color = new Color(230.0f /255.0f, 230.0f / 255.0f, 20.0f / 255.0f, 255.0f / 255.0f);
        }
        else if (type == 2)
        {
            size = 0.3f;
            score = 2;

            GetComponent<SpriteRenderer>().color = new Color(200.0f / 255.0f, 230.0f / 255.0f, 20.0f / 255.0f, 255.0f / 255.0f);
        }
        else
        {
            size = 0.15f;
            score = 1;

            GetComponent<SpriteRenderer>().color = new Color(150.0f / 255.0f, 230.0f / 255.0f, 20.0f / 255.0f, 255.0f / 255.0f);
        }
        transform.localScale = new Vector3(size, size, 0);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        s = this;        
    }


    // 점수 획득 구현
    public void Collect()
    {
        //Debug.Log("Star Collected");
        gameManager.I.addScore(score);
        G_field.G.Growing_field(); //test
        // Destroy(gameObject); // 파괴되지 않고 자석처럼 따라다녀야함
        OnStarCollected?.Invoke();
    }

    /*
    public void RCollect()
    {
        gameManager.I.minusScore(score);
        OnStarCollected?.Invoke();
    }
    */


    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector2 targetDirection = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * moveSpeed; 
        }
        
        /* test
        float dist = Vector2.Distance(Player.transform.position, transform.position);
        Vector3 v = Player.transform.position - transform.position;
        //rb.AddForce(v.normalized * (1.0f - dist / maxGravityDist) * maxGravity);
        lookDirection = Player.transform.position - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        */
}

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }

    public void Update()
    {
        /*
        // test - follow
        distanceToPlayer = Vector2.Distance(Player.position, transform.position);
        if (distanceToPlayer <= influenceRange)
        {
            pullForce = (transform.position - Player.position).normalized / distanceToPlayer * intensity;
            playerBody.AddForce(pullForce, ForceMode2D.Force);
        }
        */
    }
}
