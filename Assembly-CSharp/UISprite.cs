// Decompiled with JetBrains decompiler
// Type: UISprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite")]
public class UISprite : UIBasicSprite
{
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Object mAtlas;
  [HideInInspector]
  [SerializeField]
  private string mSpriteName;
  [HideInInspector]
  [SerializeField]
  private bool mFixedAspect;
  [HideInInspector]
  [SerializeField]
  private bool mFillCenter = true;
  [NonSerialized]
  protected UISpriteData mSprite;
  [NonSerialized]
  private bool mSpriteSet;

  public override Texture mainTexture
  {
    get
    {
      Material material = (Material) null;
      if (this.mAtlas is INGUIAtlas mAtlas)
        material = mAtlas.spriteMaterial;
      return !((UnityEngine.Object) material != (UnityEngine.Object) null) ? (Texture) null : material.mainTexture;
    }
    set => base.mainTexture = value;
  }

  public override Material material
  {
    get
    {
      Material material = base.material;
      if ((UnityEngine.Object) material != (UnityEngine.Object) null)
        return material;
      return this.mAtlas is INGUIAtlas mAtlas ? mAtlas.spriteMaterial : (Material) null;
    }
    set => base.material = value;
  }

  public INGUIAtlas atlas
  {
    get => this.mAtlas as INGUIAtlas;
    set
    {
      if (this.mAtlas as INGUIAtlas == value)
        return;
      this.RemoveFromPanel();
      this.mAtlas = value as UnityEngine.Object;
      this.mSpriteSet = false;
      this.mSprite = (UISpriteData) null;
      if (string.IsNullOrEmpty(this.mSpriteName) && this.mAtlas is INGUIAtlas mAtlas && mAtlas.spriteList.Count > 0)
      {
        this.SetAtlasSprite(mAtlas.spriteList[0]);
        this.mSpriteName = this.mSprite.name;
      }
      if (string.IsNullOrEmpty(this.mSpriteName))
        return;
      string mSpriteName = this.mSpriteName;
      this.mSpriteName = "";
      this.spriteName = mSpriteName;
      this.MarkAsChanged();
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

  public UISpriteData GetSprite(string spriteName) => this.atlas?.GetSprite(spriteName);

  public override void MarkAsChanged()
  {
    this.mSprite = (UISpriteData) null;
    this.mSpriteSet = false;
    base.MarkAsChanged();
  }

  public string spriteName
  {
    get => this.mSpriteName;
    set
    {
      if (string.IsNullOrEmpty(value))
      {
        if (string.IsNullOrEmpty(this.mSpriteName))
          return;
        this.mSpriteName = "";
        this.mSprite = (UISpriteData) null;
        this.mChanged = true;
        this.mSpriteSet = false;
        this.MarkAsChanged();
      }
      else
      {
        if (!(this.mSpriteName != value))
          return;
        this.mSpriteName = value;
        this.mSprite = (UISpriteData) null;
        this.mChanged = true;
        this.mSpriteSet = false;
        this.MarkAsChanged();
      }
    }
  }

  public bool isValid => this.GetAtlasSprite() != null;

  [Obsolete("Use 'centerType' instead")]
  public bool fillCenter
  {
    get => this.centerType != 0;
    set
    {
      if (value == (this.centerType != 0))
        return;
      this.centerType = value ? UIBasicSprite.AdvancedType.Sliced : UIBasicSprite.AdvancedType.Invisible;
      this.MarkAsChanged();
    }
  }

  public bool applyGradient
  {
    get => this.mApplyGradient;
    set
    {
      if (this.mApplyGradient == value)
        return;
      this.mApplyGradient = value;
      this.MarkAsChanged();
    }
  }

  public Color gradientTop
  {
    get => this.mGradientTop;
    set
    {
      if (!(this.mGradientTop != value))
        return;
      this.mGradientTop = value;
      if (!this.mApplyGradient)
        return;
      this.MarkAsChanged();
    }
  }

  public Color gradientBottom
  {
    get => this.mGradientBottom;
    set
    {
      if (!(this.mGradientBottom != value))
        return;
      this.mGradientBottom = value;
      if (!this.mApplyGradient)
        return;
      this.MarkAsChanged();
    }
  }

  public override Vector4 border
  {
    get
    {
      UISpriteData atlasSprite = this.GetAtlasSprite();
      return atlasSprite == null ? base.border : new Vector4((float) atlasSprite.borderLeft, (float) atlasSprite.borderBottom, (float) atlasSprite.borderRight, (float) atlasSprite.borderTop);
    }
  }

  protected override Vector4 padding
  {
    get
    {
      UISpriteData atlasSprite = this.GetAtlasSprite();
      Vector4 padding = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
      if (atlasSprite != null)
      {
        padding.x = (float) atlasSprite.paddingLeft;
        padding.y = (float) atlasSprite.paddingBottom;
        padding.z = (float) atlasSprite.paddingRight;
        padding.w = (float) atlasSprite.paddingTop;
      }
      return padding;
    }
  }

  public override float pixelSize => this.mAtlas == (UnityEngine.Object) null || !(this.mAtlas is INGUIAtlas mAtlas) ? 1f : mAtlas.pixelSize;

  public override int minWidth
  {
    get
    {
      if (this.type != UIBasicSprite.Type.Sliced && this.type != UIBasicSprite.Type.Advanced)
        return base.minWidth;
      float pixelSize = this.pixelSize;
      Vector4 vector4 = this.border * this.pixelSize;
      int num = Mathf.RoundToInt(vector4.x + vector4.z);
      UISpriteData atlasSprite = this.GetAtlasSprite();
      if (atlasSprite != null)
        num += Mathf.RoundToInt(pixelSize * (float) (atlasSprite.paddingLeft + atlasSprite.paddingRight));
      return Mathf.Max(base.minWidth, (num & 1) == 1 ? num + 1 : num);
    }
  }

  public override int minHeight
  {
    get
    {
      if (this.type != UIBasicSprite.Type.Sliced && this.type != UIBasicSprite.Type.Advanced)
        return base.minHeight;
      float pixelSize = this.pixelSize;
      Vector4 vector4 = this.border * this.pixelSize;
      int num = Mathf.RoundToInt(vector4.y + vector4.w);
      UISpriteData atlasSprite = this.GetAtlasSprite();
      if (atlasSprite != null)
        num += Mathf.RoundToInt(pixelSize * (float) (atlasSprite.paddingTop + atlasSprite.paddingBottom));
      return Mathf.Max(base.minHeight, (num & 1) == 1 ? num + 1 : num);
    }
  }

  public override Vector4 drawingDimensions
  {
    get
    {
      Vector2 pivotOffset = this.pivotOffset;
      float num1 = -pivotOffset.x * (float) this.mWidth;
      float num2 = -pivotOffset.y * (float) this.mHeight;
      float num3 = num1 + (float) this.mWidth;
      float num4 = num2 + (float) this.mHeight;
      if (this.GetAtlasSprite() != null && this.mType != UIBasicSprite.Type.Tiled)
      {
        int paddingLeft = this.mSprite.paddingLeft;
        int paddingBottom = this.mSprite.paddingBottom;
        int paddingRight = this.mSprite.paddingRight;
        int paddingTop = this.mSprite.paddingTop;
        if (this.mType != UIBasicSprite.Type.Simple)
        {
          float pixelSize = this.pixelSize;
          if ((double) pixelSize != 1.0)
          {
            paddingLeft = Mathf.RoundToInt(pixelSize * (float) paddingLeft);
            paddingBottom = Mathf.RoundToInt(pixelSize * (float) paddingBottom);
            paddingRight = Mathf.RoundToInt(pixelSize * (float) paddingRight);
            paddingTop = Mathf.RoundToInt(pixelSize * (float) paddingTop);
          }
        }
        int num5 = this.mSprite.width + paddingLeft + paddingRight;
        int num6 = this.mSprite.height + paddingBottom + paddingTop;
        float num7 = 1f;
        float num8 = 1f;
        if (num5 > 0 && num6 > 0 && (this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled))
        {
          if ((num5 & 1) != 0)
            ++paddingRight;
          if ((num6 & 1) != 0)
            ++paddingTop;
          num7 = 1f / (float) num5 * (float) this.mWidth;
          num8 = 1f / (float) num6 * (float) this.mHeight;
        }
        if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
        {
          num1 += (float) paddingRight * num7;
          num3 -= (float) paddingLeft * num7;
        }
        else
        {
          num1 += (float) paddingLeft * num7;
          num3 -= (float) paddingRight * num7;
        }
        if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
        {
          num2 += (float) paddingTop * num8;
          num4 -= (float) paddingBottom * num8;
        }
        else
        {
          num2 += (float) paddingBottom * num8;
          num4 -= (float) paddingTop * num8;
        }
      }
      if ((double) this.mDrawRegion.x == 0.0 && (double) this.mDrawRegion.y == 0.0 && (double) this.mDrawRegion.z == 1.0 && (double) this.mDrawRegion.w == 0.0)
        return new Vector4(num1, num2, num3, num4);
      float num9;
      float num10;
      if (this.mFixedAspect)
      {
        num9 = 0.0f;
        num10 = 0.0f;
      }
      else
      {
        Vector4 vector4 = this.mAtlas != (UnityEngine.Object) null ? this.border * this.pixelSize : Vector4.zero;
        num9 = vector4.x + vector4.z;
        num10 = vector4.y + vector4.w;
      }
      double x = (double) Mathf.Lerp(num1, num3 - num9, this.mDrawRegion.x);
      float num11 = Mathf.Lerp(num2, num4 - num10, this.mDrawRegion.y);
      float num12 = Mathf.Lerp(num1 + num9, num3, this.mDrawRegion.z);
      float num13 = Mathf.Lerp(num2 + num10, num4, this.mDrawRegion.w);
      double y = (double) num11;
      double z = (double) num12;
      double w = (double) num13;
      return new Vector4((float) x, (float) y, (float) z, (float) w);
    }
  }

  public override bool premultipliedAlpha => this.mAtlas is INGUIAtlas mAtlas && mAtlas.premultipliedAlpha;

  public UISpriteData GetAtlasSprite()
  {
    if (!this.mSpriteSet)
      this.mSprite = (UISpriteData) null;
    if (this.mSprite == null && this.mAtlas is INGUIAtlas mAtlas)
    {
      if (!string.IsNullOrEmpty(this.mSpriteName))
      {
        UISpriteData sprite = mAtlas.GetSprite(this.mSpriteName);
        if (sprite == null)
          return (UISpriteData) null;
        this.SetAtlasSprite(sprite);
      }
      if (this.mSprite == null && mAtlas.spriteList.Count > 0)
      {
        UISpriteData sprite = mAtlas.spriteList[0];
        if (sprite == null)
          return (UISpriteData) null;
        this.SetAtlasSprite(sprite);
        if (this.mSprite == null)
        {
          Debug.LogError((object) ((mAtlas as UnityEngine.Object).name + " seems to have a null sprite!"));
          return (UISpriteData) null;
        }
        this.mSpriteName = this.mSprite.name;
      }
    }
    return this.mSprite;
  }

  protected void SetAtlasSprite(UISpriteData sp)
  {
    this.mChanged = true;
    this.mSpriteSet = true;
    if (sp != null)
    {
      this.mSprite = sp;
      this.mSpriteName = this.mSprite.name;
    }
    else
    {
      this.mSpriteName = this.mSprite != null ? this.mSprite.name : "";
      this.mSprite = sp;
    }
  }

  public override void MakePixelPerfect()
  {
    if (!this.isValid)
      return;
    base.MakePixelPerfect();
    if (this.mType == UIBasicSprite.Type.Tiled)
      return;
    UISpriteData atlasSprite = this.GetAtlasSprite();
    if (atlasSprite == null)
      return;
    Texture mainTexture = this.mainTexture;
    if ((UnityEngine.Object) mainTexture == (UnityEngine.Object) null || this.mType != UIBasicSprite.Type.Simple && this.mType != UIBasicSprite.Type.Filled && atlasSprite.hasBorder || !((UnityEngine.Object) mainTexture != (UnityEngine.Object) null))
      return;
    int num1 = Mathf.RoundToInt(this.pixelSize * (float) (atlasSprite.width + atlasSprite.paddingLeft + atlasSprite.paddingRight));
    int num2 = Mathf.RoundToInt(this.pixelSize * (float) (atlasSprite.height + atlasSprite.paddingTop + atlasSprite.paddingBottom));
    if ((num1 & 1) == 1)
      ++num1;
    if ((num2 & 1) == 1)
      ++num2;
    this.width = num1;
    this.height = num2;
  }

  protected override void OnInit()
  {
    if (!this.mFillCenter)
    {
      this.mFillCenter = true;
      this.centerType = UIBasicSprite.AdvancedType.Invisible;
    }
    base.OnInit();
  }

  protected override void OnUpdate()
  {
    base.OnUpdate();
    if (this.mChanged || !this.mSpriteSet)
    {
      this.mSpriteSet = true;
      this.mSprite = (UISpriteData) null;
      this.mChanged = true;
    }
    if (!this.mFixedAspect || (!this.mSpriteSet || this.mSprite == null) && this.GetAtlasSprite() == null || this.mSprite == null)
      return;
    int paddingLeft = this.mSprite.paddingLeft;
    int paddingBottom = this.mSprite.paddingBottom;
    int paddingRight = this.mSprite.paddingRight;
    int paddingTop = this.mSprite.paddingTop;
    int num1 = Mathf.RoundToInt((float) this.mSprite.width);
    int num2 = Mathf.RoundToInt((float) this.mSprite.height);
    int num3 = paddingLeft + paddingRight;
    int num4 = num1 + num3;
    int num5 = num2 + (paddingTop + paddingBottom);
    float mWidth = (float) this.mWidth;
    float mHeight = (float) this.mHeight;
    float num6 = mWidth / mHeight;
    float num7 = (float) num4 / (float) num5;
    if ((double) num7 < (double) num6)
    {
      float x = (float) (((double) mWidth - (double) mHeight * (double) num7) / (double) mWidth * 0.5);
      this.drawRegion = new Vector4(x, 0.0f, 1f - x, 1f);
    }
    else
    {
      float y = (float) (((double) mHeight - (double) mWidth / (double) num7) / (double) mHeight * 0.5);
      this.drawRegion = new Vector4(0.0f, y, 1f, 1f - y);
    }
  }

  public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
    Texture mainTexture = this.mainTexture;
    if ((UnityEngine.Object) mainTexture == (UnityEngine.Object) null || (!this.mSpriteSet || this.mSprite == null) && this.GetAtlasSprite() == null)
      return;
    Rect rect1 = new Rect((float) this.mSprite.x, (float) this.mSprite.y, (float) this.mSprite.width, (float) this.mSprite.height);
    Rect rect2 = new Rect((float) (this.mSprite.x + this.mSprite.borderLeft), (float) (this.mSprite.y + this.mSprite.borderTop), (float) (this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight), (float) (this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop));
    Rect texCoords1 = NGUIMath.ConvertToTexCoords(rect1, mainTexture.width, mainTexture.height);
    Rect texCoords2 = NGUIMath.ConvertToTexCoords(rect2, mainTexture.width, mainTexture.height);
    int count = verts.Count;
    this.Fill(verts, uvs, cols, texCoords1, texCoords2);
    if (this.onPostFill == null)
      return;
    this.onPostFill((UIWidget) this, count, verts, uvs, cols);
  }
}
