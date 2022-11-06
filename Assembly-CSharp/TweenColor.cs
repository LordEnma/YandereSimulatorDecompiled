// Decompiled with JetBrains decompiler
// Type: TweenColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Color")]
public class TweenColor : UITweener
{
  public Color from = Color.white;
  public Color to = Color.white;
  private bool mCached;
  private UIWidget mWidget;
  private Material mMat;
  private Light mLight;
  private SpriteRenderer mSr;

  private void Cache()
  {
    this.mCached = true;
    this.mWidget = this.GetComponent<UIWidget>();
    if ((UnityEngine.Object) this.mWidget != (UnityEngine.Object) null)
      return;
    this.mSr = this.GetComponent<SpriteRenderer>();
    if ((UnityEngine.Object) this.mSr != (UnityEngine.Object) null)
      return;
    Renderer component = this.GetComponent<Renderer>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
    {
      this.mMat = component.material;
    }
    else
    {
      this.mLight = this.GetComponent<Light>();
      if (!((UnityEngine.Object) this.mLight == (UnityEngine.Object) null))
        return;
      this.mWidget = this.GetComponentInChildren<UIWidget>();
    }
  }

  [Obsolete("Use 'value' instead")]
  public Color color
  {
    get => this.value;
    set => this.value = value;
  }

  public Color value
  {
    get
    {
      if (!this.mCached)
        this.Cache();
      if ((UnityEngine.Object) this.mWidget != (UnityEngine.Object) null)
        return this.mWidget.color;
      if ((UnityEngine.Object) this.mMat != (UnityEngine.Object) null)
        return this.mMat.color;
      if ((UnityEngine.Object) this.mSr != (UnityEngine.Object) null)
        return this.mSr.color;
      return (UnityEngine.Object) this.mLight != (UnityEngine.Object) null ? this.mLight.color : Color.black;
    }
    set
    {
      if (!this.mCached)
        this.Cache();
      if ((UnityEngine.Object) this.mWidget != (UnityEngine.Object) null)
        this.mWidget.color = value;
      else if ((UnityEngine.Object) this.mMat != (UnityEngine.Object) null)
        this.mMat.color = value;
      else if ((UnityEngine.Object) this.mSr != (UnityEngine.Object) null)
      {
        this.mSr.color = value;
      }
      else
      {
        if (!((UnityEngine.Object) this.mLight != (UnityEngine.Object) null))
          return;
        this.mLight.color = value;
        this.mLight.enabled = (double) value.r + (double) value.g + (double) value.b > 0.0099999997764825821;
      }
    }
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.value = Color.Lerp(this.from, this.to, factor);

  public static TweenColor Begin(GameObject go, float duration, Color color)
  {
    TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration);
    tweenColor.from = tweenColor.value;
    tweenColor.to = color;
    if ((double) duration <= 0.0)
    {
      tweenColor.Sample(1f, true);
      tweenColor.enabled = false;
    }
    return tweenColor;
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
