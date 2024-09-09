using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : LifeController
{
    public static Point instance;

    private void Awake()
    {
        instance = this;
    }
}