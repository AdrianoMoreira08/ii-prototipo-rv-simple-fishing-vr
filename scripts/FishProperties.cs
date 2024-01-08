using UnityEngine;

namespace MyAssets.Scripts
{
    [CreateAssetMenu(menuName = "FishProperties")]
    public class FishProperties : ScriptableObject
    {
        public float swimSpeed = 1f;
        public float swimRadius = 3f;
        public float distanceToBait = 3f;
        public float swimToBaitProbability = 0.4f;
        public float size = 1f;

        public GameObject fishModel;
    }
}