using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_StarMagnet : MonoBehaviour
{
    public GameObject b_star;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ū �� Magnet ���� �ȿ� ������,
        if (collision.gameObject.TryGetComponent<Player>(out Player Player))
        {
            // �÷��̾ ū �������� �����̵���
            Player.SetTarget(transform.parent.position);

        }

        // ���� �� Magnet ���� �ȿ� ������,
        if (collision.gameObject.TryGetComponent<Star>(out Star star))
        {
            // ���� ���� ū ���� ����ǵ���
            star.SetTarget(transform.parent.position);

            b_star.transform.localScale = new Vector3(transform.localScale.x + 0.3f * 1 * Time.deltaTime,
                                            transform.localScale.y + 0.3f * 1 * Time.deltaTime, 0);
            // star ���� - ���۵�
            Destroy(star);

        }
    }



}
