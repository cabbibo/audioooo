using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInfo{


    public static Vector2 GetScreenSizeAtDist(float distance){

      Camera cam = Camera.main;
      float h =2.0f * distance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);;
      return new Vector2( h*cam.aspect , h );

    }

}
