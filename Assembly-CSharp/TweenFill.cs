using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
[RequireComponent(typeof(UIBasicSprite))]
[AddComponentMenu("NGUI/Tween/Tween Fill")]
public class TweenFill : UITweener
{
	// Token: 0x0600057D RID: 1405 RVA: 0x00034647 File Offset: 0x00032847
	private void Cache()
	{
		this.mCached = true;
		this.mSprite = base.GetComponent<UISprite>();
	}

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x0600057E RID: 1406 RVA: 0x0003465C File Offset: 0x0003285C
	// (set) Token: 0x0600057F RID: 1407 RVA: 0x0003468B File Offset: 0x0003288B
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

	// Token: 0x06000580 RID: 1408 RVA: 0x000346B5 File Offset: 0x000328B5
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Mathf.Lerp(this.from, this.to, factor);
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x000346D0 File Offset: 0x000328D0
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

	// Token: 0x06000582 RID: 1410 RVA: 0x00034719 File Offset: 0x00032919
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00034727 File Offset: 0x00032927
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005BF RID: 1471
	[Range(0f, 1f)]
	public float from = 1f;

	// Token: 0x040005C0 RID: 1472
	[Range(0f, 1f)]
	public float to = 1f;

	// Token: 0x040005C1 RID: 1473
	private bool mCached;

	// Token: 0x040005C2 RID: 1474
	private UIBasicSprite mSprite;
}
