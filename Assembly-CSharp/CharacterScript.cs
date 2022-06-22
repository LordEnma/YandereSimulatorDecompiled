// Decompiled with JetBrains decompiler
// Type: CharacterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CharacterScript : MonoBehaviour
{
  public Transform RightBreast;
  public Transform LeftBreast;
  public Transform ItemParent;
  public Transform PelvisRoot;
  public Transform RightEye;
  public Transform LeftEye;
  public Transform Head;
  public Transform[] Spine;
  public Transform[] Arm;
  public SkinnedMeshRenderer MyRenderer;
  public Renderer RightYandereEye;
  public Renderer LeftYandereEye;

  private void SetAnimations()
  {
    Animation component = this.GetComponent<Animation>();
    component["f02_yanderePose_00"].layer = 1;
    component["f02_yanderePose_00"].weight = 0.0f;
    component.Play("f02_yanderePose_00");
    component["f02_shy_00"].layer = 2;
    component["f02_shy_00"].weight = 0.0f;
    component.Play("f02_shy_00");
    component["f02_fist_00"].layer = 3;
    component["f02_fist_00"].weight = 0.0f;
    component.Play("f02_fist_00");
    component["f02_mopping_00"].layer = 4;
    component["f02_mopping_00"].weight = 0.0f;
    component["f02_mopping_00"].speed = 2f;
    component.Play("f02_mopping_00");
    component["f02_carry_00"].layer = 5;
    component["f02_carry_00"].weight = 0.0f;
    component.Play("f02_carry_00");
    component["f02_mopCarry_00"].layer = 6;
    component["f02_mopCarry_00"].weight = 0.0f;
    component.Play("f02_mopCarry_00");
    component["f02_bucketCarry_00"].layer = 7;
    component["f02_bucketCarry_00"].weight = 0.0f;
    component.Play("f02_bucketCarry_00");
    component["f02_cameraPose_00"].layer = 8;
    component["f02_cameraPose_00"].weight = 0.0f;
    component.Play("f02_cameraPose_00");
    component["f02_dipping_00"].speed = 2f;
    component["f02_cameraPose_00"].weight = 0.0f;
    component["f02_shy_00"].weight = 0.0f;
  }
}
