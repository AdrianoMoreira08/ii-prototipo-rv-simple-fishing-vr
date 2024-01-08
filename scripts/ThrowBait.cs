using UnityEngine;
using UnityEngine.InputSystem;

namespace MyAssets.Scripts
{
    public class ThrowBait : MonoBehaviour
    {
        [SerializeField] private InputActionReference triggerAction;
        [SerializeField] private Rigidbody baitRigidbody;
        [SerializeField] private float throwForce = 10f;
        [SerializeField] private Transform baitSpawnPoint;

        private void Start()
        {
            triggerAction.action.performed += TriggerActionOnPerformed;
            triggerAction.action.Enable();
        }
    
        private void TriggerActionOnPerformed(InputAction.CallbackContext obj)
        {
            baitRigidbody.transform.position = baitSpawnPoint.position;
            baitRigidbody.transform.rotation = baitSpawnPoint.rotation;
            baitRigidbody.velocity = Vector3.zero;
            baitRigidbody.isKinematic = false;
            baitRigidbody.GetComponent<Collider>().enabled = true;
            baitRigidbody.AddForce(baitSpawnPoint.up * throwForce, ForceMode.Impulse);
        }
    
    }
}