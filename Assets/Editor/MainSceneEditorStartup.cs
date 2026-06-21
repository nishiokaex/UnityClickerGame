using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class MainSceneEditorStartup
{
    private const string MainScenePath = "Assets/Scenes/MainScene.unity";

    static MainSceneEditorStartup()
    {
        EditorApplication.delayCall += ConfigureMainScene;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            ConfigureMainScene();
        }
    }

    private static void ConfigureMainScene()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
        {
            SetPlayModeStartScene();
            OpenMainSceneIfSafe();
            return;
        }

        if (EditorApplication.isPlaying)
        {
            return;
        }

        SetPlayModeStartScene();
        OpenMainSceneIfSafe();
    }

    private static void SetPlayModeStartScene()
    {
        SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(MainScenePath);
        if (sceneAsset == null)
        {
            Debug.LogWarning($"MainScene not found: {MainScenePath}");
            return;
        }

        EditorSceneManager.playModeStartScene = sceneAsset;
    }

    private static void OpenMainSceneIfSafe()
    {
        Scene activeScene = EditorSceneManager.GetActiveScene();
        if (activeScene.path == MainScenePath)
        {
            return;
        }

        for (int i = 0; i < EditorSceneManager.sceneCount; i++)
        {
            Scene openScene = EditorSceneManager.GetSceneAt(i);
            if (openScene.isDirty && openScene.path != MainScenePath)
            {
                Debug.LogWarning($"MainScene was not opened because another scene has unsaved changes: {openScene.path}");
                return;
            }
        }

        EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
    }
}
