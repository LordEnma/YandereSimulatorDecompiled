using System;
using UnityEngine;

// Token: 0x0200008A RID: 138
[AddComponentMenu("NGUI/Tween/Tween Color")]
public class TweenColor : UITweener
{
	// Token: 0x06000565 RID: 1381 RVA: 0x00034104 File Offset: 0x00032304
	private void Cache()
	{
		this.mCached = true;
		this.mWidget = base.GetComponent<UIWidget>();
		if (this.mWidget != null)
		{
			return;
		}
		this.mSr = base.GetComponent<SpriteRenderer>();
		if (this.mSr != null)
		{
			return;
		}
		Renderer component = base.GetComponent<Renderer>();
		if (component != null)
		{
			this.mMat = component.material;
			return;
		}
		this.mLight = base.GetComponent<Light>();
		if (this.mLight == null)
		{
			this.mWidget = base.GetComponentInChildren<UIWidget>();
		}
	}

	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x06000566 RID: 1382 RVA: 0x00034191 File Offset: 0x00032391
	// (set) Token: 0x06000567 RID: 1383 RVA: 0x00034199 File Offset: 0x00032399
	[Obsolete("Use 'value' instead")]
	public Color color
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x06000568 RID: 1384 RVA: 0x000341A4 File Offset: 0x000323A4
	// (set) Token: 0x06000569 RID: 1385 RVA: 0x0003422C File Offset: 0x0003242C
	public Color value
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mWidget != null)
			{
				return this.mWidget.color;
			}
			if (this.mMat != null)
			{
				return this.mMat.color;
			}
			if (this.mSr != null)
			{
				return this.mSr.color;
			}
			if (this.mLight != null)
			{
				return this.mLight.color;
			}
			return Color.black;
		}
		set
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mWidget != null)
			{
				this.mWidget.color = value;
				return;
			}
			if (this.mMat != null)
			{
				this.mMat.color = value;
				return;
			}
			if (this.mSr != null)
			{
				this.mSr.color = value;
				return;
			}
			if (this.mLight != null)
			{
				this.mLight.color = value;
				this.mLight.enabled = (value.r + value.g + value.b > 0.01f);
			}
		}
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x000342D8 File Offset: 0x000324D8
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Color.Lerp(this.from, this.to, factor);
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x000342F4 File Offset: 0x000324F4
	public static TweenColor Begin(GameObject go, float duration, Color color)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration, 0f);
		tweenColor.from = tweenColor.value;
		tweenColor.to = color;
		if (duration <= 0f)
		{
			tweenColor.Sample(1f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x0003433D File Offset: 0x0003253D
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x0003434B File Offset: 0x0003254B
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x00034359 File Offset: 0x00032559
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x00034367 File Offset: 0x00032567
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005AA RID: 1450
	public Color from = Color.white;

	// Token: 0x040005AB RID: 1451
	public Color to = Color.white;

	// Token: 0x040005AC RID: 1452
	private bool mCached;

	// Token: 0x040005AD RID: 1453
	private UIWidget mWidget;

	// Token: 0x040005AE RID: 1454
	private Material mMat;

	// Token: 0x040005AF RID: 1455
	private Light mLight;

	// Token: 0x040005B0 RID: 1456
	private SpriteRenderer mSr;
}
