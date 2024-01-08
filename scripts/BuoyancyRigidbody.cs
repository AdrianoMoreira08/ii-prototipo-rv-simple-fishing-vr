using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class BuoyancyRigidbody : MonoBehaviour
    {
        public float submergenceOffset = 0.5f;
        public float submergenceRange = 1f;
        public float buoyancy = 1f;
        public float waterDrag = 0.99f;
        public LayerMask waterMask;

        private float submergence;
        private Rigidbody rigidBody;
        
        public bool isSubmerged => submergence > 0f;
        
        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (waterMask == (waterMask | (1 << other.gameObject.layer)))
            {
                CalculateSubmergence();
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (waterMask == (waterMask | (1 << other.gameObject.layer)))
            {
                CalculateSubmergence();
            }
        }
        
        
        private void CalculateSubmergence()
        {
            if (Physics.Raycast(
                    rigidBody.position + Vector3.up * submergenceOffset,
                    Vector3.down, out var hit, submergenceRange + 1f,
                    waterMask, QueryTriggerInteraction.Collide
                )) {
                submergence = 1f - hit.distance / submergenceRange;
            }
            else {
                submergence = 1f;
            }
        }

        private void FixedUpdate()
        {
            if (submergence <= 0f) return;
            var drag = Mathf.Max(0f, 1f - waterDrag * submergence * Time.deltaTime);
            rigidBody.velocity *= drag;
            rigidBody.AddForce(
                Physics.gravity * -(buoyancy * submergence),
                ForceMode.Acceleration
            );
            submergence = 0f;
        }
    }
}
