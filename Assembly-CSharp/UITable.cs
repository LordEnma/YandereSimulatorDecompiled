// Decompiled with JetBrains decompiler
// Type: UITable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Table")]
public class UITable : UIWidgetContainer
{
  public int columns;
  public UITable.Direction direction;
  public UITable.Sorting sorting;
  public UIWidget.Pivot pivot;
  public UIWidget.Pivot cellAlignment;
  public bool hideInactive = true;
  public bool keepWithinPanel;
  public Vector2 padding = Vector2.zero;
  public UITable.OnReposition onReposition;
  public Comparison<Transform> onCustomSort;
  protected UIPanel mPanel;
  protected bool mInitDone;
  protected bool mReposition;

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
      if (!this.hideInactive || (bool) (UnityEngine.Object) child && NGUITools.GetActive(child.gameObject))
        list.Add(child);
    }
    if (this.sorting != UITable.Sorting.None)
    {
      if (this.sorting == UITable.Sorting.Alphabetic)
        list.Sort(new Comparison<Transform>(UIGrid.SortByName));
      else if (this.sorting == UITable.Sorting.Horizontal)
        list.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
      else if (this.sorting == UITable.Sorting.Vertical)
        list.Sort(new Comparison<Transform>(UIGrid.SortVertical));
      else if (this.onCustomSort != null)
        list.Sort(this.onCustomSort);
      else
        this.Sort(list);
    }
    return list;
  }

  protected virtual void Sort(List<Transform> list) => list.Sort(new Comparison<Transform>(UIGrid.SortByName));

  protected virtual void Start()
  {
    this.Init();
    this.Reposition();
    this.enabled = false;
  }

  protected virtual void Init()
  {
    this.mInitDone = true;
    this.mPanel = NGUITools.FindInParents<UIPanel>(this.gameObject);
  }

  protected virtual void LateUpdate()
  {
    if (this.mReposition)
      this.Reposition();
    this.enabled = false;
  }

  private void OnValidate()
  {
    if (Application.isPlaying || !NGUITools.GetActive((Behaviour) this))
      return;
    this.Reposition();
  }

  protected void RepositionVariableSize(List<Transform> children)
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    int length1 = this.columns > 0 ? children.Count / this.columns + 1 : 1;
    int length2 = this.columns > 0 ? this.columns : children.Count;
    Bounds[,] boundsArray1 = new Bounds[length1, length2];
    Bounds[] boundsArray2 = new Bounds[length2];
    Bounds[] boundsArray3 = new Bounds[length1];
    int index1 = 0;
    int index2 = 0;
    int index3 = 0;
    for (int count = children.Count; index3 < count; ++index3)
    {
      Transform child = children[index3];
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(child, !this.hideInactive);
      Vector3 localScale = child.localScale;
      relativeWidgetBounds.min = Vector3.Scale(relativeWidgetBounds.min, localScale);
      relativeWidgetBounds.max = Vector3.Scale(relativeWidgetBounds.max, localScale);
      boundsArray1[index2, index1] = relativeWidgetBounds;
      boundsArray2[index1].Encapsulate(relativeWidgetBounds);
      boundsArray3[index2].Encapsulate(relativeWidgetBounds);
      if (++index1 >= this.columns && this.columns > 0)
      {
        index1 = 0;
        ++index2;
      }
    }
    int index4 = 0;
    int index5 = 0;
    Vector2 pivotOffset1 = NGUIMath.GetPivotOffset(this.cellAlignment);
    int index6 = 0;
    for (int count = children.Count; index6 < count; ++index6)
    {
      Transform child = children[index6];
      Bounds bounds1 = boundsArray1[index5, index4];
      Bounds bounds2 = boundsArray2[index4];
      Bounds bounds3 = boundsArray3[index5];
      Vector3 localPosition = child.localPosition with
      {
        x = num1 + bounds1.extents.x - bounds1.center.x
      };
      localPosition.x -= Mathf.Lerp(0.0f, bounds1.max.x - bounds1.min.x - bounds2.max.x + bounds2.min.x, pivotOffset1.x) - this.padding.x;
      if (this.direction == UITable.Direction.Down)
      {
        localPosition.y = -num2 - bounds1.extents.y - bounds1.center.y;
        localPosition.y += Mathf.Lerp(bounds1.max.y - bounds1.min.y - bounds3.max.y + bounds3.min.y, 0.0f, pivotOffset1.y) - this.padding.y;
      }
      else
      {
        localPosition.y = num2 + bounds1.extents.y - bounds1.center.y;
        localPosition.y -= Mathf.Lerp(0.0f, bounds1.max.y - bounds1.min.y - bounds3.max.y + bounds3.min.y, pivotOffset1.y) - this.padding.y;
      }
      num1 += bounds2.size.x + this.padding.x * 2f;
      child.localPosition = localPosition;
      if (++index4 >= this.columns && this.columns > 0)
      {
        index4 = 0;
        ++index5;
        num1 = 0.0f;
        num2 += bounds3.size.y + this.padding.y * 2f;
      }
    }
    if (this.pivot == UIWidget.Pivot.TopLeft)
      return;
    Vector2 pivotOffset2 = NGUIMath.GetPivotOffset(this.pivot);
    Bounds relativeWidgetBounds1 = NGUIMath.CalculateRelativeWidgetBounds(this.transform);
    float num3 = Mathf.Lerp(0.0f, relativeWidgetBounds1.size.x, pivotOffset2.x);
    float num4 = Mathf.Lerp(-relativeWidgetBounds1.size.y, 0.0f, pivotOffset2.y);
    Transform transform = this.transform;
    for (int index7 = 0; index7 < transform.childCount; ++index7)
    {
      Transform child = transform.GetChild(index7);
      SpringPosition component = child.GetComponent<SpringPosition>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        component.enabled = false;
        component.target.x -= num3;
        component.target.y -= num4;
        component.enabled = true;
      }
      else
      {
        Vector3 localPosition = child.localPosition;
        localPosition.x -= num3;
        localPosition.y -= num4;
        child.localPosition = localPosition;
      }
    }
  }

  [ContextMenu("Execute")]
  public virtual void Reposition()
  {
    if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive((Behaviour) this))
      this.Init();
    this.mReposition = false;
    Transform transform = this.transform;
    List<Transform> childList = this.GetChildList();
    if (childList.Count > 0)
      this.RepositionVariableSize(childList);
    if (this.keepWithinPanel && (UnityEngine.Object) this.mPanel != (UnityEngine.Object) null)
    {
      this.mPanel.ConstrainTargetToBounds(transform, true);
      UIScrollView component = this.mPanel.GetComponent<UIScrollView>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.UpdateScrollbars(true);
    }
    if (this.onReposition == null)
      return;
    this.onReposition();
  }

  public delegate void OnReposition();

  [DoNotObfuscateNGUI]
  public enum Direction
  {
    Down,
    Up,
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
