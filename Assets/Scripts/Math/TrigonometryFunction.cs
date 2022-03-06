using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigonometryFunction 
{
    #region Serialized Fields
    #endregion

    #region Private Fields

    private float _amplitude;
    private float _period;
    private float _verticalShift;
    private float _phaseShift;

    #endregion

    #region Public Properties
    public float Amplitude
    {
        get => _amplitude;
        set => _amplitude = value;
    }

    public float Period
    {
        get => _period;
        set => _period = value;
    }

    public float VerticalShift
    {
        get => _verticalShift;
        set => _verticalShift = value;
    }

    public float PhaseShift
    {
        get => _phaseShift;
        set => _phaseShift = value;
    }

    #endregion

    #region Constructors

    public TrigonometryFunction()
    {
        Amplitude = 1;
        Period = 1;
        VerticalShift = 0;
        _phaseShift = 0;

    }

    public TrigonometryFunction(float period)
    {
        Amplitude = 1;
        Period = period;
        VerticalShift = 0;
        _phaseShift = 0;
    }
    public TrigonometryFunction(float period,float amplitude)
    {
        Amplitude = amplitude;
        Period = period;
        VerticalShift = 0;
        _phaseShift = 0;
    }

    public TrigonometryFunction(float period,float amplitude,float verticalShift)
    {
        Amplitude = amplitude;
        Period = period;
        VerticalShift = verticalShift;
        _phaseShift = 0;
    }
    public TrigonometryFunction(float period,float amplitude,float verticalShift,float phaseShift)
    {
        Amplitude = amplitude;
        Period = period;
        VerticalShift = verticalShift;
        _phaseShift = phaseShift;
    }
    

    #endregion
    
    #region PublicMethods

    public float GetSin(float x)
    {
        return _amplitude * Mathf.Sin(_period * (x + _phaseShift)) + _verticalShift;
    }
    #endregion

    #region PrivateMethods

    #endregion

  
}
