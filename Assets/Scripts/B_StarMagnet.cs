using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_StarMagnet : MonoBehaviour
{
    public GameObject b_star;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 큰 별 Magnet 범위 안에 있으면,
        if (collision.gameObject.TryGetComponent<Player>(out Player Player))
        {
            // 플레이어가 큰 별쪽으로 움직이도록
            Player.SetTarget(transform.parent.position);

        }

        // 작은 별 Magnet 범위 안에 있으면,
        if (collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // 작은 별이 큰 별에 흡수되도록
            star.SetTarget(transform.parent.position);

            b_star.transform.localScale = new Vector3(transform.localScale.x + 0.3f * 1 * Time.deltaTime,
                                            transform.localScale.y + 0.3f * 1 * Time.deltaTime, 0);
            // star 제거 - 미작동
            Destroy(star);

        }
    }



}
