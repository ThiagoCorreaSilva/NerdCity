using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyAttack : MonoBehaviour
{
    [SerializeField] UnityEvent action;

    public void ActiveAction()
    {
        action.Invoke();
    }
}