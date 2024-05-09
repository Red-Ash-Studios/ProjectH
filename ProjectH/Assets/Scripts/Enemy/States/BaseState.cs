namespace ProjectH.Scripts.Enemy.States
{
    public abstract class BaseState
    {
        public EnemyMotor enemyMotor;
        public StateMachine StateMachine;

        public abstract void Enter();
        public abstract void Perform();
        public abstract void Exit();
        
    }
}