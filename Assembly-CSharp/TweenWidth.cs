using System;
using UnityEngine;

// Token: 0x02000095 RID: 149
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Tween/Tween Width")]
public class TweenWidth : UITweener
{
	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x060005DA RID: 1498 RVA: 0x000356C6 File Offset: 0x000338C6
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
	// (get) Token: 0x060005DB RID: 1499 RVA: 0x000356E8 File Offset: 0x000338E8
	// (set) Token: 0x060005DC RID: 1500 RVA: 0x000356F0 File Offset: 0x000338F0
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
	// (get) Token: 0x060005DD RID: 1501 RVA: 0x000356F9 File Offset: 0x000338F9
	// (set) Token: 0x060005DE RID: 1502 RVA: 0x00035706 File Offset: 0x00033906
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

	// Token: 0x060005DF RID: 1503 RVA: 0x00035714 File Offset: 0x00033914
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

	// Token: 0x060005E0 RID: 1504 RVA: 0x000357CC File Offset: 0x000339CC
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

	// Token: 0x060005E1 RID: 1505 RVA: 0x0003581A File Offset: 0x00033A1A
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x00035828 File Offset: 0x00033A28
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x00035836 File Offset: 0x00033A36
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x00035844 File Offset: 0x00033A44
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005E2 RID: 1506
	public int from = 100;

	// Token: 0x040005E3 RID: 1507
	public int to = 100;

	// Token: 0x040005E4 RID: 1508
	[Tooltip("If set, 'from' value will be set to match the specified rectangle")]
	public UIWidget fromTarget;

	// Token: 0x040005E5 RID: 1509
	[Tooltip("If set, 'to' value will be set to match the specified rectangle")]
	public UIWidget toTarget;

	// Token: 0x040005E6 RID: 1510
	[Tooltip("Whether there is a table that should be updated")]
	public bool updateTable;

	// Token: 0x040005E7 RID: 1511
	private UIWidget mWidget;

	// Token: 0x040005E8 RID: 1512
	private UITable mTable;
}
