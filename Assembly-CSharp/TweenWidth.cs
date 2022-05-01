using System;
using UnityEngine;

// Token: 0x02000095 RID: 149
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Tween/Tween Width")]
public class TweenWidth : UITweener
{
	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x060005DA RID: 1498 RVA: 0x000359B6 File Offset: 0x00033BB6
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
	// (get) Token: 0x060005DB RID: 1499 RVA: 0x000359D8 File Offset: 0x00033BD8
	// (set) Token: 0x060005DC RID: 1500 RVA: 0x000359E0 File Offset: 0x00033BE0
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
	// (get) Token: 0x060005DD RID: 1501 RVA: 0x000359E9 File Offset: 0x00033BE9
	// (set) Token: 0x060005DE RID: 1502 RVA: 0x000359F6 File Offset: 0x00033BF6
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

	// Token: 0x060005DF RID: 1503 RVA: 0x00035A04 File Offset: 0x00033C04
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

	// Token: 0x060005E0 RID: 1504 RVA: 0x00035ABC File Offset: 0x00033CBC
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

	// Token: 0x060005E1 RID: 1505 RVA: 0x00035B0A File Offset: 0x00033D0A
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x00035B18 File Offset: 0x00033D18
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x00035B26 File Offset: 0x00033D26
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x00035B34 File Offset: 0x00033D34
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005EE RID: 1518
	public int from = 100;

	// Token: 0x040005EF RID: 1519
	public int to = 100;

	// Token: 0x040005F0 RID: 1520
	[Tooltip("If set, 'from' value will be set to match the specified rectangle")]
	public UIWidget fromTarget;

	// Token: 0x040005F1 RID: 1521
	[Tooltip("If set, 'to' value will be set to match the specified rectangle")]
	public UIWidget toTarget;

	// Token: 0x040005F2 RID: 1522
	[Tooltip("Whether there is a table that should be updated")]
	public bool updateTable;

	// Token: 0x040005F3 RID: 1523
	private UIWidget mWidget;

	// Token: 0x040005F4 RID: 1524
	private UITable mTable;
}
