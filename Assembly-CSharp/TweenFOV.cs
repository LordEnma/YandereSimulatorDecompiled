// Decompiled with JetBrains decompiler
// Type: TweenFOV
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("NGUI/Tween/Tween Field of View")]
public class TweenFOV : UITweener
{
  public float from = 45f;
  public float to = 45f;
  private Camera mCam;

  public Camera cachedCamera
  {
    get
    {
      if ((UnityEngine.Object) this.mCam == (UnityEngine.Object) null)
        this.mCam = this.GetComponent<Camera>();
      return this.mCam;
    }
  }

  [Obsolete("Use 'value' instead")]
  public float fov
  {
    get => this.value;
    set => this.value = value;
  }

  public float value
  {
    get => this.cachedCamera.fieldOfView;
    set => this.cachedCamera.fieldOfView = value;
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.value = (float) ((double) this.from * (1.0 - (double) factor) + (double) this.to * (double) factor);

  public static TweenFOV Begin(GameObject go, float duration, float to)
  {
    TweenFOV tweenFov = UITweener.Begin<TweenFOV>(go, duration);
    tweenFov.from = tweenFov.value;
    tweenFov.to = to;
    if ((double) duration <= 0.0)
    {
      tweenFov.Sample(1f, true);
      tweenFov.enabled = false;
    }
    return tweenFov;
  }

  [ContextMenu("Set 'From' to current value")]
  public override void SetStartToCurrentValue() => this.from = this.value;

  [ContextMenu("Set 'To' to current value")]
  public override void SetEndToCurrentValue() => this.to = this.value;

  [ContextMenu("Assume value of 'From'")]
  private void SetCurrentValueToStart() => this.value = this.from;

  [ContextMenu("Assume value of 'To'")]
  private void SetCurrentValueToEnd() => this.value = this.to;
}
