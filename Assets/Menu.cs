using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool on;

    public void Toggle(){
      print("togl");
      on = !on;
      if( !on ){
        gameObject.SetActive( false );
      }else{
        gameObject.SetActive( true );
      }
    }
}
