using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioExtension 
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    
    
    #region PublicMethods
    /// <summary>
    /// Plays the audio if not already playing
    /// </summary>
    /// <param name="source">Source Object</param>
    public static void PlayWithLogic(this  AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    
    /// <summary>
    /// Plays the audio while get key true (not playing if already playing)
    /// </summary>
    /// <param name="source">Source Object</param>
    /// <param name="keyCode">Key to get</param>
    public static void PlayOnGetKey(this  AudioSource source,KeyCode keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            PlayWithLogic(source);
        }else{source.Stop();}
    }
    #endregion
    
    #region PrivateMethods
    #endregion
}
