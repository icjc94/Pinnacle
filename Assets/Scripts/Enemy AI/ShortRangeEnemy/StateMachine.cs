﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
    
public class StateMachine : MonoBehaviour
{

    public Dictionary<Type, BaseState> _availableStates; 
    public BaseState CurrentState{get; set;}
    public event Action<BaseState> OnStateChanged;
    
    public void SetState(Dictionary<Type, BaseState> states)
    {
        _availableStates = states;
    }

    
    // Update is called once per frame
    private void Update()
    {
        if(CurrentState == null)
        {
            CurrentState = _availableStates.Values.First(); 
        }

        var nextState = CurrentState.Tick();
         
        if((nextState != null) && (nextState  != CurrentState?.GetType()))
        {
            SwitchToNewState(nextState);
           
        }
    }
    public void SwitchToNewState(Type nextState)
    {
        CurrentState =  _availableStates[nextState];
        Debug.Log("Switching to new state..");
        OnStateChanged?.Invoke(CurrentState);
    }
 }
