using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraBackground : MonoBehaviour
    {

        [SerializeField]
        private Camera _cameraToFollow;

        [SerializeField]
        private Vector3 _screenPosition = new Vector3(0, 0, 50);
        [SerializeField]
        private float _smoothingOnY = 10;

        private float _cameraStartY;
        private Vector3 _cameraTopLeftCorner;
        private float _maxDiffOnY;

        private float _diffInY;

        void Start()
        {
            _cameraStartY = _cameraToFollow.transform.position.y;

            var spriteSize = GetComponent<Renderer>().bounds.size.y;
            var spriteTopLeftCorner = transform.position + new Vector3(0, spriteSize, 0);
            _cameraTopLeftCorner = _cameraToFollow.ScreenToWorldPoint(new Vector3(0, _cameraToFollow.pixelHeight, _screenPosition.z));

            _maxDiffOnY = _cameraTopLeftCorner.y - spriteTopLeftCorner.y;
        }

        void Update()
        {
            var alignToCamera = _cameraToFollow.ScreenToWorldPoint(_screenPosition);
    
            _diffInY = _cameraStartY - _cameraToFollow.transform.position.y;

            var clampedDiff = Mathf.Clamp(_diffInY / _smoothingOnY, _maxDiffOnY, 0);

            var newPos = alignToCamera + new Vector3(0, clampedDiff, 0);

            transform.position = newPos;
        }

    }