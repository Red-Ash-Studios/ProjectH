using DG.Tweening;
using UnityEngine;

namespace ProjectH.Scripts.Enemy.States
{
    public class DeadState : BaseState
    {
        #region Fields

        private bool _isDead;

        #endregion

        public override void Enter()
        {
        }

        public override void Perform()
        {
            if (!_isDead)
            {
                if (enemyMotor.EnemyStats.IsEnemyDead)
                {
                    enemyMotor.Agent.velocity = Vector3.zero;
                    enemyMotor.Agent.acceleration = 0;
                    enemyMotor.transform.DORotate(new Vector3(enemyMotor.transform.rotation.x, enemyMotor.transform.rotation.y, 90), 0.3f);
                    enemyMotor.transform.DOMove(new Vector3(enemyMotor.transform.position.x, 0.5f, enemyMotor.transform.position.z), 0.3f);
                    _isDead = true;
                }
            }
        }

        public override void Exit()
        {
        }
    }
}