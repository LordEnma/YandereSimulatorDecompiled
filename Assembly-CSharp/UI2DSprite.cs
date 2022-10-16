// Decompiled with JetBrains decompiler
// Type: UI2DSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Unity2D Sprite")]
public class UI2DSprite : UIBasicSprite
{
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Sprite mSprite;
  [HideInInspector]
  [SerializeField]
  private Shader mShader;
  [HideInInspector]
  [SerializeField]
  private Vector4 mBorder = Vector4.zero;
  [HideInInspector]
  [SerializeField]
  private bool mFixedAspect;
  [HideInInspector]
  [SerializeField]
  private float mPixelSize = 1f;
  public UnityEngine.Sprite nextSprite;
  [NonSerialized]
  private int mPMA = -1;

  public UnityEngine.Sprite sprite2D
  {
    get => this.mSprite;
    set
    {
      if (!((UnityEngine.Object) this.mSprite != (UnityEngine.Object) value))
        return;
      this.RemoveFromPanel();
      this.mSprite = value;
      this.nextSprite = (UnityEngine.Sprite) null;
      this.CreatePanel();
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
      this.RemoveFromPanel();
      this.mShader = value;
      if (!((UnityEngine.Object) this.mMat == (UnityEngine.Object) null))
        return;
      this.mPMA = -1;
      this.MarkAsChanged();
    }
  }

  public override Texture mainTexture
  {
    get
    {
      if ((UnityEngine.Object) this.mSprite != (UnityEngine.Object) null)
        return (Texture) this.mSprite.texture;
      return (UnityEngine.Object) this.mMat != (UnityEngine.Object) null ? this.mMat.mainTexture : (Texture) null;
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

  public override bool premultipliedAlpha
  {
    get
    {
      if (this.mPMA == -1)
      {
        Shader shader = this.shader;
        this.mPMA = !((UnityEngine.Object) shader != (UnityEngine.Object) null) || !shader.name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
    }
  }

  public override float pixelSize => this.mPixelSize;

  public override Vector4 drawingDimensions
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float a1 = -pivotOffset.x * (float) this.mWidth;
      float a2 = -pivotOffset.y * (float) this.mHeight;
      float b1 = a1 + (float) this.mWidth;
      float b2 = a2 + (float) this.mHeight;
      if ((UnityEngine.Object) this.mSprite != (UnityEngine.Object) null && this.mType != UIBasicSprite.Type.Tiled)
      {
        int num1 = Mathf.RoundToInt(this.mSprite.rect.width);
        int num2 = Mathf.RoundToInt(this.mSprite.rect.height);
        int num3 = Mathf.RoundToInt(this.mSprite.textureRectOffset.x);
        int num4 = Mathf.RoundToInt(this.mSprite.textureRectOffset.y);
        int num5 = Mathf.RoundToInt(this.mSprite.rect.width - this.mSprite.textureRect.width - this.mSprite.textureRectOffset.x);
        int num6 = Mathf.RoundToInt(this.mSprite.rect.height - this.mSprite.textureRect.height - this.mSprite.textureRectOffset.y);
        float num7 = 1f;
        float num8 = 1f;
        if (num1 > 0 && num2 > 0 && (this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled))
        {
          if ((num1 & 1) != 0)
            ++num5;
          if ((num2 & 1) != 0)
            ++num6;
          num7 = 1f / (float) num1 * (float) this.mWidth;
          num8 = 1f / (float) num2 * (float) this.mHeight;
        }
        if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
        {
          a1 += (float) num5 * num7;
          b1 -= (float) num3 * num7;
        }
        else
        {
          a1 += (float) num3 * num7;
          b1 -= (float) num5 * num7;
        }
        if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
        {
          a2 += (float) num6 * num8;
          b2 -= (float) num4 * num8;
        }
        else
        {
          a2 += (float) num4 * num8;
          b2 -= (float) num6 * num8;
        }
      }
      float num9;
      float num10;
      if (this.mFixedAspect)
      {
        num9 = 0.0f;
        num10 = 0.0f;
      }
      else
      {
        Vector4 vector4 = this.border * this.pixelSize;
        num9 = vector4.x + vector4.z;
        num10 = vector4.y + vector4.w;
      }
      double x = (double) Mathf.Lerp(a1, b1 - num9, this.mDrawRegion.x);
      float num11 = Mathf.Lerp(a2, b2 - num10, this.mDrawRegion.y);
      float num12 = Mathf.Lerp(a1 + num9, b1, this.mDrawRegion.z);
      float num13 = Mathf.Lerp(a2 + num10, b2, this.mDrawRegion.w);
      double y = (double) num11;
      double z = (double) num12;
      double w = (double) num13;
      return new Vector4((float) x, (float) y, (float) z, (float) w);
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

  protected override void OnUpdate()
  {
    if ((UnityEngine.Object) this.nextSprite != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.nextSprite != (UnityEngine.Object) this.mSprite)
        this.sprite2D = this.nextSprite;
      this.nextSprite = (UnityEngine.Sprite) null;
    }
    base.OnUpdate();
    if (!this.mFixedAspect || !((UnityEngine.Object) this.mainTexture != (UnityEngine.Object) null))
      return;
    Rect rect = this.mSprite.rect;
    int num1 = Mathf.RoundToInt(rect.width);
    rect = this.mSprite.rect;
    int num2 = Mathf.RoundToInt(rect.height);
    int num3 = Mathf.RoundToInt(this.mSprite.textureRectOffset.x);
    int num4 = Mathf.RoundToInt(this.mSprite.textureRectOffset.y);
    rect = this.mSprite.rect;
    double width1 = (double) rect.width;
    rect = this.mSprite.textureRect;
    double width2 = (double) rect.width;
    int num5 = Mathf.RoundToInt((float) (width1 - width2) - this.mSprite.textureRectOffset.x);
    rect = this.mSprite.rect;
    double height1 = (double) rect.height;
    rect = this.mSprite.textureRect;
    double height2 = (double) rect.height;
    int num6 = Mathf.RoundToInt((float) (height1 - height2) - this.mSprite.textureRectOffset.y);
    int num7 = num3 + num5;
    int num8 = num1 + num7;
    int num9 = num2 + (num6 + num4);
    float mWidth = (float) this.mWidth;
    float mHeight = (float) this.mHeight;
    float num10 = mWidth / mHeight;
    float num11 = (float) num8 / (float) num9;
    if ((double) num11 < (double) num10)
    {
      float x = (float) (((double) mWidth - (double) mHeight * (double) num11) / (double) mWidth * 0.5);
      this.drawRegion = new Vector4(x, 0.0f, 1f - x, 1f);
    }
    else
    {
      float y = (float) (((double) mHeight - (double) mWidth / (double) num11) / (double) mHeight * 0.5);
      this.drawRegion = new Vector4(0.0f, y, 1f, 1f - y);
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
    Rect rect = this.mSprite.rect;
    int num1 = Mathf.RoundToInt(this.pixelSize * rect.width);
    int num2 = Mathf.RoundToInt(this.pixelSize * rect.height);
    if ((num1 & 1) == 1)
      ++num1;
    if ((num2 & 1) == 1)
      ++num2;
    this.width = num1;
    this.height = num2;
  }

  public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
    Texture mainTexture = this.mainTexture;
    if ((UnityEngine.Object) mainTexture == (UnityEngine.Object) null)
      return;
    Rect outer = (UnityEngine.Object) this.mSprite != (UnityEngine.Object) null ? this.mSprite.textureRect : new Rect(0.0f, 0.0f, (float) mainTexture.width, (float) mainTexture.height);
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
