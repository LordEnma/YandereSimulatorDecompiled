using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Tween/Tween Height")]
public class TweenHeight : UITweener
{
	// Token: 0x170000BE RID: 190
	// (get) Token: 0x06000585 RID: 1413 RVA: 0x000345AB File Offset: 0x000327AB
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

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x06000586 RID: 1414 RVA: 0x000345CD File Offset: 0x000327CD
	// (set) Token: 0x06000587 RID: 1415 RVA: 0x000345D5 File Offset: 0x000327D5
	[Obsolete("Use 'value' instead")]
	public int height
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

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x06000588 RID: 1416 RVA: 0x000345DE File Offset: 0x000327DE
	// (set) Token: 0x06000589 RID: 1417 RVA: 0x000345EB File Offset: 0x000327EB
	public int value
	{
		get
		{
			return this.cachedWidget.height;
		}
		set
		{
			this.cachedWidget.height = value;
		}
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x000345FC File Offset: 0x000327FC
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

	// Token: 0x0600058B RID: 1419 RVA: 0x000346B4 File Offset: 0x000328B4
	public static TweenHeight Begin(UIWidget widget, float duration, int height)
	{
		TweenHeight tweenHeight = UITweener.Begin<TweenHeight>(widget.gameObject, duration, 0f);
		tweenHeight.from = widget.height;
		tweenHeight.to = height;
		if (duration <= 0f)
		{
			tweenHeight.Sample(1f, true);
			tweenHeight.enabled = false;
		}
		return tweenHeight;
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x00034702 File Offset: 0x00032902
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x00034710 File Offset: 0x00032910
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x0003471E File Offset: 0x0003291E
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x0003472C File Offset: 0x0003292C
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005B8 RID: 1464
	public int from = 100;

	// Token: 0x040005B9 RID: 1465
	public int to = 100;

	// Token: 0x040005BA RID: 1466
	[Tooltip("If set, 'from' value will be set to match the specified rectangle")]
	public UIWidget fromTarget;

	// Token: 0x040005BB RID: 1467
	[Tooltip("If set, 'to' value will be set to match the specified rectangle")]
	public UIWidget toTarget;

	// Token: 0x040005BC RID: 1468
	[Tooltip("Whether there is a table that should be updated")]
	public bool updateTable;

	// Token: 0x040005BD RID: 1469
	private UIWidget mWidget;

	// Token: 0x040005BE RID: 1470
	private UITable mTable;
}
