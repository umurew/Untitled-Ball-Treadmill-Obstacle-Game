using UnityEngine;

public static class SceneInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeGame()
    {
        // Define the essential prefabs
        GameObject InputManagerPrefab = Resources.Load<GameObject>("SceneInitialization/InputManager");
        GameObject LevelManagerPrefab = Resources.Load<GameObject>("SceneInitialization/LevelManager");

        // Early return in case they are null
        if (InputManagerPrefab is null || LevelManagerPrefab is null)
        {
            Debug.LogError("SceneInitializer:InitializeGame() :: One or more of prefabs were null.");
            return;
        }

        // Clone them into the scene
        GameObject.Instantiate(InputManagerPrefab);
        GameObject.Instantiate(LevelManagerPrefab);

        Debug.Log("SceneInitializer:InitializeGame() :: Initialized successfully.");
    }
}