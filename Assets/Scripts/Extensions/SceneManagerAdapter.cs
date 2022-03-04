using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static  class SceneManagerAdapter
{
    #region Serialized Fields
    #endregion

    #region Private Fields

    private static CoroutineRunner _coroutineRunner;
    #endregion

    #region Public Properties
    public static CoroutineRunner CoroutineRunner
    {
        get => GetCoroutineRunner();
    }
    #endregion
    
    #region PublicMethods
    /// <summary>
    /// Loads current scene asynchronously
    /// </summary>
    /// <returns>Null</returns>
    public static IEnumerator LoadCurrentScene()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    /// <summary>
    /// Loads the given scene asynchronously
    /// </summary>
    /// <param name="sceneName">Scene name to load</param>
    /// <returns>Null</returns>
    public static IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    /// <summary>
    /// Loads the given scene asynchronously
    /// </summary>
    /// <param name="sceneIndex">Index of scene on builder</param>
    /// <returns>Null</returns>
    public static IEnumerator LoadSceneAsync(int sceneIndex)
    {
        if (sceneIndex<0)
        {
            throw new Exception("Scene Index cannot be lower than 0");
        }
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    /// <summary>
    /// Reloads the current Level
    /// </summary>
    public static void ReloadLevel()
    {
       CoroutineRunner.StartCoroutine(SceneManagerAdapter.LoadCurrentScene());
    }
    /// <summary>
    /// Loads Next Level by build index
    /// </summary>
    public static void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                
        CoroutineRunner.StartCoroutine(SceneManagerAdapter.LoadSceneAsync(nextSceneIndex));
    }
    
    #endregion
    
    #region PrivateMethods
    static CoroutineRunner GetCoroutineRunner()
    {
        GameObject instance = new GameObject();
        instance.isStatic = true;
        _coroutineRunner = instance.AddComponent<CoroutineRunner>();
        return _coroutineRunner;
    }
    #endregion
}


