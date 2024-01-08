using MyAssets.Scripts;
using MyAssets.Scripts.StateMachineScripts;
using UnityEngine;

public class StateMachine
{
    public BaseState currentState;
    public readonly IdleState idleState;
    public readonly SwimmingRandomState swimmingRandomState;
    public readonly SwimmingToBaitState swimmingToBaitState;
    public readonly EatingState eatingState;
    public float stateTimer;
    public float deltaTime;
        
    public StateMachine(FishBehaviour fishBehaviour, FishProperties fishProperties)
    {
        idleState = new IdleState(fishBehaviour, fishProperties, this);
        swimmingRandomState = new SwimmingRandomState(fishBehaviour, fishProperties, this);
        swimmingToBaitState = new SwimmingToBaitState(fishBehaviour, fishProperties, this);
        eatingState = new EatingState(fishBehaviour, fishProperties, this);
        currentState = null;
    }
    
    public void SetInitialState(BaseState initialState)
    {
        currentState = initialState;
        currentState.OnEnter();
    }
    public void ChangeState(BaseState newState) 
    {
        currentState.OnExit();
        stateTimer = 0;
        currentState = newState;
        currentState.OnEnter();
    }
    public void UpdateState(float delta)
    {
        deltaTime = delta;
        stateTimer += delta;
        currentState.OnUpdate();
    }
    
    public float EaseInOut(float t)
    {
        return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }
}