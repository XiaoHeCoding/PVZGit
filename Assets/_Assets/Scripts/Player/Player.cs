using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private float inputX;
    private float inputY;
    private Vector3 movementInput;
    

    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal"); //获取x轴移动值
        inputY = Input.GetAxisRaw("Vertical"); //获取y轴移动值
        movementInput = new Vector3(inputX,0,inputY);//移动的方向

        movementInput = movementInput.normalized; //单位化,平衡斜着走速度快的问题

        transform.position += movementInput * Time.deltaTime * speed;

        //人物转向
        if(movementInput != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, movementInput, Time.deltaTime * rotateSpeed);
            // transform.forward = movementInput;
        }
        
    }

    private void Update() 
    {
        PlayerInput();
    }
}
