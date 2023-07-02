using UnityEngine;

namespace Kdevaulo.RainDemo.Scripts.CharacterBehaviour
{
    public class CameraInput : MonoBehaviour
    {
        [Min(0.0001f)]
        [SerializeField] private float _tiltSpeed = 1f;

        [SerializeField] private Transform _cameraContainer;

        [SerializeField] private Vector2 _tiltRange;

        private void Update()
        {
            float vertical = Input.GetAxis("Mouse Y");

            float rotationX = _cameraContainer.localRotation.eulerAngles.x;
            float clampedValue = ClampValue(rotationX, -vertical * _tiltSpeed);

            _cameraContainer.Rotate(new Vector3(clampedValue, 0, 0));
        }

        private float ClampValue(float lastValue, float additiveValue)
        {
            if (lastValue > 180)
            {
                lastValue -= 360;
            }

            float targetValue = lastValue + additiveValue;

            if (targetValue < _tiltRange.x || targetValue > _tiltRange.y)
            {
                return 0;
            }

            return additiveValue;
        }
    }
}