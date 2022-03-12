using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CpuPlayer : Player
{
    public override void TurnStart()
    {
        background.color = activeColor;
    }
    public override void TurnEnd()
    {
        background.color = inactiveColor;
    }
}
