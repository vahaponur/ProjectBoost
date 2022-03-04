using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles Player Collision Events
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                SceneManagerAdapter.LoadNextLevel();
                break;
            case "Fuel":
                
                break;
            case "Friendly":
                
                break;
            default:
               SceneManagerAdapter.ReloadLevel();
                break;
        }
    }

    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    #endregion
}
