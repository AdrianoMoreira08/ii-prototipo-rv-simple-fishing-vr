namespace MyAssets.Scripts.StateMachineScripts
{
    public abstract class BaseState
    {
        protected readonly FishBehaviour fishBehaviour;
        protected readonly FishProperties fishProperties;
        protected readonly StateMachine stateMachine;
        protected float stateTimer => stateMachine.stateTimer;
        protected float deltaTime => stateMachine.deltaTime;
        
        protected BaseState(FishBehaviour fishBehaviour, FishProperties fishProperties, StateMachine stateMachine)
        {
            this.fishProperties = fishProperties;
            this.fishBehaviour = fishBehaviour;
            this.stateMachine = stateMachine;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
    }
}