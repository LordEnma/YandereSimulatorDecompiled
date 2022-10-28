// Decompiled with JetBrains decompiler
// Type: TweenRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Rotation")]
public class TweenRotation : UITweener
{
  public Vector3 from;
  public Vector3 to;
  public bool quaternionLerp;
  private Transform mTrans;

  public Transform cachedTransform
  {
    get
    {
      if ((UnityEngine.Object) this.mTrans == (UnityEngine.Object) null)
        this.mTrans = this.transform;
      return this.mTrans;
    }
  }

  [Obsolete("Use 'value' instead")]
  public Quaternion rotation
  {
    get => this.value;
    set => this.value = value;
  }

  public Quaternion value
  {
    get => this.cachedTransform.localRotation;
    set => this.cachedTransform.localRotation = value;
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.value = this.quaternionLerp ? Quaternion.Slerp(Quaternion.Euler(this.from), Quaternion.Euler(this.to), factor) : Quaternion.Euler(new Vector3(Mathf.Lerp(this.from.x, this.to.x, factor), Mathf.Lerp(this.from.y, this.to.y, factor), Mathf.Lerp(this.from.z, this.to.z, factor)));

  public static TweenRotation Begin(GameObject go, float duration, Quaternion rot)
  {
    TweenRotation tweenRotation = UITweener.Begin<TweenRotation>(go, duration);
    tweenRotation.from = tweenRotation.value.eulerAngles;
    tweenRotation.to = rot.eulerAngles;
    if ((double) duration <= 0.0)
    {
      tweenRotation.Sample(1f, true);
      tweenRotation.enabled = false;
    }
    return tweenRotation;
  }

  [ContextMenu("Set 'From' to current value")]
  public override void SetStartToCurrentValue() => this.from = this.value.eulerAngles;

  [ContextMenu("Set 'To' to current value")]
  public override void SetEndToCurrentValue() => this.to = this.value.eulerAngles;

  [ContextMenu("Assume value of 'From'")]
  private void SetCurrentValueToStart() => this.value = Quaternion.Euler(this.from);

  [ContextMenu("Assume value of 'To'")]
  private void SetCurrentValueToEnd() => this.value = Quaternion.Euler(this.to);
}
