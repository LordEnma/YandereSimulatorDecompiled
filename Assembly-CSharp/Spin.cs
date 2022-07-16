// Decompiled with JetBrains decompiler
// Type: Spin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
  public Vector3 rotationsPerSecond = new Vector3(0.0f, 0.1f, 0.0f);
  public bool ignoreTimeScale;
  private Rigidbody mRb;
  private Transform mTrans;

  private void Start()
  {
    this.mTrans = this.transform;
    this.mRb = this.GetComponent<Rigidbody>();
  }

  private void Update()
  {
    if (!((Object) this.mRb == (Object) null))
      return;
    this.ApplyDelta(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
  }

  private void FixedUpdate()
  {
    if (!((Object) this.mRb != (Object) null))
      return;
    this.ApplyDelta(Time.deltaTime);
  }

  public void ApplyDelta(float delta)
  {
    delta *= 360f;
    Quaternion quaternion = Quaternion.Euler(this.rotationsPerSecond * delta);
    if ((Object) this.mRb == (Object) null)
      this.mTrans.rotation *= quaternion;
    else
      this.mRb.MoveRotation(this.mRb.rotation * quaternion);
  }
}
