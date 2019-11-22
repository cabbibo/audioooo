using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      float[] spectrum = new float[2084];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        
    }
}
