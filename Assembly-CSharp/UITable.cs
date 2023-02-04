using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Table")]
public class UITable : UIWidgetContainer
{
	public delegate void OnReposition();

	[DoNotObfuscateNGUI]
	public enum Direction
	{
		Down = 0,
		Up = 1
	}

	[DoNotObfuscateNGUI]
	public enum Sorting
	{
		None = 0,
		Alphabetic = 1,
		Horizontal = 2,
		Vertical = 3,
		Custom = 4
	}

	public int columns;

	public Direction direction;

	public Sorting sorting;

	public UIWidget.Pivot pivot;

	public UIWidget.Pivot cellAlignment;

	public bool hideInactive = true;

	public bool keepWithinPanel;

	public Vector2 padding = Vector2.zero;

	public OnReposition onReposition;

	public Comparison<Transform> onCustomSort;

	protected UIPanel mPanel;

	protected bool mInitDone;

	protected bool mReposition;

	public bool repositionNow
	{
		set
		{
			if (value)
			{
				mReposition = true;
				base.enabled = true;
			}
		}
	}

	public List<Transform> GetChildList()
	{
		Transform transform = base.transform;
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (!hideInactive || ((bool)child && NGUITools.GetActive(child.gameObject)))
			{
				list.Add(child);
			}
		}
		if (sorting != 0)
		{
			if (sorting == Sorting.Alphabetic)
			{
				list.Sort(UIGrid.SortByName);
			}
			else if (sorting == Sorting.Horizontal)
			{
				list.Sort(UIGrid.SortHorizontal);
			}
			else if (sorting == Sorting.Vertical)
			{
				list.Sort(UIGrid.SortVertical);
			}
			else if (onCustomSort != null)
			{
				list.Sort(onCustomSort);
			}
			else
			{
				Sort(list);
			}
		}
		return list;
	}

	protected virtual void Sort(List<Transform> list)
	{
		list.Sort(UIGrid.SortByName);
	}

	protected virtual void Start()
	{
		Init();
		Reposition();
		base.enabled = false;
	}

	protected virtual void Init()
	{
		mInitDone = true;
		mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
	}

	protected virtual void LateUpdate()
	{
		if (mReposition)
		{
			Reposition();
		}
		base.enabled = false;
	}

	private void OnValidate()
	{
		if (!Application.isPlaying && NGUITools.GetActive(this))
		{
			Reposition();
		}
	}

	protected void RepositionVariableSize(List<Transform> children)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = ((columns <= 0) ? 1 : (children.Count / columns + 1));
		int num4 = ((columns > 0) ? columns : children.Count);
		Bounds[,] array = new Bounds[num3, num4];
		Bounds[] array2 = new Bounds[num4];
		Bounds[] array3 = new Bounds[num3];
		int num5 = 0;
		int num6 = 0;
		int i = 0;
		for (int count = children.Count; i < count; i++)
		{
			Transform obj = children[i];
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(obj, !hideInactive);
			Vector3 localScale = obj.localScale;
			bounds.min = Vector3.Scale(bounds.min, localScale);
			bounds.max = Vector3.Scale(bounds.max, localScale);
			array[num6, num5] = bounds;
			array2[num5].Encapsulate(bounds);
			array3[num6].Encapsulate(bounds);
			if (++num5 >= columns && columns > 0)
			{
				num5 = 0;
				num6++;
			}
		}
		num5 = 0;
		num6 = 0;
		Vector2 pivotOffset = NGUIMath.GetPivotOffset(cellAlignment);
		int j = 0;
		for (int count2 = children.Count; j < count2; j++)
		{
			Transform obj2 = children[j];
			Bounds bounds2 = array[num6, num5];
			Bounds bounds3 = array2[num5];
			Bounds bounds4 = array3[num6];
			Vector3 localPosition = obj2.localPosition;
			localPosition.x = num + bounds2.extents.x - bounds2.center.x;
			localPosition.x -= Mathf.Lerp(0f, bounds2.max.x - bounds2.min.x - bounds3.max.x + bounds3.min.x, pivotOffset.x) - padding.x;
			if (direction == Direction.Down)
			{
				localPosition.y = 0f - num2 - bounds2.extents.y - bounds2.center.y;
				localPosition.y += Mathf.Lerp(bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y, 0f, pivotOffset.y) - padding.y;
			}
			else
			{
				localPosition.y = num2 + bounds2.extents.y - bounds2.center.y;
				localPosition.y -= Mathf.Lerp(0f, bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y, pivotOffset.y) - padding.y;
			}
			num += bounds3.size.x + padding.x * 2f;
			obj2.localPosition = localPosition;
			if (++num5 >= columns && columns > 0)
			{
				num5 = 0;
				num6++;
				num = 0f;
				num2 += bounds4.size.y + padding.y * 2f;
			}
		}
		if (pivot == UIWidget.Pivot.TopLeft)
		{
			return;
		}
		pivotOffset = NGUIMath.GetPivotOffset(pivot);
		Bounds bounds5 = NGUIMath.CalculateRelativeWidgetBounds(base.transform);
		float num7 = Mathf.Lerp(0f, bounds5.size.x, pivotOffset.x);
		float num8 = Mathf.Lerp(0f - bounds5.size.y, 0f, pivotOffset.y);
		Transform transform = base.transform;
		for (int k = 0; k < transform.childCount; k++)
		{
			Transform child = transform.GetChild(k);
			SpringPosition component = child.GetComponent<SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
				component.target.x -= num7;
				component.target.y -= num8;
				component.enabled = true;
			}
			else
			{
				Vector3 localPosition2 = child.localPosition;
				localPosition2.x -= num7;
				localPosition2.y -= num8;
				child.localPosition = localPosition2;
			}
		}
	}

	[ContextMenu("Execute")]
	public virtual void Reposition()
	{
		if (Application.isPlaying && !mInitDone && NGUITools.GetActive(this))
		{
			Init();
		}
		mReposition = false;
		Transform target = base.transform;
		List<Transform> childList = GetChildList();
		if (childList.Count > 0)
		{
			RepositionVariableSize(childList);
		}
		if (keepWithinPanel && mPanel != null)
		{
			mPanel.ConstrainTargetToBounds(target, immediate: true);
			UIScrollView component = mPanel.GetComponent<UIScrollView>();
			if (component != null)
			{
				component.UpdateScrollbars(recalculateBounds: true);
			}
		}
		if (onReposition != null)
		{
			onReposition();
		}
	}
}
