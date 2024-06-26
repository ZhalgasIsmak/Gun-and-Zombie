using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;
    private float minMovingspeed = 0.1f;
    private bool isRunning=false;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += GameInput_OnPlayerAttack;
    }

    private void GameInput_OnPlayerAttack(object sender, System.EventArgs e)
    {
        ActiveWeapons.Instance.GetActiveWeapons().Attack();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingspeed || Mathf.Abs(inputVector.y) > minMovingspeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        }
    public bool IsRunning()
    {
        return isRunning;
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition =  Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
    }

