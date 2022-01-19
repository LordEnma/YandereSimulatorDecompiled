using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
[RequireComponent(typeof(UIBasicSprite))]
[AddComponentMenu("NGUI/Tween/Tween Fill")]
public class TweenFill : UITweener
{
	// Token: 0x0600057D RID: 1405 RVA: 0x00034497 File Offset: 0x00032697
	private void Cache()
	{
		this.mCached = true;
		this.mSprite = base.GetComponent<UISprite>();
	}

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x0600057E RID: 1406 RVA: 0x000344AC File Offset: 0x000326AC
	// (set) Token: 0x0600057F RID: 1407 RVA: 0x000344DB File Offset: 0x000326DB
	public float value
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mSprite != null)
			{
				return this.mSprite.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mSprite != null)
			{
				this.mSprite.fillAmount = value;
			}
		}
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00034505 File Offset: 0x00032705
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Mathf.Lerp(this.from, this.to, factor);
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x00034520 File Offset: 0x00032720
	public static TweenFill Begin(GameObject go, float duration, float fill)
	{
		TweenFill tweenFill = UITweener.Begin<TweenFill>(go, duration, 0f);
		tweenFill.from = tweenFill.value;
		tweenFill.to = fill;
		if (duration <= 0f)
		{
			tweenFill.Sample(1f, true);
			tweenFill.enabled = false;
		}
		return tweenFill;
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x00034569 File Offset: 0x00032769
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00034577 File Offset: 0x00032777
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005B5 RID: 1461
	[Range(0f, 1f)]
	public float from = 1f;

	// Token: 0x040005B6 RID: 1462
	[Range(0f, 1f)]
	public float to = 1f;

	// Token: 0x040005B7 RID: 1463
	private bool mCached;

	// Token: 0x040005B8 RID: 1464
	private UIBasicSprite mSprite;
}
