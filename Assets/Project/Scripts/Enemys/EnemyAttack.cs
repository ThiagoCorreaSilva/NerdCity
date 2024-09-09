using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public void Attack()
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, 2f))
        {
            if (_hit.collider.gameObject.layer == LayerMask.NameToLayer("Point"))
            {
                _hit.collider.gameObject.GetComponent<Point>().TakeDamage(EnemyIA.instance.attackDamage);
                Debug.DrawRay(transform.position, _hit.point * 10f, Color.red);
                Debug.Log("Dano");
            }
            else
                Debug.Log("Objeto errado");
        }
        else
            Debug.Log("Sem acerto");
    }
}