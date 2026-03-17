using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;


namespace RPG.Character
{
    public class Movement: MonoBehaviour
    {
        private NavMeshAgent agent;
        private Vector3 movementVector;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MovePlayer();
            Rotate();
        }

        private void Rotate()
        {
            if (movementVector == Vector3.zero) return;
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.LookRotation(movementVector);
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.deltaTime * agent.angularSpeed);
        }

        public void HandleMove(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            movementVector = new Vector3(input.x, 0, input.y);
        }

        private void MovePlayer()
        {
            agent.Move(movementVector * Time.deltaTime * agent.speed);
        }
    }
}
