using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToLoudness : MonoBehaviour
{

  public Vector3 originalScale;
  public AudioSourceLoudnessTester tester;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = originalScale * ( 1 + tester.clipLoudness );
    }
}
