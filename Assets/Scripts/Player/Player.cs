using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : GarnishItemHolder
{    
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;

    public static Player Instance { get; private set; }

    private bool isWalking = false;
    private Vector3 direction;
    private BaseCounter selectedCounter;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;    
    }


    private void Update() 
    {
        HandleInteraction();
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    public bool IsWalking
    {
        get
        {
            return isWalking;
        }
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        selectedCounter?.Interact(this);
    }

    private void HandleMovement()
    {
        direction = gameInput.GetMovementDirectionNormalized();

        isWalking = direction != Vector3.zero;

        transform.position += direction * Time.deltaTime * speed;

        //人物转向
        if(direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
        }
    }

    private void HandleInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask))
        {
            if(hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {
                // counter.Interact();
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    public void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();

            this.selectedCounter = counter;
    }

}
