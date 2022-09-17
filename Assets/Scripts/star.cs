using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random; // Random 모호한 참조 해결

public class star : MonoBehaviour, ICollectible
{
    public static event Action OnStarCollected;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 targetPosition;
    float moveSpeed = 5f;

    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(-4.5f, 4.5f);

        transform.position = new Vector3(x, y, 0);

        float size = Random.Range(0.15f, 0.7f);
        transform.localScale = new Vector3(size, size, 0);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Collect()
    {
        Debug.Log("Star Collected");
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
