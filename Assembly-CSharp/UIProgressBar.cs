// Decompiled with JetBrains decompiler
// Type: UIProgressBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Progress Bar")]
public class UIProgressBar : UIWidgetContainer
{
  public static UIProgressBar current;
  public UIProgressBar.OnDragFinished onDragFinished;
  public Transform thumb;
  [HideInInspector]
  [SerializeField]
  protected UIWidget mBG;
  [HideInInspector]
  [SerializeField]
  protected UIWidget mFG;
  [HideInInspector]
  [SerializeField]
  protected float mValue = 1f;
  [HideInInspector]
  [SerializeField]
  protected UIProgressBar.FillDirection mFill;
  [NonSerialized]
  protected bool mStarted;
  [NonSerialized]
  protected Transform mTrans;
  [NonSerialized]
  protected bool mIsDirty;
  [NonSerialized]
  protected Camera mCam;
  [NonSerialized]
  protected float mOffset;
  public int numberOfSteps;
  public List<EventDelegate> onChange = new List<EventDelegate>();

  public Transform cachedTransform
  {
    get
    {
      if ((UnityEngine.Object) this.mTrans == (UnityEngine.Object) null)
        this.mTrans = this.transform;
      return this.mTrans;
    }
  }

  public Camera cachedCamera
  {
    get
    {
      if ((UnityEngine.Object) this.mCam == (UnityEngine.Object) null)
        this.mCam = NGUITools.FindCameraForLayer(this.gameObject.layer);
      return this.mCam;
    }
  }

  public UIWidget foregroundWidget
  {
    get => this.mFG;
    set
    {
      if (!((UnityEngine.Object) this.mFG != (UnityEngine.Object) value))
        return;
      this.mFG = value;
      this.mIsDirty = true;
    }
  }

  public UIWidget backgroundWidget
  {
    get => this.mBG;
    set
    {
      if (!((UnityEngine.Object) this.mBG != (UnityEngine.Object) value))
        return;
      this.mBG = value;
      this.mIsDirty = true;
    }
  }

  public UIProgressBar.FillDirection fillDirection
  {
    get => this.mFill;
    set
    {
      if (this.mFill == value)
        return;
      this.mFill = value;
      if (!this.mStarted)
        return;
      this.ForceUpdate();
    }
  }

  public float value
  {
    get => this.numberOfSteps > 1 ? Mathf.Round(this.mValue * (float) (this.numberOfSteps - 1)) / (float) (this.numberOfSteps - 1) : this.mValue;
    set => this.Set(value);
  }

  public float alpha
  {
    get
    {
      if ((UnityEngine.Object) this.mFG != (UnityEngine.Object) null)
        return this.mFG.alpha;
      return (UnityEngine.Object) this.mBG != (UnityEngine.Object) null ? this.mBG.alpha : 1f;
    }
    set
    {
      if ((UnityEngine.Object) this.mFG != (UnityEngine.Object) null)
      {
        this.mFG.alpha = value;
        if ((UnityEngine.Object) this.mFG.GetComponent<Collider>() != (UnityEngine.Object) null)
          this.mFG.GetComponent<Collider>().enabled = (double) this.mFG.alpha > 1.0 / 1000.0;
        else if ((UnityEngine.Object) this.mFG.GetComponent<Collider2D>() != (UnityEngine.Object) null)
          this.mFG.GetComponent<Collider2D>().enabled = (double) this.mFG.alpha > 1.0 / 1000.0;
      }
      if ((UnityEngine.Object) this.mBG != (UnityEngine.Object) null)
      {
        this.mBG.alpha = value;
        if ((UnityEngine.Object) this.mBG.GetComponent<Collider>() != (UnityEngine.Object) null)
          this.mBG.GetComponent<Collider>().enabled = (double) this.mBG.alpha > 1.0 / 1000.0;
        else if ((UnityEngine.Object) this.mBG.GetComponent<Collider2D>() != (UnityEngine.Object) null)
          this.mBG.GetComponent<Collider2D>().enabled = (double) this.mBG.alpha > 1.0 / 1000.0;
      }
      if (!((UnityEngine.Object) this.thumb != (UnityEngine.Object) null))
        return;
      UIWidget component = this.thumb.GetComponent<UIWidget>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      component.alpha = value;
      if ((UnityEngine.Object) component.GetComponent<Collider>() != (UnityEngine.Object) null)
      {
        component.GetComponent<Collider>().enabled = (double) component.alpha > 1.0 / 1000.0;
      }
      else
      {
        if (!((UnityEngine.Object) component.GetComponent<Collider2D>() != (UnityEngine.Object) null))
          return;
        component.GetComponent<Collider2D>().enabled = (double) component.alpha > 1.0 / 1000.0;
      }
    }
  }

  protected bool isHorizontal => this.mFill == UIProgressBar.FillDirection.LeftToRight || this.mFill == UIProgressBar.FillDirection.RightToLeft;

  protected bool isInverted => this.mFill == UIProgressBar.FillDirection.RightToLeft || this.mFill == UIProgressBar.FillDirection.TopToBottom;

  public void Set(float val, bool notify = true)
  {
    val = Mathf.Clamp01(val);
    if ((double) this.mValue == (double) val)
      return;
    float num = this.value;
    this.mValue = val;
    if (!this.mStarted || (double) num == (double) this.value)
      return;
    if (notify && NGUITools.GetActive((Behaviour) this) && EventDelegate.IsValid(this.onChange))
    {
      UIProgressBar.current = this;
      EventDelegate.Execute(this.onChange);
      UIProgressBar.current = (UIProgressBar) null;
    }
    this.ForceUpdate();
  }

  public void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    this.Upgrade();
    if (Application.isPlaying)
    {
      if ((UnityEngine.Object) this.mBG != (UnityEngine.Object) null)
        this.mBG.autoResizeBoxCollider = true;
      this.OnStart();
      if ((UnityEngine.Object) UIProgressBar.current == (UnityEngine.Object) null && this.onChange != null)
      {
        UIProgressBar.current = this;
        EventDelegate.Execute(this.onChange);
        UIProgressBar.current = (UIProgressBar) null;
      }
    }
    this.ForceUpdate();
  }

  protected virtual void Upgrade()
  {
  }

  protected virtual void OnStart()
  {
  }

  protected void Update()
  {
    if (!this.mIsDirty)
      return;
    this.ForceUpdate();
  }

  protected void OnValidate()
  {
    if (NGUITools.GetActive((Behaviour) this))
    {
      this.Upgrade();
      this.mIsDirty = true;
      float num = Mathf.Clamp01(this.mValue);
      if ((double) this.mValue != (double) num)
        this.mValue = num;
      if (this.numberOfSteps < 0)
        this.numberOfSteps = 0;
      else if (this.numberOfSteps > 21)
        this.numberOfSteps = 21;
      this.ForceUpdate();
    }
    else
    {
      float num = Mathf.Clamp01(this.mValue);
      if ((double) this.mValue != (double) num)
        this.mValue = num;
      if (this.numberOfSteps < 0)
      {
        this.numberOfSteps = 0;
      }
      else
      {
        if (this.numberOfSteps <= 21)
          return;
        this.numberOfSteps = 21;
      }
    }
  }

  protected float ScreenToValue(Vector2 screenPos)
  {
    Transform cachedTransform = this.cachedTransform;
    Plane plane = new Plane(cachedTransform.rotation * Vector3.back, cachedTransform.position);
    Ray ray = this.cachedCamera.ScreenPointToRay((Vector3) screenPos);
    float enter;
    return !plane.Raycast(ray, out enter) ? this.value : this.LocalToValue((Vector2) cachedTransform.InverseTransformPoint(ray.GetPoint(enter)));
  }

  protected virtual float LocalToValue(Vector2 localPos)
  {
    if (!((UnityEngine.Object) this.mFG != (UnityEngine.Object) null))
      return this.value;
    Vector3[] localCorners = this.mFG.localCorners;
    Vector3 vector3 = localCorners[2] - localCorners[0];
    if (this.isHorizontal)
    {
      float num = (localPos.x - localCorners[0].x) / vector3.x;
      return !this.isInverted ? num : 1f - num;
    }
    float num1 = (localPos.y - localCorners[0].y) / vector3.y;
    return !this.isInverted ? num1 : 1f - num1;
  }

  public virtual void ForceUpdate()
  {
    this.mIsDirty = false;
    bool flag = false;
    if ((UnityEngine.Object) this.mFG != (UnityEngine.Object) null)
    {
      UIBasicSprite mFg = this.mFG as UIBasicSprite;
      if (this.isHorizontal)
      {
        if ((UnityEngine.Object) mFg != (UnityEngine.Object) null && mFg.type == UIBasicSprite.Type.Filled)
        {
          if (mFg.fillDirection == UIBasicSprite.FillDirection.Horizontal || mFg.fillDirection == UIBasicSprite.FillDirection.Vertical)
          {
            mFg.fillDirection = UIBasicSprite.FillDirection.Horizontal;
            mFg.invert = this.isInverted;
          }
          mFg.fillAmount = this.value;
        }
        else
        {
          this.mFG.drawRegion = this.isInverted ? new Vector4(1f - this.value, 0.0f, 1f, 1f) : new Vector4(0.0f, 0.0f, this.value, 1f);
          this.mFG.enabled = true;
          flag = (double) this.value < 1.0 / 1000.0;
        }
      }
      else if ((UnityEngine.Object) mFg != (UnityEngine.Object) null && mFg.type == UIBasicSprite.Type.Filled)
      {
        if (mFg.fillDirection == UIBasicSprite.FillDirection.Horizontal || mFg.fillDirection == UIBasicSprite.FillDirection.Vertical)
        {
          mFg.fillDirection = UIBasicSprite.FillDirection.Vertical;
          mFg.invert = this.isInverted;
        }
        mFg.fillAmount = this.value;
      }
      else
      {
        this.mFG.drawRegion = this.isInverted ? new Vector4(0.0f, 1f - this.value, 1f, 1f) : new Vector4(0.0f, 0.0f, 1f, this.value);
        this.mFG.enabled = true;
        flag = (double) this.value < 1.0 / 1000.0;
      }
    }
    if ((UnityEngine.Object) this.thumb != (UnityEngine.Object) null && ((UnityEngine.Object) this.mFG != (UnityEngine.Object) null || (UnityEngine.Object) this.mBG != (UnityEngine.Object) null))
    {
      Vector3[] vector3Array = (UnityEngine.Object) this.mFG != (UnityEngine.Object) null ? this.mFG.localCorners : this.mBG.localCorners;
      Vector4 vector4 = (UnityEngine.Object) this.mFG != (UnityEngine.Object) null ? this.mFG.border : this.mBG.border;
      vector3Array[0].x += vector4.x;
      vector3Array[1].x += vector4.x;
      vector3Array[2].x -= vector4.z;
      vector3Array[3].x -= vector4.z;
      vector3Array[0].y += vector4.y;
      vector3Array[1].y -= vector4.w;
      vector3Array[2].y -= vector4.w;
      vector3Array[3].y += vector4.y;
      Transform transform = (UnityEngine.Object) this.mFG != (UnityEngine.Object) null ? this.mFG.cachedTransform : this.mBG.cachedTransform;
      for (int index = 0; index < 4; ++index)
        vector3Array[index] = transform.TransformPoint(vector3Array[index]);
      if (this.isHorizontal)
        this.SetThumbPosition(Vector3.Lerp(Vector3.Lerp(vector3Array[0], vector3Array[1], 0.5f), Vector3.Lerp(vector3Array[2], vector3Array[3], 0.5f), this.isInverted ? 1f - this.value : this.value));
      else
        this.SetThumbPosition(Vector3.Lerp(Vector3.Lerp(vector3Array[0], vector3Array[3], 0.5f), Vector3.Lerp(vector3Array[1], vector3Array[2], 0.5f), this.isInverted ? 1f - this.value : this.value));
    }
    if (!flag)
      return;
    this.mFG.enabled = false;
  }

  protected void SetThumbPosition(Vector3 worldPos)
  {
    Transform parent = this.thumb.parent;
    if ((UnityEngine.Object) parent != (UnityEngine.Object) null)
    {
      worldPos = parent.InverseTransformPoint(worldPos);
      worldPos.x = Mathf.Round(worldPos.x);
      worldPos.y = Mathf.Round(worldPos.y);
      worldPos.z = 0.0f;
      if ((double) Vector3.Distance(this.thumb.localPosition, worldPos) <= 1.0 / 1000.0)
        return;
      this.thumb.localPosition = worldPos;
    }
    else
    {
      if ((double) Vector3.Distance(this.thumb.position, worldPos) <= 9.9999997473787516E-06)
        return;
      this.thumb.position = worldPos;
    }
  }

  public virtual void OnPan(Vector2 delta)
  {
    if (!this.enabled)
      return;
    switch (this.mFill)
    {
      case UIProgressBar.FillDirection.LeftToRight:
        float num1 = Mathf.Clamp01(this.mValue + delta.x);
        this.value = num1;
        this.mValue = num1;
        break;
      case UIProgressBar.FillDirection.RightToLeft:
        float num2 = Mathf.Clamp01(this.mValue - delta.x);
        this.value = num2;
        this.mValue = num2;
        break;
      case UIProgressBar.FillDirection.BottomToTop:
        float num3 = Mathf.Clamp01(this.mValue + delta.y);
        this.value = num3;
        this.mValue = num3;
        break;
      case UIProgressBar.FillDirection.TopToBottom:
        float num4 = Mathf.Clamp01(this.mValue - delta.y);
        this.value = num4;
        this.mValue = num4;
        break;
    }
  }

  [DoNotObfuscateNGUI]
  public enum FillDirection
  {
    LeftToRight,
    RightToLeft,
    BottomToTop,
    TopToBottom,
  }

  public delegate void OnDragFinished();
}
