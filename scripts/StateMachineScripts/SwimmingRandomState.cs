using UnityEngine;

namespace MyAssets.Scripts.StateMachineScripts
{
    public class SwimmingRandomState: BaseState
    {
        public SwimmingRandomState(FishBehaviour fishBehaviour, FishProperties fishProperties, StateMachine stateMachine) : base(fishBehaviour, fishProperties, stateMachine) { }
        
        private BaseState _nextState;
        private float _arriveTime;
        private Vector3 _swimTarget;
        private Vector3 _startSwimmingPosition;
        public override void OnEnter()
        {
            var randomPoint = Random.insideUnitCircle * fishProperties.swimRadius;
            var randomPoint3D = new Vector3(randomPoint.x, 0, randomPoint.y);
            _swimTarget = fishBehaviour.startPosition + randomPoint3D;
            _arriveTime = Vector3.Distance(fishBehaviour.transform.position, _swimTarget) / fishProperties.swimSpeed;
            _startSwimmingPosition = fishBehaviour.transform.position;
        }

        public override void OnUpdate()
        {
            var t = Mathf.Clamp01(stateTimer / _arriveTime);
            fishBehaviour.transform.position = Vector3.Lerp(_startSwimmingPosition, _swimTarget, stateMachine.EaseInOut(t));
            if (stateTimer > _arriveTime) stateMachine.ChangeState(stateMachine.idleState);
        }
        
    }
}