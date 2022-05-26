// Decompiled with JetBrains decompiler
// Type: UICenterOnChild
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Center Scroll View on Child")]
public class UICenterOnChild : MonoBehaviour
{
  public float springStrength = 8f;
  public float nextPageThreshold;
  public SpringPanel.OnFinished onFinished;
  public UICenterOnChild.OnCenterCallback onCenter;
  private UIScrollView mScrollView;
  private GameObject mCenteredObject;

  public GameObject centeredObject => this.mCenteredObject;

  private void Start() => this.Recenter();

  private void OnEnable()
  {
    if (!(bool) (Object) this.mScrollView)
      return;
    this.mScrollView.centerOnChild = this;
    this.Recenter();
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.mScrollView)
      return;
    this.mScrollView.centerOnChild = (UICenterOnChild) null;
  }

  private void OnDragFinished()
  {
    if (!this.enabled)
      return;
    this.Recenter();
  }

  private void OnValidate() => this.nextPageThreshold = Mathf.Abs(this.nextPageThreshold);

  [ContextMenu("Execute")]
  public void Recenter()
  {
    if ((Object) this.mScrollView == (Object) null)
    {
      this.mScrollView = NGUITools.FindInParents<UIScrollView>(this.gameObject);
      if ((Object) this.mScrollView == (Object) null)
      {
        Debug.LogWarning((object) (((object) this).GetType()?.ToString() + " requires " + typeof (UIScrollView)?.ToString() + " on a parent object in order to work"), (Object) this);
        this.enabled = false;
        return;
      }
      if ((bool) (Object) this.mScrollView)
        this.mScrollView.centerOnChild = this;
      if ((Object) this.mScrollView.horizontalScrollBar != (Object) null)
        this.mScrollView.horizontalScrollBar.onDragFinished += new UIProgressBar.OnDragFinished(this.OnDragFinished);
      if ((Object) this.mScrollView.verticalScrollBar != (Object) null)
        this.mScrollView.verticalScrollBar.onDragFinished += new UIProgressBar.OnDragFinished(this.OnDragFinished);
    }
    if ((Object) this.mScrollView.panel == (Object) null)
      return;
    Transform transform1 = this.transform;
    if (transform1.childCount == 0)
      return;
    Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
    Vector3 panelCenter = (worldCorners[2] + worldCorners[0]) * 0.5f;
    Vector3 velocity = this.mScrollView.currentMomentum * this.mScrollView.momentumAmount;
    Vector3 vector3_1 = NGUIMath.SpringDampen(ref velocity, 9f, 2f);
    Vector3 vector3_2 = panelCenter - vector3_1 * 0.01f;
    float num1 = float.MaxValue;
    Transform target = (Transform) null;
    int index1 = 0;
    int num2 = 0;
    UIGrid component = this.GetComponent<UIGrid>();
    List<Transform> transformList = (List<Transform>) null;
    if ((Object) component != (Object) null)
    {
      transformList = component.GetChildList();
      int index2 = 0;
      int count = transformList.Count;
      int num3 = 0;
      for (; index2 < count; ++index2)
      {
        Transform transform2 = transformList[index2];
        if (transform2.gameObject.activeInHierarchy)
        {
          float num4 = Vector3.SqrMagnitude(transform2.position - vector3_2);
          if ((double) num4 < (double) num1)
          {
            num1 = num4;
            target = transform2;
            index1 = index2;
            num2 = num3;
          }
          ++num3;
        }
      }
    }
    else
    {
      int index3 = 0;
      int childCount = transform1.childCount;
      int num5 = 0;
      for (; index3 < childCount; ++index3)
      {
        Transform child = transform1.GetChild(index3);
        if (child.gameObject.activeInHierarchy)
        {
          float num6 = Vector3.SqrMagnitude(child.position - vector3_2);
          if ((double) num6 < (double) num1)
          {
            num1 = num6;
            target = child;
            index1 = index3;
            num2 = num5;
          }
          ++num5;
        }
      }
    }
    if ((double) this.nextPageThreshold > 0.0 && UICamera.currentTouch != null && (Object) this.mCenteredObject != (Object) null && (Object) this.mCenteredObject.transform == (transformList != null ? (Object) transformList[index1] : (Object) transform1.GetChild(index1)))
    {
      Vector3 vector3_3 = this.transform.rotation * (Vector3) UICamera.currentTouch.totalDelta;
      float f;
      switch (this.mScrollView.movement)
      {
        case UIScrollView.Movement.Horizontal:
          f = vector3_3.x;
          break;
        case UIScrollView.Movement.Vertical:
          f = -vector3_3.y;
          break;
        default:
          f = vector3_3.magnitude;
          break;
      }
      if ((double) Mathf.Abs(f) > (double) this.nextPageThreshold)
      {
        if ((double) f > (double) this.nextPageThreshold)
          target = transformList == null ? (num2 <= 0 ? ((Object) this.GetComponent<UIWrapContent>() == (Object) null ? transform1.GetChild(0) : transform1.GetChild(transform1.childCount - 1)) : transform1.GetChild(num2 - 1)) : (num2 <= 0 ? ((Object) this.GetComponent<UIWrapContent>() == (Object) null ? transformList[0] : transformList[transformList.Count - 1]) : transformList[num2 - 1]);
        else if ((double) f < -(double) this.nextPageThreshold)
          target = transformList == null ? (num2 >= transform1.childCount - 1 ? ((Object) this.GetComponent<UIWrapContent>() == (Object) null ? transform1.GetChild(transform1.childCount - 1) : transform1.GetChild(0)) : transform1.GetChild(num2 + 1)) : (num2 >= transformList.Count - 1 ? ((Object) this.GetComponent<UIWrapContent>() == (Object) null ? transformList[transformList.Count - 1] : transformList[0]) : transformList[num2 + 1]);
      }
    }
    this.CenterOn(target, panelCenter);
  }

  private void CenterOn(Transform target, Vector3 panelCenter)
  {
    if ((Object) target != (Object) null && (Object) this.mScrollView != (Object) null && (Object) this.mScrollView.panel != (Object) null)
    {
      Transform cachedTransform = this.mScrollView.panel.cachedTransform;
      this.mCenteredObject = target.gameObject;
      Vector3 vector3 = cachedTransform.InverseTransformPoint(target.position) - cachedTransform.InverseTransformPoint(panelCenter);
      if (!this.mScrollView.canMoveHorizontally)
        vector3.x = 0.0f;
      if (!this.mScrollView.canMoveVertically)
        vector3.y = 0.0f;
      vector3.z = 0.0f;
      Vector3 pos = cachedTransform.localPosition - vector3;
      pos.x = Mathf.Round(pos.x);
      pos.y = Mathf.Round(pos.y);
      pos.z = Mathf.Round(pos.z);
      SpringPanel.Begin(this.mScrollView.panel.cachedGameObject, pos, this.springStrength).onFinished = this.onFinished;
    }
    else
      this.mCenteredObject = (GameObject) null;
    if (this.onCenter == null)
      return;
    this.onCenter(this.mCenteredObject);
  }

  public void CenterOn(Transform target)
  {
    if (!((Object) this.mScrollView != (Object) null) || !((Object) this.mScrollView.panel != (Object) null))
      return;
    Vector3[] worldCorners = this.mScrollView.panel.worldCorners;
    Vector3 panelCenter = (worldCorners[2] + worldCorners[0]) * 0.5f;
    this.CenterOn(target, panelCenter);
  }

  public delegate void OnCenterCallback(GameObject centeredObject);
}
