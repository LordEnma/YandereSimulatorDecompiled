// Decompiled with JetBrains decompiler
// Type: EyeShapeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class EyeShapeScript : MonoBehaviour
{
  public Transform eyelid_und1_Left;
  public Transform eyelid_und1_Right;
  public Transform eyelid_und2_Left;
  public Transform eyelid_und2_Right;
  public Transform eyelid_und_Left;
  public Transform eyelid_und_Right;
  public Transform eyerid1_Left;
  public Transform eyerid1_Right;
  public Transform eyerid2_Left;
  public Transform eyerid2_Right;
  public Transform eyerid_Left;
  public Transform eyerid_Right;
  public Transform inner_corner_of_eye_Left;
  public Transform inner_corner_of_eye_Reft;
  public Transform tail_of_eye_Left;
  public Transform tail_of_eye_Right;
  public float PosOffsetX;
  public float PosOffsetY;
  public float PosOffsetZ;
  public float RotOffsetX;
  public float RotOffsetY;
  public float RotOffsetZ;

  private void Start()
  {
    this.PosOffsetX = Random.Range(-1f / 500f, 1f / 500f);
    this.PosOffsetY = Random.Range(-1f / 500f, 1f / 500f);
    this.PosOffsetZ = Random.Range(-1f / 500f, 1f / 500f);
    this.RotOffsetX = Random.Range(-15f, 15f);
    this.RotOffsetY = Random.Range(-15f, 15f);
    this.RotOffsetZ = Random.Range(-15f, 15f);
  }

  private void LateUpdate()
  {
    this.eyelid_und1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyelid_und1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyelid_und2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyelid_und2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyelid_und_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyelid_und_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyerid1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyerid1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyerid2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyerid2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyerid_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.eyerid_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.inner_corner_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.inner_corner_of_eye_Reft.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.tail_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
    this.tail_of_eye_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
    this.eyelid_und1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyelid_und1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyelid_und2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyelid_und2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyelid_und_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyelid_und_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyerid1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyerid1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyerid2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyerid2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.eyerid_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.eyerid_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.inner_corner_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.inner_corner_of_eye_Reft.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
    this.tail_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
    this.tail_of_eye_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
  }
}
