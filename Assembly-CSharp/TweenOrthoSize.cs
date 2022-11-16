// Decompiled with JetBrains decompiler
// Type: TweenOrthoSize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("NGUI/Tween/Tween Orthographic Size")]
public class TweenOrthoSize : UITweener
{
  public float from = 1f;
  public float to = 1f;
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
  public float orthoSize
  {
    get => this.value;
    set => this.value = value;
  }

  public float value
  {
    get => this.cachedCamera.orthographicSize;
    set => this.cachedCamera.orthographicSize = value;
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.value = (float) ((double) this.from * (1.0 - (double) factor) + (double) this.to * (double) factor);

  public static TweenOrthoSize Begin(GameObject go, float duration, float to)
  {
    TweenOrthoSize tweenOrthoSize = UITweener.Begin<TweenOrthoSize>(go, duration);
    tweenOrthoSize.from = tweenOrthoSize.value;
    tweenOrthoSize.to = to;
    if ((double) duration <= 0.0)
    {
      tweenOrthoSize.Sample(1f, true);
      tweenOrthoSize.enabled = false;
    }
    return tweenOrthoSize;
  }

  public override void SetStartToCurrentValue() => this.from = this.value;

  public override void SetEndToCurrentValue() => this.to = this.value;
}
