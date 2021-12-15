using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;


public class ChaseState : BaseState
{
    private ShortRangeEnemy _ShortRangeEnemy;
    private Vector3 playerPosition;

    private float direction;
    public ChaseState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy =  shortRangeEnemy;
    }

    public override Type Tick(){

        if(Vector3.Distance(transform.position,playerPosition) > _ShortRangeEnemy.hearRadius)
            {
                return typeof(WanderState);
            }
        
        playerPosition = _ShortRangeEnemy.playerManager.player.transform.position;

        if(playerPosition.x  < _ShortRangeEnemy.transform.position.x)
        {
            if(_ShortRangeEnemy.movingRight){
                    _ShortRangeEnemy.movingRight = false;
                    direction = -1.0f;
                    _ShortRangeEnemy.EnemyMove(direction);
            }
            else
            {
                direction = -1.0f;
                    _ShortRangeEnemy.EnemyMove(direction);
            }
        }
        else
        {
            if(!_ShortRangeEnemy.movingRight){
                    _ShortRangeEnemy.movingRight = true;
                    direction = 1.0f;
                    _ShortRangeEnemy.EnemyMove(direction);
            }
            else
            {
                direction = 1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
            }
        }

        //Debug.Log("Made it to chase state");
        return typeof(ChaseState);
    }
}
