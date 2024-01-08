using System;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class FishingLineSimple : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private GameObject bait;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            bait = GameObject.Find("Bait");
        }
        
        void Start()
        {
            lineRenderer.positionCount = 2;
        }
        
        void Update()
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, bait.transform.position);
        }
    }
}
