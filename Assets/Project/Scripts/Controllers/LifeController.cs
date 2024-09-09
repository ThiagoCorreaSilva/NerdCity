using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [Header("Life Controller")]
    [SerializeField] protected float currentLife;
    [SerializeField] protected float maxLife;
    protected bool isDeath;

    protected virtual void Start()
    {
        currentLife = maxLife;
    }

    public virtual void TakeDamage(float _damage)
    {
        currentLife = Mathf.Max(currentLife - _damage, 0f);

        if (currentLife == 0) Death();
    }

    public virtual void ReceiveHeal(float _heal)
    {
        currentLife = Mathf.Min(currentLife + _heal, maxLife);
    }

    private void Death()
    {
        isDeath = true;
        gameObject.SetActive(false);
    }
}