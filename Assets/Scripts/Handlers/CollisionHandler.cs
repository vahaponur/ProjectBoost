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

    private Movement _movement;
    private AudioSource _audioSource;
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
        if (!isTransitioning)
        {
            //ToDo add Crash particle effect
            _audioSource.PlayWithLogic(_failSFX);
            _movement.enabled = false;
            Invoke("ReloadLevel",_sceneLoadDelay);  
        }

        isTransitioning = true;
    }
    
    /// <summary>
    /// Starts the sequence of events when player succeed
    /// </summary>
    void StartSuccessSequence()
    {
        if (!isTransitioning)
        {
            //ToDo add Success particle effect
            _audioSource.PlayWithLogic(_successSFX);
            _movement.enabled = false;
            Invoke("LoadNextLevel",_sceneLoadDelay);
        }

        isTransitioning = true;
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
