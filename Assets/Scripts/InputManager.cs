using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Singleton")]
    public static InputManager Instance { get; private set; }

    [Header("Input")]
    [SerializeField] private InputActionAsset InputAsset;

    [Space(5)]
    private InputActionMap PlayerMap;

    [Space(5)]
    public InputAction MoveAction;

    private void Awake()
    {
        // Early return if there is another instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Guarantee the instance
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Find and bind the action variables
        PlayerMap = InputAsset.FindActionMap("Player");

        MoveAction = PlayerMap.FindAction("Move");
    }

    private void OnEnable()
    {
        // Enable action maps to make them start listening
        PlayerMap?.Enable();
    }

    private void OnDisable()
    {
        // Disable action maps to free CPU usage
        PlayerMap?.Disable();
    }
}