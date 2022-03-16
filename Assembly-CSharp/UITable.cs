using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000066 RID: 102
[AddComponentMenu("NGUI/Interaction/Table")]
public class UITable : UIWidgetContainer
{
	// Token: 0x17000042 RID: 66
	// (set) Token: 0x060002C4 RID: 708 RVA: 0x0001E0F1 File Offset: 0x0001C2F1
	public bool repositionNow
	{
		set
		{
			if (value)
			{
				this.mReposition = true;
				base.enabled = true;
			}
		}
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0001E104 File Offset: 0x0001C304
	public List<Transform> GetChildList()
	{
		Transform transform = base.transform;
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (!this.hideInactive || (child && NGUITools.GetActive(child.gameObject)))
			{
				list.Add(child);
			}
		}
		if (this.sorting != UITable.Sorting.None)
		{
			if (this.sorting == UITable.Sorting.Alphabetic)
			{
				list.Sort(new Comparison<Transform>(UIGrid.SortByName));
			}
			else if (this.sorting == UITable.Sorting.Horizontal)
			{
				list.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
			}
			else if (this.sorting == UITable.Sorting.Vertical)
			{
				list.Sort(new Comparison<Transform>(UIGrid.SortVertical));
			}
			else if (this.onCustomSort != null)
			{
				list.Sort(this.onCustomSort);
			}
			else
			{
				this.Sort(list);
			}
		}
		return list;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0001E1D8 File Offset: 0x0001C3D8
	protected virtual void Sort(List<Transform> list)
	{
		list.Sort(new Comparison<Transform>(UIGrid.SortByName));
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x0001E1EC File Offset: 0x0001C3EC
	protected virtual void Start()
	{
		this.Init();
		this.Reposition();
		base.enabled = false;
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x0001E201 File Offset: 0x0001C401
	protected virtual void Init()
	{
		this.mInitDone = true;
		this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x0001E21B File Offset: 0x0001C41B
	protected virtual void LateUpdate()
	{
		if (this.mReposition)
		{
			this.Reposition();
		}
		base.enabled = false;
	}

	// Token: 0x060002CA RID: 714 RVA: 0x0001E232 File Offset: 0x0001C432
	private void OnValidate()
	{
		if (!Application.isPlaying && NGUITools.GetActive(this))
		{
			this.Reposition();
		}
	}

	// Token: 0x060002CB RID: 715 RVA: 0x0001E24C File Offset: 0x0001C44C
	protected void RepositionVariableSize(List<Transform> children)
	{
		float num = 0f;
		float num2 = 0f;
		object obj = (this.columns > 0) ? (children.Count / this.columns + 1) : 1;
		int num3 = (this.columns > 0) ? this.columns : children.Count;
		object obj2 = obj;
		Bounds[,] array = new Bounds[obj2, num3];
		Bounds[] array2 = new Bounds[num3];
		Bounds[] array3 = new Bounds[obj2];
		int num4 = 0;
		int num5 = 0;
		int i = 0;
		int count = children.Count;
		while (i < count)
		{
			Transform transform = children[i];
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(transform, !this.hideInactive);
			Vector3 localScale = transform.localScale;
			bounds.min = Vector3.Scale(bounds.min, localScale);
			bounds.max = Vector3.Scale(bounds.max, localScale);
			array[num5, num4] = bounds;
			array2[num4].Encapsulate(bounds);
			array3[num5].Encapsulate(bounds);
			if (++num4 >= this.columns && this.columns > 0)
			{
				num4 = 0;
				num5++;
			}
			i++;
		}
		num4 = 0;
		num5 = 0;
		Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.cellAlignment);
		int j = 0;
		int count2 = children.Count;
		while (j < count2)
		{
			Transform transform2 = children[j];
			Bounds bounds2 = array[num5, num4];
			Bounds bounds3 = array2[num4];
			Bounds bounds4 = array3[num5];
			Vector3 localPosition = transform2.localPosition;
			localPosition.x = num + bounds2.extents.x - bounds2.center.x;
			localPosition.x -= Mathf.Lerp(0f, bounds2.max.x - bounds2.min.x - bounds3.max.x + bounds3.min.x, pivotOffset.x) - this.padding.x;
			if (this.direction == UITable.Direction.Down)
			{
				localPosition.y = -num2 - bounds2.extents.y - bounds2.center.y;
				localPosition.y += Mathf.Lerp(bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y, 0f, pivotOffset.y) - this.padding.y;
			}
			else
			{
				localPosition.y = num2 + bounds2.extents.y - bounds2.center.y;
				localPosition.y -= Mathf.Lerp(0f, bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y, pivotOffset.y) - this.padding.y;
			}
			num += bounds3.size.x + this.padding.x * 2f;
			transform2.localPosition = localPosition;
			if (++num4 >= this.columns && this.columns > 0)
			{
				num4 = 0;
				num5++;
				num = 0f;
				num2 += bounds4.size.y + this.padding.y * 2f;
			}
			j++;
		}
		if (this.pivot != UIWidget.Pivot.TopLeft)
		{
			pivotOffset = NGUIMath.GetPivotOffset(this.pivot);
			Bounds bounds5 = NGUIMath.CalculateRelativeWidgetBounds(base.transform);
			float num6 = Mathf.Lerp(0f, bounds5.size.x, pivotOffset.x);
			float num7 = Mathf.Lerp(-bounds5.size.y, 0f, pivotOffset.y);
			Transform transform3 = base.transform;
			for (int k = 0; k < transform3.childCount; k++)
			{
				Transform child = transform3.GetChild(k);
				SpringPosition component = child.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
					SpringPosition springPosition = component;
					springPosition.target.x = springPosition.target.x - num6;
					SpringPosition springPosition2 = component;
					springPosition2.target.y = springPosition2.target.y - num7;
					component.enabled = true;
				}
				else
				{
					Vector3 localPosition2 = child.localPosition;
					localPosition2.x -= num6;
					localPosition2.y -= num7;
					child.localPosition = localPosition2;
				}
			}
		}
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0001E6CC File Offset: 0x0001C8CC
	[ContextMenu("Execute")]
	public virtual void Reposition()
	{
		if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive(this))
		{
			this.Init();
		}
		this.mReposition = false;
		Transform transform = base.transform;
		List<Transform> childList = this.GetChildList();
		if (childList.Count > 0)
		{
			this.RepositionVariableSize(childList);
		}
		if (this.keepWithinPanel && this.mPanel != null)
		{
			this.mPanel.ConstrainTargetToBounds(transform, true);
			UIScrollView component = this.mPanel.GetComponent<UIScrollView>();
			if (component != null)
			{
				component.UpdateScrollbars(true);
			}
		}
		if (this.onReposition != null)
		{
			this.onReposition();
		}
	}

	// Token: 0x04000449 RID: 1097
	public int columns;

	// Token: 0x0400044A RID: 1098
	public UITable.Direction direction;

	// Token: 0x0400044B RID: 1099
	public UITable.Sorting sorting;

	// Token: 0x0400044C RID: 1100
	public UIWidget.Pivot pivot;

	// Token: 0x0400044D RID: 1101
	public UIWidget.Pivot cellAlignment;

	// Token: 0x0400044E RID: 1102
	public bool hideInactive = true;

	// Token: 0x0400044F RID: 1103
	public bool keepWithinPanel;

	// Token: 0x04000450 RID: 1104
	public Vector2 padding = Vector2.zero;

	// Token: 0x04000451 RID: 1105
	public UITable.OnReposition onReposition;

	// Token: 0x04000452 RID: 1106
	public Comparison<Transform> onCustomSort;

	// Token: 0x04000453 RID: 1107
	protected UIPanel mPanel;

	// Token: 0x04000454 RID: 1108
	protected bool mInitDone;

	// Token: 0x04000455 RID: 1109
	protected bool mReposition;

	// Token: 0x020005E3 RID: 1507
	// (Invoke) Token: 0x06002546 RID: 9542
	public delegate void OnReposition();

	// Token: 0x020005E4 RID: 1508
	[DoNotObfuscateNGUI]
	public enum Direction
	{
		// Token: 0x04004DFD RID: 19965
		Down,
		// Token: 0x04004DFE RID: 19966
		Up
	}

	// Token: 0x020005E5 RID: 1509
	[DoNotObfuscateNGUI]
	public enum Sorting
	{
		// Token: 0x04004E00 RID: 19968
		None,
		// Token: 0x04004E01 RID: 19969
		Alphabetic,
		// Token: 0x04004E02 RID: 19970
		Horizontal,
		// Token: 0x04004E03 RID: 19971
		Vertical,
		// Token: 0x04004E04 RID: 19972
		Custom
	}
}
