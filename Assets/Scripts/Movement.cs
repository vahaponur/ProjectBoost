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
    [SerializeField] private KeyCode _leftRotateKey = KeyCode.A;
    [SerializeField] private KeyCode _rightRotateKey = KeyCode.D;
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
        if (Input.GetKey(_thrushtKey))
        {
            StartThrusting();
        }
        else
        {
            StopThrushting();
        }
    }

    /// <summary>
    /// Process rockets rotation by given inputs
    /// </summary>
    void ProcessRotation()
    {
        if (Input.GetKey(_rightRotateKey))
        {
            StartRightRotation();
            return;
        }

        if (Input.GetKey(_leftRotateKey))
        {
            StartLeftRotation();
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
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                 RigidbodyConstraints.FreezePositionZ;
    }
    
    /// <summary>
    /// Sequence of events when starting thrusting
    /// </summary>
    void StartThrusting()
    {
        _audioSource.PlayOnGetKey(_thrushtKey, _thrustSFX);
        _thrushtParticle.PlayOnGetKey(_thrushtKey);
        _rigidbody.AddRelativeForce(Vector3.up * _thrustForce * Time.deltaTime);
    }
    
    /// <summary>
    /// Sequence of events when thrusting stopped
    /// </summary>
    void StopThrushting()
    {
    }
    
    /// <summary>
    /// Sequence of events in case player starts to right rotation
    /// </summary>
    void StartRightRotation()
    {
        _leftBooster.PlayOnGetKey(_rightRotateKey);
        ApplyRotation(-_rotationSpeed);
    }
    
    /// <summary>
    /// Sequence of events in case player starts to left rotation
    /// </summary>
    void StartLeftRotation()
    {
        _rightBooster.PlayOnGetKey(_leftRotateKey);
        ApplyRotation(_rotationSpeed);
    }

    #endregion
}