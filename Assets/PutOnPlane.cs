using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnPlane : MonoBehaviour
{

  public TouchToRay touchInfo;
  public Transform plane;
  public Collider c; 
  public float forwardDist;

  public void RandomLocation(){
    Vector3 pos = new Vector3( Random.Range( -.499f , .499f) , Random.Range( -.499f , .499f) , 0 );
    transform.position = plane.TransformPoint( pos )- plane.forward * forwardDist;
  }

  void OnEnable(){
    touchInfo.WhileDown.AddListener( Touch );
  }

  void OnDisable(){
    touchInfo.WhileDown.AddListener( Touch );
  }

  public bool touchDown;
  public float lastTouchTime;
  public void Touch( Ray r){
    print( touchInfo.currentHitName );
    print( this.gameObject.name );
    if( touchInfo.currentHitName == plane.gameObject.name && touchInfo.vel.magnitude > 2 ){
      print("TOCUHGIN");
      touchDown = true;
      transform.position = touchInfo.currentHitLocation - plane.forward * forwardDist;
    }
  }
  public void Update(){
    if( touchInfo.Down == 0 || touchInfo.vel.magnitude < 2 ){
      touchDown = false;
    }

    if( touchDown == false ){
      if( Time.time - lastTouchTime > .8f ){
        RandomLocation();
        lastTouchTime = Time.time;
      }
    }
  }
}
