// Decompiled with JetBrains decompiler
// Type: TweenAlpha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
  [Range(0.0f, 1f)]
  public float from = 1f;
  [Range(0.0f, 1f)]
  public float to = 1f;
  [Tooltip("If used on a renderer, the material should probably be cleaned up after this script gets destroyed...")]
  public bool autoCleanup;
  [Tooltip("Color to adjust")]
  public string colorProperty;
  [NonSerialized]
  private bool mCached;
  [NonSerialized]
  private UIRect mRect;
  [NonSerialized]
  private Material mShared;
  [NonSerialized]
  private Material mMat;
  [NonSerialized]
  private Light mLight;
  [NonSerialized]
  private SpriteRenderer mSr;
  [NonSerialized]
  private float mBaseIntensity = 1f;

  [Obsolete("Use 'value' instead")]
  public float alpha
  {
    get => this.value;
    set => this.value = value;
  }

  private void OnDestroy()
  {
    if (!this.autoCleanup || !((UnityEngine.Object) this.mMat != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mShared != (UnityEngine.Object) this.mMat))
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.mMat);
    this.mMat = (Material) null;
  }

  private void Cache()
  {
    this.mCached = true;
    this.mRect = this.GetComponent<UIRect>();
    this.mSr = this.GetComponent<SpriteRenderer>();
    if (!((UnityEngine.Object) this.mRect == (UnityEngine.Object) null) || !((UnityEngine.Object) this.mSr == (UnityEngine.Object) null))
      return;
    this.mLight = this.GetComponent<Light>();
    if ((UnityEngine.Object) this.mLight == (UnityEngine.Object) null)
    {
      Renderer component = this.GetComponent<Renderer>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        this.mShared = component.sharedMaterial;
        this.mMat = component.material;
      }
      if (!((UnityEngine.Object) this.mMat == (UnityEngine.Object) null))
        return;
      this.mRect = this.GetComponentInChildren<UIRect>();
    }
    else
      this.mBaseIntensity = this.mLight.intensity;
  }

  public float value
  {
    get
    {
      if (!this.mCached)
        this.Cache();
      if ((UnityEngine.Object) this.mRect != (UnityEngine.Object) null)
        return this.mRect.alpha;
      if ((UnityEngine.Object) this.mSr != (UnityEngine.Object) null)
        return this.mSr.color.a;
      if ((UnityEngine.Object) this.mMat == (UnityEngine.Object) null)
        return 1f;
      return string.IsNullOrEmpty(this.colorProperty) ? this.mMat.color.a : this.mMat.GetColor(this.colorProperty).a;
    }
    set
    {
      if (!this.mCached)
        this.Cache();
      if ((UnityEngine.Object) this.mRect != (UnityEngine.Object) null)
        this.mRect.alpha = value;
      else if ((UnityEngine.Object) this.mSr != (UnityEngine.Object) null)
        this.mSr.color = this.mSr.color with { a = value };
      else if ((UnityEngine.Object) this.mMat != (UnityEngine.Object) null)
      {
        if (string.IsNullOrEmpty(this.colorProperty))
          this.mMat.color = this.mMat.color with
          {
            a = value
          };
        else
          this.mMat.SetColor(this.colorProperty, this.mMat.GetColor(this.colorProperty) with
          {
            a = value
          });
      }
      else
      {
        if (!((UnityEngine.Object) this.mLight != (UnityEngine.Object) null))
          return;
        this.mLight.intensity = this.mBaseIntensity * value;
      }
    }
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.value = Mathf.Lerp(this.from, this.to, factor);

  public static TweenAlpha Begin(
    GameObject go,
    float duration,
    float alpha,
    float delay = 0.0f)
  {
    TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration, delay);
    tweenAlpha.from = tweenAlpha.value;
    tweenAlpha.to = alpha;
    if ((double) duration <= 0.0)
    {
      tweenAlpha.Sample(1f, true);
      tweenAlpha.enabled = false;
    }
    return tweenAlpha;
  }

  public override void SetStartToCurrentValue() => this.from = this.value;

  public override void SetEndToCurrentValue() => this.to = this.value;
}
