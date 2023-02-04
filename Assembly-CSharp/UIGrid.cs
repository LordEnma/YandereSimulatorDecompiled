using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Grid")]
public class UIGrid : UIWidgetContainer
{
	public delegate void OnReposition();

	[DoNotObfuscateNGUI]
	public enum Arrangement
	{
		Horizontal = 0,
		Vertical = 1,
		CellSnap = 2
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

	public Arrangement arrangement;

	public Sorting sorting;

	public UIWidget.Pivot pivot;

	public int maxPerLine;

	public float cellWidth = 200f;

	public float cellHeight = 200f;

	public bool animateSmoothly;

	public bool hideInactive;

	public bool keepWithinPanel;

	public OnReposition onReposition;

	public Comparison<Transform> onCustomSort;

	[HideInInspector]
	[SerializeField]
	private bool sorted;

	protected bool mReposition;

	protected UIPanel mPanel;

	protected bool mInitDone;

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
			if ((!hideInactive || ((bool)child && child.gameObject.activeSelf)) && !UIDragDropItem.IsDragged(child.gameObject))
			{
				list.Add(child);
			}
		}
		if (sorting != 0 && arrangement != Arrangement.CellSnap)
		{
			if (sorting == Sorting.Alphabetic)
			{
				list.Sort(SortByName);
			}
			else if (sorting == Sorting.Horizontal)
			{
				list.Sort(SortHorizontal);
			}
			else if (sorting == Sorting.Vertical)
			{
				list.Sort(SortVertical);
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

	public Transform GetChild(int index)
	{
		List<Transform> childList = GetChildList();
		if (index >= childList.Count)
		{
			return null;
		}
		return childList[index];
	}

	public int GetIndex(Transform trans)
	{
		return GetChildList().IndexOf(trans);
	}

	[Obsolete("Use gameObject.AddChild or transform.parent = gridTransform")]
	public void AddChild(Transform trans)
	{
		if (trans != null)
		{
			trans.parent = base.transform;
			ResetPosition(GetChildList());
		}
	}

	[Obsolete("Use gameObject.AddChild or transform.parent = gridTransform")]
	public void AddChild(Transform trans, bool sort)
	{
		if (trans != null)
		{
			trans.parent = base.transform;
			ResetPosition(GetChildList());
		}
	}

	public bool RemoveChild(Transform t)
	{
		List<Transform> childList = GetChildList();
		if (childList.Remove(t))
		{
			ResetPosition(childList);
			return true;
		}
		return false;
	}

	protected virtual void Init()
	{
		mInitDone = true;
		mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
	}

	protected virtual void Start()
	{
		if (!mInitDone)
		{
			Init();
		}
		bool flag = animateSmoothly;
		animateSmoothly = false;
		Reposition();
		animateSmoothly = flag;
		base.enabled = false;
	}

	protected virtual void Update()
	{
		Reposition();
		base.enabled = false;
	}

	private void OnValidate()
	{
		if (!Application.isPlaying && NGUITools.GetActive(this))
		{
			Reposition();
		}
	}

	public static int SortByName(Transform a, Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	public static int SortHorizontal(Transform a, Transform b)
	{
		return a.localPosition.x.CompareTo(b.localPosition.x);
	}

	public static int SortVertical(Transform a, Transform b)
	{
		return b.localPosition.y.CompareTo(a.localPosition.y);
	}

	protected virtual void Sort(List<Transform> list)
	{
	}

	[ContextMenu("Execute")]
	public virtual void Reposition()
	{
		if (Application.isPlaying && !mInitDone && NGUITools.GetActive(base.gameObject))
		{
			Init();
		}
		if (sorted)
		{
			sorted = false;
			if (sorting == Sorting.None)
			{
				sorting = Sorting.Alphabetic;
			}
			NGUITools.SetDirty(this);
		}
		List<Transform> childList = GetChildList();
		ResetPosition(childList);
		if (keepWithinPanel)
		{
			ConstrainWithinPanel();
		}
		if (onReposition != null)
		{
			onReposition();
		}
	}

	public void ConstrainWithinPanel()
	{
		if (mPanel != null)
		{
			mPanel.ConstrainTargetToBounds(base.transform, immediate: true);
			UIScrollView component = mPanel.GetComponent<UIScrollView>();
			if (component != null)
			{
				component.UpdateScrollbars(recalculateBounds: true);
			}
		}
	}

	protected virtual void ResetPosition(List<Transform> list)
	{
		mReposition = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int i = 0;
		for (int count = list.Count; i < count; i++)
		{
			Transform transform = list[i];
			Vector3 vector = transform.localPosition;
			float z = vector.z;
			if (arrangement == Arrangement.CellSnap)
			{
				if (cellWidth > 0f)
				{
					vector.x = Mathf.Round(vector.x / cellWidth) * cellWidth;
				}
				if (cellHeight > 0f)
				{
					vector.y = Mathf.Round(vector.y / cellHeight) * cellHeight;
				}
			}
			else
			{
				vector = ((arrangement == Arrangement.Horizontal) ? new Vector3(cellWidth * (float)num, (0f - cellHeight) * (float)num2, z) : new Vector3(cellWidth * (float)num2, (0f - cellHeight) * (float)num, z));
			}
			if (animateSmoothly && Application.isPlaying && (pivot != 0 || Vector3.SqrMagnitude(transform.localPosition - vector) >= 0.0001f))
			{
				SpringPosition springPosition = SpringPosition.Begin(transform.gameObject, vector, 15f);
				springPosition.updateScrollView = true;
				springPosition.ignoreTimeScale = true;
			}
			else
			{
				transform.localPosition = vector;
			}
			num3 = Mathf.Max(num3, num);
			num4 = Mathf.Max(num4, num2);
			if (++num >= maxPerLine && maxPerLine > 0)
			{
				num = 0;
				num2++;
			}
		}
		if (pivot == UIWidget.Pivot.TopLeft)
		{
			return;
		}
		Vector2 pivotOffset = NGUIMath.GetPivotOffset(pivot);
		float num5;
		float num6;
		if (arrangement == Arrangement.Horizontal)
		{
			num5 = Mathf.Lerp(0f, (float)num3 * cellWidth, pivotOffset.x);
			num6 = Mathf.Lerp((float)(-num4) * cellHeight, 0f, pivotOffset.y);
		}
		else
		{
			num5 = Mathf.Lerp(0f, (float)num4 * cellWidth, pivotOffset.x);
			num6 = Mathf.Lerp((float)(-num3) * cellHeight, 0f, pivotOffset.y);
		}
		foreach (Transform item in list)
		{
			SpringPosition component = item.GetComponent<SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
				component.target.x -= num5;
				component.target.y -= num6;
				component.enabled = true;
			}
			else
			{
				Vector3 localPosition = item.localPosition;
				localPosition.x -= num5;
				localPosition.y -= num6;
				item.localPosition = localPosition;
			}
		}
	}
}
