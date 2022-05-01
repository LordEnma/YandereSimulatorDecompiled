using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
[RequireComponent(typeof(UIBasicSprite))]
[AddComponentMenu("NGUI/Tween/Tween Fill")]
public class TweenFill : UITweener
{
	// Token: 0x0600057D RID: 1405 RVA: 0x00034787 File Offset: 0x00032987
	private void Cache()
	{
		this.mCached = true;
		this.mSprite = base.GetComponent<UISprite>();
	}

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x0600057E RID: 1406 RVA: 0x0003479C File Offset: 0x0003299C
	// (set) Token: 0x0600057F RID: 1407 RVA: 0x000347CB File Offset: 0x000329CB
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

	// Token: 0x06000580 RID: 1408 RVA: 0x000347F5 File Offset: 0x000329F5
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Mathf.Lerp(this.from, this.to, factor);
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x00034810 File Offset: 0x00032A10
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

	// Token: 0x06000582 RID: 1410 RVA: 0x00034859 File Offset: 0x00032A59
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00034867 File Offset: 0x00032A67
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005C1 RID: 1473
	[Range(0f, 1f)]
	public float from = 1f;

	// Token: 0x040005C2 RID: 1474
	[Range(0f, 1f)]
	public float to = 1f;

	// Token: 0x040005C3 RID: 1475
	private bool mCached;

	// Token: 0x040005C4 RID: 1476
	private UIBasicSprite mSprite;
}
