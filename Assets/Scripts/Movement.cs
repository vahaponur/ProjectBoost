using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Represents Rocket Movement Behaviour
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private float _thrustForce = 100f;
    [SerializeField] private float _rotationSpeed = 30f;
    #endregion

    #region Private Fields
    /// <summary>
    /// Rigidbody of the attached gameobject
    /// </summary>
    private Rigidbody _rigidbody;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    void Start()
    {
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
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up* _thrustForce* Time.deltaTime );
        }

      
    }
    
    /// <summary>
    /// Process rockets rotation by given inputs
    /// </summary>
    void ProcessRotation()
    {
    
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_rotationSpeed);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_rotationSpeed);
            return;
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
