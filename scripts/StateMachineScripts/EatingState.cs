using UnityEngine;

namespace MyAssets.Scripts.StateMachineScripts
{
    public class EatingState: BaseState
    {
        public EatingState(FishBehaviour fishBehaviour, FishProperties fishProperties, StateMachine stateMachine) : base(fishBehaviour, fishProperties, stateMachine) { }
        
        public override void OnEnter()
        {
            fishBehaviour.fishingRod.baitedFish = fishBehaviour;
        }
        
        public override void OnUpdate()
        {
            if (fishBehaviour.fishingRod.baitedFish != fishBehaviour) stateMachine.ChangeState(stateMachine.swimmingRandomState);
            fishBehaviour.transform.position = fishBehaviour.bait.position + Vector3.up * 0.01f;
        }
    }
}