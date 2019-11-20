﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace IMMATERIA {
public class God : Cycle {

public bool AllInEditMode;
private static God _instance;
  
public bool started;

public bool godPause;

public List<Form> forms;
public List<Life> lifes;
public List<Binder> binders;

public override void Create(){

    if( forms == null ){ 
        forms = new List<Form>(); 
    }

    if( lifes == null ){ 
        lifes = new List<Life>(); 
    }

    if( binders == null ){ 
        binders = new List<Binder>(); 
    }

    lifes.Clear();
    forms.Clear();
    binders.Clear();





    if( data != null ){
        SafePrepend(data);
    }else{
        print("DUDE WHERE'S MY DATA");
    }

   //Application.targetFrameRate = 60;


}

public override void OnBirthed(){
    GetCycleInfo( this );
}

public void GetCycleInfo( Cycle cycle ){
    
    if( cycle is Form ){
        forms.Add( (Form)cycle );
    }
    if( cycle is Life ){
        lifes.Add( (Life)cycle );
    }

    if( cycle is Binder ){
        binders.Add( (Binder)cycle );
    }

    foreach( Cycle c in cycle.Cycles ){
        GetCycleInfo( c );
    }

}

public void SaveAllForms(){
    foreach( Form f  in forms ){

     if( Saveable.Check(f.saveName)){
        Saveable.Delete(f.saveName);
     }

        f.saveName = Saveable.GetSafeName();
        Saveable.Save(f);
        
    }
}



public void LateUpdate(){

    if( started == false ){ 
        _OnLive(); 
        started = true;
    }
    
    if( birthing ){ _WhileBirthing(1);}
    if( living ){ _WhileLiving(1); }
    if( dying ){ _WhileDying(1); }

    if( created ){ _WhileDebug(); }

}




public void OnEnable(){




    started = false;


    if( _instance == null ){ _instance = this; }

    #if UNITY_EDITOR 
        EditorApplication.update += Always;

         Reset();
        _Destroy(); 
        _Create(); 
        _OnGestate();
        _OnGestated();
        _OnBirth(); 
        _OnBirthed();

    #else

    

    print("god enambles");


    if( Application.isPlaying ){
    
        Reset();
        _Destroy(); 
        _Create(); 
        _OnGestate();
        _OnGestated();
        _OnBirth(); 
        _OnBirthed();

    }

    #endif


}



public void OnDisable(){


    //print("god disabblee");
    #if UNITY_EDITOR 
        EditorApplication.update -= Always;
        _Destroy();   

    #else
     
    if( Application.isPlaying ){
        _Destroy();   
    }
    #endif
}


 
void Always(){    
  #if UNITY_EDITOR 
  if( AllInEditMode ){
    if(!godPause) EditorApplication.QueuePlayerLoopUpdate();
  }
  #endif
}





public void Rebuild(){
    Reset();
    OnDisable();
    OnEnable();
}



}
}