using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemClick : MonoBehaviour
{

  public SceneSwitcher switcher;
  public int which;
  public Menu menu;

  public void OnMouseDown(){
    switcher.SwitchScene( which );
    menu.Toggle();
  }

}
