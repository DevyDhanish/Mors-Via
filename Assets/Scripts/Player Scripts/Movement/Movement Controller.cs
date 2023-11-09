using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    MovementState currentState;
    SprintState sprint = new SprintState();
    WalkState walk = new WalkState();
    IdleState idle = new IdleState();

    private void Start()
    {
        currentState = idle;
        currentState.onEnter();
    }
    private void Update()
    {
        if(GAME.Instance.gameState == GAME.GameState.RUNNING)
        {
            if (!GAME.Instance.player.isMoving && GAME.Instance.player.currentPlayerState != PLAYER.playerState.IDLE) switchState(idle);
            else if (GAME.Instance.player.isMoving && GAME.Instance.player.currentPlayerState != PLAYER.playerState.WALK && !InputBindings.Instance.isHoldingShift) switchState(walk);
            else if(GAME.Instance.player.isMoving && GAME.Instance.player.currentPlayerState != PLAYER.playerState.SPRINT && InputBindings.Instance.isHoldingShift) switchState(sprint);
        }
        // set for sprint too

        currentState.onUpdate();
    }

    public void switchState(MovementState newState)
    {
        currentState.onExit();
        currentState = newState;
        currentState.onEnter();
    }
}
