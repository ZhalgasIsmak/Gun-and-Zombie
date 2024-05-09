using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapons : MonoBehaviour
{
    public static ActiveWeapons Instance { get; private set; }

    [SerializeField] private Knife knife;

    private void Awake()
    {
        Instance = this;
    }
    public Knife GetActiveWeapons()
    {
        return knife;
    }
}
