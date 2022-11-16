// Decompiled with JetBrains decompiler
// Type: TweenPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
  public Vector3 from;
  public Vector3 to;
  [HideInInspector]
  public bool worldSpace;
  private Transform mTrans;
  private UIRect mRect;

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
  public Vector3 position
  {
    get => this.value;
    set => this.value = value;
  }

  public Vector3 value
  {
    get => !this.worldSpace ? this.cachedTransform.localPosition : this.cachedTransform.position;
    set
    {
      if ((UnityEngine.Object) this.mRect == (UnityEngine.Object) null || !this.mRect.isAnchored || this.worldSpace)
      {
        if (this.worldSpace)
          this.cachedTransform.position = value;
        else
          this.cachedTransform.localPosition = value;
      }
      else
      {
        value -= this.cachedTransform.localPosition;
        NGUIMath.MoveRect(this.mRect, value.x, value.y);
      }
    }
  }

  private void Awake() => this.mRect = this.GetComponent<UIRect>();

  protected override void OnUpdate(float factor, bool isFinished) => this.value = this.from * (1f - factor) + this.to * factor;

  public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
  {
    TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
    tweenPosition.from = tweenPosition.value;
    tweenPosition.to = pos;
    if ((double) duration <= 0.0)
    {
      tweenPosition.Sample(1f, true);
      tweenPosition.enabled = false;
    }
    return tweenPosition;
  }

  public static TweenPosition Begin(
    GameObject go,
    float duration,
    Vector3 pos,
    bool worldSpace)
  {
    TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
    tweenPosition.worldSpace = worldSpace;
    tweenPosition.from = tweenPosition.value;
    tweenPosition.to = pos;
    if ((double) duration <= 0.0)
    {
      tweenPosition.Sample(1f, true);
      tweenPosition.enabled = false;
    }
    return tweenPosition;
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
