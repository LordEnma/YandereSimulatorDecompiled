// Decompiled with JetBrains decompiler
// Type: UIScrollView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UIPanel))]
[AddComponentMenu("NGUI/Interaction/Scroll View")]
public class UIScrollView : MonoBehaviour
{
  public static BetterList<UIScrollView> list = new BetterList<UIScrollView>();
  public UIScrollView.Movement movement;
  public UIScrollView.DragEffect dragEffect = UIScrollView.DragEffect.MomentumAndSpring;
  public bool restrictWithinPanel = true;
  [Tooltip("Whether the scroll view will execute its constrain within bounds logic on every drag operation")]
  public bool constrainOnDrag;
  public bool disableDragIfFits;
  public bool smoothDragStart = true;
  public bool iOSDragEmulation = true;
  public float scrollWheelFactor = 0.25f;
  public float momentumAmount = 35f;
  public float dampenStrength = 9f;
  public UIProgressBar horizontalScrollBar;
  public UIProgressBar verticalScrollBar;
  public UIScrollView.ShowCondition showScrollBars = UIScrollView.ShowCondition.OnlyIfNeeded;
  public Vector2 customMovement = new Vector2(1f, 0.0f);
  public UIWidget.Pivot contentPivot;
  public UIScrollView.OnDragNotification onDragStarted;
  public UIScrollView.OnDragNotification onDragFinished;
  public UIScrollView.OnDragNotification onMomentumMove;
  public UIScrollView.OnDragNotification onStoppedMoving;
  [HideInInspector]
  [SerializeField]
  private Vector3 scale = new Vector3(1f, 0.0f, 0.0f);
  [SerializeField]
  [HideInInspector]
  private Vector2 relativePositionOnReset = Vector2.zero;
  protected Transform mTrans;
  protected UIPanel mPanel;
  protected Plane mPlane;
  protected Vector3 mLastPos;
  protected bool mPressed;
  protected Vector3 mMomentum = Vector3.zero;
  protected float mScroll;
  protected Bounds mBounds;
  protected bool mCalculatedBounds;
  protected bool mShouldMove;
  protected bool mIgnoreCallbacks;
  protected int mDragID = -10;
  protected Vector2 mDragStartOffset = Vector2.zero;
  protected bool mDragStarted;
  [NonSerialized]
  private bool mStarted;
  [HideInInspector]
  public UICenterOnChild centerOnChild;

  public UIPanel panel => this.mPanel;

  public bool isDragging => this.mPressed && this.mDragStarted;

  public virtual Bounds bounds
  {
    get
    {
      if (!this.mCalculatedBounds)
      {
        this.mCalculatedBounds = true;
        this.mTrans = this.transform;
        this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.mTrans, this.mTrans);
      }
      return this.mBounds;
    }
  }

  public bool canMoveHorizontally
  {
    get
    {
      if (this.movement == UIScrollView.Movement.Horizontal || this.movement == UIScrollView.Movement.Unrestricted)
        return true;
      return this.movement == UIScrollView.Movement.Custom && (double) this.customMovement.x != 0.0;
    }
  }

  public bool canMoveVertically
  {
    get
    {
      if (this.movement == UIScrollView.Movement.Vertical || this.movement == UIScrollView.Movement.Unrestricted)
        return true;
      return this.movement == UIScrollView.Movement.Custom && (double) this.customMovement.y != 0.0;
    }
  }

  public virtual bool shouldMoveHorizontally
  {
    get
    {
      float x = this.bounds.size.x;
      if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        x += this.mPanel.clipSoftness.x * 2f;
      return Mathf.RoundToInt(x - this.mPanel.width) > 0;
    }
  }

  public virtual bool shouldMoveVertically
  {
    get
    {
      float y = this.bounds.size.y;
      if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        y += this.mPanel.clipSoftness.y * 2f;
      return Mathf.RoundToInt(y - this.mPanel.height) > 0;
    }
  }

  protected virtual bool shouldMove
  {
    get
    {
      if (!this.disableDragIfFits)
        return true;
      if ((UnityEngine.Object) this.mPanel == (UnityEngine.Object) null)
        this.mPanel = this.GetComponent<UIPanel>();
      Vector4 finalClipRegion = this.mPanel.finalClipRegion;
      Bounds bounds = this.bounds;
      float num1 = (double) finalClipRegion.z == 0.0 ? (float) Screen.width : finalClipRegion.z * 0.5f;
      float num2 = (double) finalClipRegion.w == 0.0 ? (float) Screen.height : finalClipRegion.w * 0.5f;
      return this.canMoveHorizontally && ((double) bounds.min.x + 1.0 / 1000.0 < (double) finalClipRegion.x - (double) num1 || (double) bounds.max.x - 1.0 / 1000.0 > (double) finalClipRegion.x + (double) num1) || this.canMoveVertically && ((double) bounds.min.y + 1.0 / 1000.0 < (double) finalClipRegion.y - (double) num2 || (double) bounds.max.y - 1.0 / 1000.0 > (double) finalClipRegion.y + (double) num2);
    }
  }

  public Vector3 currentMomentum
  {
    get => this.mMomentum;
    set
    {
      this.mMomentum = value;
      this.mShouldMove = true;
    }
  }

  private void Awake()
  {
    this.mTrans = this.transform;
    this.mPanel = this.GetComponent<UIPanel>();
    if (this.mPanel.clipping == UIDrawCall.Clipping.None)
      this.mPanel.clipping = UIDrawCall.Clipping.ConstrainButDontClip;
    if (this.movement != UIScrollView.Movement.Custom && (double) this.scale.sqrMagnitude > 1.0 / 1000.0)
    {
      if ((double) this.scale.x == 1.0 && (double) this.scale.y == 0.0)
        this.movement = UIScrollView.Movement.Horizontal;
      else if ((double) this.scale.x == 0.0 && (double) this.scale.y == 1.0)
        this.movement = UIScrollView.Movement.Vertical;
      else if ((double) this.scale.x == 1.0 && (double) this.scale.y == 1.0)
      {
        this.movement = UIScrollView.Movement.Unrestricted;
      }
      else
      {
        this.movement = UIScrollView.Movement.Custom;
        this.customMovement.x = this.scale.x;
        this.customMovement.y = this.scale.y;
      }
      this.scale = Vector3.zero;
    }
    if (this.contentPivot != UIWidget.Pivot.TopLeft || !(this.relativePositionOnReset != Vector2.zero))
      return;
    this.contentPivot = NGUIMath.GetPivot(new Vector2(this.relativePositionOnReset.x, 1f - this.relativePositionOnReset.y));
    this.relativePositionOnReset = Vector2.zero;
  }

  private void OnEnable()
  {
    UIScrollView.list.Add(this);
    if (!this.mStarted || !Application.isPlaying)
      return;
    this.CheckScrollbars();
  }

  private void Start()
  {
    this.mStarted = true;
    if (!Application.isPlaying)
      return;
    this.CheckScrollbars();
  }

  private void CheckScrollbars()
  {
    if ((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null)
    {
      EventDelegate.Add(this.horizontalScrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
      this.horizontalScrollBar.BroadcastMessage("CacheDefaultColor", SendMessageOptions.DontRequireReceiver);
      this.horizontalScrollBar.alpha = this.showScrollBars == UIScrollView.ShowCondition.Always || this.shouldMoveHorizontally ? 1f : 0.0f;
    }
    if (!((UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null))
      return;
    EventDelegate.Add(this.verticalScrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
    this.verticalScrollBar.BroadcastMessage("CacheDefaultColor", SendMessageOptions.DontRequireReceiver);
    this.verticalScrollBar.alpha = this.showScrollBars == UIScrollView.ShowCondition.Always || this.shouldMoveVertically ? 1f : 0.0f;
  }

  private void OnDisable()
  {
    UIScrollView.list.Remove(this);
    this.mPressed = false;
  }

  public bool RestrictWithinBounds(bool instant) => this.RestrictWithinBounds(instant, true, true);

  public bool RestrictWithinBounds(bool instant, bool horizontal, bool vertical)
  {
    if ((UnityEngine.Object) this.mPanel == (UnityEngine.Object) null)
      return false;
    Bounds bounds = this.bounds;
    Vector3 constrainOffset = this.mPanel.CalculateConstrainOffset((Vector2) bounds.min, (Vector2) bounds.max);
    if (!horizontal)
      constrainOffset.x = 0.0f;
    if (!vertical)
      constrainOffset.y = 0.0f;
    if ((double) constrainOffset.sqrMagnitude <= 0.100000001490116)
      return false;
    if (!instant && this.dragEffect == UIScrollView.DragEffect.MomentumAndSpring)
    {
      Vector3 pos = this.mTrans.localPosition + constrainOffset;
      pos.x = Mathf.Round(pos.x);
      pos.y = Mathf.Round(pos.y);
      SpringPanel.Begin(this.mPanel.gameObject, pos, 8f);
    }
    else
    {
      this.MoveRelative(constrainOffset);
      if ((double) Mathf.Abs(constrainOffset.x) > 0.00999999977648258)
        this.mMomentum.x = 0.0f;
      if ((double) Mathf.Abs(constrainOffset.y) > 0.00999999977648258)
        this.mMomentum.y = 0.0f;
      if ((double) Mathf.Abs(constrainOffset.z) > 0.00999999977648258)
        this.mMomentum.z = 0.0f;
      this.mScroll = 0.0f;
    }
    return true;
  }

  public void DisableSpring()
  {
    SpringPanel component = this.GetComponent<SpringPanel>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    component.enabled = false;
  }

  public void UpdateScrollbars() => this.UpdateScrollbars(true);

  public virtual void UpdateScrollbars(bool recalculateBounds)
  {
    if ((UnityEngine.Object) this.mPanel == (UnityEngine.Object) null)
      return;
    if ((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null || (UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null)
    {
      if (recalculateBounds)
      {
        this.mCalculatedBounds = false;
        this.mShouldMove = this.shouldMove;
      }
      Bounds bounds = this.bounds;
      Vector2 min = (Vector2) bounds.min;
      Vector2 max = (Vector2) bounds.max;
      if ((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null && (double) max.x > (double) min.x)
      {
        Vector4 finalClipRegion = this.mPanel.finalClipRegion;
        int num1 = Mathf.RoundToInt(finalClipRegion.z);
        if ((num1 & 1) != 0)
          --num1;
        float num2 = Mathf.Round((float) num1 * 0.5f);
        if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
          num2 -= this.mPanel.clipSoftness.x;
        float contentSize = max.x - min.x;
        float viewSize = num2 * 2f;
        float x1 = min.x;
        float x2 = max.x;
        float num3 = finalClipRegion.x - num2;
        float num4 = finalClipRegion.x + num2;
        this.UpdateScrollbars(this.horizontalScrollBar, num3 - x1, x2 - num4, contentSize, viewSize, false);
      }
      if (!((UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null) || (double) max.y <= (double) min.y)
        return;
      Vector4 finalClipRegion1 = this.mPanel.finalClipRegion;
      int num5 = Mathf.RoundToInt(finalClipRegion1.w);
      if ((num5 & 1) != 0)
        --num5;
      float num6 = Mathf.Round((float) num5 * 0.5f);
      if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        num6 -= this.mPanel.clipSoftness.y;
      float contentSize1 = max.y - min.y;
      float viewSize1 = num6 * 2f;
      float y1 = min.y;
      float y2 = max.y;
      float num7 = finalClipRegion1.y - num6;
      float num8 = finalClipRegion1.y + num6;
      this.UpdateScrollbars(this.verticalScrollBar, num7 - y1, y2 - num8, contentSize1, viewSize1, true);
    }
    else
    {
      if (!recalculateBounds)
        return;
      this.mCalculatedBounds = false;
    }
  }

  protected void UpdateScrollbars(
    UIProgressBar slider,
    float contentMin,
    float contentMax,
    float contentSize,
    float viewSize,
    bool inverted)
  {
    if ((UnityEngine.Object) slider == (UnityEngine.Object) null)
      return;
    this.mIgnoreCallbacks = true;
    float num;
    if ((double) viewSize < (double) contentSize)
    {
      contentMin = Mathf.Clamp01(contentMin / contentSize);
      contentMax = Mathf.Clamp01(contentMax / contentSize);
      num = contentMin + contentMax;
      slider.value = inverted ? ((double) num > 1.0 / 1000.0 ? (float) (1.0 - (double) contentMin / (double) num) : 0.0f) : ((double) num > 1.0 / 1000.0 ? contentMin / num : 1f);
    }
    else
    {
      contentMin = Mathf.Clamp01(-contentMin / contentSize);
      contentMax = Mathf.Clamp01(-contentMax / contentSize);
      num = contentMin + contentMax;
      slider.value = inverted ? ((double) num > 1.0 / 1000.0 ? (float) (1.0 - (double) contentMin / (double) num) : 0.0f) : ((double) num > 1.0 / 1000.0 ? contentMin / num : 1f);
      if ((double) contentSize > 0.0)
      {
        contentMin = Mathf.Clamp01(contentMin / contentSize);
        contentMax = Mathf.Clamp01(contentMax / contentSize);
        num = contentMin + contentMax;
      }
    }
    UIScrollBar uiScrollBar = slider as UIScrollBar;
    if ((UnityEngine.Object) uiScrollBar != (UnityEngine.Object) null)
      uiScrollBar.barSize = 1f - num;
    this.mIgnoreCallbacks = false;
  }

  public virtual void SetDragAmount(float x, float y, bool updateScrollbars)
  {
    if ((UnityEngine.Object) this.mPanel == (UnityEngine.Object) null)
      this.mPanel = this.GetComponent<UIPanel>();
    this.DisableSpring();
    Bounds bounds = this.bounds;
    if ((double) bounds.min.x == (double) bounds.max.x || (double) bounds.min.y == (double) bounds.max.y)
      return;
    Vector4 finalClipRegion = this.mPanel.finalClipRegion;
    float num1 = finalClipRegion.z * 0.5f;
    float num2 = finalClipRegion.w * 0.5f;
    float a1 = bounds.min.x + num1;
    float b1 = bounds.max.x - num1;
    float b2 = bounds.min.y + num2;
    float a2 = bounds.max.y - num2;
    if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
    {
      a1 -= this.mPanel.clipSoftness.x;
      b1 += this.mPanel.clipSoftness.x;
      b2 -= this.mPanel.clipSoftness.y;
      a2 += this.mPanel.clipSoftness.y;
    }
    float num3 = Mathf.Lerp(a1, b1, x);
    float num4 = Mathf.Lerp(a2, b2, y);
    if (!updateScrollbars)
    {
      Vector3 localPosition = this.mTrans.localPosition;
      if (this.canMoveHorizontally)
        localPosition.x += finalClipRegion.x - num3;
      if (this.canMoveVertically)
        localPosition.y += finalClipRegion.y - num4;
      this.mTrans.localPosition = localPosition;
    }
    if (this.canMoveHorizontally)
      finalClipRegion.x = num3;
    if (this.canMoveVertically)
      finalClipRegion.y = num4;
    Vector4 baseClipRegion = this.mPanel.baseClipRegion;
    this.mPanel.clipOffset = new Vector2(finalClipRegion.x - baseClipRegion.x, finalClipRegion.y - baseClipRegion.y);
    if (!updateScrollbars)
      return;
    this.UpdateScrollbars(this.mDragID == -10);
  }

  public void InvalidateBounds() => this.mCalculatedBounds = false;

  [ContextMenu("Reset Clipping Position")]
  public void ResetPosition()
  {
    if (!NGUITools.GetActive((Behaviour) this))
      return;
    this.mCalculatedBounds = false;
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.contentPivot);
    this.SetDragAmount(pivotOffset.x, 1f - pivotOffset.y, false);
    this.SetDragAmount(pivotOffset.x, 1f - pivotOffset.y, true);
  }

  public void UpdatePosition()
  {
    if (this.mIgnoreCallbacks || !((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null) && !((UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null))
      return;
    this.mIgnoreCallbacks = true;
    this.mCalculatedBounds = false;
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.contentPivot);
    this.SetDragAmount((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null ? this.horizontalScrollBar.value : pivotOffset.x, (UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null ? this.verticalScrollBar.value : 1f - pivotOffset.y, false);
    this.UpdateScrollbars(true);
    this.mIgnoreCallbacks = false;
  }

  public void OnScrollBar()
  {
    if (this.mIgnoreCallbacks)
      return;
    this.mIgnoreCallbacks = true;
    this.SetDragAmount((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null ? this.horizontalScrollBar.value : 0.0f, (UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null ? this.verticalScrollBar.value : 0.0f, false);
    this.mIgnoreCallbacks = false;
  }

  public virtual void MoveRelative(Vector3 relative)
  {
    this.mTrans.localPosition += relative;
    Vector2 clipOffset = this.mPanel.clipOffset;
    clipOffset.x -= relative.x;
    clipOffset.y -= relative.y;
    this.mPanel.clipOffset = clipOffset;
    this.UpdateScrollbars(false);
  }

  public void MoveAbsolute(Vector3 absolute) => this.MoveRelative(this.mTrans.InverseTransformPoint(absolute) - this.mTrans.InverseTransformPoint(Vector3.zero));

  public void Press(bool pressed)
  {
    if (this.mPressed == pressed || UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    if (this.smoothDragStart & pressed)
    {
      this.mDragStarted = false;
      this.mDragStartOffset = Vector2.zero;
    }
    if (!this.enabled || !NGUITools.GetActive(this.gameObject))
      return;
    if (!pressed && this.mDragID == UICamera.currentTouchID)
      this.mDragID = -10;
    this.mCalculatedBounds = false;
    this.mShouldMove = this.shouldMove;
    if (!this.mShouldMove)
      return;
    this.mPressed = pressed;
    if (pressed)
    {
      this.mMomentum = Vector3.zero;
      this.mScroll = 0.0f;
      this.DisableSpring();
      this.mLastPos = UICamera.lastWorldPosition;
      this.mPlane = new Plane(this.mTrans.rotation * Vector3.back, this.mLastPos);
      Vector2 clipOffset = this.mPanel.clipOffset;
      clipOffset.x = Mathf.Round(clipOffset.x);
      clipOffset.y = Mathf.Round(clipOffset.y);
      this.mPanel.clipOffset = clipOffset;
      Vector3 localPosition = this.mTrans.localPosition;
      localPosition.x = Mathf.Round(localPosition.x);
      localPosition.y = Mathf.Round(localPosition.y);
      this.mTrans.localPosition = localPosition;
      if (this.smoothDragStart)
        return;
      this.mDragStarted = true;
      this.mDragStartOffset = Vector2.zero;
      if (this.onDragStarted == null)
        return;
      this.onDragStarted();
    }
    else if ((bool) (UnityEngine.Object) this.centerOnChild)
    {
      if (this.mDragStarted && this.onDragFinished != null)
        this.onDragFinished();
      this.centerOnChild.Recenter();
    }
    else
    {
      if (this.mDragStarted && this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
        this.RestrictWithinBounds(this.dragEffect == UIScrollView.DragEffect.None, this.canMoveHorizontally, this.canMoveVertically);
      if (this.mDragStarted && this.onDragFinished != null)
        this.onDragFinished();
      if (this.mShouldMove || this.onStoppedMoving == null)
        return;
      this.onStoppedMoving();
    }
  }

  public void Drag()
  {
    if (!this.mPressed || UICamera.currentScheme == UICamera.ControlScheme.Controller || !this.enabled || !NGUITools.GetActive(this.gameObject) || !this.mShouldMove)
      return;
    if (this.mDragID == -10)
      this.mDragID = UICamera.currentTouchID;
    UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
    if (this.smoothDragStart && !this.mDragStarted)
    {
      this.mDragStarted = true;
      this.mDragStartOffset = UICamera.currentTouch.totalDelta;
      if (this.onDragStarted != null)
        this.onDragStarted();
    }
    Ray ray = this.smoothDragStart ? UICamera.currentCamera.ScreenPointToRay((Vector3) (UICamera.currentTouch.pos - this.mDragStartOffset)) : UICamera.currentCamera.ScreenPointToRay((Vector3) UICamera.currentTouch.pos);
    float enter = 0.0f;
    if (!this.mPlane.Raycast(ray, out enter))
      return;
    Vector3 point = ray.GetPoint(enter);
    Vector3 vector3 = point - this.mLastPos;
    this.mLastPos = point;
    if ((double) vector3.x != 0.0 || (double) vector3.y != 0.0 || (double) vector3.z != 0.0)
    {
      Vector3 direction = this.mTrans.InverseTransformDirection(vector3);
      if (this.movement == UIScrollView.Movement.Horizontal)
      {
        direction.y = 0.0f;
        direction.z = 0.0f;
      }
      else if (this.movement == UIScrollView.Movement.Vertical)
      {
        direction.x = 0.0f;
        direction.z = 0.0f;
      }
      else if (this.movement == UIScrollView.Movement.Unrestricted)
        direction.z = 0.0f;
      else
        direction.Scale((Vector3) this.customMovement);
      vector3 = this.mTrans.TransformDirection(direction);
    }
    this.mMomentum = this.dragEffect != UIScrollView.DragEffect.None ? Vector3.Lerp(this.mMomentum, this.mMomentum + vector3 * (0.01f * this.momentumAmount), 0.67f) : Vector3.zero;
    if (!this.iOSDragEmulation || this.dragEffect != UIScrollView.DragEffect.MomentumAndSpring)
    {
      this.MoveAbsolute(vector3);
    }
    else
    {
      UIPanel mPanel = this.mPanel;
      Bounds bounds = this.bounds;
      Vector2 min = (Vector2) bounds.min;
      bounds = this.bounds;
      Vector2 max = (Vector2) bounds.max;
      Vector3 constrainOffset = mPanel.CalculateConstrainOffset(min, max);
      if (this.movement == UIScrollView.Movement.Horizontal)
        constrainOffset.y = 0.0f;
      else if (this.movement == UIScrollView.Movement.Vertical)
        constrainOffset.x = 0.0f;
      else if (this.movement == UIScrollView.Movement.Custom)
      {
        constrainOffset.x *= this.customMovement.x;
        constrainOffset.y *= this.customMovement.y;
      }
      if ((double) constrainOffset.magnitude > 1.0)
      {
        this.MoveAbsolute(vector3 * 0.5f);
        this.mMomentum *= 0.5f;
      }
      else
        this.MoveAbsolute(vector3);
    }
    if (!this.constrainOnDrag || !this.restrictWithinPanel || this.mPanel.clipping == UIDrawCall.Clipping.None || this.dragEffect == UIScrollView.DragEffect.MomentumAndSpring)
      return;
    this.RestrictWithinBounds(true, this.canMoveHorizontally, this.canMoveVertically);
  }

  public void Scroll(float delta)
  {
    if (!this.enabled || !NGUITools.GetActive(this.gameObject) || (double) this.scrollWheelFactor == 0.0)
      return;
    this.DisableSpring();
    this.mShouldMove |= this.shouldMove;
    if ((double) Mathf.Sign(this.mScroll) != (double) Mathf.Sign(delta))
      this.mScroll = 0.0f;
    this.mScroll += delta * this.scrollWheelFactor;
  }

  private void LateUpdate()
  {
    if (!Application.isPlaying)
      return;
    float deltaTime = RealTime.deltaTime;
    if (this.showScrollBars != UIScrollView.ShowCondition.Always && ((bool) (UnityEngine.Object) this.verticalScrollBar || (bool) (UnityEngine.Object) this.horizontalScrollBar))
    {
      bool flag1 = false;
      bool flag2 = false;
      if (this.showScrollBars != UIScrollView.ShowCondition.WhenDragging || this.mDragID != -10 || (double) this.mMomentum.magnitude > 0.00999999977648258)
      {
        flag1 = this.shouldMoveVertically;
        flag2 = this.shouldMoveHorizontally;
      }
      if ((bool) (UnityEngine.Object) this.verticalScrollBar)
      {
        float num = Mathf.Clamp01(this.verticalScrollBar.alpha + (flag1 ? deltaTime * 6f : (float) (-(double) deltaTime * 3.0)));
        if ((double) this.verticalScrollBar.alpha != (double) num)
          this.verticalScrollBar.alpha = num;
      }
      if ((bool) (UnityEngine.Object) this.horizontalScrollBar)
      {
        float num = Mathf.Clamp01(this.horizontalScrollBar.alpha + (flag2 ? deltaTime * 6f : (float) (-(double) deltaTime * 3.0)));
        if ((double) this.horizontalScrollBar.alpha != (double) num)
          this.horizontalScrollBar.alpha = num;
      }
    }
    if (!this.mShouldMove)
      return;
    if (!this.mPressed)
    {
      if ((double) this.mMomentum.magnitude > 9.99999974737875E-05 || (double) Mathf.Abs(this.mScroll) > 9.99999974737875E-05)
      {
        if (this.movement == UIScrollView.Movement.Horizontal)
          this.mMomentum -= this.mTrans.TransformDirection(new Vector3(this.mScroll * 0.05f, 0.0f, 0.0f));
        else if (this.movement == UIScrollView.Movement.Vertical)
          this.mMomentum -= this.mTrans.TransformDirection(new Vector3(0.0f, this.mScroll * 0.05f, 0.0f));
        else if (this.movement == UIScrollView.Movement.Unrestricted)
          this.mMomentum -= this.mTrans.TransformDirection(new Vector3(this.mScroll * 0.05f, this.mScroll * 0.05f, 0.0f));
        else
          this.mMomentum -= this.mTrans.TransformDirection(new Vector3((float) ((double) this.mScroll * (double) this.customMovement.x * 0.0500000007450581), (float) ((double) this.mScroll * (double) this.customMovement.y * 0.0500000007450581), 0.0f));
        this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0.0f, 20f, deltaTime);
        this.MoveAbsolute(NGUIMath.SpringDampen(ref this.mMomentum, this.dampenStrength, deltaTime));
        if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
        {
          if (NGUITools.GetActive((Behaviour) this.centerOnChild))
          {
            if ((double) this.centerOnChild.nextPageThreshold != 0.0)
            {
              this.mMomentum = Vector3.zero;
              this.mScroll = 0.0f;
            }
            else
              this.centerOnChild.Recenter();
          }
          else
            this.RestrictWithinBounds(false, this.canMoveHorizontally, this.canMoveVertically);
        }
        if (this.onMomentumMove == null)
          return;
        this.onMomentumMove();
      }
      else
      {
        this.mScroll = 0.0f;
        this.mMomentum = Vector3.zero;
        SpringPanel component = this.GetComponent<SpringPanel>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.enabled)
          return;
        this.mShouldMove = false;
        if (this.onStoppedMoving == null)
          return;
        this.onStoppedMoving();
      }
    }
    else
    {
      this.mScroll = 0.0f;
      NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
    }
  }

  public void OnPan(Vector2 delta)
  {
    if ((UnityEngine.Object) this.horizontalScrollBar != (UnityEngine.Object) null)
      this.horizontalScrollBar.OnPan(delta);
    if ((UnityEngine.Object) this.verticalScrollBar != (UnityEngine.Object) null)
      this.verticalScrollBar.OnPan(delta);
    if (!((UnityEngine.Object) this.horizontalScrollBar == (UnityEngine.Object) null) || !((UnityEngine.Object) this.verticalScrollBar == (UnityEngine.Object) null))
      return;
    if (this.canMoveHorizontally)
    {
      this.Scroll(delta.x);
    }
    else
    {
      if (!this.canMoveVertically)
        return;
      this.Scroll(delta.y);
    }
  }

  [DoNotObfuscateNGUI]
  public enum Movement
  {
    Horizontal,
    Vertical,
    Unrestricted,
    Custom,
  }

  [DoNotObfuscateNGUI]
  public enum DragEffect
  {
    None,
    Momentum,
    MomentumAndSpring,
  }

  [DoNotObfuscateNGUI]
  public enum ShowCondition
  {
    Always,
    OnlyIfNeeded,
    WhenDragging,
  }

  public delegate void OnDragNotification();
}
