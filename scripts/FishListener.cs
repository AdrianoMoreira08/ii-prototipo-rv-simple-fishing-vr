using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace MyAssets.Scripts
{
    public class FishListener : MonoBehaviour
    {
        private XRGrabInteractable _grabInteractable;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void OnEnable()
        {
            _grabInteractable.onSelectExited.AddListener(OnRelease);
        }

        private void OnRelease(XRBaseInteractor arg0)
        {
            _rigidbody.isKinematic = false;
        }
    }
}