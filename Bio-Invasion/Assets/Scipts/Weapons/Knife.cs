using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public EventHandler OnKnifeAttack;
    public void Attack()
    {
        OnKnifeAttack?.Invoke(this, EventArgs.Empty);
    }
}
