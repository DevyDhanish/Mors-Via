using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputBindings : MonoBehaviour
{
    public static InputBindings Instance;
    private void Awake()
    {
        if(Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public Vector2 movementVector;
    public Vector2 cameraVectorAxis;
    public KeyCode Forward = KeyCode.W;
    public KeyCode Backward = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public string UpAndDown = "Horizontal";
    public string RightAndLeft = "Vertical";
    public string MouseX = "Mouse X";
    public string MouseY = "Mouse Y";
    public KeyCode Interact = KeyCode.E;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode PauseGame = KeyCode.Escape;
    public KeyCode SprintKey = KeyCode.RightShift;
    public bool isHoldingShift;

    private void getMovementVector()
    {
        movementVector.x = Input.GetAxisRaw(RightAndLeft);
        movementVector.y = Input.GetAxisRaw(UpAndDown);
        movementVector.Normalize();
    }

    private void getMouseMovementVector()
    {
        cameraVectorAxis.x = Input.GetAxisRaw(MouseX);
        cameraVectorAxis.y = Input.GetAxisRaw(MouseY);
    }

    public void Update()
    {
        getMovementVector();
        getMouseMovementVector();
        isHoldingShift = Input.GetKey(SprintKey);
        if(movementVector.x != 0 || movementVector.y != 0)
        {
            GAME.Instance.player.setIsMoving(true);
        }
        else
        {
            GAME.Instance.player.setIsMoving(false);
        }
    }
}
