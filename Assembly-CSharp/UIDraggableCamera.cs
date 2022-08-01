// Decompiled with JetBrains decompiler
// Type: UIDraggableCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("NGUI/Interaction/Draggable Camera")]
public class UIDraggableCamera : MonoBehaviour
{
  public Transform rootForBounds;
  public Vector2 scale = Vector2.one;
  public float scrollWheelFactor;
  public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;
  public bool smoothDragStart = true;
  public float momentumAmount = 35f;
  private Camera mCam;
  private Transform mTrans;
  private bool mPressed;
  private Vector2 mMomentum = Vector2.zero;
  private Bounds mBounds;
  private float mScroll;
  private UIRoot mRoot;
  private bool mDragStarted;

  public Vector2 currentMomentum
  {
    get => this.mMomentum;
    set => this.mMomentum = value;
  }

  private void Start()
  {
    this.mCam = this.GetComponent<Camera>();
    this.mTrans = this.transform;
    this.mRoot = NGUITools.FindInParents<UIRoot>(this.gameObject);
    if (!((Object) this.rootForBounds == (Object) null))
      return;
    Debug.LogError((object) (NGUITools.GetHierarchy(this.gameObject) + " needs the 'Root For Bounds' parameter to be set"), (Object) this);
    this.enabled = false;
  }

  private Vector3 CalculateConstrainOffset()
  {
    if ((Object) this.rootForBounds == (Object) null || this.rootForBounds.childCount == 0)
      return Vector3.zero;
    Vector3 position1 = new Vector3(this.mCam.rect.xMin * (float) Screen.width, this.mCam.rect.yMin * (float) Screen.height, 0.0f);
    Vector3 position2 = new Vector3(this.mCam.rect.xMax * (float) Screen.width, this.mCam.rect.yMax * (float) Screen.height, 0.0f);
    return (Vector3) NGUIMath.ConstrainRect(new Vector2(this.mBounds.min.x, this.mBounds.min.y), new Vector2(this.mBounds.max.x, this.mBounds.max.y), (Vector2) this.mCam.ScreenToWorldPoint(position1), (Vector2) this.mCam.ScreenToWorldPoint(position2));
  }

  public bool ConstrainToBounds(bool immediate)
  {
    if ((Object) this.mTrans != (Object) null && (Object) this.rootForBounds != (Object) null)
    {
      Vector3 constrainOffset = this.CalculateConstrainOffset();
      if ((double) constrainOffset.sqrMagnitude > 0.0)
      {
        if (immediate)
        {
          this.mTrans.position -= constrainOffset;
        }
        else
        {
          SpringPosition springPosition = SpringPosition.Begin(this.gameObject, this.mTrans.position - constrainOffset, 13f);
          springPosition.ignoreTimeScale = true;
          springPosition.worldSpace = true;
        }
        return true;
      }
    }
    return false;
  }

  public void Press(bool isPressed)
  {
    if (isPressed)
      this.mDragStarted = false;
    if (!((Object) this.rootForBounds != (Object) null))
      return;
    this.mPressed = isPressed;
    if (isPressed)
    {
      this.mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
      this.mMomentum = Vector2.zero;
      this.mScroll = 0.0f;
      SpringPosition component = this.GetComponent<SpringPosition>();
      if (!((Object) component != (Object) null))
        return;
      component.enabled = false;
    }
    else
    {
      if (this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring)
        return;
      this.ConstrainToBounds(false);
    }
  }

  public void Drag(Vector2 delta)
  {
    if (this.smoothDragStart && !this.mDragStarted)
    {
      this.mDragStarted = true;
    }
    else
    {
      UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
      if ((Object) this.mRoot != (Object) null)
        delta *= this.mRoot.pixelSizeAdjustment;
      Vector2 vector2 = Vector2.Scale(delta, -this.scale);
      this.mTrans.localPosition += (Vector3) vector2;
      this.mMomentum = Vector2.Lerp(this.mMomentum, this.mMomentum + vector2 * (0.01f * this.momentumAmount), 0.67f);
      if (this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring || !this.ConstrainToBounds(true))
        return;
      this.mMomentum = Vector2.zero;
      this.mScroll = 0.0f;
    }
  }

  public void Scroll(float delta)
  {
    if (!this.enabled || !NGUITools.GetActive(this.gameObject))
      return;
    if ((double) Mathf.Sign(this.mScroll) != (double) Mathf.Sign(delta))
      this.mScroll = 0.0f;
    this.mScroll += delta * this.scrollWheelFactor;
  }

  private void Update()
  {
    float deltaTime = RealTime.deltaTime;
    if (this.mPressed)
    {
      SpringPosition component = this.GetComponent<SpringPosition>();
      if ((Object) component != (Object) null)
        component.enabled = false;
      this.mScroll = 0.0f;
    }
    else
    {
      this.mMomentum += this.scale * (this.mScroll * 20f);
      this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0.0f, 20f, deltaTime);
      if ((double) this.mMomentum.magnitude > 0.00999999977648258)
      {
        this.mTrans.localPosition += (Vector3) NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
        this.mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
        if (this.ConstrainToBounds(this.dragEffect == UIDragObject.DragEffect.None))
          return;
        SpringPosition component = this.GetComponent<SpringPosition>();
        if (!((Object) component != (Object) null))
          return;
        component.enabled = false;
        return;
      }
      this.mScroll = 0.0f;
    }
    NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
  }
}
