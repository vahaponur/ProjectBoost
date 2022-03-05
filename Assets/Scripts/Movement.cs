using UnityEngine;

/// <summary>
/// Represents Rocket Movement Behaviour
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private float _thrustForce = 1000f;
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private KeyCode _thrushtKey = KeyCode.Space;
    [SerializeField] private KeyCode _leftRotateKey = KeyCode.D;
    [SerializeField] private KeyCode _rightRotateKey = KeyCode.A;
    [SerializeField] private AudioClip _thrustSFX;
    [SerializeField] private ParticleSystem _thrushtParticle;
    [SerializeField] private ParticleSystem _leftBooster;
    [SerializeField] private ParticleSystem _rightBooster;
    #endregion

    #region Private Fields
    /// <summary>
    /// Rigidbody of the attached gameobject
    /// </summary>
    private Rigidbody _rigidbody;
    
    /// <summary>
    /// Audio source attached to gameobject
    /// </summary>
    private AudioSource _audioSource;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _audioSource = this.GetComponent<AudioSource>();

    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    
    /// <summary>
    /// Process the rockets thrust by given inputs 
    /// </summary>
    private void ProcessThrust()
    {
        _audioSource.PlayOnGetKey(_thrushtKey,_thrustSFX);
        _thrushtParticle.PlayOnGetKey(_thrushtKey);
        
        if (Input.GetKey(_thrushtKey))
        {
         
            _rigidbody.AddRelativeForce(Vector3.up* _thrustForce* Time.deltaTime );
        }
    
        
    }
    
    /// <summary>
    /// Process rockets rotation by given inputs
    /// </summary>
    void ProcessRotation()
    {
        _rightBooster.PlayOnGetKey(_rightRotateKey);
        _leftBooster.PlayOnGetKey(_leftRotateKey);
        
        if (Input.GetKey(_rightRotateKey))
        {
            ApplyRotation(_rotationSpeed);
            return;
        }

        if (Input.GetKey(_leftRotateKey))
        {
            ApplyRotation(-_rotationSpeed);
        }
       
    }
    
    /// <summary>
    /// Applies rotation with given speed on Z axis
    /// </summary>
    /// <param name="rotationSpeed">Rotation Speed, negative if back</param>
    void ApplyRotation(float rotationSpeed)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;

    }
    
    
    #endregion
}
