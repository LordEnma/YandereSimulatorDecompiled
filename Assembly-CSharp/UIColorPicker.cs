// Decompiled with JetBrains decompiler
// Type: UIColorPicker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (UITexture))]
public class UIColorPicker : MonoBehaviour
{
  public static UIColorPicker current;
  public Color value = Color.white;
  public UIWidget selectionWidget;
  public List<EventDelegate> onChange = new List<EventDelegate>();
  [NonSerialized]
  private Transform mTrans;
  [NonSerialized]
  private UITexture mUITex;
  [NonSerialized]
  private Texture2D mTex;
  [NonSerialized]
  private UICamera mCam;
  [NonSerialized]
  private Vector2 mPos;
  [NonSerialized]
  private int mWidth;
  [NonSerialized]
  private int mHeight;
  private static AnimationCurve mRed;
  private static AnimationCurve mGreen;
  private static AnimationCurve mBlue;

  private void Start()
  {
    this.mTrans = this.transform;
    this.mUITex = this.GetComponent<UITexture>();
    this.mCam = UICamera.FindCameraForLayer(this.gameObject.layer);
    this.mWidth = this.mUITex.width;
    this.mHeight = this.mUITex.height;
    Color[] colors = new Color[this.mWidth * this.mHeight];
    for (int index1 = 0; index1 < this.mHeight; ++index1)
    {
      float y = ((float) index1 - 1f) / (float) this.mHeight;
      for (int index2 = 0; index2 < this.mWidth; ++index2)
      {
        float x = ((float) index2 - 1f) / (float) this.mWidth;
        int index3 = index2 + index1 * this.mWidth;
        colors[index3] = UIColorPicker.Sample(x, y);
      }
    }
    this.mTex = new Texture2D(this.mWidth, this.mHeight, TextureFormat.RGB24, false);
    this.mTex.SetPixels(colors);
    this.mTex.filterMode = FilterMode.Trilinear;
    this.mTex.wrapMode = TextureWrapMode.Clamp;
    this.mTex.Apply();
    this.mUITex.mainTexture = (Texture) this.mTex;
    this.Select(this.value);
  }

  private void OnDestroy()
  {
    UnityEngine.Object.Destroy((UnityEngine.Object) this.mTex);
    this.mTex = (Texture2D) null;
  }

  private void OnPress(bool pressed)
  {
    if (!(this.enabled & pressed) || UICamera.currentScheme == UICamera.ControlScheme.Controller)
      return;
    this.Sample();
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.enabled)
      return;
    this.Sample();
  }

  private void OnPan(Vector2 delta)
  {
    if (!this.enabled)
      return;
    this.mPos.x = Mathf.Clamp01(this.mPos.x + delta.x);
    this.mPos.y = Mathf.Clamp01(this.mPos.y + delta.y);
    this.Select(this.mPos);
  }

  private void Sample()
  {
    Vector3 position = this.mTrans.InverseTransformPoint(UICamera.lastWorldPosition);
    Vector3[] localCorners = this.mUITex.localCorners;
    this.mPos.x = Mathf.Clamp01((float) (((double) position.x - (double) localCorners[0].x) / ((double) localCorners[2].x - (double) localCorners[0].x)));
    this.mPos.y = Mathf.Clamp01((float) (((double) position.y - (double) localCorners[0].y) / ((double) localCorners[2].y - (double) localCorners[0].y)));
    if ((UnityEngine.Object) this.selectionWidget != (UnityEngine.Object) null)
    {
      position.x = Mathf.Lerp(localCorners[0].x, localCorners[2].x, this.mPos.x);
      position.y = Mathf.Lerp(localCorners[0].y, localCorners[2].y, this.mPos.y);
      this.selectionWidget.transform.OverlayPosition(this.mTrans.TransformPoint(position), this.mCam.cachedCamera);
    }
    this.value = UIColorPicker.Sample(this.mPos.x, this.mPos.y);
    UIColorPicker.current = this;
    EventDelegate.Execute(this.onChange);
    UIColorPicker.current = (UIColorPicker) null;
  }

  public void Select(Vector2 v)
  {
    v.x = Mathf.Clamp01(v.x);
    v.y = Mathf.Clamp01(v.y);
    this.mPos = v;
    if ((UnityEngine.Object) this.selectionWidget != (UnityEngine.Object) null)
    {
      Vector3[] localCorners = this.mUITex.localCorners;
      v.x = Mathf.Lerp(localCorners[0].x, localCorners[2].x, this.mPos.x);
      v.y = Mathf.Lerp(localCorners[0].y, localCorners[2].y, this.mPos.y);
      v = (Vector2) this.mTrans.TransformPoint((Vector3) v);
      this.selectionWidget.transform.OverlayPosition((Vector3) v, this.mCam.cachedCamera);
    }
    this.value = UIColorPicker.Sample(this.mPos.x, this.mPos.y);
    UIColorPicker.current = this;
    EventDelegate.Execute(this.onChange);
    UIColorPicker.current = (UIColorPicker) null;
  }

  public Vector2 Select(Color c)
  {
    if ((UnityEngine.Object) this.mUITex == (UnityEngine.Object) null)
    {
      this.value = c;
      return this.mPos;
    }
    float num1 = float.MaxValue;
    for (int index1 = 0; index1 < this.mHeight; ++index1)
    {
      float y = ((float) index1 - 1f) / (float) this.mHeight;
      for (int index2 = 0; index2 < this.mWidth; ++index2)
      {
        float x = ((float) index2 - 1f) / (float) this.mWidth;
        Color color = UIColorPicker.Sample(x, y);
        color.r -= c.r;
        color.g -= c.g;
        color.b -= c.b;
        float num2 = (float) ((double) color.r * (double) color.r + (double) color.g * (double) color.g + (double) color.b * (double) color.b);
        if ((double) num2 < (double) num1)
        {
          num1 = num2;
          this.mPos.x = x;
          this.mPos.y = y;
        }
      }
    }
    if ((UnityEngine.Object) this.selectionWidget != (UnityEngine.Object) null)
    {
      Vector3[] localCorners = this.mUITex.localCorners;
      Vector3 vector3;
      vector3.x = Mathf.Lerp(localCorners[0].x, localCorners[2].x, this.mPos.x);
      vector3.y = Mathf.Lerp(localCorners[0].y, localCorners[2].y, this.mPos.y);
      vector3.z = 0.0f;
      vector3 = this.mTrans.TransformPoint(vector3);
      this.selectionWidget.transform.OverlayPosition(vector3, this.mCam.cachedCamera);
    }
    this.value = c;
    UIColorPicker.current = this;
    EventDelegate.Execute(this.onChange);
    UIColorPicker.current = (UIColorPicker) null;
    return this.mPos;
  }

  public static Color Sample(float x, float y)
  {
    if (UIColorPicker.mRed == null)
    {
      UIColorPicker.mRed = new AnimationCurve(new Keyframe[8]
      {
        new Keyframe(0.0f, 1f),
        new Keyframe(0.1428571f, 1f),
        new Keyframe(0.2857143f, 0.0f),
        new Keyframe(0.4285714f, 0.0f),
        new Keyframe(0.5714286f, 0.0f),
        new Keyframe(0.7142857f, 1f),
        new Keyframe(0.8571429f, 1f),
        new Keyframe(1f, 0.5f)
      });
      UIColorPicker.mGreen = new AnimationCurve(new Keyframe[8]
      {
        new Keyframe(0.0f, 0.0f),
        new Keyframe(0.1428571f, 1f),
        new Keyframe(0.2857143f, 1f),
        new Keyframe(0.4285714f, 1f),
        new Keyframe(0.5714286f, 0.0f),
        new Keyframe(0.7142857f, 0.0f),
        new Keyframe(0.8571429f, 0.0f),
        new Keyframe(1f, 0.5f)
      });
      UIColorPicker.mBlue = new AnimationCurve(new Keyframe[8]
      {
        new Keyframe(0.0f, 0.0f),
        new Keyframe(0.1428571f, 0.0f),
        new Keyframe(0.2857143f, 0.0f),
        new Keyframe(0.4285714f, 1f),
        new Keyframe(0.5714286f, 1f),
        new Keyframe(0.7142857f, 1f),
        new Keyframe(0.8571429f, 0.0f),
        new Keyframe(1f, 0.5f)
      });
    }
    Vector3 a = new Vector3(UIColorPicker.mRed.Evaluate(x), UIColorPicker.mGreen.Evaluate(x), UIColorPicker.mBlue.Evaluate(x));
    if ((double) y < 0.5)
    {
      y *= 2f;
      a.x *= y;
      a.y *= y;
      a.z *= y;
    }
    else
      a = Vector3.Lerp(a, Vector3.one, (float) ((double) y * 2.0 - 1.0));
    return new Color(a.x, a.y, a.z, 1f);
  }
}
