using System;
using ProjectH.Scripts.Enemy.States;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectH.Scripts.Enemy
{
    public class StateMachine:MonoBehaviour
    {
        public BaseState activeState;

        public void Initialize()
        {
            ChangeState(new PatrolState());
        }
        
        private void Start()
        {
            
        }

        private void Update()
        {
            if (activeState != null)
                activeState.Perform();
        }
        
        public void ChangeState(BaseState newState)
        {
            //check activeState != null
            if (activeState != null)
            {
                //run cleanup on activeState
                activeState.Exit();
            }

            //change to a new state
            activeState = newState;

            //fail-safe null check
            if (activeState != null)
            {
                activeState.StateMachine = this;
                activeState.enemyMotor = GetComponent<EnemyMotor>();
                activeState.Enter();
            }
        }
    }
}