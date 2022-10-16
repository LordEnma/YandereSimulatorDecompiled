// Decompiled with JetBrains decompiler
// Type: UIDragDropItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag and Drop Item")]
public class UIDragDropItem : MonoBehaviour
{
  [Tooltip("What kind of restriction is applied to the drag & drop logic before dragging is made possible.")]
  public UIDragDropItem.Restriction restriction;
  [Tooltip("By default, dragging only happens while holding the mouse button / touch. If desired, you can opt to use a click-based approach instead. Note that this only works with a mouse.")]
  public bool clickToDrag;
  [Tooltip("Whether a copy of the item will be dragged instead of the item itself.")]
  public bool cloneOnDrag;
  [Tooltip("Whether this drag and drop item can be interacted with. If not, only tooltips will work.")]
  public bool interactable = true;
  [Tooltip("How long the user has to press on an item before the drag action activates.")]
  [HideInInspector]
  public float pressAndHoldDelay = 1f;
  [NonSerialized]
  protected Transform mTrans;
  [NonSerialized]
  protected Transform mParent;
  [NonSerialized]
  protected Collider mCollider;
  [NonSerialized]
  protected Collider2D mCollider2D;
  [NonSerialized]
  protected UIButton mButton;
  [NonSerialized]
  protected UIRoot mRoot;
  [NonSerialized]
  protected UIGrid mGrid;
  [NonSerialized]
  protected UITable mTable;
  [NonSerialized]
  protected float mDragStartTime;
  [NonSerialized]
  protected UIDragScrollView mDragScrollView;
  [NonSerialized]
  protected bool mPressed;
  [NonSerialized]
  protected bool mDragging;
  [NonSerialized]
  protected UICamera.MouseOrTouch mTouch;
  [NonSerialized]
  public static List<UIDragDropItem> draggedItems = new List<UIDragDropItem>();
  [NonSerialized]
  private static int mIgnoreClick = 0;

  public static bool IsDragged(GameObject go)
  {
    foreach (Component draggedItem in UIDragDropItem.draggedItems)
    {
      if ((UnityEngine.Object) draggedItem.gameObject == (UnityEngine.Object) go)
        return true;
    }
    return false;
  }

  protected virtual void Awake()
  {
    this.mTrans = this.transform;
    this.mCollider = this.gameObject.GetComponent<Collider>();
    this.mCollider2D = this.gameObject.GetComponent<Collider2D>();
  }

  protected virtual void OnEnable()
  {
  }

  protected virtual void OnDisable()
  {
    if (!this.mDragging)
      return;
    this.StopDragging();
    UICamera.onPress -= new UICamera.BoolDelegate(this.OnGlobalPress);
    UICamera.onClick -= new UICamera.VoidDelegate(this.OnGlobalClick);
    UICamera.onMouseMove -= new UICamera.MoveDelegate(this.OnDrag);
  }

  protected virtual void Start()
  {
    this.mButton = this.GetComponent<UIButton>();
    this.mDragScrollView = this.GetComponent<UIDragScrollView>();
  }

  protected virtual void OnPress(bool isPressed)
  {
    if (!this.interactable || UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
      return;
    if (isPressed)
    {
      if (this.mPressed)
        return;
      this.mTouch = UICamera.currentTouch;
      this.mDragStartTime = RealTime.time + this.pressAndHoldDelay;
      this.mPressed = true;
    }
    else
    {
      if (!this.mPressed || this.mTouch != UICamera.currentTouch)
        return;
      this.mPressed = false;
      if (this.mDragging && this.clickToDrag)
        return;
      this.mTouch = (UICamera.MouseOrTouch) null;
    }
  }

  protected virtual void OnClick()
  {
    if (UIDragDropItem.mIgnoreClick == Time.frameCount || !this.clickToDrag || this.mDragging || UICamera.currentTouchID != -1 || UIDragDropItem.draggedItems.Count != 0)
      return;
    this.mTouch = UICamera.currentTouch;
    UIDragDropItem uiDragDropItem = this.StartDragging();
    if (!this.clickToDrag || !((UnityEngine.Object) uiDragDropItem != (UnityEngine.Object) null))
      return;
    UICamera.onMouseMove += new UICamera.MoveDelegate(uiDragDropItem.OnDrag);
    UICamera.onPress += new UICamera.BoolDelegate(uiDragDropItem.OnGlobalPress);
    UICamera.onClick += new UICamera.VoidDelegate(uiDragDropItem.OnGlobalClick);
  }

  protected void OnGlobalPress(GameObject go, bool state)
  {
    if (!state || UICamera.currentTouchID == -1)
      return;
    UIDragDropItem.mIgnoreClick = Time.frameCount;
    this.StopDragging();
    UICamera.onPress -= new UICamera.BoolDelegate(this.OnGlobalPress);
    UICamera.onClick -= new UICamera.VoidDelegate(this.OnGlobalClick);
    UICamera.onMouseMove -= new UICamera.MoveDelegate(this.OnDrag);
  }

  protected void OnGlobalClick(GameObject go)
  {
    UIDragDropItem.mIgnoreClick = Time.frameCount;
    if (UICamera.currentTouchID == -1)
      this.StopDragging(go);
    else
      this.StopDragging();
    UICamera.onPress -= new UICamera.BoolDelegate(this.OnGlobalPress);
    UICamera.onClick -= new UICamera.VoidDelegate(this.OnGlobalClick);
    UICamera.onMouseMove -= new UICamera.MoveDelegate(this.OnDrag);
  }

  protected virtual void Update()
  {
    if (this.restriction != UIDragDropItem.Restriction.PressAndHold || !this.mPressed || this.mDragging || (double) this.mDragStartTime >= (double) RealTime.time)
      return;
    this.StartDragging();
  }

  protected virtual void OnDragStart()
  {
    if (!this.interactable || !this.enabled || this.mTouch != UICamera.currentTouch)
      return;
    if (this.restriction != UIDragDropItem.Restriction.None)
    {
      if (this.restriction == UIDragDropItem.Restriction.Horizontal)
      {
        Vector2 totalDelta = this.mTouch.totalDelta;
        if ((double) Mathf.Abs(totalDelta.x) < (double) Mathf.Abs(totalDelta.y))
          return;
      }
      else if (this.restriction == UIDragDropItem.Restriction.Vertical)
      {
        Vector2 totalDelta = this.mTouch.totalDelta;
        if ((double) Mathf.Abs(totalDelta.x) > (double) Mathf.Abs(totalDelta.y))
          return;
      }
      else if (this.restriction == UIDragDropItem.Restriction.PressAndHold)
        return;
    }
    this.StartDragging();
  }

  public virtual UIDragDropItem StartDragging()
  {
    if (!this.interactable || !(bool) (UnityEngine.Object) this.transform || !(bool) (UnityEngine.Object) this.transform.parent)
      return (UIDragDropItem) null;
    if (this.mDragging)
      return (UIDragDropItem) null;
    if (this.cloneOnDrag)
    {
      this.mPressed = false;
      GameObject gameObject = this.transform.parent.gameObject.AddChild(this.gameObject);
      gameObject.transform.localPosition = this.transform.localPosition;
      gameObject.transform.localRotation = this.transform.localRotation;
      gameObject.transform.localScale = this.transform.localScale;
      UIButtonColor component1 = gameObject.GetComponent<UIButtonColor>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        component1.defaultColor = this.GetComponent<UIButtonColor>().defaultColor;
      if (this.mTouch != null && (UnityEngine.Object) this.mTouch.pressed == (UnityEngine.Object) this.gameObject)
      {
        this.mTouch.current = gameObject;
        this.mTouch.pressed = gameObject;
        this.mTouch.dragged = gameObject;
        this.mTouch.last = gameObject;
      }
      UIDragDropItem component2 = gameObject.GetComponent<UIDragDropItem>();
      component2.mTouch = this.mTouch;
      component2.mPressed = true;
      component2.mDragging = true;
      component2.Start();
      component2.OnClone(this.gameObject);
      component2.OnDragDropStart();
      if (UICamera.currentTouch == null)
        UICamera.currentTouch = this.mTouch;
      this.mTouch = (UICamera.MouseOrTouch) null;
      UICamera.Notify(this.gameObject, "OnPress", (object) false);
      UICamera.Notify(this.gameObject, "OnHover", (object) false);
      return component2;
    }
    this.mDragging = true;
    this.OnDragDropStart();
    return this;
  }

  protected virtual void OnClone(GameObject original)
  {
  }

  protected virtual void OnDrag(Vector2 delta)
  {
    if (!this.interactable || !this.mDragging || !this.enabled || this.mTouch != UICamera.currentTouch)
      return;
    if ((UnityEngine.Object) this.mRoot != (UnityEngine.Object) null)
      this.OnDragDropMove(delta * this.mRoot.pixelSizeAdjustment);
    else
      this.OnDragDropMove(delta);
  }

  protected virtual void OnDragEnd()
  {
    if (!this.interactable || !this.enabled || this.mTouch != UICamera.currentTouch)
      return;
    this.StopDragging((UnityEngine.Object) UICamera.lastHit.collider != (UnityEngine.Object) null ? UICamera.lastHit.collider.gameObject : (GameObject) null);
  }

  public void StopDragging(GameObject go = null)
  {
    if (!this.mDragging)
      return;
    this.mDragging = false;
    this.OnDragDropRelease(go);
  }

  protected virtual void OnDragDropStart()
  {
    if (!UIDragDropItem.draggedItems.Contains(this))
      UIDragDropItem.draggedItems.Add(this);
    if ((UnityEngine.Object) this.mDragScrollView != (UnityEngine.Object) null)
      this.mDragScrollView.enabled = false;
    if ((UnityEngine.Object) this.mButton != (UnityEngine.Object) null)
      this.mButton.isEnabled = false;
    else if ((UnityEngine.Object) this.mCollider != (UnityEngine.Object) null)
      this.mCollider.enabled = false;
    else if ((UnityEngine.Object) this.mCollider2D != (UnityEngine.Object) null)
      this.mCollider2D.enabled = false;
    this.mParent = this.mTrans.parent;
    this.mRoot = NGUITools.FindInParents<UIRoot>(this.mParent);
    this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
    this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
    if ((UnityEngine.Object) UIDragDropRoot.root != (UnityEngine.Object) null)
      this.mTrans.parent = UIDragDropRoot.root;
    this.mTrans.localPosition = this.mTrans.localPosition with
    {
      z = 0.0f
    };
    TweenPosition component1 = this.GetComponent<TweenPosition>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      component1.enabled = false;
    SpringPosition component2 = this.GetComponent<SpringPosition>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      component2.enabled = false;
    NGUITools.MarkParentAsChanged(this.gameObject);
    if ((UnityEngine.Object) this.mTable != (UnityEngine.Object) null)
      this.mTable.repositionNow = true;
    if (!((UnityEngine.Object) this.mGrid != (UnityEngine.Object) null))
      return;
    this.mGrid.repositionNow = true;
  }

  protected virtual void OnDragDropMove(Vector2 delta)
  {
    if (!((UnityEngine.Object) this.mParent != (UnityEngine.Object) null))
      return;
    this.mTrans.localPosition += this.mTrans.InverseTransformDirection((Vector3) delta);
  }

  protected virtual void OnDragDropRelease(GameObject surface)
  {
    if (!this.cloneOnDrag)
    {
      foreach (UIDragScrollView componentsInChild in this.GetComponentsInChildren<UIDragScrollView>())
        componentsInChild.scrollView = (UIScrollView) null;
      if ((UnityEngine.Object) this.mButton != (UnityEngine.Object) null)
        this.mButton.isEnabled = true;
      else if ((UnityEngine.Object) this.mCollider != (UnityEngine.Object) null)
        this.mCollider.enabled = true;
      else if ((UnityEngine.Object) this.mCollider2D != (UnityEngine.Object) null)
        this.mCollider2D.enabled = true;
      UIDragDropContainer dragDropContainer = (bool) (UnityEngine.Object) surface ? NGUITools.FindInParents<UIDragDropContainer>(surface) : (UIDragDropContainer) null;
      if ((UnityEngine.Object) dragDropContainer != (UnityEngine.Object) null)
      {
        this.mTrans.parent = (UnityEngine.Object) dragDropContainer.reparentTarget != (UnityEngine.Object) null ? dragDropContainer.reparentTarget : dragDropContainer.transform;
        this.mTrans.localPosition = this.mTrans.localPosition with
        {
          z = 0.0f
        };
      }
      else
        this.mTrans.parent = this.mParent;
      this.mParent = this.mTrans.parent;
      this.mGrid = NGUITools.FindInParents<UIGrid>(this.mParent);
      this.mTable = NGUITools.FindInParents<UITable>(this.mParent);
      if ((UnityEngine.Object) this.mDragScrollView != (UnityEngine.Object) null)
        this.Invoke("EnableDragScrollView", 1f / 1000f);
      NGUITools.MarkParentAsChanged(this.gameObject);
      if ((UnityEngine.Object) this.mTable != (UnityEngine.Object) null)
        this.mTable.repositionNow = true;
      if ((UnityEngine.Object) this.mGrid != (UnityEngine.Object) null)
        this.mGrid.repositionNow = true;
    }
    this.OnDragDropEnd(surface);
    if (!this.cloneOnDrag)
      return;
    this.DestroySelf();
  }

  protected virtual void DestroySelf() => NGUITools.Destroy((UnityEngine.Object) this.gameObject);

  protected virtual void OnDragDropEnd(GameObject surface)
  {
    UIDragDropItem.draggedItems.Remove(this);
    this.mParent = (Transform) null;
  }

  protected void EnableDragScrollView()
  {
    if (!((UnityEngine.Object) this.mDragScrollView != (UnityEngine.Object) null))
      return;
    this.mDragScrollView.enabled = true;
  }

  protected void OnApplicationFocus(bool focus)
  {
    if (focus)
      return;
    this.StopDragging();
  }

  [DoNotObfuscateNGUI]
  public enum Restriction
  {
    None,
    Horizontal,
    Vertical,
    PressAndHold,
  }
}
