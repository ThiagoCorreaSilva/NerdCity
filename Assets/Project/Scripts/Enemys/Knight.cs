using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : EnemyIA
{
    private void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == "Death")
        {
            Debug.Log("MORTO");
            Death();
        }
    }
}