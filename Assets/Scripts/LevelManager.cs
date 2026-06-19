using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Singleton")]
    public static LevelManager Instance { get; private set; }

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
    }

    public void LoadBlankLevel() => SceneManager.LoadScene("Level", LoadSceneMode.Single);
}