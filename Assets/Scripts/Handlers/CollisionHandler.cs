using UnityEngine;

/// <summary>
/// Handles Player Collision Events
/// </summary>
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(AudioSource))]
public class CollisionHandler : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private float _sceneLoadDelay = 3f;
    [SerializeField] private AudioClip _successSFX;
    [SerializeField] private AudioClip _failSFX;
    
    #endregion

    #region Private Fields
    /// <summary>
    /// Movement Component Attached to Gameobject
    /// </summary>
    private Movement _movement;
    /// <summary>
    /// Audio Source Component Attached to Gameobject
    /// </summary>
    private AudioSource _audioSource;
    /// <summary>
    /// To avoid multiple transitions
    /// </summary>
    private bool isTransitioning = false;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;
       
        switch (other.gameObject.tag)
        {
            case "Finish":
                StartSuccessSequence();
                break;
            case "Friendly":
                
                break;
            default:
               StartCrashSequence();
                break;
        }
    }

    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    
    /// <summary>
    /// Starts the sequence of events when player fail
    /// </summary>
    void StartCrashSequence()
    {
       
        isTransitioning = true;
        //ToDo add Crash particle effect
        _audioSource.PlayWithLogic(_failSFX);
        _movement.enabled = false;
        Invoke("ReloadLevel",_sceneLoadDelay);  
        
        
    }
    
    /// <summary>
    /// Starts the sequence of events when player succeed
    /// </summary>
    void StartSuccessSequence()
    {
      
        isTransitioning = true;
        //ToDo add Success particle effect
        _audioSource.PlayWithLogic(_successSFX);
        _movement.enabled = false;
        Invoke("LoadNextLevel",_sceneLoadDelay);
        
        
    }
    
    /// <summary>
    /// Reloads Level, Written for invoke delay
    /// </summary>
    void ReloadLevel()
    {
        SceneManagerAdapter.ReloadLevel();
    }
    
    /// <summary>
    /// Loads next Level, Written for invoke delay
    /// </summary>
    void LoadNextLevel()
    {
        SceneManagerAdapter.LoadNextLevel();
    }
    
    #endregion
}
