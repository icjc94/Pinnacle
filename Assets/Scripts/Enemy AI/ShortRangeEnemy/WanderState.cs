using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class WanderState : BaseState
{

    private ShortRangeEnemy _ShortRangeEnemy;
    public float originOffset = 0.5f;
    private float raycastMaxDistance;

    private float direction;

    private Vector3 playerPosition;

    public WanderState(ShortRangeEnemy shortRangeEnemy) : base(shortRangeEnemy.gameObject)
    {
        _ShortRangeEnemy =  shortRangeEnemy;
    }


        public override Type Tick()
        {
            playerPosition = _ShortRangeEnemy.playerManager.player.transform.position;

          
            if(Vector3.Distance(transform.position,playerPosition) <= _ShortRangeEnemy.hearRadius)
            {
                return typeof(ChaseState);
            }
            _ShortRangeEnemy.wanderTimer -= Time.deltaTime;

            if(_ShortRangeEnemy.wanderTimer <= 0){
                if(!_ShortRangeEnemy.movingRight){
                    _ShortRangeEnemy.movingRight = true;
                    _ShortRangeEnemy.wanderTimer = UnityEngine.Random.Range(_ShortRangeEnemy.wanderMin, _ShortRangeEnemy.wanderMax);
                }
                else{
                    _ShortRangeEnemy.movingRight = false;
                     _ShortRangeEnemy.wanderTimer = UnityEngine.Random.Range(_ShortRangeEnemy.wanderMin, _ShortRangeEnemy.wanderMax);

                }
            }
        
             if( Detection(direction).collider.tag  == "Ground" && !_ShortRangeEnemy.movingRight )
             {
                _ShortRangeEnemy.movingRight = true;
            }
            else if(Detection(direction).collider.tag  == "Gronud " && _ShortRangeEnemy.movingRight)
            {
                _ShortRangeEnemy.movingRight = false;
            }
            
            if(_ShortRangeEnemy.movingRight){
                direction = 1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
            }
            else if(!_ShortRangeEnemy.movingRight) {
                direction = -1.0f;
                _ShortRangeEnemy.EnemyMove(direction);
            }
            return null;

        }

        private RaycastHit2D Detection(float direction)
        {
            float directionOriginOffset = originOffset * (direction > 0 ? 1 : -1);
            Vector2 startingPosition = new Vector2(transform.position.x + directionOriginOffset,transform.position.y);
            
            Vector2 currentDirection = new Vector2(direction, 0);
            Debug.DrawRay(startingPosition, currentDirection, Color.black);
            return Physics2D.Raycast(startingPosition, currentDirection, raycastMaxDistance);  
        }

        
    }
