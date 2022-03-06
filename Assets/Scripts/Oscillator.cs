using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Vector3 _movementVector;
    [SerializeField] private int _period;

    #endregion

    #region Private Fields

    private Vector3 _startingPos;
    [Range(0,1)] private float _movementFactor;
    private const float _tau = Mathf.PI * 2;

    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
	    
    }

    void Start()
    {
        _startingPos = transform.position;
        _period = _period == 0 ? 1 : _period;

    }

   
    void Update()
    {
        
        if (_period <= Mathf.Epsilon)
        {
            return;
        }
       CalculateMovementFactor();
        Oscillate();
    }
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods

    void CalculateMovementFactor()
    {
        var cycle = Time.time / _period;
        var xVar = _tau * cycle;
        float rawWave = Mathf.Sin(xVar - 1.5f);
        _movementFactor = 0.5f * rawWave + 0.5f;
    }

    void Oscillate()
    {
       
        var offset = _movementVector * _movementFactor;
        transform.position = _startingPos + offset;
    }
    #endregion
}


