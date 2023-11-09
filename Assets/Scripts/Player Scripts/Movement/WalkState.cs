using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementState
{
    public override void onEnter()
    {
        GAME.Instance.player.currentPlayerState = PLAYER.playerState.WALK;
        Debug.Log(GAME.Instance.player.currentPlayerState);
    }

    public override void onExit()
    {
        
    }

    public override void onUpdate()
    {
        
    }
}