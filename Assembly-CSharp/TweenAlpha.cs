using System;
using UnityEngine;

// Token: 0x02000089 RID: 137
[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x0600055A RID: 1370 RVA: 0x00033EB7 File Offset: 0x000320B7
	// (set) Token: 0x0600055B RID: 1371 RVA: 0x00033EBF File Offset: 0x000320BF
	[Obsolete("Use 'value' instead")]
	public float alpha
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

	// Token: 0x0600055C RID: 1372 RVA: 0x00033EC8 File Offset: 0x000320C8
	private void OnDestroy()
	{
		if (this.autoCleanup && this.mMat != null && this.mShared != this.mMat)
		{
			UnityEngine.Object.Destroy(this.mMat);
			this.mMat = null;
		}
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x00033F08 File Offset: 0x00032108
	private void Cache()
	{
		this.mCached = true;
		this.mRect = base.GetComponent<UIRect>();
		this.mSr = base.GetComponent<SpriteRenderer>();
		if (this.mRect == null && this.mSr == null)
		{
			this.mLight = base.GetComponent<Light>();
			if (this.mLight == null)
			{
				Renderer component = base.GetComponent<Renderer>();
				if (component != null)
				{
					this.mShared = component.sharedMaterial;
					this.mMat = component.material;
				}
				if (this.mMat == null)
				{
					this.mRect = base.GetComponentInChildren<UIRect>();
					return;
				}
			}
			else
			{
				this.mBaseIntensity = this.mLight.intensity;
			}
		}
	}

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x0600055E RID: 1374 RVA: 0x00033FC0 File Offset: 0x000321C0
	// (set) Token: 0x0600055F RID: 1375 RVA: 0x0003405C File Offset: 0x0003225C
	public float value
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mRect != null)
			{
				return this.mRect.alpha;
			}
			if (this.mSr != null)
			{
				return this.mSr.color.a;
			}
			if (this.mMat == null)
			{
				return 1f;
			}
			if (string.IsNullOrEmpty(this.colorProperty))
			{
				return this.mMat.color.a;
			}
			return this.mMat.GetColor(this.colorProperty).a;
		}
		set
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mRect != null)
			{
				this.mRect.alpha = value;
				return;
			}
			if (this.mSr != null)
			{
				Color color = this.mSr.color;
				color.a = value;
				this.mSr.color = color;
				return;
			}
			if (!(this.mMat != null))
			{
				if (this.mLight != null)
				{
					this.mLight.intensity = this.mBaseIntensity * value;
				}
				return;
			}
			if (string.IsNullOrEmpty(this.colorProperty))
			{
				Color color2 = this.mMat.color;
				color2.a = value;
				this.mMat.color = color2;
				return;
			}
			Color color3 = this.mMat.GetColor(this.colorProperty);
			color3.a = value;
			this.mMat.SetColor(this.colorProperty, color3);
		}
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0003414B File Offset: 0x0003234B
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Mathf.Lerp(this.from, this.to, factor);
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x00034168 File Offset: 0x00032368
	public static TweenAlpha Begin(GameObject go, float duration, float alpha, float delay = 0f)
	{
		TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration, delay);
		tweenAlpha.from = tweenAlpha.value;
		tweenAlpha.to = alpha;
		if (duration <= 0f)
		{
			tweenAlpha.Sample(1f, true);
			tweenAlpha.enabled = false;
		}
		return tweenAlpha;
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x000341AD File Offset: 0x000323AD
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x000341BB File Offset: 0x000323BB
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005AA RID: 1450
	[Range(0f, 1f)]
	public float from = 1f;

	// Token: 0x040005AB RID: 1451
	[Range(0f, 1f)]
	public float to = 1f;

	// Token: 0x040005AC RID: 1452
	[Tooltip("If used on a renderer, the material should probably be cleaned up after this script gets destroyed...")]
	public bool autoCleanup;

	// Token: 0x040005AD RID: 1453
	[Tooltip("Color to adjust")]
	public string colorProperty;

	// Token: 0x040005AE RID: 1454
	[NonSerialized]
	private bool mCached;

	// Token: 0x040005AF RID: 1455
	[NonSerialized]
	private UIRect mRect;

	// Token: 0x040005B0 RID: 1456
	[NonSerialized]
	private Material mShared;

	// Token: 0x040005B1 RID: 1457
	[NonSerialized]
	private Material mMat;

	// Token: 0x040005B2 RID: 1458
	[NonSerialized]
	private Light mLight;

	// Token: 0x040005B3 RID: 1459
	[NonSerialized]
	private SpriteRenderer mSr;

	// Token: 0x040005B4 RID: 1460
	[NonSerialized]
	private float mBaseIntensity = 1f;
}
