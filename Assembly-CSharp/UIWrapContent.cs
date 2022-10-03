// Decompiled with JetBrains decompiler
// Type: UIWrapContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Wrap Content")]
public class UIWrapContent : MonoBehaviour
{
  public int itemSize = 100;
  public bool cullContent = true;
  public int minIndex;
  public int maxIndex;
  public bool hideInactive;
  public UIWrapContent.OnInitializeItem onInitializeItem;
  protected Transform mTrans;
  protected UIPanel mPanel;
  protected UIScrollView mScroll;
  protected bool mHorizontal;
  protected bool mFirstTime = true;
  protected List<Transform> mChildren = new List<Transform>();

  protected virtual void Start()
  {
    this.SortBasedOnScrollMovement();
    this.WrapContent();
    if ((UnityEngine.Object) this.mScroll != (UnityEngine.Object) null)
      this.mScroll.GetComponent<UIPanel>().onClipMove = new UIPanel.OnClippingMoved(this.OnMove);
    this.mFirstTime = false;
  }

  protected virtual void OnMove(UIPanel panel) => this.WrapContent();

  [ContextMenu("Sort Based on Scroll Movement")]
  public virtual void SortBasedOnScrollMovement()
  {
    if (!this.CacheScrollView())
      return;
    this.mChildren.Clear();
    for (int index = 0; index < this.mTrans.childCount; ++index)
    {
      Transform child = this.mTrans.GetChild(index);
      if (!this.hideInactive || child.gameObject.activeInHierarchy)
        this.mChildren.Add(child);
    }
    if (this.mHorizontal)
      this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
    else
      this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortVertical));
    this.ResetChildPositions();
  }

  [ContextMenu("Sort Alphabetically")]
  public virtual void SortAlphabetically()
  {
    if (!this.CacheScrollView())
      return;
    this.mChildren.Clear();
    for (int index = 0; index < this.mTrans.childCount; ++index)
    {
      Transform child = this.mTrans.GetChild(index);
      if (!this.hideInactive || child.gameObject.activeInHierarchy)
        this.mChildren.Add(child);
    }
    this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortByName));
    this.ResetChildPositions();
  }

  protected bool CacheScrollView()
  {
    this.mTrans = this.transform;
    this.mPanel = NGUITools.FindInParents<UIPanel>(this.gameObject);
    this.mScroll = this.mPanel.GetComponent<UIScrollView>();
    if ((UnityEngine.Object) this.mScroll == (UnityEngine.Object) null)
      return false;
    if (this.mScroll.movement == UIScrollView.Movement.Horizontal)
    {
      this.mHorizontal = true;
    }
    else
    {
      if (this.mScroll.movement != UIScrollView.Movement.Vertical)
        return false;
      this.mHorizontal = false;
    }
    return true;
  }

  protected virtual void ResetChildPositions()
  {
    int index = 0;
    for (int count = this.mChildren.Count; index < count; ++index)
    {
      Transform mChild = this.mChildren[index];
      mChild.localPosition = this.mHorizontal ? new Vector3((float) (index * this.itemSize), 0.0f, 0.0f) : new Vector3(0.0f, (float) (-index * this.itemSize), 0.0f);
      this.UpdateItem(mChild, index);
    }
  }

  public virtual void WrapContent()
  {
    float num1 = (float) (this.itemSize * this.mChildren.Count) * 0.5f;
    Vector3[] worldCorners = this.mPanel.worldCorners;
    for (int index = 0; index < 4; ++index)
    {
      Vector3 vector3 = this.mTrans.InverseTransformPoint(worldCorners[index]);
      worldCorners[index] = vector3;
    }
    Vector3 vector3_1 = Vector3.Lerp(worldCorners[0], worldCorners[2], 0.5f);
    bool flag = true;
    float num2 = num1 * 2f;
    if (this.mHorizontal)
    {
      float num3 = worldCorners[0].x - (float) this.itemSize;
      float num4 = worldCorners[2].x + (float) this.itemSize;
      int index = 0;
      for (int count = this.mChildren.Count; index < count; ++index)
      {
        Transform mChild = this.mChildren[index];
        float num5 = mChild.localPosition.x - vector3_1.x;
        if ((double) num5 < -(double) num1)
        {
          Vector3 localPosition = mChild.localPosition;
          localPosition.x += num2;
          num5 = localPosition.x - vector3_1.x;
          int num6 = Mathf.RoundToInt(localPosition.x / (float) this.itemSize);
          if (this.minIndex == this.maxIndex || this.minIndex <= num6 && num6 <= this.maxIndex)
          {
            mChild.localPosition = localPosition;
            this.UpdateItem(mChild, index);
          }
          else
            flag = false;
        }
        else if ((double) num5 > (double) num1)
        {
          Vector3 localPosition = mChild.localPosition;
          localPosition.x -= num2;
          num5 = localPosition.x - vector3_1.x;
          int num7 = Mathf.RoundToInt(localPosition.x / (float) this.itemSize);
          if (this.minIndex == this.maxIndex || this.minIndex <= num7 && num7 <= this.maxIndex)
          {
            mChild.localPosition = localPosition;
            this.UpdateItem(mChild, index);
          }
          else
            flag = false;
        }
        else if (this.mFirstTime)
          this.UpdateItem(mChild, index);
        if (this.cullContent)
        {
          float num8 = num5 + (this.mPanel.clipOffset.x - this.mTrans.localPosition.x);
          if (!UICamera.IsPressed(mChild.gameObject))
            NGUITools.SetActive(mChild.gameObject, (double) num8 > (double) num3 && (double) num8 < (double) num4, false);
        }
      }
    }
    else
    {
      float num9 = worldCorners[0].y - (float) this.itemSize;
      float num10 = worldCorners[2].y + (float) this.itemSize;
      int index = 0;
      for (int count = this.mChildren.Count; index < count; ++index)
      {
        Transform mChild = this.mChildren[index];
        float num11 = mChild.localPosition.y - vector3_1.y;
        if ((double) num11 < -(double) num1)
        {
          Vector3 localPosition = mChild.localPosition;
          localPosition.y += num2;
          num11 = localPosition.y - vector3_1.y;
          int num12 = Mathf.RoundToInt(localPosition.y / (float) this.itemSize);
          if (this.minIndex == this.maxIndex || this.minIndex <= num12 && num12 <= this.maxIndex)
          {
            mChild.localPosition = localPosition;
            this.UpdateItem(mChild, index);
          }
          else
            flag = false;
        }
        else if ((double) num11 > (double) num1)
        {
          Vector3 localPosition = mChild.localPosition;
          localPosition.y -= num2;
          num11 = localPosition.y - vector3_1.y;
          int num13 = Mathf.RoundToInt(localPosition.y / (float) this.itemSize);
          if (this.minIndex == this.maxIndex || this.minIndex <= num13 && num13 <= this.maxIndex)
          {
            mChild.localPosition = localPosition;
            this.UpdateItem(mChild, index);
          }
          else
            flag = false;
        }
        else if (this.mFirstTime)
          this.UpdateItem(mChild, index);
        if (this.cullContent)
        {
          float num14 = num11 + (this.mPanel.clipOffset.y - this.mTrans.localPosition.y);
          if (!UICamera.IsPressed(mChild.gameObject))
            NGUITools.SetActive(mChild.gameObject, (double) num14 > (double) num9 && (double) num14 < (double) num10, false);
        }
      }
    }
    this.mScroll.restrictWithinPanel = !flag;
    this.mScroll.InvalidateBounds();
  }

  private void OnValidate()
  {
    if (this.maxIndex < this.minIndex)
      this.maxIndex = this.minIndex;
    if (this.minIndex <= this.maxIndex)
      return;
    this.maxIndex = this.minIndex;
  }

  protected virtual void UpdateItem(Transform item, int index)
  {
    if (this.onInitializeItem == null)
      return;
    int realIndex = this.mScroll.movement == UIScrollView.Movement.Vertical ? Mathf.RoundToInt(item.localPosition.y / (float) this.itemSize) : Mathf.RoundToInt(item.localPosition.x / (float) this.itemSize);
    this.onInitializeItem(item.gameObject, index, realIndex);
  }

  public delegate void OnInitializeItem(GameObject go, int wrapIndex, int realIndex);
}
