using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnifeVisual : MonoBehaviour
{
    [SerializeField] private Knife Knife;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ToggleSprite(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            spriteRenderer.enabled = spriteRenderer.enabled;
        }
    }
}
