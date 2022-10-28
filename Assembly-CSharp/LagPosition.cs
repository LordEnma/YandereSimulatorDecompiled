// Decompiled with JetBrains decompiler
// Type: LagPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LagPosition : MonoBehaviour
{
  public Vector3 speed = new Vector3(10f, 10f, 10f);
  public bool ignoreTimeScale;
  private Transform mTrans;
  private Vector3 mRelative;
  private Vector3 mAbsolute;
  private bool mStarted;

  public void OnRepositionEnd() => this.Interpolate(1000f);

  private void Interpolate(float delta)
  {
    Transform parent = this.mTrans.parent;
    if (!((Object) parent != (Object) null))
      return;
    Vector3 vector3 = parent.position + parent.rotation * this.mRelative;
    this.mAbsolute.x = Mathf.Lerp(this.mAbsolute.x, vector3.x, Mathf.Clamp01(delta * this.speed.x));
    this.mAbsolute.y = Mathf.Lerp(this.mAbsolute.y, vector3.y, Mathf.Clamp01(delta * this.speed.y));
    this.mAbsolute.z = Mathf.Lerp(this.mAbsolute.z, vector3.z, Mathf.Clamp01(delta * this.speed.z));
    this.mTrans.position = this.mAbsolute;
  }

  private void Awake() => this.mTrans = this.transform;

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.ResetPosition();
  }

  private void Start()
  {
    this.mStarted = true;
    this.ResetPosition();
  }

  public void ResetPosition()
  {
    this.mAbsolute = this.mTrans.position;
    this.mRelative = this.mTrans.localPosition;
  }

  private void Update() => this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
}
