using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x0003511F File Offset: 0x0003331F
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
	// (get) Token: 0x060005A7 RID: 1447 RVA: 0x00035141 File Offset: 0x00033341
	// (set) Token: 0x060005A8 RID: 1448 RVA: 0x00035149 File Offset: 0x00033349
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
	// (get) Token: 0x060005A9 RID: 1449 RVA: 0x00035152 File Offset: 0x00033352
	// (set) Token: 0x060005AA RID: 1450 RVA: 0x00035174 File Offset: 0x00033374
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

	// Token: 0x060005AB RID: 1451 RVA: 0x000351F0 File Offset: 0x000333F0
	private void Awake()
	{
		this.mRect = base.GetComponent<UIRect>();
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x000351FE File Offset: 0x000333FE
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x0003522C File Offset: 0x0003342C
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

	// Token: 0x060005AE RID: 1454 RVA: 0x00035278 File Offset: 0x00033478
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

	// Token: 0x060005AF RID: 1455 RVA: 0x000352C8 File Offset: 0x000334C8
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x000352D6 File Offset: 0x000334D6
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x000352E4 File Offset: 0x000334E4
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x000352F2 File Offset: 0x000334F2
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005D6 RID: 1494
	public Vector3 from;

	// Token: 0x040005D7 RID: 1495
	public Vector3 to;

	// Token: 0x040005D8 RID: 1496
	[HideInInspector]
	public bool worldSpace;

	// Token: 0x040005D9 RID: 1497
	private Transform mTrans;

	// Token: 0x040005DA RID: 1498
	private UIRect mRect;
}
