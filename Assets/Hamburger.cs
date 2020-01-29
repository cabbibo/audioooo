using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    public Menu menu;
    void OnMouseDown(){
      menu.Toggle();
    }
}
