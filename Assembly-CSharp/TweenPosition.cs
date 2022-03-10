using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00034F27 File Offset: 0x00033127
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x060005A7 RID: 1447 RVA: 0x00034F49 File Offset: 0x00033149
	// (set) Token: 0x060005A8 RID: 1448 RVA: 0x00034F51 File Offset: 0x00033151
	[Obsolete("Use 'value' instead")]
	public Vector3 position
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

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x060005A9 RID: 1449 RVA: 0x00034F5A File Offset: 0x0003315A
	// (set) Token: 0x060005AA RID: 1450 RVA: 0x00034F7C File Offset: 0x0003317C
	public Vector3 value
	{
		get
		{
			if (!this.worldSpace)
			{
				return this.cachedTransform.localPosition;
			}
			return this.cachedTransform.position;
		}
		set
		{
			if (!(this.mRect == null) && this.mRect.isAnchored && !this.worldSpace)
			{
				value -= this.cachedTransform.localPosition;
				NGUIMath.MoveRect(this.mRect, value.x, value.y);
				return;
			}
			if (this.worldSpace)
			{
				this.cachedTransform.position = value;
				return;
			}
			this.cachedTransform.localPosition = value;
		}
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00034FF8 File Offset: 0x000331F8
	private void Awake()
	{
		this.mRect = base.GetComponent<UIRect>();
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x00035006 File Offset: 0x00033206
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00035034 File Offset: 0x00033234
	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration, 0f);
		tweenPosition.from = tweenPosition.value;
		tweenPosition.to = pos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00035080 File Offset: 0x00033280
	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos, bool worldSpace)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration, 0f);
		tweenPosition.worldSpace = worldSpace;
		tweenPosition.from = tweenPosition.value;
		tweenPosition.to = pos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x000350D0 File Offset: 0x000332D0
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x000350DE File Offset: 0x000332DE
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x000350EC File Offset: 0x000332EC
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x000350FA File Offset: 0x000332FA
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005D4 RID: 1492
	public Vector3 from;

	// Token: 0x040005D5 RID: 1493
	public Vector3 to;

	// Token: 0x040005D6 RID: 1494
	[HideInInspector]
	public bool worldSpace;

	// Token: 0x040005D7 RID: 1495
	private Transform mTrans;

	// Token: 0x040005D8 RID: 1496
	private UIRect mRect;
}
