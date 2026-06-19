using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float HorizontalSpeed = 1000f;
    [SerializeField] private float VerticalSpeed = 600f;

    private Rigidbody rigidBody;
    private Vector2 MoveInput;

    private void Start()
    {
        // Get the essential components
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Read the input value
        MoveInput = InputManager.Instance.MoveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Apply forward force no matter what input and apply sideways force according to the input
        rigidBody.AddForce(HorizontalSpeed * Time.fixedDeltaTime * new Vector3(MoveInput.x, 0, 0));
        rigidBody.AddForce(VerticalSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}