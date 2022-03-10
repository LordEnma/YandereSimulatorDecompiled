using System;
using UnityEngine;

// Token: 0x02000095 RID: 149
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Tween/Tween Width")]
public class TweenWidth : UITweener
{
	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x060005DA RID: 1498 RVA: 0x000357BE File Offset: 0x000339BE
	public UIWidget cachedWidget
	{
		get
		{
			if (this.mWidget == null)
			{
				this.mWidget = base.GetComponent<UIWidget>();
			}
			return this.mWidget;
		}
	}

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x060005DB RID: 1499 RVA: 0x000357E0 File Offset: 0x000339E0
	// (set) Token: 0x060005DC RID: 1500 RVA: 0x000357E8 File Offset: 0x000339E8
	[Obsolete("Use 'value' instead")]
	public int width
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

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x060005DD RID: 1501 RVA: 0x000357F1 File Offset: 0x000339F1
	// (set) Token: 0x060005DE RID: 1502 RVA: 0x000357FE File Offset: 0x000339FE
	public int value
	{
		get
		{
			return this.cachedWidget.width;
		}
		set
		{
			this.cachedWidget.width = value;
		}
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x0003580C File Offset: 0x00033A0C
	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (this.fromTarget)
		{
			this.from = this.fromTarget.width;
		}
		if (this.toTarget)
		{
			this.to = this.toTarget.width;
		}
		this.value = Mathf.RoundToInt((float)this.from * (1f - factor) + (float)this.to * factor);
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

	// Token: 0x060005E0 RID: 1504 RVA: 0x000358C4 File Offset: 0x00033AC4
	public static TweenWidth Begin(UIWidget widget, float duration, int width)
	{
		TweenWidth tweenWidth = UITweener.Begin<TweenWidth>(widget.gameObject, duration, 0f);
		tweenWidth.from = widget.width;
		tweenWidth.to = width;
		if (duration <= 0f)
		{
			tweenWidth.Sample(1f, true);
			tweenWidth.enabled = false;
		}
		return tweenWidth;
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x00035912 File Offset: 0x00033B12
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x00035920 File Offset: 0x00033B20
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x0003592E File Offset: 0x00033B2E
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x0003593C File Offset: 0x00033B3C
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005EC RID: 1516
	public int from = 100;

	// Token: 0x040005ED RID: 1517
	public int to = 100;

	// Token: 0x040005EE RID: 1518
	[Tooltip("If set, 'from' value will be set to match the specified rectangle")]
	public UIWidget fromTarget;

	// Token: 0x040005EF RID: 1519
	[Tooltip("If set, 'to' value will be set to match the specified rectangle")]
	public UIWidget toTarget;

	// Token: 0x040005F0 RID: 1520
	[Tooltip("Whether there is a table that should be updated")]
	public bool updateTable;

	// Token: 0x040005F1 RID: 1521
	private UIWidget mWidget;

	// Token: 0x040005F2 RID: 1522
	private UITable mTable;
}
