using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProjectH.Scripts.Enemy.States
{
    public class SearchState : BaseState
    {
        private float _searchTimer;
        private float _moveTimer;

        #region Override: Enter | Perform | Exit

        public override void Enter()
        {
            enemyMotor.Agent.SetDestination(enemyMotor.LastKnownPosition);
        }

        public override void Perform()
        {
            if (enemyMotor.EnemyStats.IsEnemyDead)
            {
                StateMachine.ChangeState(new DeadState());
                return;
            }
            if (enemyMotor.EnemyCanSeePlayer())
                StateMachine.ChangeState(new AttackState());

            if (enemyMotor.Agent.remainingDistance < enemyMotor.Agent.stoppingDistance)
            {
                _searchTimer += Time.deltaTime;
                _moveTimer += Time.deltaTime;
                if (_moveTimer > Random.Range(3, 5))
                {
                    enemyMotor.Agent.SetDestination(enemyMotor.transform.position + (Random.insideUnitSphere * 10));
                    _moveTimer = 0;
                }
                
                if (_searchTimer > Random.Range(5f,10f))
                {
                    StateMachine.ChangeState(new PatrolState());
                }
            }
        }

        public override void Exit()
        {
        }

        #endregion
    }
}