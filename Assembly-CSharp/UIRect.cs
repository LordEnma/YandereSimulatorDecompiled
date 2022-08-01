// Decompiled with JetBrains decompiler
// Type: UIRect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public abstract class UIRect : MonoBehaviour
{
  public UIRect.AnchorPoint leftAnchor = new UIRect.AnchorPoint();
  public UIRect.AnchorPoint rightAnchor = new UIRect.AnchorPoint(1f);
  public UIRect.AnchorPoint bottomAnchor = new UIRect.AnchorPoint();
  public UIRect.AnchorPoint topAnchor = new UIRect.AnchorPoint(1f);
  public UIRect.AnchorUpdate updateAnchors = UIRect.AnchorUpdate.OnUpdate;
  [NonSerialized]
  protected GameObject mGo;
  [NonSerialized]
  protected Transform mTrans;
  [NonSerialized]
  protected BetterList<UIRect> mChildren = new BetterList<UIRect>();
  [NonSerialized]
  protected bool mChanged = true;
  [NonSerialized]
  protected bool mParentFound;
  [NonSerialized]
  private bool mUpdateAnchors = true;
  [NonSerialized]
  private int mUpdateFrame = -1;
  [NonSerialized]
  private bool mAnchorsCached;
  [NonSerialized]
  private UIRoot mRoot;
  [NonSerialized]
  private UIRect mParent;
  [NonSerialized]
  private bool mRootSet;
  [NonSerialized]
  protected Camera mCam;
  protected bool mStarted;
  [NonSerialized]
  public float finalAlpha = 1f;
  protected static Vector3[] mSides = new Vector3[4];

  public GameObject cachedGameObject
  {
    get
    {
      if ((UnityEngine.Object) this.mGo == (UnityEngine.Object) null)
        this.mGo = this.gameObject;
      return this.mGo;
    }
  }

  public Transform cachedTransform
  {
    get
    {
      if ((UnityEngine.Object) this.mTrans == (UnityEngine.Object) null)
        this.mTrans = this.transform;
      return this.mTrans;
    }
  }

  public Camera anchorCamera
  {
    get
    {
      if (!(bool) (UnityEngine.Object) this.mCam || !this.mAnchorsCached)
        this.ResetAnchors();
      return this.mCam;
    }
  }

  public bool isFullyAnchored => (bool) (UnityEngine.Object) this.leftAnchor.target && (bool) (UnityEngine.Object) this.rightAnchor.target && (bool) (UnityEngine.Object) this.topAnchor.target && (bool) (UnityEngine.Object) this.bottomAnchor.target;

  public virtual bool isAnchoredHorizontally => (bool) (UnityEngine.Object) this.leftAnchor.target || (bool) (UnityEngine.Object) this.rightAnchor.target;

  public virtual bool isAnchoredVertically => (bool) (UnityEngine.Object) this.bottomAnchor.target || (bool) (UnityEngine.Object) this.topAnchor.target;

  public virtual bool canBeAnchored => true;

  public UIRect parent
  {
    get
    {
      if (!this.mParentFound)
      {
        this.mParentFound = true;
        this.mParent = NGUITools.FindInParents<UIRect>(this.cachedTransform.parent);
      }
      return this.mParent;
    }
  }

  public UIRoot root
  {
    get
    {
      if ((UnityEngine.Object) this.parent != (UnityEngine.Object) null)
        return this.mParent.root;
      if (!this.mRootSet)
      {
        this.mRootSet = true;
        this.mRoot = NGUITools.FindInParents<UIRoot>(this.cachedTransform);
      }
      return this.mRoot;
    }
  }

  public bool isAnchored => ((bool) (UnityEngine.Object) this.leftAnchor.target || (bool) (UnityEngine.Object) this.rightAnchor.target || (bool) (UnityEngine.Object) this.topAnchor.target || (bool) (UnityEngine.Object) this.bottomAnchor.target) && this.canBeAnchored;

  public abstract float alpha { get; set; }

  public abstract float CalculateFinalAlpha(int frameID);

  public abstract Vector3[] localCorners { get; }

  public abstract Vector3[] worldCorners { get; }

  protected float cameraRayDistance
  {
    get
    {
      if ((UnityEngine.Object) this.anchorCamera == (UnityEngine.Object) null)
        return 0.0f;
      if (!this.mCam.orthographic)
      {
        Transform cachedTransform = this.cachedTransform;
        Transform transform = this.mCam.transform;
        float enter;
        if (new Plane(cachedTransform.rotation * Vector3.back, cachedTransform.position).Raycast(new Ray(transform.position, transform.rotation * Vector3.forward), out enter))
          return enter;
      }
      return Mathf.Lerp(this.mCam.nearClipPlane, this.mCam.farClipPlane, 0.5f);
    }
  }

  public virtual void Invalidate(bool includeChildren)
  {
    this.mChanged = true;
    if (!includeChildren)
      return;
    for (int index = 0; index < this.mChildren.size; ++index)
      this.mChildren.buffer[index].Invalidate(true);
  }

  public virtual Vector3[] GetSides(Transform relativeTo)
  {
    if ((UnityEngine.Object) this.anchorCamera != (UnityEngine.Object) null)
      return this.mCam.GetSides(this.cameraRayDistance, relativeTo);
    Vector3 position = this.cachedTransform.position;
    for (int index = 0; index < 4; ++index)
      UIRect.mSides[index] = position;
    if ((UnityEngine.Object) relativeTo != (UnityEngine.Object) null)
    {
      for (int index = 0; index < 4; ++index)
        UIRect.mSides[index] = relativeTo.InverseTransformPoint(UIRect.mSides[index]);
    }
    return UIRect.mSides;
  }

  protected Vector3 GetLocalPos(UIRect.AnchorPoint ac, Transform trans)
  {
    if ((UnityEngine.Object) ac.targetCam == (UnityEngine.Object) null)
      this.FindCameraFor(ac);
    if ((UnityEngine.Object) this.anchorCamera == (UnityEngine.Object) null || (UnityEngine.Object) ac.targetCam == (UnityEngine.Object) null)
      return this.cachedTransform.localPosition;
    Rect rect = ac.targetCam.rect;
    Vector3 viewportPoint = ac.targetCam.WorldToViewportPoint(ac.target.position);
    Vector3 position = this.mCam.ViewportToWorldPoint(new Vector3(viewportPoint.x * rect.width + rect.x, viewportPoint.y * rect.height + rect.y, viewportPoint.z));
    if ((UnityEngine.Object) trans != (UnityEngine.Object) null)
      position = trans.InverseTransformPoint(position);
    position.x = Mathf.Floor(position.x + 0.5f);
    position.y = Mathf.Floor(position.y + 0.5f);
    return position;
  }

  protected virtual void OnEnable()
  {
    this.mUpdateFrame = -1;
    if (this.updateAnchors == UIRect.AnchorUpdate.OnEnable)
    {
      this.mAnchorsCached = false;
      this.mUpdateAnchors = true;
    }
    if (this.mStarted)
      this.OnInit();
    this.mUpdateFrame = -1;
  }

  protected virtual void OnInit()
  {
    this.mChanged = true;
    this.mRootSet = false;
    this.mParentFound = false;
    if (!((UnityEngine.Object) this.parent != (UnityEngine.Object) null))
      return;
    this.mParent.mChildren.Add(this);
  }

  protected virtual void OnDisable()
  {
    if ((bool) (UnityEngine.Object) this.mParent)
      this.mParent.mChildren.Remove(this);
    this.mParent = (UIRect) null;
    this.mRoot = (UIRoot) null;
    this.mRootSet = false;
    this.mParentFound = false;
  }

  protected virtual void Awake()
  {
    NGUITools.CheckForPrefabStage(this.gameObject);
    this.mStarted = false;
    this.mGo = this.gameObject;
    this.mTrans = this.transform;
  }

  protected void Start()
  {
    this.mStarted = true;
    this.OnInit();
    this.OnStart();
  }

  public void Update()
  {
    if (!(bool) (UnityEngine.Object) this.mCam)
    {
      this.ResetAndUpdateAnchors();
      this.mUpdateFrame = -1;
    }
    else if (!this.mAnchorsCached)
      this.ResetAnchors();
    int frameCount = Time.frameCount;
    if (this.mUpdateFrame == frameCount)
      return;
    if (this.updateAnchors == UIRect.AnchorUpdate.OnUpdate || this.mUpdateAnchors)
      this.UpdateAnchorsInternal(frameCount);
    this.OnUpdate();
  }

  protected void UpdateAnchorsInternal(int frame)
  {
    this.mUpdateFrame = frame;
    this.mUpdateAnchors = false;
    bool flag = false;
    if ((bool) (UnityEngine.Object) this.leftAnchor.target)
    {
      flag = true;
      if ((UnityEngine.Object) this.leftAnchor.rect != (UnityEngine.Object) null && this.leftAnchor.rect.mUpdateFrame != frame)
        this.leftAnchor.rect.Update();
    }
    if ((bool) (UnityEngine.Object) this.bottomAnchor.target)
    {
      flag = true;
      if ((UnityEngine.Object) this.bottomAnchor.rect != (UnityEngine.Object) null && this.bottomAnchor.rect.mUpdateFrame != frame)
        this.bottomAnchor.rect.Update();
    }
    if ((bool) (UnityEngine.Object) this.rightAnchor.target)
    {
      flag = true;
      if ((UnityEngine.Object) this.rightAnchor.rect != (UnityEngine.Object) null && this.rightAnchor.rect.mUpdateFrame != frame)
        this.rightAnchor.rect.Update();
    }
    if ((bool) (UnityEngine.Object) this.topAnchor.target)
    {
      flag = true;
      if ((UnityEngine.Object) this.topAnchor.rect != (UnityEngine.Object) null && this.topAnchor.rect.mUpdateFrame != frame)
        this.topAnchor.rect.Update();
    }
    if (!flag)
      return;
    this.OnAnchor();
  }

  public void UpdateAnchors()
  {
    if (!this.isAnchored)
      return;
    this.mUpdateFrame = -1;
    this.mUpdateAnchors = true;
    this.UpdateAnchorsInternal(Time.frameCount);
  }

  protected abstract void OnAnchor();

  public void SetAnchor(Transform t)
  {
    this.leftAnchor.target = t;
    this.rightAnchor.target = t;
    this.topAnchor.target = t;
    this.bottomAnchor.target = t;
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public void SetAnchor(GameObject go)
  {
    Transform transform = (UnityEngine.Object) go != (UnityEngine.Object) null ? go.transform : (Transform) null;
    this.leftAnchor.target = transform;
    this.rightAnchor.target = transform;
    this.topAnchor.target = transform;
    this.bottomAnchor.target = transform;
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public void SetAnchor(GameObject go, int left, int bottom, int right, int top)
  {
    Transform transform = (UnityEngine.Object) go != (UnityEngine.Object) null ? go.transform : (Transform) null;
    this.leftAnchor.target = transform;
    this.rightAnchor.target = transform;
    this.topAnchor.target = transform;
    this.bottomAnchor.target = transform;
    this.leftAnchor.relative = 0.0f;
    this.rightAnchor.relative = 1f;
    this.bottomAnchor.relative = 0.0f;
    this.topAnchor.relative = 1f;
    this.leftAnchor.absolute = left;
    this.rightAnchor.absolute = right;
    this.bottomAnchor.absolute = bottom;
    this.topAnchor.absolute = top;
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public void SetAnchor(GameObject go, float left, float bottom, float right, float top)
  {
    Transform transform = (UnityEngine.Object) go != (UnityEngine.Object) null ? go.transform : (Transform) null;
    this.leftAnchor.target = transform;
    this.rightAnchor.target = transform;
    this.topAnchor.target = transform;
    this.bottomAnchor.target = transform;
    this.leftAnchor.relative = left;
    this.rightAnchor.relative = right;
    this.bottomAnchor.relative = bottom;
    this.topAnchor.relative = top;
    this.leftAnchor.absolute = 0;
    this.rightAnchor.absolute = 0;
    this.bottomAnchor.absolute = 0;
    this.topAnchor.absolute = 0;
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public void SetAnchor(
    GameObject go,
    float left,
    int leftOffset,
    float bottom,
    int bottomOffset,
    float right,
    int rightOffset,
    float top,
    int topOffset)
  {
    Transform transform = (UnityEngine.Object) go != (UnityEngine.Object) null ? go.transform : (Transform) null;
    this.leftAnchor.target = transform;
    this.rightAnchor.target = transform;
    this.topAnchor.target = transform;
    this.bottomAnchor.target = transform;
    this.leftAnchor.relative = left;
    this.rightAnchor.relative = right;
    this.bottomAnchor.relative = bottom;
    this.topAnchor.relative = top;
    this.leftAnchor.absolute = leftOffset;
    this.rightAnchor.absolute = rightOffset;
    this.bottomAnchor.absolute = bottomOffset;
    this.topAnchor.absolute = topOffset;
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public void SetAnchor(
    float left,
    int leftOffset,
    float bottom,
    int bottomOffset,
    float right,
    int rightOffset,
    float top,
    int topOffset)
  {
    Transform parent = this.cachedTransform.parent;
    this.leftAnchor.target = parent;
    this.rightAnchor.target = parent;
    this.topAnchor.target = parent;
    this.bottomAnchor.target = parent;
    this.leftAnchor.relative = left;
    this.rightAnchor.relative = right;
    this.bottomAnchor.relative = bottom;
    this.topAnchor.relative = top;
    this.leftAnchor.absolute = leftOffset;
    this.rightAnchor.absolute = rightOffset;
    this.bottomAnchor.absolute = bottomOffset;
    this.topAnchor.absolute = topOffset;
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public void SetScreenRect(int left, int top, int width, int height) => this.SetAnchor(0.0f, left, 1f, -top - height, 0.0f, left + width, 1f, -top);

  public void ResetAnchors()
  {
    this.mAnchorsCached = true;
    this.leftAnchor.rect = (bool) (UnityEngine.Object) this.leftAnchor.target ? this.leftAnchor.target.GetComponent<UIRect>() : (UIRect) null;
    this.bottomAnchor.rect = (bool) (UnityEngine.Object) this.bottomAnchor.target ? this.bottomAnchor.target.GetComponent<UIRect>() : (UIRect) null;
    this.rightAnchor.rect = (bool) (UnityEngine.Object) this.rightAnchor.target ? this.rightAnchor.target.GetComponent<UIRect>() : (UIRect) null;
    this.topAnchor.rect = (bool) (UnityEngine.Object) this.topAnchor.target ? this.topAnchor.target.GetComponent<UIRect>() : (UIRect) null;
    this.mCam = NGUITools.FindCameraForLayer(this.cachedGameObject.layer);
    this.FindCameraFor(this.leftAnchor);
    this.FindCameraFor(this.bottomAnchor);
    this.FindCameraFor(this.rightAnchor);
    this.FindCameraFor(this.topAnchor);
    this.mUpdateAnchors = true;
  }

  public void ResetAndUpdateAnchors()
  {
    this.ResetAnchors();
    this.UpdateAnchors();
  }

  public abstract void SetRect(float x, float y, float width, float height);

  private void FindCameraFor(UIRect.AnchorPoint ap)
  {
    if ((UnityEngine.Object) ap.target == (UnityEngine.Object) null || (UnityEngine.Object) ap.rect != (UnityEngine.Object) null)
      ap.targetCam = (Camera) null;
    else
      ap.targetCam = NGUITools.FindCameraForLayer(ap.target.gameObject.layer);
  }

  public virtual void ParentHasChanged()
  {
    this.mParentFound = false;
    UIRect inParents = NGUITools.FindInParents<UIRect>(this.cachedTransform.parent);
    if (!((UnityEngine.Object) this.mParent != (UnityEngine.Object) inParents))
      return;
    if ((bool) (UnityEngine.Object) this.mParent)
      this.mParent.mChildren.Remove(this);
    this.mParent = inParents;
    if ((bool) (UnityEngine.Object) this.mParent)
      this.mParent.mChildren.Add(this);
    this.mRootSet = false;
  }

  protected abstract void OnStart();

  protected virtual void OnUpdate()
  {
  }

  [Serializable]
  public class AnchorPoint
  {
    public Transform target;
    public float relative;
    public int absolute;
    [NonSerialized]
    public UIRect rect;
    [NonSerialized]
    public Camera targetCam;

    public AnchorPoint()
    {
    }

    public AnchorPoint(float relative) => this.relative = relative;

    public void Set(float relative, float absolute)
    {
      this.relative = relative;
      this.absolute = Mathf.FloorToInt(absolute + 0.5f);
    }

    public void Set(Transform target, float relative, float absolute)
    {
      this.target = target;
      this.relative = relative;
      this.absolute = Mathf.FloorToInt(absolute + 0.5f);
    }

    public void SetToNearest(float abs0, float abs1, float abs2) => this.SetToNearest(0.0f, 0.5f, 1f, abs0, abs1, abs2);

    public void SetToNearest(
      float rel0,
      float rel1,
      float rel2,
      float abs0,
      float abs1,
      float abs2)
    {
      float num1 = Mathf.Abs(abs0);
      float num2 = Mathf.Abs(abs1);
      float num3 = Mathf.Abs(abs2);
      if ((double) num1 < (double) num2 && (double) num1 < (double) num3)
        this.Set(rel0, abs0);
      else if ((double) num2 < (double) num1 && (double) num2 < (double) num3)
        this.Set(rel1, abs1);
      else
        this.Set(rel2, abs2);
    }

    public void SetHorizontal(Transform parent, float localPos)
    {
      if ((bool) (UnityEngine.Object) this.rect)
      {
        Vector3[] sides = this.rect.GetSides(parent);
        float num = Mathf.Lerp(sides[0].x, sides[2].x, this.relative);
        this.absolute = Mathf.FloorToInt((float) ((double) localPos - (double) num + 0.5));
      }
      else
      {
        Vector3 position = this.target.position;
        if ((UnityEngine.Object) parent != (UnityEngine.Object) null)
          position = parent.InverseTransformPoint(position);
        this.absolute = Mathf.FloorToInt((float) ((double) localPos - (double) position.x + 0.5));
      }
    }

    public void SetVertical(Transform parent, float localPos)
    {
      if ((bool) (UnityEngine.Object) this.rect)
      {
        Vector3[] sides = this.rect.GetSides(parent);
        float num = Mathf.Lerp(sides[3].y, sides[1].y, this.relative);
        this.absolute = Mathf.FloorToInt((float) ((double) localPos - (double) num + 0.5));
      }
      else
      {
        Vector3 position = this.target.position;
        if ((UnityEngine.Object) parent != (UnityEngine.Object) null)
          position = parent.InverseTransformPoint(position);
        this.absolute = Mathf.FloorToInt((float) ((double) localPos - (double) position.y + 0.5));
      }
    }

    public Vector3[] GetSides(Transform relativeTo)
    {
      if ((UnityEngine.Object) this.target != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.rect != (UnityEngine.Object) null)
          return this.rect.GetSides(relativeTo);
        Camera component = this.target.GetComponent<Camera>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          return component.GetSides(relativeTo);
      }
      return (Vector3[]) null;
    }
  }

  [DoNotObfuscateNGUI]
  public enum AnchorUpdate
  {
    OnEnable,
    OnUpdate,
    OnStart,
  }
}
