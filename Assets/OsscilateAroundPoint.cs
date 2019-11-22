using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsscilateAroundPoint : MonoBehaviour
{

    public float radius;
    public float speed;
    public float angle;

    public Transform target;


    public void LateUpdate(){

      angle += speed;
      Vector3 v = new Vector3( Mathf.Cos(angle) , 0 , -Mathf.Sin(angle));
      transform.position = target.position + v*radius;

    }
}
