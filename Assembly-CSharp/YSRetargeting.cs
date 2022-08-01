// Decompiled with JetBrains decompiler
// Type: YSRetargeting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class YSRetargeting : MonoBehaviour
{
  public GameObject Source;
  public GameObject Target;
  private Component[] SourceSkelNodes;
  private Component[] TargetSkelNodes;
  private Component[] SourceBones;
  private Component[] TargetBones;

  private void Start()
  {
    this.SourceBones = new Component[160];
    this.TargetBones = new Component[160];
    this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
    this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
    string[] strArray = new string[150]
    {
      "PelvisRoot",
      "Hips",
      "LeftUpLeg",
      "LeftLeg",
      "LeftFoot",
      "LeftToes",
      "LeftToesNull",
      "LeftLeg_Helper",
      "LeftHip_Helper",
      "RightUpLeg",
      "RightLeg",
      "RightFoot",
      "RightToes",
      "RightToesNull",
      "RightLeg_Helper",
      "RightHip_Helper",
      "Front_skart1",
      "Front_skart2",
      "Front_skart3",
      "Left_skart1",
      "Left_skart2",
      "Left_skart3",
      "Back_skart1",
      "Back_skart2",
      "Back_skart3",
      "Right_skart1",
      "Right_skart2",
      "Right_skart3",
      "Spine",
      "Spine1",
      "Spine2",
      "Spine3",
      "Neck",
      "Head",
      "Head_null",
      "FrontHair",
      "BackHair1",
      "BackHair2",
      "BackHair3",
      "BackHair4",
      "LeftHair1",
      "LeftHair2",
      "LeftHair3",
      "RightHair1",
      "RightHair2",
      "RightHair3",
      "face",
      "atama_n",
      "mayu",
      "eyebrow_a_Left",
      "eyebrow_b_Left",
      "temple_Left",
      "eyebrow_a_Right",
      "eyebrow_b_Right",
      "temple_Right",
      "eyerid_Left",
      "eye_Left",
      "eyelid_und_Left",
      "cheek_Left",
      "u_lip_center",
      "lip_top_Left",
      "lip_top_Right",
      "jaw",
      "chin",
      "b_lip_center",
      "rip_btm_Left",
      "lip_u_Left",
      "rip_btm_Right",
      "lip_u_Right",
      "nose",
      "nostrir_Right",
      "nostrir_Left",
      "inner_corner_of_eye_Left",
      "tail_of_eye_Left",
      "lip_Left",
      "lip_t_Left",
      "lip_Right",
      "lip_t_Right",
      "eyerid1_Left",
      "eyerid2_Left",
      "eyelid_und1_Left",
      "eyelid_und2_Left",
      "eyerid_Right",
      "eyerid1_Right",
      "eyerid2_Right",
      "tail_of_eye_Right",
      "eyelid_und2_Right",
      "eyelid_und_Right",
      "cheek_Right",
      "eyelid_und1_Right",
      "eye_Right",
      "inner_corner_of_eye_Right",
      "LeftShoulder",
      "LeftArm",
      "LeftArmRoll",
      "LeftForeArm",
      "LeftForeArmRoll",
      "LeftHand",
      "LeftHandThumb1",
      "LeftHandThumb2",
      "LeftHandThumb3",
      "LeftHandThumbNull",
      "LeftHandIndex1",
      "LeftHandIndex2",
      "LeftHandIndex3",
      "LeftHandIndexNull",
      "LeftHandMiddle1",
      "LeftHandMiddle2",
      "LeftHandMiddle3",
      "LeftHandMiddleNull",
      "LeftHandRing1",
      "LeftHandRing2",
      "LeftHandRing3",
      "LeftHandRingNull",
      "LeftHandPinky1",
      "LeftHandPinky2",
      "LeftHandPinky3",
      "LeftHandPinkyNull",
      "LeftForeArm_Helper",
      "RightShoulder",
      "RightArm",
      "RightArmRoll",
      "RightForeArm",
      "RightForeArmRoll",
      "RightHand",
      "RightHandThumb1",
      "RightHandThumb2",
      "RightHandThumb3",
      "RightHandThumbNull",
      "RightHandIndex1",
      "RightHandIndex2",
      "RightHandIndex3",
      "RightHandIndexNull",
      "RightHandMiddle1",
      "RightHandMiddle2",
      "RightHandMiddle3",
      "RightHandMiddleNull",
      "RightHandRing1",
      "RightHandRing2",
      "RightHandRing3",
      "RightHandRingNull",
      "RightHandPinky1",
      "RightHandPinky2",
      "RightHandPinky3",
      "RightHandPinkyNull",
      "RightForeArm_Helper",
      "LeftBreast",
      "LeftNipple",
      "RightBreast",
      "RightNipple"
    };
    List<string> stringList = new List<string>();
    foreach (string str in strArray)
      stringList.Add(str);
    int index1 = 0;
    for (int index2 = 0; index2 < this.SourceSkelNodes.Length; ++index2)
    {
      if (stringList.Contains(this.SourceSkelNodes[index2].name))
      {
        this.SourceBones[index1] = this.SourceSkelNodes[index2];
        ++index1;
      }
    }
    int index3 = 0;
    for (int index4 = 0; index4 < this.TargetSkelNodes.Length; ++index4)
    {
      if (stringList.Contains(this.TargetSkelNodes[index4].name))
      {
        this.TargetBones[index3] = this.TargetSkelNodes[index4];
        ++index3;
      }
    }
  }

  private void Update()
  {
  }

  private void LateUpdate()
  {
    for (int index = 0; index < this.TargetBones.Length; ++index)
    {
      if ((bool) (Object) this.TargetBones[index])
      {
        this.TargetBones[index].transform.localPosition = this.SourceBones[index].transform.localPosition;
        this.TargetBones[index].transform.localRotation = this.SourceBones[index].transform.localRotation;
      }
    }
  }
}
