using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    void Start()
    {
        // Stop menu music if playing, then play game music
        AudioManager.instance.Stop("MenuMusic");
        AudioManager.instance.Play("GameMusic");
    }
}
