using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;



public class ShortRangeEnemy : MonoBehaviour
{
    //Enviroment Detection

    public float hearRadius;
    public float lookRadius;
    public float playerAttackRadius;
    public Vector2 currentDirection;
    public BoxCollider2D boxCollider => GetComponent<BoxCollider2D>();
    public Rigidbody2D rigidbody2D => GetComponent<Rigidbody2D>();
    public bool movingRight;
    //public Animator animator => GetComponent<Animator>();

    // Enemy Stats

    
    
    //Enemy Controller
    public float wanderTimer;
    public float wanderMin;
    public float wanderMax;
    public float speed;
    private Vector3 m_Velocity = Vector3.zero;
    
    public StateMachine  stateMachine =>  GetComponent<StateMachine>();
    public PlayerManager playerManager => GetComponent<PlayerManager>();

    // Start is called before the first frame update
    void Awake()
    {
      InitializeStateMachine();
      

    }

    void Update()
    {
        
        
        
    }
    private void InitializeStateMachine(){
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(WanderState), new WanderState(this)},
            {typeof(ChaseState), new ChaseState(this)}

        };
         stateMachine.SetState(states);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,  hearRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,  lookRadius);
         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,  playerAttackRadius);
        
    }

    public void EnemyMove(float direction){
        
        Vector3 targetVelocity = new Vector2(direction * speed, rigidbody2D.velocity.y );
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity,ref m_Velocity , 0.3f );

    }

   public void DestroyEnemy()
   {
       Destroy(this.gameObject, 4.0f);
   }


}

