using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace IMMATERIA {
public class BindTransform : Binder
{

    public Matrix4x4 transformMatrix;
    public override void Bind(){
      toBind.BindMatrix("_Transform", () => transform.localToWorldMatrix);
    }

  }
}