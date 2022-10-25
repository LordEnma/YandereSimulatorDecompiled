// Decompiled with JetBrains decompiler
// Type: UITexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Texture")]
public class UITexture : UIBasicSprite
{
  [HideInInspector]
  [SerializeField]
  private Rect mRect = new Rect(0.0f, 0.0f, 1f, 1f);
  [HideInInspector]
  [SerializeField]
  private Texture mTexture;
  [HideInInspector]
  [SerializeField]
  private Shader mShader;
  [HideInInspector]
  [SerializeField]
  private Vector4 mBorder = Vector4.zero;
  [HideInInspector]
  [SerializeField]
  private bool mFixedAspect;
  [NonSerialized]
  private int mPMA = -1;

  public override Texture mainTexture
  {
    get
    {
      if ((UnityEngine.Object) this.mTexture != (UnityEngine.Object) null)
        return this.mTexture;
      return (UnityEngine.Object) this.mMat != (UnityEngine.Object) null ? this.mMat.mainTexture : (Texture) null;
    }
    set
    {
      if (!((UnityEngine.Object) this.mTexture != (UnityEngine.Object) value))
        return;
      if ((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null && this.drawCall.widgetCount == 1 && (UnityEngine.Object) this.mMat == (UnityEngine.Object) null)
      {
        this.mTexture = value;
        this.drawCall.mainTexture = value;
      }
      else
      {
        this.RemoveFromPanel();
        this.mTexture = value;
        this.mPMA = -1;
        this.MarkAsChanged();
      }
    }
  }

  public override Material material
  {
    get => this.mMat;
    set
    {
      if (!((UnityEngine.Object) this.mMat != (UnityEngine.Object) value))
        return;
      this.RemoveFromPanel();
      this.mShader = (Shader) null;
      this.mMat = value;
      this.mPMA = -1;
      this.MarkAsChanged();
    }
  }

  public override Shader shader
  {
    get
    {
      if ((UnityEngine.Object) this.mMat != (UnityEngine.Object) null)
        return this.mMat.shader;
      if ((UnityEngine.Object) this.mShader == (UnityEngine.Object) null)
        this.mShader = Shader.Find("Unlit/Transparent Colored");
      return this.mShader;
    }
    set
    {
      if (!((UnityEngine.Object) this.mShader != (UnityEngine.Object) value))
        return;
      if ((UnityEngine.Object) this.drawCall != (UnityEngine.Object) null && this.drawCall.widgetCount == 1 && (UnityEngine.Object) this.mMat == (UnityEngine.Object) null)
      {
        this.mShader = value;
        this.drawCall.shader = value;
      }
      else
      {
        this.RemoveFromPanel();
        this.mShader = value;
        this.mPMA = -1;
        this.mMat = (Material) null;
        this.MarkAsChanged();
      }
    }
  }

  public override bool premultipliedAlpha
  {
    get
    {
      if (this.mPMA == -1)
      {
        Material material = this.material;
        this.mPMA = !((UnityEngine.Object) material != (UnityEngine.Object) null) || !((UnityEngine.Object) material.shader != (UnityEngine.Object) null) || !material.shader.name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
    }
  }

  public override Vector4 border
  {
    get => this.mBorder;
    set
    {
      if (!(this.mBorder != value))
        return;
      this.mBorder = value;
      this.MarkAsChanged();
    }
  }

  public Rect uvRect
  {
    get => this.mRect;
    set
    {
      if (!(this.mRect != value))
        return;
      this.mRect = value;
      this.MarkAsChanged();
    }
  }

  public override Vector4 drawingDimensions
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float a1 = -pivotOffset.x * (float) this.mWidth;
      float a2 = -pivotOffset.y * (float) this.mHeight;
      float b1 = a1 + (float) this.mWidth;
      float b2 = a2 + (float) this.mHeight;
      if ((UnityEngine.Object) this.mTexture != (UnityEngine.Object) null && this.mType != UIBasicSprite.Type.Tiled)
      {
        int width = this.mTexture.width;
        int height = this.mTexture.height;
        int num1 = 0;
        int num2 = 0;
        float num3 = 1f;
        float num4 = 1f;
        if (width > 0 && height > 0 && (this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled))
        {
          if ((width & 1) != 0)
            ++num1;
          if ((height & 1) != 0)
            ++num2;
          num3 = 1f / (float) width * (float) this.mWidth;
          num4 = 1f / (float) height * (float) this.mHeight;
        }
        if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
          a1 += (float) num1 * num3;
        else
          b1 -= (float) num1 * num3;
        if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
          a2 += (float) num2 * num4;
        else
          b2 -= (float) num2 * num4;
      }
      float num5;
      float num6;
      if (this.mFixedAspect)
      {
        num5 = 0.0f;
        num6 = 0.0f;
      }
      else
      {
        Vector4 border = this.border;
        num5 = border.x + border.z;
        num6 = border.y + border.w;
      }
      double x = (double) Mathf.Lerp(a1, b1 - num5, this.mDrawRegion.x);
      float num7 = Mathf.Lerp(a2, b2 - num6, this.mDrawRegion.y);
      float num8 = Mathf.Lerp(a1 + num5, b1, this.mDrawRegion.z);
      float num9 = Mathf.Lerp(a2 + num6, b2, this.mDrawRegion.w);
      double y = (double) num7;
      double z = (double) num8;
      double w = (double) num9;
      return new Vector4((float) x, (float) y, (float) z, (float) w);
    }
  }

  public bool fixedAspect
  {
    get => this.mFixedAspect;
    set
    {
      if (this.mFixedAspect == value)
        return;
      this.mFixedAspect = value;
      this.mDrawRegion = new Vector4(0.0f, 0.0f, 1f, 1f);
      this.MarkAsChanged();
    }
  }

  public override void MakePixelPerfect()
  {
    base.MakePixelPerfect();
    if (this.mType == UIBasicSprite.Type.Tiled)
      return;
    Texture mainTexture = this.mainTexture;
    if ((UnityEngine.Object) mainTexture == (UnityEngine.Object) null || this.mType != UIBasicSprite.Type.Simple && this.mType != UIBasicSprite.Type.Filled && this.hasBorder || !((UnityEngine.Object) mainTexture != (UnityEngine.Object) null))
      return;
    int width = mainTexture.width;
    int height = mainTexture.height;
    if ((width & 1) == 1)
      ++width;
    if ((height & 1) == 1)
      ++height;
    this.width = width;
    this.height = height;
  }

  protected override void OnUpdate()
  {
    base.OnUpdate();
    if (!this.mFixedAspect)
      return;
    Texture mainTexture = this.mainTexture;
    if (!((UnityEngine.Object) mainTexture != (UnityEngine.Object) null))
      return;
    int width = mainTexture.width;
    int height = mainTexture.height;
    if ((width & 1) == 1)
      ++width;
    if ((height & 1) == 1)
      ++height;
    float mWidth = (float) this.mWidth;
    float mHeight = (float) this.mHeight;
    float num1 = mWidth / mHeight;
    float num2 = (float) width / (float) height;
    if ((double) num2 < (double) num1)
    {
      float x = (float) (((double) mWidth - (double) mHeight * (double) num2) / (double) mWidth * 0.5);
      this.drawRegion = new Vector4(x, 0.0f, 1f - x, 1f);
    }
    else
    {
      float y = (float) (((double) mHeight - (double) mWidth / (double) num2) / (double) mHeight * 0.5);
      this.drawRegion = new Vector4(0.0f, y, 1f, 1f - y);
    }
  }

  public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
    Texture mainTexture = this.mainTexture;
    if ((UnityEngine.Object) mainTexture == (UnityEngine.Object) null)
      return;
    Rect outer = new Rect(this.mRect.x * (float) mainTexture.width, this.mRect.y * (float) mainTexture.height, (float) mainTexture.width * this.mRect.width, (float) mainTexture.height * this.mRect.height);
    Rect inner = outer;
    Vector4 border = this.border;
    inner.xMin += border.x;
    inner.yMin += border.y;
    inner.xMax -= border.z;
    inner.yMax -= border.w;
    float num1 = 1f / (float) mainTexture.width;
    float num2 = 1f / (float) mainTexture.height;
    outer.xMin *= num1;
    outer.xMax *= num1;
    outer.yMin *= num2;
    outer.yMax *= num2;
    inner.xMin *= num1;
    inner.xMax *= num1;
    inner.yMin *= num2;
    inner.yMax *= num2;
    int count = verts.Count;
    this.Fill(verts, uvs, cols, outer, inner);
    if (this.onPostFill == null)
      return;
    this.onPostFill((UIWidget) this, count, verts, uvs, cols);
  }
}
