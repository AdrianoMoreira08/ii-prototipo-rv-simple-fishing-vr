using UnityEngine;

namespace MyAssets.Scripts.StateMachineScripts
{
    public class IdleState : BaseState
    {
        public IdleState(FishBehaviour fishBehaviour, FishProperties fishProperties, StateMachine stateMachine) : base(fishBehaviour, fishProperties, stateMachine) { }
        
        private BaseState _nextState;
        public override void OnEnter()
        {
            var isBaitProbability = Random.value < fishProperties.swimToBaitProbability;
            var isInYRange = fishBehaviour.transform.position.y > fishBehaviour.bait.position.y - 0.1f && fishBehaviour.transform.position.y < fishBehaviour.bait.position.y + 0.1f;
            var canGoToBait = isBaitProbability && isInYRange;
            if (!fishBehaviour.fishingRod.baitedFish && Vector3.Distance(fishBehaviour.transform.position, fishBehaviour.bait.position) < fishProperties.distanceToBait && canGoToBait)
            {
                _nextState = stateMachine.swimmingToBaitState;
                
            }
            else
            {
                _nextState = stateMachine.swimmingRandomState;
            }
        }

        public override void OnUpdate()
        {
            if (stateTimer > 1f) stateMachine.ChangeState(_nextState);
        }
        
        
    }
}