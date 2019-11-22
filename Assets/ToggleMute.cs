using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMute : MonoBehaviour
{

    public ToggleOnTouch touch;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        source.mute = !touch.on;
    }
}
