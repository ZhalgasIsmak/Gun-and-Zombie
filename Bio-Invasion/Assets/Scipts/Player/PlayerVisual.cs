using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Knife knife;
    private const string ATTACK = "Attack";

    private const string IS_RUNNING = "IsRunning";
    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        knife.OnKnifeAttack += Knife_OnKnifeAttack;
    }
    private void Knife_OnKnifeAttack(object sender,System.EventArgs e)
    {
        animator.SetTrigger(ATTACK);
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING,Player.Instance.IsRunning());
        AdjustPlayerFacingDirectoin();
    }
    private void AdjustPlayerFacingDirectoin()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();

        if(mousePos.x > playerPosition.x) {
            spriteRenderer.flipX = false;
                }
        else
        {
            spriteRenderer.flipX = true;
        }
    } 
}
