using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementState
{
    public override void onEnter(MovementController controller)
    {
        GAME.Instance.player.currentPlayerState = PLAYER.playerState.IDLE;
        Debug.Log(GAME.Instance.player.currentPlayerState);
    }

    public override void onExit(MovementController controller)
    {
        
    }

    public override void onUpdate(MovementController controller)
    {
        
    }
}
