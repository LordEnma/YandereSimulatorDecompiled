// Decompiled with JetBrains decompiler
// Type: UITooltip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Tooltip")]
public class UITooltip : MonoBehaviour
{
  protected static UITooltip mInstance;
  public Camera uiCamera;
  public UILabel text;
  public GameObject tooltipRoot;
  public UISprite background;
  public float appearSpeed = 10f;
  public bool scalingTransitions = true;
  protected GameObject mTooltip;
  protected Transform mTrans;
  protected float mTarget;
  protected float mCurrent;
  protected Vector3 mPos;
  protected Vector3 mSize = Vector3.zero;
  protected UIWidget[] mWidgets;

  public static bool isVisible => (UnityEngine.Object) UITooltip.mInstance != (UnityEngine.Object) null && (double) UITooltip.mInstance.mTarget == 1.0;

  private void Awake() => UITooltip.mInstance = this;

  private void OnDestroy() => UITooltip.mInstance = (UITooltip) null;

  protected virtual void Start()
  {
    this.mTrans = this.transform;
    this.mWidgets = this.GetComponentsInChildren<UIWidget>();
    this.mPos = this.mTrans.localPosition;
    if ((UnityEngine.Object) this.uiCamera == (UnityEngine.Object) null)
      this.uiCamera = NGUITools.FindCameraForLayer(this.gameObject.layer);
    this.SetAlpha(0.0f);
  }

  protected virtual void Update()
  {
    if ((UnityEngine.Object) this.mTooltip != (UnityEngine.Object) UICamera.tooltipObject)
    {
      this.mTooltip = (GameObject) null;
      this.mTarget = 0.0f;
    }
    if ((double) this.mCurrent == (double) this.mTarget)
      return;
    this.mCurrent = Mathf.Lerp(this.mCurrent, this.mTarget, RealTime.deltaTime * this.appearSpeed);
    if ((double) Mathf.Abs(this.mCurrent - this.mTarget) < 1.0 / 1000.0)
      this.mCurrent = this.mTarget;
    this.SetAlpha(this.mCurrent * this.mCurrent);
    if (!this.scalingTransitions)
      return;
    Vector3 vector3_1 = this.mSize * 0.25f;
    vector3_1.y = -vector3_1.y;
    Vector3 vector3_2 = Vector3.one * (float) (1.5 - (double) this.mCurrent * 0.5);
    this.mTrans.localPosition = Vector3.Lerp(this.mPos - vector3_1, this.mPos, this.mCurrent);
    this.mTrans.localScale = vector3_2;
  }

  protected virtual void SetAlpha(float val)
  {
    int index = 0;
    for (int length = this.mWidgets.Length; index < length; ++index)
    {
      UIWidget mWidget = this.mWidgets[index];
      mWidget.color = mWidget.color with { a = val };
    }
  }

  protected virtual void SetText(string tooltipText)
  {
    if ((UnityEngine.Object) this.text != (UnityEngine.Object) null && !string.IsNullOrEmpty(tooltipText))
    {
      this.mTarget = 1f;
      this.mTooltip = UICamera.tooltipObject;
      this.text.text = tooltipText;
      this.mPos = (Vector3) UICamera.lastEventPosition;
      Transform transform = this.text.transform;
      Vector3 localPosition = transform.localPosition;
      Vector3 localScale = transform.localScale;
      this.mSize = (Vector3) this.text.printedSize;
      this.mSize.x *= localScale.x;
      this.mSize.y *= localScale.y;
      if ((UnityEngine.Object) this.background != (UnityEngine.Object) null)
      {
        Vector4 border = this.background.border;
        this.mSize.x += (float) ((double) border.x + (double) border.z + ((double) localPosition.x - (double) border.x) * 2.0);
        this.mSize.y += (float) ((double) border.y + (double) border.w + (-(double) localPosition.y - (double) border.y) * 2.0);
        this.background.width = Mathf.RoundToInt(this.mSize.x);
        this.background.height = Mathf.RoundToInt(this.mSize.y);
      }
      if ((UnityEngine.Object) this.uiCamera != (UnityEngine.Object) null)
      {
        this.mPos.x = Mathf.Clamp01(this.mPos.x / (float) Screen.width);
        this.mPos.y = Mathf.Clamp01(this.mPos.y / (float) Screen.height);
        float num = (float) Screen.height * 0.5f / (this.uiCamera.orthographicSize / this.mTrans.parent.lossyScale.y);
        Vector2 vector2 = new Vector2(num * this.mSize.x / (float) Screen.width, num * this.mSize.y / (float) Screen.height);
        this.mPos.x = Mathf.Min(this.mPos.x, 1f - vector2.x);
        this.mPos.y = Mathf.Max(this.mPos.y, vector2.y);
        this.mTrans.position = this.uiCamera.ViewportToWorldPoint(this.mPos);
        this.mPos = this.mTrans.localPosition;
        this.mPos.x = Mathf.Round(this.mPos.x);
        this.mPos.y = Mathf.Round(this.mPos.y);
      }
      else
      {
        if ((double) this.mPos.x + (double) this.mSize.x > (double) Screen.width)
          this.mPos.x = (float) Screen.width - this.mSize.x;
        if ((double) this.mPos.y - (double) this.mSize.y < 0.0)
          this.mPos.y = this.mSize.y;
        this.mPos.x -= (float) Screen.width * 0.5f;
        this.mPos.y -= (float) Screen.height * 0.5f;
      }
      this.mTrans.localPosition = this.mPos;
      if ((UnityEngine.Object) this.tooltipRoot != (UnityEngine.Object) null)
        this.tooltipRoot.BroadcastMessage("UpdateAnchors");
      else
        this.text.BroadcastMessage("UpdateAnchors");
    }
    else
    {
      this.mTooltip = (GameObject) null;
      this.mTarget = 0.0f;
    }
  }

  [Obsolete("Use UITooltip.Show instead")]
  public static void ShowText(string text)
  {
    if (!((UnityEngine.Object) UITooltip.mInstance != (UnityEngine.Object) null))
      return;
    UITooltip.mInstance.SetText(text);
  }

  public static void Show(string text)
  {
    if (!((UnityEngine.Object) UITooltip.mInstance != (UnityEngine.Object) null))
      return;
    UITooltip.mInstance.SetText(text);
  }

  public static void Hide()
  {
    if (!((UnityEngine.Object) UITooltip.mInstance != (UnityEngine.Object) null))
      return;
    UITooltip.mInstance.mTooltip = (GameObject) null;
    UITooltip.mInstance.mTarget = 0.0f;
  }
}
