using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [Header("Player Resources")]
    public int playerSouls;

    private void Awake()
    {
        instance = this;
    }

    public void AddSouls(int _souls)
    {
        playerSouls += _souls;
    }

    public void RemoveSouls(int _souls)
    {
        playerSouls = Mathf.Max(playerSouls - _souls, 0);
    }
}