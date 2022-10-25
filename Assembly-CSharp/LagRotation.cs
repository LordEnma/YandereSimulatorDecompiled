// Decompiled with JetBrains decompiler
// Type: LagRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
  public float speed = 10f;
  public bool ignoreTimeScale;
  private Transform mTrans;
  private Quaternion mRelative;
  private Quaternion mAbsolute;

  public void OnRepositionEnd() => this.Interpolate(1000f);

  private void Interpolate(float delta)
  {
    if (!((Object) this.mTrans != (Object) null))
      return;
    Transform parent = this.mTrans.parent;
    if (!((Object) parent != (Object) null))
      return;
    this.mAbsolute = Quaternion.Slerp(this.mAbsolute, parent.rotation * this.mRelative, delta * this.speed);
    this.mTrans.rotation = this.mAbsolute;
  }

  private void Start()
  {
    this.mTrans = this.transform;
    this.mRelative = this.mTrans.localRotation;
    this.mAbsolute = this.mTrans.rotation;
  }

  private void Update() => this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
}
