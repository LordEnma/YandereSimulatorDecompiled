// Decompiled with JetBrains decompiler
// Type: EyeTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EyeTestScript : MonoBehaviour
{
  public Animation MyAnimation;

  private void Start()
  {
    this.MyAnimation["moodyEyes_00"].layer = 1;
    this.MyAnimation.Play("moodyEyes_00");
    this.MyAnimation["moodyEyes_00"].weight = 1f;
    this.MyAnimation.Play("moodyEyes_00");
  }
}
