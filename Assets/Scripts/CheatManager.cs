using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatManager : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields

    private List<GameObject> _gameObjects;
    private bool isColliderClosed;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
        var cheats = FindObjectsOfType<CheatManager>().ToArray();
        
        if (cheats.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _gameObjects = GameObject.FindObjectsOfType<GameObject>().ToList();
        
    }

   
    void Update()
    {
     ProcessCheatKeys();   
    }
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods

    void ProcessCheatKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isColliderClosed)
            {
               OpenColliders();
            }
            else
            {
                CloseColliders();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManagerAdapter.LoadNextLevel();
        }
    }
    void CloseColliders()
    {
        RefreshGameObjectList();
        Collider coll;
        foreach (var gameObject in _gameObjects)
        {
           
            if ((coll = gameObject.GetComponent<Collider>()) != null)
            {
                coll.enabled = false;
            }
        }

        isColliderClosed = true;
    }

    void RefreshGameObjectList()
    {
        _gameObjects = GameObject.FindObjectsOfType<GameObject>().ToList();

    }

    void OpenColliders()
    {
        RefreshGameObjectList();
        Collider coll;
        foreach (var gameObject in _gameObjects)
        {
           
            if ((coll = gameObject.GetComponent<Collider>()) != null)
            {
                coll.enabled = true;
            }
        }

        isColliderClosed = false;
    }
  
    #endregion
}
