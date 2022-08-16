// Decompiled with JetBrains decompiler
// Type: UIDragObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Object")]
public class UIDragObject : MonoBehaviour
{
  public Transform target;
  public UIPanel panelRegion;
  public Vector3 scrollMomentum = Vector3.zero;
  public bool restrictWithinPanel;
  public UIRect contentRect;
  public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;
  public float momentumAmount = 35f;
  [SerializeField]
  protected Vector3 scale = new Vector3(1f, 1f, 0.0f);
  [SerializeField]
  [HideInInspector]
  private float scrollWheelFactor;
  private Plane mPlane;
  private Vector3 mTargetPos;
  private Vector3 mLastPos;
  private Vector3 mMomentum = Vector3.zero;
  private Vector3 mScroll = Vector3.zero;
  private Bounds mBounds;
  private int mTouchID;
  private bool mStarted;
  private bool mPressed;

  public Vector3 dragMovement
  {
    get => this.scale;
    set => this.scale = value;
  }

  private void OnEnable()
  {
    if ((double) this.scrollWheelFactor != 0.0)
    {
      this.scrollMomentum = this.scale * this.scrollWheelFactor;
      this.scrollWheelFactor = 0.0f;
    }
    if ((Object) this.contentRect == (Object) null && (Object) this.target != (Object) null && Application.isPlaying)
    {
      UIWidget component = this.target.GetComponent<UIWidget>();
      if ((Object) component != (Object) null)
        this.contentRect = (UIRect) component;
    }
    this.mTargetPos = (Object) this.target != (Object) null ? this.target.position : Vector3.zero;
  }

  private void OnDisable() => this.mStarted = false;

  private void FindPanel()
  {
    this.panelRegion = (Object) this.target != (Object) null ? UIPanel.Find(this.target.transform.parent) : (UIPanel) null;
    if (!((Object) this.panelRegion == (Object) null))
      return;
    this.restrictWithinPanel = false;
  }

  private void UpdateBounds()
  {
    if ((bool) (Object) this.contentRect)
    {
      Matrix4x4 worldToLocalMatrix = this.panelRegion.cachedTransform.worldToLocalMatrix;
      Vector3[] worldCorners = this.contentRect.worldCorners;
      for (int index = 0; index < 4; ++index)
        worldCorners[index] = worldToLocalMatrix.MultiplyPoint3x4(worldCorners[index]);
      this.mBounds = new Bounds(worldCorners[0], Vector3.zero);
      for (int index = 1; index < 4; ++index)
        this.mBounds.Encapsulate(worldCorners[index]);
    }
    else
      this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.panelRegion.cachedTransform, this.target);
  }

  private void OnPress(bool pressed)
  {
    if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
      return;
    float timeScale = Time.timeScale;
    if ((double) timeScale < 0.0099999997764825821 && (double) timeScale != 0.0 || !this.enabled || !NGUITools.GetActive(this.gameObject) || !((Object) this.target != (Object) null))
      return;
    if (pressed)
    {
      if (this.mPressed)
        return;
      this.mTouchID = UICamera.currentTouchID;
      this.mPressed = true;
      this.mStarted = false;
      this.CancelMovement();
      if (this.restrictWithinPanel && (Object) this.panelRegion == (Object) null)
        this.FindPanel();
      if (this.restrictWithinPanel)
        this.UpdateBounds();
      this.CancelSpring();
      Transform transform = UICamera.currentCamera.transform;
      this.mPlane = new Plane(((Object) this.panelRegion != (Object) null ? this.panelRegion.cachedTransform.rotation : transform.rotation) * Vector3.back, UICamera.lastWorldPosition);
    }
    else
    {
      if (!this.mPressed || this.mTouchID != UICamera.currentTouchID)
        return;
      this.mPressed = false;
      if (!this.restrictWithinPanel || this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring || !this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, false))
        return;
      this.CancelMovement();
    }
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.mPressed || this.mTouchID != UICamera.currentTouchID || !this.enabled || !NGUITools.GetActive(this.gameObject) || !((Object) this.target != (Object) null))
      return;
    UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
    Ray ray = UICamera.currentCamera.ScreenPointToRay((Vector3) UICamera.currentTouch.pos);
    float enter = 0.0f;
    if (!this.mPlane.Raycast(ray, out enter))
      return;
    Vector3 point = ray.GetPoint(enter);
    Vector3 vector3 = point - this.mLastPos;
    this.mLastPos = point;
    if (!this.mStarted)
    {
      this.mStarted = true;
      vector3 = Vector3.zero;
    }
    if ((double) vector3.x != 0.0 || (double) vector3.y != 0.0)
    {
      Vector3 direction = this.target.InverseTransformDirection(vector3);
      direction.Scale(this.scale);
      vector3 = this.target.TransformDirection(direction);
    }
    if (this.dragEffect != UIDragObject.DragEffect.None)
      this.mMomentum = Vector3.Lerp(this.mMomentum, this.mMomentum + vector3 * (0.01f * this.momentumAmount), 0.67f);
    Vector3 localPosition = this.target.localPosition;
    this.Move(vector3);
    if (!this.restrictWithinPanel)
      return;
    this.mBounds.center += this.target.localPosition - localPosition;
    if (this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring || !this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, true))
      return;
    this.CancelMovement();
  }

  private void Move(Vector3 worldDelta)
  {
    if ((Object) this.panelRegion != (Object) null)
    {
      this.mTargetPos += worldDelta;
      Transform parent = this.target.parent;
      Rigidbody component1 = this.target.GetComponent<Rigidbody>();
      if ((Object) parent != (Object) null)
      {
        Vector3 point = parent.worldToLocalMatrix.MultiplyPoint3x4(this.mTargetPos);
        point.x = Mathf.Round(point.x);
        point.y = Mathf.Round(point.y);
        if ((Object) component1 != (Object) null)
        {
          Vector3 vector3 = parent.localToWorldMatrix.MultiplyPoint3x4(point);
          component1.position = vector3;
        }
        else
          this.target.localPosition = point;
      }
      else if ((Object) component1 != (Object) null)
        component1.position = this.mTargetPos;
      else
        this.target.position = this.mTargetPos;
      UIScrollView component2 = this.panelRegion.GetComponent<UIScrollView>();
      if (!((Object) component2 != (Object) null))
        return;
      component2.UpdateScrollbars(true);
    }
    else
      this.target.position += worldDelta;
  }

  private void LateUpdate()
  {
    if ((Object) this.target == (Object) null)
      return;
    float deltaTime = RealTime.deltaTime;
    this.mMomentum -= this.mScroll;
    this.mScroll = NGUIMath.SpringLerp(this.mScroll, Vector3.zero, 20f, deltaTime);
    if ((double) this.mMomentum.magnitude < 9.9999997473787516E-05)
      return;
    if (!this.mPressed)
    {
      if ((Object) this.panelRegion == (Object) null)
        this.FindPanel();
      this.Move(NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime));
      if (this.restrictWithinPanel && (Object) this.panelRegion != (Object) null)
      {
        this.UpdateBounds();
        if (this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, this.dragEffect == UIDragObject.DragEffect.None))
          this.CancelMovement();
        else
          this.CancelSpring();
      }
      NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
      if ((double) this.mMomentum.magnitude >= 9.9999997473787516E-05)
        return;
      this.CancelMovement();
    }
    else
      NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
  }

  public void CancelMovement()
  {
    if ((Object) this.target != (Object) null)
    {
      Vector3 localPosition = this.target.localPosition;
      localPosition.x = (float) Mathf.RoundToInt(localPosition.x);
      localPosition.y = (float) Mathf.RoundToInt(localPosition.y);
      localPosition.z = (float) Mathf.RoundToInt(localPosition.z);
      this.target.localPosition = localPosition;
    }
    this.mTargetPos = (Object) this.target != (Object) null ? this.target.position : Vector3.zero;
    this.mMomentum = Vector3.zero;
    this.mScroll = Vector3.zero;
  }

  public void CancelSpring()
  {
    SpringPosition component = this.target.GetComponent<SpringPosition>();
    if (!((Object) component != (Object) null))
      return;
    component.enabled = false;
  }

  private void OnScroll(float delta)
  {
    if (!this.enabled || !NGUITools.GetActive(this.gameObject))
      return;
    this.mScroll -= this.scrollMomentum * (delta * 0.05f);
  }

  [DoNotObfuscateNGUI]
  public enum DragEffect
  {
    None,
    Momentum,
    MomentumAndSpring,
  }
}
