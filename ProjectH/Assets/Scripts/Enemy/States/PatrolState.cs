using UnityEngine;

namespace ProjectH.Scripts.Enemy.States
{
    public class PatrolState : BaseState
    {
        public int waypointIndex;
        public float waitTimer;

        public override void Enter()
        {
        }

        public override void Perform()
        {
            if (enemyMotor.EnemyStats.IsEnemyDead)
            {
                StateMachine.ChangeState(new DeadState());
                return;
            }

            PatrolCycle();
            
            if (enemyMotor.EnemyCanSeePlayer())
                StateMachine.ChangeState(new AttackState());
        }

        public override void Exit()
        {
            
        }

        public void PatrolCycle()
        {
            if (enemyMotor.Agent.remainingDistance < 0.5f)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer > 3)
                {
                    if (waypointIndex < enemyMotor.Path.ListWaypoint.Count - 1)
                        waypointIndex++;
                    else
                        waypointIndex = 0;
                    enemyMotor.Agent.SetDestination(enemyMotor.Path.ListWaypoint[waypointIndex].position);
                    waitTimer = 0;
                }
            }
        }
    }
}