using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ���� ���� �ε����ٸ�
        if(collision.gameObject.TryGetComponent<star>(out star star))
        {
            // ���� �÷��̾������� �����̵���
            star.SetTarget(transform.parent.position);

        }


    }
}
