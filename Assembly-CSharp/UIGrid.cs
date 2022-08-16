// Decompiled with JetBrains decompiler
// Type: UIGrid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Grid")]
public class UIGrid : UIWidgetContainer
{
  public UIGrid.Arrangement arrangement;
  public UIGrid.Sorting sorting;
  public UIWidget.Pivot pivot;
  public int maxPerLine;
  public float cellWidth = 200f;
  public float cellHeight = 200f;
  public bool animateSmoothly;
  public bool hideInactive;
  public bool keepWithinPanel;
  public UIGrid.OnReposition onReposition;
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
      if (!value)
        return;
      this.mReposition = true;
      this.enabled = true;
    }
  }

  public List<Transform> GetChildList()
  {
    Transform transform = this.transform;
    List<Transform> list = new List<Transform>();
    for (int index = 0; index < transform.childCount; ++index)
    {
      Transform child = transform.GetChild(index);
      if ((!this.hideInactive || (bool) (UnityEngine.Object) child && child.gameObject.activeSelf) && !UIDragDropItem.IsDragged(child.gameObject))
        list.Add(child);
    }
    if (this.sorting != UIGrid.Sorting.None && this.arrangement != UIGrid.Arrangement.CellSnap)
    {
      if (this.sorting == UIGrid.Sorting.Alphabetic)
        list.Sort(new Comparison<Transform>(UIGrid.SortByName));
      else if (this.sorting == UIGrid.Sorting.Horizontal)
        list.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
      else if (this.sorting == UIGrid.Sorting.Vertical)
        list.Sort(new Comparison<Transform>(UIGrid.SortVertical));
      else if (this.onCustomSort != null)
        list.Sort(this.onCustomSort);
      else
        this.Sort(list);
    }
    return list;
  }

  public Transform GetChild(int index)
  {
    List<Transform> childList = this.GetChildList();
    return index >= childList.Count ? (Transform) null : childList[index];
  }

  public int GetIndex(Transform trans) => this.GetChildList().IndexOf(trans);

  [Obsolete("Use gameObject.AddChild or transform.parent = gridTransform")]
  public void AddChild(Transform trans)
  {
    if (!((UnityEngine.Object) trans != (UnityEngine.Object) null))
      return;
    trans.parent = this.transform;
    this.ResetPosition(this.GetChildList());
  }

  [Obsolete("Use gameObject.AddChild or transform.parent = gridTransform")]
  public void AddChild(Transform trans, bool sort)
  {
    if (!((UnityEngine.Object) trans != (UnityEngine.Object) null))
      return;
    trans.parent = this.transform;
    this.ResetPosition(this.GetChildList());
  }

  public bool RemoveChild(Transform t)
  {
    List<Transform> childList = this.GetChildList();
    if (!childList.Remove(t))
      return false;
    this.ResetPosition(childList);
    return true;
  }

  protected virtual void Init()
  {
    this.mInitDone = true;
    this.mPanel = NGUITools.FindInParents<UIPanel>(this.gameObject);
  }

  protected virtual void Start()
  {
    if (!this.mInitDone)
      this.Init();
    bool animateSmoothly = this.animateSmoothly;
    this.animateSmoothly = false;
    this.Reposition();
    this.animateSmoothly = animateSmoothly;
    this.enabled = false;
  }

  protected virtual void Update()
  {
    this.Reposition();
    this.enabled = false;
  }

  private void OnValidate()
  {
    if (Application.isPlaying || !NGUITools.GetActive((Behaviour) this))
      return;
    this.Reposition();
  }

  public static int SortByName(Transform a, Transform b) => string.Compare(a.name, b.name);

  public static int SortHorizontal(Transform a, Transform b) => a.localPosition.x.CompareTo(b.localPosition.x);

  public static int SortVertical(Transform a, Transform b) => b.localPosition.y.CompareTo(a.localPosition.y);

  protected virtual void Sort(List<Transform> list)
  {
  }

  [ContextMenu("Execute")]
  public virtual void Reposition()
  {
    if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive(this.gameObject))
      this.Init();
    if (this.sorted)
    {
      this.sorted = false;
      if (this.sorting == UIGrid.Sorting.None)
        this.sorting = UIGrid.Sorting.Alphabetic;
      NGUITools.SetDirty((UnityEngine.Object) this);
    }
    this.ResetPosition(this.GetChildList());
    if (this.keepWithinPanel)
      this.ConstrainWithinPanel();
    if (this.onReposition == null)
      return;
    this.onReposition();
  }

  public void ConstrainWithinPanel()
  {
    if (!((UnityEngine.Object) this.mPanel != (UnityEngine.Object) null))
      return;
    this.mPanel.ConstrainTargetToBounds(this.transform, true);
    UIScrollView component = this.mPanel.GetComponent<UIScrollView>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.UpdateScrollbars(true);
  }

  protected virtual void ResetPosition(List<Transform> list)
  {
    this.mReposition = false;
    int b1 = 0;
    int b2 = 0;
    int a1 = 0;
    int a2 = 0;
    int index = 0;
    for (int count = list.Count; index < count; ++index)
    {
      Transform transform = list[index];
      Vector3 pos = transform.localPosition;
      float z = pos.z;
      if (this.arrangement == UIGrid.Arrangement.CellSnap)
      {
        if ((double) this.cellWidth > 0.0)
          pos.x = Mathf.Round(pos.x / this.cellWidth) * this.cellWidth;
        if ((double) this.cellHeight > 0.0)
          pos.y = Mathf.Round(pos.y / this.cellHeight) * this.cellHeight;
      }
      else
        pos = this.arrangement == UIGrid.Arrangement.Horizontal ? new Vector3(this.cellWidth * (float) b1, -this.cellHeight * (float) b2, z) : new Vector3(this.cellWidth * (float) b2, -this.cellHeight * (float) b1, z);
      if (this.animateSmoothly && Application.isPlaying && (this.pivot != UIWidget.Pivot.TopLeft || (double) Vector3.SqrMagnitude(transform.localPosition - pos) >= 9.9999997473787516E-05))
      {
        SpringPosition springPosition = SpringPosition.Begin(transform.gameObject, pos, 15f);
        springPosition.updateScrollView = true;
        springPosition.ignoreTimeScale = true;
      }
      else
        transform.localPosition = pos;
      a1 = Mathf.Max(a1, b1);
      a2 = Mathf.Max(a2, b2);
      if (++b1 >= this.maxPerLine && this.maxPerLine > 0)
      {
        b1 = 0;
        ++b2;
      }
    }
    if (this.pivot == UIWidget.Pivot.TopLeft)
      return;
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.pivot);
    float num1;
    float num2;
    if (this.arrangement == UIGrid.Arrangement.Horizontal)
    {
      num1 = Mathf.Lerp(0.0f, (float) a1 * this.cellWidth, pivotOffset.x);
      num2 = Mathf.Lerp((float) -a2 * this.cellHeight, 0.0f, pivotOffset.y);
    }
    else
    {
      num1 = Mathf.Lerp(0.0f, (float) a2 * this.cellWidth, pivotOffset.x);
      num2 = Mathf.Lerp((float) -a1 * this.cellHeight, 0.0f, pivotOffset.y);
    }
    foreach (Transform transform in list)
    {
      SpringPosition component = transform.GetComponent<SpringPosition>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        component.enabled = false;
        component.target.x -= num1;
        component.target.y -= num2;
        component.enabled = true;
      }
      else
      {
        Vector3 localPosition = transform.localPosition;
        localPosition.x -= num1;
        localPosition.y -= num2;
        transform.localPosition = localPosition;
      }
    }
  }

  public delegate void OnReposition();

  [DoNotObfuscateNGUI]
  public enum Arrangement
  {
    Horizontal,
    Vertical,
    CellSnap,
  }

  [DoNotObfuscateNGUI]
  public enum Sorting
  {
    None,
    Alphabetic,
    Horizontal,
    Vertical,
    Custom,
  }
}
