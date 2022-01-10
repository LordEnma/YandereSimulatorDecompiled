using System;
using UnityEngine;

// Token: 0x02000092 RID: 146
[AddComponentMenu("NGUI/Tween/Tween Scale")]
public class TweenScale : UITweener
{
	// Token: 0x170000CA RID: 202
	// (get) Token: 0x060005C0 RID: 1472 RVA: 0x000351D3 File Offset: 0x000333D3
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

	// Token: 0x170000CB RID: 203
	// (get) Token: 0x060005C1 RID: 1473 RVA: 0x000351F5 File Offset: 0x000333F5
	// (set) Token: 0x060005C2 RID: 1474 RVA: 0x00035202 File Offset: 0x00033402
	public Vector3 value
	{
		get
		{
			return this.cachedTransform.localScale;
		}
		set
		{
			this.cachedTransform.localScale = value;
		}
	}

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00035210 File Offset: 0x00033410
	// (set) Token: 0x060005C4 RID: 1476 RVA: 0x00035218 File Offset: 0x00033418
	[Obsolete("Use 'value' instead")]
	public Vector3 scale
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

	// Token: 0x060005C5 RID: 1477 RVA: 0x00035224 File Offset: 0x00033424
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
		if (this.updateTable)
		{
			if (this.mTable == null)
			{
				this.mTable = NGUITools.FindInParents<UITable>(base.gameObject);
				if (this.mTable == null)
				{
					this.updateTable = false;
					return;
				}
			}
			this.mTable.repositionNow = true;
		}
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x000352A4 File Offset: 0x000334A4
	public static TweenScale Begin(GameObject go, float duration, Vector3 scale)
	{
		TweenScale tweenScale = UITweener.Begin<TweenScale>(go, duration, 0f);
		tweenScale.from = tweenScale.value;
		tweenScale.to = scale;
		if (duration <= 0f)
		{
			tweenScale.Sample(1f, true);
			tweenScale.enabled = false;
		}
		return tweenScale;
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x000352ED File Offset: 0x000334ED
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x000352FB File Offset: 0x000334FB
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00035309 File Offset: 0x00033509
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00035317 File Offset: 0x00033517
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005D2 RID: 1490
	public Vector3 from = Vector3.one;

	// Token: 0x040005D3 RID: 1491
	public Vector3 to = Vector3.one;

	// Token: 0x040005D4 RID: 1492
	public bool updateTable;

	// Token: 0x040005D5 RID: 1493
	private Transform mTrans;

	// Token: 0x040005D6 RID: 1494
	private UITable mTable;
}
