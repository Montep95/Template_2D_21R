using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random ��ȣ�� ���� �ذ�

public class Star : MonoBehaviour, ICollectible
{
    // test 2022-09-29 13:38
    public Transform CollectorCollider;

    // test
    public GameObject G_field;
    //public Transform Player;
    Rigidbody2D playerBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    Vector2 pullForce;

    public static event Action OnStarCollected;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 4f;

    // ���� UI
    int score;
    public int type; // ���� ����
    float size;

    // star ��� ���� (�̱���)
    #region Singleton class: Star

    public static Star s;
    //public static gameManager Instance;


    #endregion

    void Start()
    {
        float x = Random.Range(-6.0f, 6.0f);
        float y = Random.Range(-9.0f, 9.0f);

        transform.position = new Vector3(x, y, 0);

        // ���� UI
        type = Random.Range(1, 4);
        if(type == 1)
        {
            size = 0.25f;
            score = 3;

            GetComponent<SpriteRenderer>().color = new Color(235.0f /255.0f, 160.0f / 255.0f, 20.0f / 255.0f, 255.0f / 255.0f);
        }
        else if (type == 2)
        {
            size = 0.15f;
            score = 2;

            GetComponent<SpriteRenderer>().color = new Color(235.0f / 255.0f, 200.0f / 255.0f, 20.0f / 255.0f, 255.0f / 255.0f);
        }
        else
        {
            size = 0.1f;
            score = 1;

            GetComponent<SpriteRenderer>().color = new Color(235.0f / 255.0f, 245.0f / 255.0f, 20.0f / 255.0f, 255.0f / 255.0f);
        }
        transform.localScale = new Vector3(size, size, 0);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        s = this;        
    }


    // ���� ȹ�� ����
    public void Collect()
    {
        //Debug.Log("Star Collected");
        gameManager.I.addScore(score);
        // Destroy(gameObject); // �ı����� �ʰ� �ڼ�ó�� ����ٳ����
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

    public void Update()
    {

    }
}
