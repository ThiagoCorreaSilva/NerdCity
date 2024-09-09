using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public void Attack()
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, 10f))
        {
            if (_hit.collider.gameObject.layer == LayerMask.NameToLayer("Point"))
            {
                _hit.collider.gameObject.GetComponent<Point>().TakeDamage(EnemyIA.instance.attackDamage);
                Debug.Log("Dano");
            }
            else
                Debug.Log("Objeto errado");
        }
        else
            Debug.Log("Sem acerto");
    }
}