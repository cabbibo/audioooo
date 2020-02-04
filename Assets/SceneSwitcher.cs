﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IMMATERIA;

  [ExecuteAlways]
public class SceneSwitcher : MonoBehaviour
{

  public Scene[] scenes;
  public int currScene;
  public int oldScene;
  public bool switching;
  public Vector3 targetPosition;
  public Quaternion targetRotation;
  public Vector3 startPosition;
  public Quaternion startRotation;
  public float switchSpeed;
  public float switchTime;

  public Menu menu;


  public void SwitchScene( int scene ){

      for(int i =0; i < scenes.Length; i++ ){
        if( i != currScene && i != scene){
          scenes[i].gameObject.SetActive( false);
          scenes[i].active = false;
        }
      }
    oldScene = currScene;
    currScene = scene;

    scenes[currScene].gameObject.SetActive( true );
    scenes[currScene].active = true;
    switchTime = Time.time;
    switching = true;

    startPosition = Camera.main.transform.position;
    startRotation = Camera.main.transform.rotation;
    targetPosition = scenes[currScene].view.position;
    targetRotation = scenes[currScene].view.rotation;

  }

  public void Update(){
    if( switching == true ){
      float v = (Time.time - switchTime)/switchSpeed;
      if( v > 1 ){
        switching = false;
        Camera.main.transform.position = targetPosition;
        Camera.main.transform.rotation = targetRotation;
        OnNewScene();
      }else{
        Camera.main.transform.position = Vector3.Lerp( startPosition , targetPosition , v );
        Camera.main.transform.rotation = Quaternion.Slerp( startRotation , targetRotation , v);
      }
    }
  }

  public void OnNewScene(){
    if( currScene != oldScene ){
      scenes[oldScene].gameObject.SetActive(false );

    scenes[oldScene].active = false;
    }
  }

}