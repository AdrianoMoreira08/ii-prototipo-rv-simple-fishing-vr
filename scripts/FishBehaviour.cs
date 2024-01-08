using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyAssets.Scripts
{
    public class FishBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject fishSilhouette;
        public FishProperties fishProperties;
        public Vector3 startPosition;
        private StateMachine _stateMachine;

        public FishingRod fishingRod;
        [HideInInspector] public Transform bait;
        private void Start()
        {
            startPosition = transform.position;
            bait = GameObject.Find("Bait").transform;
            _stateMachine = new StateMachine(this, fishProperties);
            fishingRod.OnLiftingFish += LiftingFish;
            _stateMachine.SetInitialState(_stateMachine.idleState);
            fishSilhouette.transform.localScale = Vector3.one * fishProperties.size;
        }
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _stateMachine.UpdateState(deltaTime);
        }
        private void LiftingFish()
        {
            if (_stateMachine.currentState == _stateMachine.eatingState) fishSilhouette.SetActive(false);
        }
    }
}