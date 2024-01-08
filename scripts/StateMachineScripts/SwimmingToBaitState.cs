using UnityEngine;

namespace MyAssets.Scripts.StateMachineScripts
{
    public class SwimmingToBaitState: BaseState
    {
        public SwimmingToBaitState(FishBehaviour fishBehaviour, FishProperties fishProperties, StateMachine stateMachine) : base(fishBehaviour, fishProperties, stateMachine) { }
        
        private float _arriveTime;
        private Vector3 _startSwimmingPosition;
        
        public override void OnEnter()
        {
            var position = fishBehaviour.bait.position;
            _arriveTime = Vector3.Distance(fishBehaviour.transform.position, position) / fishProperties.swimSpeed;
            _startSwimmingPosition = fishBehaviour.transform.position;
        }

        public override void OnUpdate()
        {
            var t = Mathf.Clamp01(stateTimer / _arriveTime);
            fishBehaviour.transform.position = Vector3.Lerp(_startSwimmingPosition, fishBehaviour.bait.position, stateMachine.EaseInOut(t));
            if (fishBehaviour.fishingRod.baitedFish) stateMachine.ChangeState(stateMachine.swimmingRandomState);
            if (stateTimer > _arriveTime) stateMachine.ChangeState(stateMachine.eatingState);
        }

    }
}