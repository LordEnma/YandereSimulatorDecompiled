// Decompiled with JetBrains decompiler
// Type: EyeTestScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
