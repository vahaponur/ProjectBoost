using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                
                break;
            case "Fuel":
                
                break;
            case "Friendly":
                
                break;
            default:
                Debug.Log("You bumped an obstacle");
                break;
        }
    }

    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    
    #endregion
}
