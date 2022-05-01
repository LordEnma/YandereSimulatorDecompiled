using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000057 RID: 87
[AddComponentMenu("NGUI/Interaction/Grid")]
public class UIGrid : UIWidgetContainer
{
	// Token: 0x17000017 RID: 23
	// (set) Token: 0x060001C0 RID: 448 RVA: 0x0001787E File Offset: 0x00015A7E
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

	// Token: 0x060001C1 RID: 449 RVA: 0x00017894 File Offset: 0x00015A94
	public List<Transform> GetChildList()
	{
		Transform transform = base.transform;
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if ((!this.hideInactive || (child && child.gameObject.activeSelf)) && !UIDragDropItem.IsDragged(child.gameObject))
			{
				list.Add(child);
			}
		}
		if (this.sorting != UIGrid.Sorting.None && this.arrangement != UIGrid.Arrangement.CellSnap)
		{
			if (this.sorting == UIGrid.Sorting.Alphabetic)
			{
				list.Sort(new Comparison<Transform>(UIGrid.SortByName));
			}
			else if (this.sorting == UIGrid.Sorting.Horizontal)
			{
				list.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
			}
			else if (this.sorting == UIGrid.Sorting.Vertical)
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

	// Token: 0x060001C2 RID: 450 RVA: 0x00017980 File Offset: 0x00015B80
	public Transform GetChild(int index)
	{
		List<Transform> childList = this.GetChildList();
		if (index >= childList.Count)
		{
			return null;
		}
		return childList[index];
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x000179A6 File Offset: 0x00015BA6
	public int GetIndex(Transform trans)
	{
		return this.GetChildList().IndexOf(trans);
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x000179B4 File Offset: 0x00015BB4
	[Obsolete("Use gameObject.AddChild or transform.parent = gridTransform")]
	public void AddChild(Transform trans)
	{
		if (trans != null)
		{
			trans.parent = base.transform;
			this.ResetPosition(this.GetChildList());
		}
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x000179D7 File Offset: 0x00015BD7
	[Obsolete("Use gameObject.AddChild or transform.parent = gridTransform")]
	public void AddChild(Transform trans, bool sort)
	{
		if (trans != null)
		{
			trans.parent = base.transform;
			this.ResetPosition(this.GetChildList());
		}
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x000179FC File Offset: 0x00015BFC
	public bool RemoveChild(Transform t)
	{
		List<Transform> childList = this.GetChildList();
		if (childList.Remove(t))
		{
			this.ResetPosition(childList);
			return true;
		}
		return false;
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x00017A23 File Offset: 0x00015C23
	protected virtual void Init()
	{
		this.mInitDone = true;
		this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00017A40 File Offset: 0x00015C40
	protected virtual void Start()
	{
		if (!this.mInitDone)
		{
			this.Init();
		}
		bool flag = this.animateSmoothly;
		this.animateSmoothly = false;
		this.Reposition();
		this.animateSmoothly = flag;
		base.enabled = false;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00017A7D File Offset: 0x00015C7D
	protected virtual void Update()
	{
		this.Reposition();
		base.enabled = false;
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00017A8C File Offset: 0x00015C8C
	private void OnValidate()
	{
		if (!Application.isPlaying && NGUITools.GetActive(this))
		{
			this.Reposition();
		}
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00017AA3 File Offset: 0x00015CA3
	public static int SortByName(Transform a, Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00017AB8 File Offset: 0x00015CB8
	public static int SortHorizontal(Transform a, Transform b)
	{
		return a.localPosition.x.CompareTo(b.localPosition.x);
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00017AE4 File Offset: 0x00015CE4
	public static int SortVertical(Transform a, Transform b)
	{
		return b.localPosition.y.CompareTo(a.localPosition.y);
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00017B0F File Offset: 0x00015D0F
	protected virtual void Sort(List<Transform> list)
	{
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00017B14 File Offset: 0x00015D14
	[ContextMenu("Execute")]
	public virtual void Reposition()
	{
		if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive(base.gameObject))
		{
			this.Init();
		}
		if (this.sorted)
		{
			this.sorted = false;
			if (this.sorting == UIGrid.Sorting.None)
			{
				this.sorting = UIGrid.Sorting.Alphabetic;
			}
			NGUITools.SetDirty(this, "last change");
		}
		List<Transform> childList = this.GetChildList();
		this.ResetPosition(childList);
		if (this.keepWithinPanel)
		{
			this.ConstrainWithinPanel();
		}
		if (this.onReposition != null)
		{
			this.onReposition();
		}
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00017B9C File Offset: 0x00015D9C
	public void ConstrainWithinPanel()
	{
		if (this.mPanel != null)
		{
			this.mPanel.ConstrainTargetToBounds(base.transform, true);
			UIScrollView component = this.mPanel.GetComponent<UIScrollView>();
			if (component != null)
			{
				component.UpdateScrollbars(true);
			}
		}
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00017BE8 File Offset: 0x00015DE8
	protected virtual void ResetPosition(List<Transform> list)
	{
		this.mReposition = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int i = 0;
		int count = list.Count;
		while (i < count)
		{
			Transform transform = list[i];
			Vector3 vector = transform.localPosition;
			float z = vector.z;
			if (this.arrangement == UIGrid.Arrangement.CellSnap)
			{
				if (this.cellWidth > 0f)
				{
					vector.x = Mathf.Round(vector.x / this.cellWidth) * this.cellWidth;
				}
				if (this.cellHeight > 0f)
				{
					vector.y = Mathf.Round(vector.y / this.cellHeight) * this.cellHeight;
				}
			}
			else
			{
				vector = ((this.arrangement == UIGrid.Arrangement.Horizontal) ? new Vector3(this.cellWidth * (float)num, -this.cellHeight * (float)num2, z) : new Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num, z));
			}
			if (this.animateSmoothly && Application.isPlaying && (this.pivot != UIWidget.Pivot.TopLeft || Vector3.SqrMagnitude(transform.localPosition - vector) >= 0.0001f))
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
			if (++num >= this.maxPerLine && this.maxPerLine > 0)
			{
				num = 0;
				num2++;
			}
			i++;
		}
		if (this.pivot != UIWidget.Pivot.TopLeft)
		{
			Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.pivot);
			float num5;
			float num6;
			if (this.arrangement == UIGrid.Arrangement.Horizontal)
			{
				num5 = Mathf.Lerp(0f, (float)num3 * this.cellWidth, pivotOffset.x);
				num6 = Mathf.Lerp((float)(-(float)num4) * this.cellHeight, 0f, pivotOffset.y);
			}
			else
			{
				num5 = Mathf.Lerp(0f, (float)num4 * this.cellWidth, pivotOffset.x);
				num6 = Mathf.Lerp((float)(-(float)num3) * this.cellHeight, 0f, pivotOffset.y);
			}
			foreach (Transform transform2 in list)
			{
				SpringPosition component = transform2.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
					SpringPosition springPosition2 = component;
					springPosition2.target.x = springPosition2.target.x - num5;
					SpringPosition springPosition3 = component;
					springPosition3.target.y = springPosition3.target.y - num6;
					component.enabled = true;
				}
				else
				{
					Vector3 localPosition = transform2.localPosition;
					localPosition.x -= num5;
					localPosition.y -= num6;
					transform2.localPosition = localPosition;
				}
			}
		}
	}

	// Token: 0x04000389 RID: 905
	public UIGrid.Arrangement arrangement;

	// Token: 0x0400038A RID: 906
	public UIGrid.Sorting sorting;

	// Token: 0x0400038B RID: 907
	public UIWidget.Pivot pivot;

	// Token: 0x0400038C RID: 908
	public int maxPerLine;

	// Token: 0x0400038D RID: 909
	public float cellWidth = 200f;

	// Token: 0x0400038E RID: 910
	public float cellHeight = 200f;

	// Token: 0x0400038F RID: 911
	public bool animateSmoothly;

	// Token: 0x04000390 RID: 912
	public bool hideInactive;

	// Token: 0x04000391 RID: 913
	public bool keepWithinPanel;

	// Token: 0x04000392 RID: 914
	public UIGrid.OnReposition onReposition;

	// Token: 0x04000393 RID: 915
	public Comparison<Transform> onCustomSort;

	// Token: 0x04000394 RID: 916
	[HideInInspector]
	[SerializeField]
	private bool sorted;

	// Token: 0x04000395 RID: 917
	protected bool mReposition;

	// Token: 0x04000396 RID: 918
	protected UIPanel mPanel;

	// Token: 0x04000397 RID: 919
	protected bool mInitDone;

	// Token: 0x020005D5 RID: 1493
	// (Invoke) Token: 0x06002552 RID: 9554
	public delegate void OnReposition();

	// Token: 0x020005D6 RID: 1494
	[DoNotObfuscateNGUI]
	public enum Arrangement
	{
		// Token: 0x04004E14 RID: 19988
		Horizontal,
		// Token: 0x04004E15 RID: 19989
		Vertical,
		// Token: 0x04004E16 RID: 19990
		CellSnap
	}

	// Token: 0x020005D7 RID: 1495
	[DoNotObfuscateNGUI]
	public enum Sorting
	{
		// Token: 0x04004E18 RID: 19992
		None,
		// Token: 0x04004E19 RID: 19993
		Alphabetic,
		// Token: 0x04004E1A RID: 19994
		Horizontal,
		// Token: 0x04004E1B RID: 19995
		Vertical,
		// Token: 0x04004E1C RID: 19996
		Custom
	}
}
