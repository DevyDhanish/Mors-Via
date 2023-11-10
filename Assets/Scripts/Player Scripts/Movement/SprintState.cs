using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : MovementState
{
    private Vector3 cameraForward;
    private Vector3 cameraRight;
    private Vector3 relativeDirection;
    public override void onEnter(MovementController controller)
    {
        GAME.Instance.player.currentPlayerState = PLAYER.playerState.SPRINT;
        Debug.Log(GAME.Instance.player.currentPlayerState);
    }

    public override void onExit(MovementController controller)
    {
        
    }

    public override void onUpdate(MovementController controller)
    {
        playerSprint(controller);
    }

    private void playerSprint(MovementController controller)
    {
        cameraForward = Camera.main.transform.forward * InputBindings.Instance.movementVector.x;
        cameraRight = Camera.main.transform.right * InputBindings.Instance.movementVector.y;

        relativeDirection = controller.transform.forward.z * cameraForward + controller.transform.right.x * cameraRight;

        relativeDirection.y = 0.0f;
        relativeDirection.Normalize();

        controller.playerController.Move(relativeDirection * GAME.Instance.player.sprintSpeed * Time.deltaTime);
    }
}