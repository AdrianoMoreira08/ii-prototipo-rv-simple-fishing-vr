using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class FishingRod : MonoBehaviour
    {
        public Rigidbody baitRigidbody;
        [SerializeField] private SteeringWheel steeringWheel;
        [SerializeField] private Transform reelEndTransform;
        [SerializeField] private float pullForce = 10f;
        [SerializeField] private float distanceToCatch = 5f;
        [SerializeField] private float distanceToReset = 1f;
        
        private AudioSource audioSource;
        private float currentAngle;
        private float previousAngle;
    
        public event Action OnLiftingFish;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            steeringWheel.OnWheelRotated += OnWheelRotatedEvent;
        }
        public FishBehaviour baitedFish { get; set; }
    
        private void OnWheelRotatedEvent(float angle)
        {
            if (angle < 0) return;
            if (angle > 2) angle = 2;
            var direction = (reelEndTransform.position - baitRigidbody.transform.position).normalized;
            
            if (Vector3.Distance(reelEndTransform.position, baitRigidbody.transform.position) < distanceToCatch)
            {
                if (baitedFish != null)
                {
                    // Instantiate random fish and parent it to the reel
                    var fish = Instantiate(baitedFish.fishProperties.fishModel, reelEndTransform.position, Quaternion.identity);
                    fish.transform.parent = baitRigidbody.transform;
                    fish.transform.localPosition = Vector3.up * 0.1f;
                    fish.GetComponent<Rigidbody>().isKinematic = true;
                    
                    baitRigidbody.GetComponent<Collider>().enabled = false;

                    OnLiftingFish?.Invoke();
                    baitedFish = null;
                }
                    
                
                baitRigidbody.isKinematic = true;
                baitRigidbody.transform.position += direction * angle * 0.01f;
            }
            else
            {
                var force = direction * angle * pullForce;
                force.y = 0;
                baitRigidbody.isKinematic = false;
                baitRigidbody.AddForce(force, ForceMode.Impulse);
            }
            
            currentAngle += angle;
            if (!(currentAngle - previousAngle > 15)) return;
            Vibrate();
            previousAngle = currentAngle;
            audioSource.Play();
        }

        private void Vibrate()
        {
            Invoke(nameof(StartVibration), 0f);
            Invoke(nameof(StopVibration), .1f);
        }
        
        public void StartVibration()
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        }
        
        public void StopVibration()
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
}
