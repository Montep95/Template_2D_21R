using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random 모호한 참조 해결
using System;

public class star : MonoBehaviour, ICollectible
{
    public static event Action OnStarCollected;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 1.2f;

    // 점수 UI
    int score;
    public int type; // 점수 배점
    float size;

    // star 사용 공유 (싱글톤)
    #region Singleton class: gamaManager

    public static star s;
    //public static gameManager Instance;


    #endregion

    void Start()
    {
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
        Debug.Log("플레이어와 부딪힘");
        gameManager.I.addScore(score);
        Destroy(gameObject);
        OnStarCollected?.Invoke();
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
}
