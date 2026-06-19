using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 CameraOffset;

    [Header("Obstacle Avoidance")]
    public LayerMask ObstacleLayer;
    public float StepAmount = 0.5f;
    public int MaximumChecks = 20;
    public float SmoothSpeed = 2f;

    private float TargetObstacleY = 0f;
    private float CurrentObstacleY = 0f;

    private void LateUpdate()
    {
        if (PlayerTransform is null)
        {
            Debug.LogError("FollowCamera:LateUpdate() :: PlayerTransform reference is missing!");
            return;
        }

        Vector3 BasePosition = new Vector3(0, PlayerTransform.position.y, PlayerTransform.position.z) + CameraOffset;

        Vector3 CheckPosition = BasePosition;
        float RequiredOffset = 0f;
        int Checks = 0;

        while (Checks < MaximumChecks)
        {
            Vector3 ToPlayer = PlayerTransform.position - CheckPosition;
            float MaximumDistance = ToPlayer.magnitude - 0.1f;

            if (Physics.Raycast(CheckPosition, ToPlayer.normalized, out RaycastHit RaycastHit, MaximumDistance, ObstacleLayer))
            {
                CheckPosition.y += StepAmount;
                RequiredOffset += StepAmount;
                Checks++;
            }
            else
                break;
        }

        TargetObstacleY = RequiredOffset;
        CurrentObstacleY = Mathf.Lerp(CurrentObstacleY, TargetObstacleY, SmoothSpeed * Time.deltaTime);

        transform.position = BasePosition + new Vector3(0, CurrentObstacleY, 0);
        transform.LookAt(PlayerTransform);
    }

    private void OnDrawGizmosSelected()
    {
        if (PlayerTransform is null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -PlayerTransform.position);
    }
}