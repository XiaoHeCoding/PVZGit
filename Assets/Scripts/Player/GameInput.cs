using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private Vector3 direction;

    private GameControl gameControl;
    public event EventHandler OnInteractAction;

    private void Awake() 
    {
        gameControl = new GameControl();
        gameControl.Player.Enable();

        gameControl.Player.Interact.performed += Interact_Performed;
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2 = gameControl.Player.Move.ReadValue<Vector2>();
        // horizontal = Input.GetAxisRaw("Horizontal"); //获取x轴的值
        // vertical = Input.GetAxisRaw("Vertical"); //获取y轴的值

        direction = new Vector3(inputVector2.x, 0, inputVector2.y); //方向

        direction = direction.normalized;  //向量化，平衡斜着走速度快的问题

        return direction;
    }
}
