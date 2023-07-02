using UnityEngine;

namespace Kdevaulo.RainDemo.Scripts.CharacterBehaviour
{
    public class MovementInput : MonoBehaviour
    {
        [Min(0.0001f)]
        [SerializeField] private float _movementSpeed = 0.007f;
        [Min(0.0001f)]
        [SerializeField] private float _rotationSpeed = 1;

        [SerializeField] private CharacterController _characterController;

        [SerializeField] private Transform _characterContainer;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            _characterController.Move(_movementSpeed * vertical * _characterContainer.forward);
            _characterController.Move(_movementSpeed * horizontal * _characterContainer.right);

            float mouseHorizontal = Input.GetAxis("Mouse X");

            _characterContainer.Rotate(new Vector3(0, mouseHorizontal * _rotationSpeed, 0));
        }
    }
}