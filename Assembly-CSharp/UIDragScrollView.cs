// Decompiled with JetBrains decompiler
// Type: UIDragScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag Scroll View")]
public class UIDragScrollView : MonoBehaviour
{
  public UIScrollView scrollView;
  [HideInInspector]
  [SerializeField]
  private UIScrollView draggablePanel;
  private Transform mTrans;
  private UIScrollView mScroll;
  private bool mAutoFind;
  private bool mStarted;
  [NonSerialized]
  private bool mPressed;

  private void OnEnable()
  {
    this.mTrans = this.transform;
    if ((UnityEngine.Object) this.scrollView == (UnityEngine.Object) null && (UnityEngine.Object) this.draggablePanel != (UnityEngine.Object) null)
    {
      this.scrollView = this.draggablePanel;
      this.draggablePanel = (UIScrollView) null;
    }
    if (!this.mStarted || !this.mAutoFind && !((UnityEngine.Object) this.mScroll == (UnityEngine.Object) null))
      return;
    this.FindScrollView();
  }

  private void Start()
  {
    this.mStarted = true;
    this.FindScrollView();
  }

  private void FindScrollView()
  {
    UIScrollView inParents = NGUITools.FindInParents<UIScrollView>(this.mTrans);
    if ((UnityEngine.Object) this.scrollView == (UnityEngine.Object) null || this.mAutoFind && (UnityEngine.Object) inParents != (UnityEngine.Object) this.scrollView)
    {
      this.scrollView = inParents;
      this.mAutoFind = true;
    }
    else if ((UnityEngine.Object) this.scrollView == (UnityEngine.Object) inParents)
      this.mAutoFind = true;
    this.mScroll = this.scrollView;
  }

  private void OnDisable()
  {
    if (!this.mPressed || !((UnityEngine.Object) this.mScroll != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mScroll.GetComponentInChildren<UIWrapContent>() == (UnityEngine.Object) null))
      return;
    this.mScroll.Press(false);
    this.mScroll = (UIScrollView) null;
  }

  private void OnPress(bool pressed)
  {
    this.mPressed = pressed;
    if (this.mAutoFind && (UnityEngine.Object) this.mScroll != (UnityEngine.Object) this.scrollView)
    {
      this.mScroll = this.scrollView;
      this.mAutoFind = false;
    }
    if (!(bool) (UnityEngine.Object) this.scrollView || !this.enabled || !NGUITools.GetActive(this.gameObject))
      return;
    this.scrollView.Press(pressed);
    if (pressed || !this.mAutoFind)
      return;
    this.scrollView = NGUITools.FindInParents<UIScrollView>(this.mTrans);
    this.mScroll = this.scrollView;
  }

  private void OnDrag(Vector2 delta)
  {
    if (!(bool) (UnityEngine.Object) this.scrollView || !NGUITools.GetActive((Behaviour) this))
      return;
    this.scrollView.Drag();
  }

  private void OnScroll(float delta)
  {
    if (!(bool) (UnityEngine.Object) this.scrollView || !NGUITools.GetActive((Behaviour) this))
      return;
    this.scrollView.Scroll(delta);
  }

  public void OnPan(Vector2 delta)
  {
    if (!(bool) (UnityEngine.Object) this.scrollView || !NGUITools.GetActive((Behaviour) this))
      return;
    this.scrollView.OnPan(delta);
  }
}
