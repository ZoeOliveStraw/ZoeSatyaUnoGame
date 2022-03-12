using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [SerializeField] protected Color activeColor;
    [SerializeField] protected Color inactiveColor;

    protected SpriteRenderer background;

    private void Awake()
    {
        background = GetComponent<SpriteRenderer>();
    }

    public abstract void TurnStart();
    public abstract void TurnEnd();
}
