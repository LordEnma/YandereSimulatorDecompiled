using System;
using UnityEngine;

// Token: 0x02000090 RID: 144
[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00034E2F File Offset: 0x0003302F
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
	// (get) Token: 0x060005A7 RID: 1447 RVA: 0x00034E51 File Offset: 0x00033051
	// (set) Token: 0x060005A8 RID: 1448 RVA: 0x00034E59 File Offset: 0x00033059
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
	// (get) Token: 0x060005A9 RID: 1449 RVA: 0x00034E62 File Offset: 0x00033062
	// (set) Token: 0x060005AA RID: 1450 RVA: 0x00034E84 File Offset: 0x00033084
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

	// Token: 0x060005AB RID: 1451 RVA: 0x00034F00 File Offset: 0x00033100
	private void Awake()
	{
		this.mRect = base.GetComponent<UIRect>();
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x00034F0E File Offset: 0x0003310E
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00034F3C File Offset: 0x0003313C
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

	// Token: 0x060005AE RID: 1454 RVA: 0x00034F88 File Offset: 0x00033188
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

	// Token: 0x060005AF RID: 1455 RVA: 0x00034FD8 File Offset: 0x000331D8
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x00034FE6 File Offset: 0x000331E6
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x00034FF4 File Offset: 0x000331F4
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x00035002 File Offset: 0x00033202
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005CB RID: 1483
	public Vector3 from;

	// Token: 0x040005CC RID: 1484
	public Vector3 to;

	// Token: 0x040005CD RID: 1485
	[HideInInspector]
	public bool worldSpace;

	// Token: 0x040005CE RID: 1486
	private Transform mTrans;

	// Token: 0x040005CF RID: 1487
	private UIRect mRect;
}
