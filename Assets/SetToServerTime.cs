using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMMATERIA {
public class SetToServerTime : Cycle
{

  public Animator animator;
  public string clipName;
  public float speedMultiplier;

  public float oT;
  public float delta;
  private int animationID;
  public override void Create(){
    if( animator == null ){ animator = GetComponent<Animator>();}
    animationID = Animator.StringToHash(clipName);
  }

  public override void OnBirthed(){
    animator.StopPlayback();
    animator.Play(animationID, 0, 0.0f);
    oT = data.SERVER_TIME;
  }

  public override void WhileLiving(float v){
    delta = data.SERVER_TIME - oT;
    //animator.Update(delta);
    animator.Update(delta);

    animator.SetFloat("Time",data.SERVER_TIME * speedMultiplier);
    oT = data.SERVER_TIME;
  }
}
}