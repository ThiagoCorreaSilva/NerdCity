using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Point instance;

    private void Awake()
    {
        instance = this;
    }
}