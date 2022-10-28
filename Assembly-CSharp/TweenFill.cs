// Decompiled with JetBrains decompiler
// Type: TweenFill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UIBasicSprite))]
[AddComponentMenu("NGUI/Tween/Tween Fill")]
public class TweenFill : UITweener
{
  [Range(0.0f, 1f)]
  public float from = 1f;
  [Range(0.0f, 1f)]
  public float to = 1f;
  private bool mCached;
  private UIBasicSprite mSprite;

  private void Cache()
  {
    this.mCached = true;
    this.mSprite = (UIBasicSprite) this.GetComponent<UISprite>();
  }

  public float value
  {
    get
    {
      if (!this.mCached)
        this.Cache();
      return (Object) this.mSprite != (Object) null ? this.mSprite.fillAmount : 0.0f;
    }
    set
    {
      if (!this.mCached)
        this.Cache();
      if (!((Object) this.mSprite != (Object) null))
        return;
      this.mSprite.fillAmount = value;
    }
  }

  protected override void OnUpdate(float factor, bool isFinished) => this.value = Mathf.Lerp(this.from, this.to, factor);

  public static TweenFill Begin(GameObject go, float duration, float fill)
  {
    TweenFill tweenFill = UITweener.Begin<TweenFill>(go, duration);
    tweenFill.from = tweenFill.value;
    tweenFill.to = fill;
    if ((double) duration <= 0.0)
    {
      tweenFill.Sample(1f, true);
      tweenFill.enabled = false;
    }
    return tweenFill;
  }

  public override void SetStartToCurrentValue() => this.from = this.value;

  public override void SetEndToCurrentValue() => this.to = this.value;
}
