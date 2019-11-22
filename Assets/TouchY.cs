using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchY : MonoBehaviour
{
    public TouchToRay touch;


  public float y;
  private BoxCollider bc;
  void Start(){
    bc = GetComponent<BoxCollider>();
  }

  public void Touch( Ray r ){
    if(touch.currentHitName == gameObject.name && touch.downHitName == gameObject.name){

      Vector3 local = transform.InverseTransformPoint(touch.currentHitLocation);
      print(local.z/GetComponent<BoxCollider>().size.z);
      y = (local.z/bc.size.z) + .5f;//((local.z/bc.size.z) + 1) /2;
      y = local.z;
    }
  }
}
