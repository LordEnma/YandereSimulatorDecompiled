// Decompiled with JetBrains decompiler
// Type: SimpleLookScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SimpleLookScript : MonoBehaviour
{
  public StudentScript Student;
  public PerfectLookAt HeadLookAt;
  public PerfectLookAt NeckLookAt;
  public PerfectLookAt SpineLookAt;
  public Transform EyeL;
  public Transform EyeR;
  public Transform Head;
  public Transform Neck;
  public Transform Spine;
  public Transform YandereHead;
  public Transform MyHead;
  public Transform Forward;
  public Transform LookTarget;
  public Transform Yandere;
  public float PreviousEye;
  public float PreviousHead;
  public float PreviousNeck;
  public float PreviousSpine;
  public float Rotation;
  public float IgnoreTimer;
  public float LookTimer;
  public float Speed;
  public float Timer;
  public bool Ignore;
  public bool Look;

  private void Start()
  {
    this.LookTarget.parent = this.transform.parent;
    this.HeadLookAt.enabled = false;
    this.NeckLookAt.enabled = false;
    this.SpineLookAt.enabled = false;
    this.Yandere = this.Student.Yandere.transform;
    this.YandereHead = this.Student.Yandere.Head;
  }

  private void LateUpdate()
  {
    if (this.Student.Routine)
    {
      if ((double) this.Student.DistanceToPlayer < 2.0 || this.Look)
      {
        if ((double) Mathf.Abs(Vector3.Angle(-this.transform.forward, this.Yandere.transform.position - this.transform.position)) >= 90.0 && (double) this.Student.DistanceToPlayer < 2.0 && !this.Ignore)
        {
          this.LookTimer += Time.deltaTime;
          if ((double) this.LookTimer > 5.0)
          {
            this.LookTimer = 0.0f;
            this.Ignore = true;
          }
          this.Look = true;
          this.Timer = 0.0f;
        }
        else
        {
          if (this.Ignore)
          {
            this.IgnoreTimer += Time.deltaTime;
            if ((double) this.IgnoreTimer > 5.0)
            {
              this.IgnoreTimer = 0.0f;
              this.Ignore = false;
            }
          }
          if (this.Look)
          {
            this.Timer += Time.deltaTime;
            if ((double) this.Timer > 2.0)
            {
              this.Look = false;
              this.Timer = 0.0f;
            }
          }
        }
      }
    }
    else
      this.Look = false;
    if (this.Look)
    {
      double f = (double) Vector3.Angle(this.transform.forward, this.Yandere.transform.position - this.transform.position);
      Vector3 vector3 = this.YandereHead.transform.position - this.MyHead.transform.position;
      float num = Vector3.Angle(this.transform.right, new Vector3(vector3.x, 0.0f, vector3.z));
      this.Rotation = (double) Mathf.Abs((float) f) > 90.0 || (double) this.Student.DistanceToPlayer >= 2.0 || this.Ignore ? Mathf.Lerp(this.Rotation, 0.0f, (float) ((double) Time.deltaTime * 3.5999999046325684 * 0.5)) : ((double) num > 90.0 ? Mathf.Lerp(this.Rotation, -10f * (float) ((90.0 - (180.0 - (double) num)) / 90.0), Time.deltaTime * 3.6f) : Mathf.Lerp(this.Rotation, 10f * (float) ((90.0 - (double) num) / 90.0), Time.deltaTime * 3.6f));
      if ((double) this.EyeL.localEulerAngles.y != (double) this.PreviousEye)
      {
        this.EyeL.localEulerAngles += new Vector3(0.0f, this.Rotation, 0.0f);
        this.EyeR.localEulerAngles += new Vector3(0.0f, this.Rotation, 0.0f);
      }
      if ((double) this.Head.localEulerAngles.y != (double) this.PreviousHead)
        this.Head.localEulerAngles += new Vector3(0.0f, this.Rotation * 2f, 0.0f);
      if ((double) this.Neck.localEulerAngles.y != (double) this.PreviousNeck)
        this.Neck.localEulerAngles += new Vector3(0.0f, this.Rotation * 1.5f, 0.0f);
      if ((double) this.Spine.localEulerAngles.y != (double) this.PreviousSpine)
        this.Spine.localEulerAngles += new Vector3(0.0f, this.Rotation * 1f, 0.0f);
      this.PreviousEye = this.EyeL.localEulerAngles.y;
      this.PreviousHead = this.Head.localEulerAngles.y;
      this.PreviousNeck = this.Neck.localEulerAngles.y;
      this.PreviousSpine = this.Spine.localEulerAngles.y;
    }
    if (this.Student.Alive)
      return;
    this.enabled = false;
  }
}
