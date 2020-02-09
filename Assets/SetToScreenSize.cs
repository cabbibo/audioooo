using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToScreenSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 size = ScreenInfo.GetScreenSizeAtDist( (transform.position - Camera.main.transform.position).magnitude);
        transform.localScale = new Vector3( size.x , size.y , 1 ) * 1;
    }
}
