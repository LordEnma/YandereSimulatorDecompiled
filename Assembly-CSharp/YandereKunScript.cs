// Decompiled with JetBrains decompiler
// Type: YandereKunScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YandereKunScript : MonoBehaviour
{
  public Transform ChanItemParent;
  public Transform KunItemParent;
  public Transform ChanHips;
  public Transform ChanSpine;
  public Transform ChanSpine1;
  public Transform ChanSpine2;
  public Transform ChanSpine3;
  public Transform ChanNeck;
  public Transform ChanHead;
  public Transform ChanRightUpLeg;
  public Transform ChanRightLeg;
  public Transform ChanRightFoot;
  public Transform ChanRightToes;
  public Transform ChanLeftUpLeg;
  public Transform ChanLeftLeg;
  public Transform ChanLeftFoot;
  public Transform ChanLeftToes;
  public Transform ChanRightShoulder;
  public Transform ChanRightArm;
  public Transform ChanRightArmRoll;
  public Transform ChanRightForeArm;
  public Transform ChanRightForeArmRoll;
  public Transform ChanRightHand;
  public Transform ChanLeftShoulder;
  public Transform ChanLeftArm;
  public Transform ChanLeftArmRoll;
  public Transform ChanLeftForeArm;
  public Transform ChanLeftForeArmRoll;
  public Transform ChanLeftHand;
  public Transform ChanLeftHandPinky1;
  public Transform ChanLeftHandPinky2;
  public Transform ChanLeftHandPinky3;
  public Transform ChanLeftHandRing1;
  public Transform ChanLeftHandRing2;
  public Transform ChanLeftHandRing3;
  public Transform ChanLeftHandMiddle1;
  public Transform ChanLeftHandMiddle2;
  public Transform ChanLeftHandMiddle3;
  public Transform ChanLeftHandIndex1;
  public Transform ChanLeftHandIndex2;
  public Transform ChanLeftHandIndex3;
  public Transform ChanLeftHandThumb1;
  public Transform ChanLeftHandThumb2;
  public Transform ChanLeftHandThumb3;
  public Transform ChanRightHandPinky1;
  public Transform ChanRightHandPinky2;
  public Transform ChanRightHandPinky3;
  public Transform ChanRightHandRing1;
  public Transform ChanRightHandRing2;
  public Transform ChanRightHandRing3;
  public Transform ChanRightHandMiddle1;
  public Transform ChanRightHandMiddle2;
  public Transform ChanRightHandMiddle3;
  public Transform ChanRightHandIndex1;
  public Transform ChanRightHandIndex2;
  public Transform ChanRightHandIndex3;
  public Transform ChanRightHandThumb1;
  public Transform ChanRightHandThumb2;
  public Transform ChanRightHandThumb3;
  public Transform KunHips;
  public Transform KunSpine;
  public Transform KunSpine1;
  public Transform KunSpine2;
  public Transform KunSpine3;
  public Transform KunNeck;
  public Transform KunHead;
  public Transform KunRightUpLeg;
  public Transform KunRightLeg;
  public Transform KunRightFoot;
  public Transform KunRightToes;
  public Transform KunLeftUpLeg;
  public Transform KunLeftLeg;
  public Transform KunLeftFoot;
  public Transform KunLeftToes;
  public Transform KunRightShoulder;
  public Transform KunRightArm;
  public Transform KunRightArmRoll;
  public Transform KunRightForeArm;
  public Transform KunRightForeArmRoll;
  public Transform KunRightHand;
  public Transform KunLeftShoulder;
  public Transform KunLeftArm;
  public Transform KunLeftArmRoll;
  public Transform KunLeftForeArm;
  public Transform KunLeftForeArmRoll;
  public Transform KunLeftHand;
  public Transform KunLeftHandPinky1;
  public Transform KunLeftHandPinky2;
  public Transform KunLeftHandPinky3;
  public Transform KunLeftHandRing1;
  public Transform KunLeftHandRing2;
  public Transform KunLeftHandRing3;
  public Transform KunLeftHandMiddle1;
  public Transform KunLeftHandMiddle2;
  public Transform KunLeftHandMiddle3;
  public Transform KunLeftHandIndex1;
  public Transform KunLeftHandIndex2;
  public Transform KunLeftHandIndex3;
  public Transform KunLeftHandThumb1;
  public Transform KunLeftHandThumb2;
  public Transform KunLeftHandThumb3;
  public Transform KunRightHandPinky1;
  public Transform KunRightHandPinky2;
  public Transform KunRightHandPinky3;
  public Transform KunRightHandRing1;
  public Transform KunRightHandRing2;
  public Transform KunRightHandRing3;
  public Transform KunRightHandMiddle1;
  public Transform KunRightHandMiddle2;
  public Transform KunRightHandMiddle3;
  public Transform KunRightHandIndex1;
  public Transform KunRightHandIndex2;
  public Transform KunRightHandIndex3;
  public Transform KunRightHandThumb1;
  public Transform KunRightHandThumb2;
  public Transform KunRightHandThumb3;
  public SkinnedMeshRenderer MyRenderer;
  public SkinnedMeshRenderer SecondRenderer;
  public SkinnedMeshRenderer ThirdRenderer;
  public bool Kizuna;
  public bool Man;
  public int ID;
  private bool Adjusted;

  private void Start()
  {
    if (!this.Kizuna)
    {
      if ((Object) this.KunHips != (Object) null)
        this.KunHips.parent = this.ChanHips;
      if ((Object) this.KunSpine != (Object) null)
        this.KunSpine.parent = this.ChanSpine;
      if ((Object) this.KunSpine1 != (Object) null)
        this.KunSpine1.parent = this.ChanSpine1;
      if ((Object) this.KunSpine2 != (Object) null)
        this.KunSpine2.parent = this.ChanSpine2;
      if ((Object) this.KunSpine3 != (Object) null)
        this.KunSpine3.parent = this.ChanSpine3;
      if ((Object) this.KunNeck != (Object) null)
        this.KunNeck.parent = this.ChanNeck;
      if ((Object) this.KunHead != (Object) null)
        this.KunHead.parent = this.ChanHead;
      this.KunRightUpLeg.parent = this.ChanRightUpLeg;
      this.KunRightLeg.parent = this.ChanRightLeg;
      this.KunRightFoot.parent = this.ChanRightFoot;
      this.KunRightToes.parent = this.ChanRightToes;
      this.KunLeftUpLeg.parent = this.ChanLeftUpLeg;
      this.KunLeftLeg.parent = this.ChanLeftLeg;
      this.KunLeftFoot.parent = this.ChanLeftFoot;
      this.KunLeftToes.parent = this.ChanLeftToes;
      this.KunRightShoulder.parent = this.ChanRightShoulder;
      this.KunRightArm.parent = this.ChanRightArm;
      if ((Object) this.KunRightArmRoll != (Object) null)
        this.KunRightArmRoll.parent = this.ChanRightArmRoll;
      this.KunRightForeArm.parent = this.ChanRightForeArm;
      if ((Object) this.KunRightForeArmRoll != (Object) null)
        this.KunRightForeArmRoll.parent = this.ChanRightForeArmRoll;
      this.KunRightHand.parent = this.ChanRightHand;
      this.KunLeftShoulder.parent = this.ChanLeftShoulder;
      this.KunLeftArm.parent = this.ChanLeftArm;
      if ((Object) this.KunLeftArmRoll != (Object) null)
        this.KunLeftArmRoll.parent = this.ChanLeftArmRoll;
      this.KunLeftForeArm.parent = this.ChanLeftForeArm;
      if ((Object) this.KunLeftForeArmRoll != (Object) null)
        this.KunLeftForeArmRoll.parent = this.ChanLeftForeArmRoll;
      this.KunLeftHand.parent = this.ChanLeftHand;
      if (!this.Man)
      {
        this.KunLeftHandPinky1.parent = this.ChanLeftHandPinky1;
        this.KunLeftHandPinky2.parent = this.ChanLeftHandPinky2;
        this.KunLeftHandPinky3.parent = this.ChanLeftHandPinky3;
        this.KunLeftHandRing1.parent = this.ChanLeftHandRing1;
        this.KunLeftHandRing2.parent = this.ChanLeftHandRing2;
        this.KunLeftHandRing3.parent = this.ChanLeftHandRing3;
        this.KunLeftHandMiddle1.parent = this.ChanLeftHandMiddle1;
        this.KunLeftHandMiddle2.parent = this.ChanLeftHandMiddle2;
        this.KunLeftHandMiddle3.parent = this.ChanLeftHandMiddle3;
        this.KunLeftHandIndex1.parent = this.ChanLeftHandIndex1;
        this.KunLeftHandIndex2.parent = this.ChanLeftHandIndex2;
        this.KunLeftHandIndex3.parent = this.ChanLeftHandIndex3;
        this.KunLeftHandThumb1.parent = this.ChanLeftHandThumb1;
        this.KunLeftHandThumb2.parent = this.ChanLeftHandThumb2;
        this.KunLeftHandThumb3.parent = this.ChanLeftHandThumb3;
        this.KunRightHandPinky1.parent = this.ChanRightHandPinky1;
        this.KunRightHandPinky2.parent = this.ChanRightHandPinky2;
        this.KunRightHandPinky3.parent = this.ChanRightHandPinky3;
        this.KunRightHandRing1.parent = this.ChanRightHandRing1;
        this.KunRightHandRing2.parent = this.ChanRightHandRing2;
        this.KunRightHandRing3.parent = this.ChanRightHandRing3;
        this.KunRightHandMiddle1.parent = this.ChanRightHandMiddle1;
        this.KunRightHandMiddle2.parent = this.ChanRightHandMiddle2;
        this.KunRightHandMiddle3.parent = this.ChanRightHandMiddle3;
        this.KunRightHandIndex1.parent = this.ChanRightHandIndex1;
        this.KunRightHandIndex2.parent = this.ChanRightHandIndex2;
        this.KunRightHandIndex3.parent = this.ChanRightHandIndex3;
        this.KunRightHandThumb1.parent = this.ChanRightHandThumb1;
        this.KunRightHandThumb2.parent = this.ChanRightHandThumb2;
        this.KunRightHandThumb3.parent = this.ChanRightHandThumb3;
      }
    }
    if ((Object) this.MyRenderer != (Object) null)
      this.MyRenderer.enabled = true;
    if ((Object) this.SecondRenderer != (Object) null)
      this.SecondRenderer.enabled = true;
    if ((Object) this.ThirdRenderer != (Object) null)
      this.ThirdRenderer.enabled = true;
    this.gameObject.SetActive(false);
  }

  private void LateUpdate()
  {
    if (this.Man)
    {
      this.ChanItemParent.position = this.KunItemParent.position;
      if (!this.Adjusted)
      {
        this.KunRightShoulder.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunRightArm.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunRightForeArm.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunRightHand.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunLeftShoulder.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunLeftArm.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunLeftForeArm.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.KunLeftHand.position += new Vector3(0.0f, 0.1f, 0.0f);
        this.Adjusted = true;
      }
    }
    if (!this.Kizuna)
      return;
    this.KunItemParent.localPosition = new Vector3(0.066666f, -0.033333f, 0.02f);
    this.ChanItemParent.position = this.KunItemParent.position;
    this.KunHips.localPosition = this.ChanHips.localPosition;
    if ((Object) this.KunHips != (Object) null)
      this.KunHips.eulerAngles = this.ChanHips.eulerAngles;
    if ((Object) this.KunSpine != (Object) null)
      this.KunSpine.eulerAngles = this.ChanSpine.eulerAngles;
    if ((Object) this.KunSpine1 != (Object) null)
      this.KunSpine1.eulerAngles = this.ChanSpine1.eulerAngles;
    if ((Object) this.KunSpine2 != (Object) null)
      this.KunSpine2.eulerAngles = this.ChanSpine2.eulerAngles;
    if ((Object) this.KunSpine3 != (Object) null)
      this.KunSpine3.eulerAngles = this.ChanSpine3.eulerAngles;
    if ((Object) this.KunNeck != (Object) null)
      this.KunNeck.eulerAngles = this.ChanNeck.eulerAngles;
    if ((Object) this.KunHead != (Object) null)
      this.KunHead.eulerAngles = this.ChanHead.eulerAngles;
    this.KunRightUpLeg.eulerAngles = this.ChanRightUpLeg.eulerAngles;
    this.KunRightLeg.eulerAngles = this.ChanRightLeg.eulerAngles;
    this.KunRightFoot.eulerAngles = this.ChanRightFoot.eulerAngles;
    this.KunRightToes.eulerAngles = this.ChanRightToes.eulerAngles;
    this.KunLeftUpLeg.eulerAngles = this.ChanLeftUpLeg.eulerAngles;
    this.KunLeftLeg.eulerAngles = this.ChanLeftLeg.eulerAngles;
    this.KunLeftFoot.eulerAngles = this.ChanLeftFoot.eulerAngles;
    this.KunLeftToes.eulerAngles = this.ChanLeftToes.eulerAngles;
    this.KunRightShoulder.eulerAngles = this.ChanRightShoulder.eulerAngles;
    this.KunRightArm.eulerAngles = this.ChanRightArm.eulerAngles;
    if ((Object) this.KunLeftArmRoll != (Object) null)
      this.KunRightArmRoll.eulerAngles = this.ChanRightArmRoll.eulerAngles;
    this.KunRightForeArm.eulerAngles = this.ChanRightForeArm.eulerAngles;
    if ((Object) this.KunLeftArmRoll != (Object) null)
      this.KunRightForeArmRoll.eulerAngles = this.ChanRightForeArmRoll.eulerAngles;
    this.KunRightHand.eulerAngles = this.ChanRightHand.eulerAngles;
    this.KunLeftShoulder.eulerAngles = this.ChanLeftShoulder.eulerAngles;
    this.KunLeftArm.eulerAngles = this.ChanLeftArm.eulerAngles;
    if ((Object) this.KunLeftArmRoll != (Object) null)
      this.KunLeftArmRoll.eulerAngles = this.ChanLeftArmRoll.eulerAngles;
    this.KunLeftForeArm.eulerAngles = this.ChanLeftForeArm.eulerAngles;
    if ((Object) this.KunLeftForeArmRoll != (Object) null)
      this.KunLeftForeArmRoll.eulerAngles = this.ChanLeftForeArmRoll.eulerAngles;
    this.KunLeftHand.eulerAngles = this.ChanLeftHand.eulerAngles;
    this.KunLeftHandPinky1.eulerAngles = this.ChanLeftHandPinky1.eulerAngles;
    this.KunLeftHandPinky2.eulerAngles = this.ChanLeftHandPinky2.eulerAngles;
    this.KunLeftHandPinky3.eulerAngles = this.ChanLeftHandPinky3.eulerAngles;
    this.KunLeftHandRing1.eulerAngles = this.ChanLeftHandRing1.eulerAngles;
    this.KunLeftHandRing2.eulerAngles = this.ChanLeftHandRing2.eulerAngles;
    this.KunLeftHandRing3.eulerAngles = this.ChanLeftHandRing3.eulerAngles;
    this.KunLeftHandMiddle1.eulerAngles = this.ChanLeftHandMiddle1.eulerAngles;
    this.KunLeftHandMiddle2.eulerAngles = this.ChanLeftHandMiddle2.eulerAngles;
    this.KunLeftHandMiddle3.eulerAngles = this.ChanLeftHandMiddle3.eulerAngles;
    this.KunLeftHandIndex1.eulerAngles = this.ChanLeftHandIndex1.eulerAngles;
    this.KunLeftHandIndex2.eulerAngles = this.ChanLeftHandIndex2.eulerAngles;
    this.KunLeftHandIndex3.eulerAngles = this.ChanLeftHandIndex3.eulerAngles;
    this.KunLeftHandThumb1.eulerAngles = this.ChanLeftHandThumb1.eulerAngles;
    this.KunLeftHandThumb2.eulerAngles = this.ChanLeftHandThumb2.eulerAngles;
    this.KunLeftHandThumb3.eulerAngles = this.ChanLeftHandThumb3.eulerAngles;
    this.KunRightHandPinky1.eulerAngles = this.ChanRightHandPinky1.eulerAngles;
    this.KunRightHandPinky2.eulerAngles = this.ChanRightHandPinky2.eulerAngles;
    this.KunRightHandPinky3.eulerAngles = this.ChanRightHandPinky3.eulerAngles;
    this.KunRightHandRing1.eulerAngles = this.ChanRightHandRing1.eulerAngles;
    this.KunRightHandRing2.eulerAngles = this.ChanRightHandRing2.eulerAngles;
    this.KunRightHandRing3.eulerAngles = this.ChanRightHandRing3.eulerAngles;
    this.KunRightHandMiddle1.eulerAngles = this.ChanRightHandMiddle1.eulerAngles;
    this.KunRightHandMiddle2.eulerAngles = this.ChanRightHandMiddle2.eulerAngles;
    this.KunRightHandMiddle3.eulerAngles = this.ChanRightHandMiddle3.eulerAngles;
    this.KunRightHandIndex1.eulerAngles = this.ChanRightHandIndex1.eulerAngles;
    this.KunRightHandIndex2.eulerAngles = this.ChanRightHandIndex2.eulerAngles;
    this.KunRightHandIndex3.eulerAngles = this.ChanRightHandIndex3.eulerAngles;
    this.KunRightHandThumb1.eulerAngles = this.ChanRightHandThumb1.eulerAngles;
    this.KunRightHandThumb2.eulerAngles = this.ChanRightHandThumb2.eulerAngles;
    this.KunRightHandThumb3.eulerAngles = this.ChanRightHandThumb3.eulerAngles;
    if (!Input.GetKeyDown(KeyCode.Space))
      return;
    if (this.ID > -1)
    {
      for (int index = 0; index < 32; ++index)
        this.SecondRenderer.SetBlendShapeWeight(index, 0.0f);
      if (this.ID > 32)
        this.ID = 0;
      this.SecondRenderer.SetBlendShapeWeight(this.ID, 100f);
    }
    ++this.ID;
  }
}
