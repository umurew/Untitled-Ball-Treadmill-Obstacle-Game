using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -10)
            LevelManager.Instance.LoadBlankLevel();
    }
}