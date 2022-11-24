// Decompiled with JetBrains decompiler
// Type: EyeTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
