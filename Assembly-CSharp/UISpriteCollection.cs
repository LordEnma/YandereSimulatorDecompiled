// Decompiled with JetBrains decompiler
// Type: UISpriteCollection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite Collection")]
public class UISpriteCollection : UIBasicSprite
{
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Object mAtlas;
  [NonSerialized]
  private Dictionary<object, UISpriteCollection.Sprite> mSprites = new Dictionary<object, UISpriteCollection.Sprite>();
  [NonSerialized]
  private UISpriteData mSprite;
  public UISpriteCollection.OnHoverCB onHover;
  public UISpriteCollection.OnPressCB onPress;
  public UISpriteCollection.OnClickCB onClick;
  public UISpriteCollection.OnDragCB onDrag;
  public UISpriteCollection.OnTooltipCB onTooltip;
  [NonSerialized]
  private object mLastHover;
  [NonSerialized]
  private object mLastPress;
  [NonSerialized]
  private object mLastTooltip;

  public override Texture mainTexture
  {
    get
    {
      Material material = (Material) null;
      INGUIAtlas atlas = this.atlas;
      if (atlas != null)
        material = atlas.spriteMaterial;
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
      return this.atlas?.spriteMaterial;
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
      this.mSprites.Clear();
      this.MarkAsChanged();
    }
  }

  public override float pixelSize
  {
    get
    {
      INGUIAtlas atlas = this.atlas;
      return atlas != null ? atlas.pixelSize : 1f;
    }
  }

  public override bool premultipliedAlpha
  {
    get
    {
      INGUIAtlas atlas = this.atlas;
      return atlas != null && atlas.premultipliedAlpha;
    }
  }

  public override Vector4 border => this.mSprite == null ? base.border : new Vector4((float) this.mSprite.borderLeft, (float) this.mSprite.borderBottom, (float) this.mSprite.borderRight, (float) this.mSprite.borderTop);

  protected override Vector4 padding
  {
    get
    {
      Vector4 padding = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
      if (this.mSprite != null)
      {
        padding.x = (float) this.mSprite.paddingLeft;
        padding.y = (float) this.mSprite.paddingBottom;
        padding.z = (float) this.mSprite.paddingRight;
        padding.w = (float) this.mSprite.paddingTop;
      }
      return padding;
    }
  }

  public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
  {
    Texture mainTexture = this.mainTexture;
    if ((UnityEngine.Object) mainTexture == (UnityEngine.Object) null)
      return;
    int count1 = verts.Count;
    Vector4 drawRegion = this.drawRegion;
    foreach (KeyValuePair<object, UISpriteCollection.Sprite> mSprite in this.mSprites)
    {
      UISpriteCollection.Sprite sprite = mSprite.Value;
      if (sprite.enabled)
      {
        this.mSprite = sprite.sprite;
        if (this.mSprite != null)
        {
          Color c = (Color) sprite.color with
          {
            a = this.finalAlpha
          };
          if ((double) c.a != 0.0)
          {
            Rect rect1 = new Rect((float) this.mSprite.x, (float) this.mSprite.y, (float) this.mSprite.width, (float) this.mSprite.height);
            Rect rect2 = new Rect((float) (this.mSprite.x + this.mSprite.borderLeft), (float) (this.mSprite.y + this.mSprite.borderTop), (float) (this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight), (float) (this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop));
            this.mOuterUV = NGUIMath.ConvertToTexCoords(rect1, mainTexture.width, mainTexture.height);
            this.mInnerUV = NGUIMath.ConvertToTexCoords(rect2, mainTexture.width, mainTexture.height);
            this.mFlip = sprite.flip;
            Vector4 drawingDimensions = sprite.GetDrawingDimensions(this.pixelSize);
            Vector4 drawingUvs = this.drawingUVs;
            if (this.premultipliedAlpha)
              c = NGUITools.ApplyPMA(c);
            int count2 = verts.Count;
            switch (sprite.type)
            {
              case UIBasicSprite.Type.Simple:
                this.SimpleFill(verts, uvs, cols, ref drawingDimensions, ref drawingUvs, ref c);
                break;
              case UIBasicSprite.Type.Sliced:
                this.SlicedFill(verts, uvs, cols, ref drawingDimensions, ref drawingUvs, ref c);
                break;
              case UIBasicSprite.Type.Tiled:
                this.TiledFill(verts, uvs, cols, ref drawingDimensions, ref c);
                break;
              case UIBasicSprite.Type.Filled:
                this.FilledFill(verts, uvs, cols, ref drawingDimensions, ref drawingUvs, ref c);
                break;
              case UIBasicSprite.Type.Advanced:
                this.AdvancedFill(verts, uvs, cols, ref drawingDimensions, ref drawingUvs, ref c);
                break;
            }
            if ((double) sprite.rot != 0.0)
            {
              double f = (double) sprite.rot * (Math.PI / 180.0) * 0.5;
              float num1 = Mathf.Sin((float) f);
              double num2 = (double) Mathf.Cos((float) f);
              float num3 = num1 * 2f;
              float num4 = num1 * num3;
              double num5 = (double) num3;
              float num6 = (float) (num2 * num5);
              int index = count2;
              for (int count3 = verts.Count; index < count3; ++index)
              {
                Vector3 vector3 = verts[index];
                vector3 = new Vector3((float) ((1.0 - (double) num4) * (double) vector3.x - (double) num6 * (double) vector3.y), (float) ((double) num6 * (double) vector3.x + (1.0 - (double) num4) * (double) vector3.y), vector3.z);
                vector3.x += sprite.pos.x;
                vector3.y += sprite.pos.y;
                verts[index] = vector3;
              }
            }
            else
            {
              int index = count2;
              for (int count4 = verts.Count; index < count4; ++index)
              {
                Vector3 vert = verts[index];
                vert.x += sprite.pos.x;
                vert.y += sprite.pos.y;
                verts[index] = vert;
              }
            }
          }
        }
      }
    }
    this.mSprite = (UISpriteData) null;
    if (this.onPostFill == null)
      return;
    this.onPostFill((UIWidget) this, count1, verts, uvs, cols);
  }

  public void Add(object obj, string spriteName, Vector2 pos, float width, float height) => this.AddSprite(obj, spriteName, pos, width, height, new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(0.5f, 0.5f));

  public void Add(
    object obj,
    string spriteName,
    Vector2 pos,
    float width,
    float height,
    Color32 color)
  {
    this.AddSprite(obj, spriteName, pos, width, height, color, new Vector2(0.5f, 0.5f));
  }

  public void AddSprite(
    object id,
    string spriteName,
    Vector2 pos,
    float width,
    float height,
    Color32 color,
    Vector2 pivot,
    float rot = 0.0f,
    UIBasicSprite.Type type = UIBasicSprite.Type.Simple,
    UIBasicSprite.Flip flip = UIBasicSprite.Flip.Nothing,
    bool enabled = true)
  {
    if (this.mAtlas == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "Atlas must be assigned first");
    }
    else
    {
      UISpriteCollection.Sprite sprite = new UISpriteCollection.Sprite();
      INGUIAtlas atlas = this.atlas;
      if (atlas != null)
        sprite.sprite = atlas.GetSprite(spriteName);
      if (sprite.sprite == null)
        return;
      sprite.pos = pos;
      sprite.rot = rot;
      sprite.width = width;
      sprite.height = height;
      sprite.color = color;
      sprite.pivot = pivot;
      sprite.type = type;
      sprite.flip = flip;
      sprite.enabled = enabled;
      this.mSprites[id] = sprite;
      if (!enabled || this.mChanged)
        return;
      this.MarkAsChanged();
    }
  }

  public UISpriteCollection.Sprite? GetSprite(object id)
  {
    UISpriteCollection.Sprite sprite;
    return this.mSprites.TryGetValue(id, out sprite) ? new UISpriteCollection.Sprite?(sprite) : new UISpriteCollection.Sprite?();
  }

  public bool RemoveSprite(object id)
  {
    if (!this.mSprites.Remove(id))
      return false;
    if (!this.mChanged)
      this.MarkAsChanged();
    return true;
  }

  public bool SetSprite(object id, UISpriteCollection.Sprite sp)
  {
    this.mSprites[id] = sp;
    if (!this.mChanged)
      this.MarkAsChanged();
    return true;
  }

  [ContextMenu("Clear")]
  public void Clear()
  {
    if (this.mSprites.Count == 0)
      return;
    this.mSprites.Clear();
    this.MarkAsChanged();
  }

  public bool IsActive(object id)
  {
    UISpriteCollection.Sprite sprite;
    return this.mSprites.TryGetValue(id, out sprite) && sprite.enabled;
  }

  public bool SetActive(object id, bool visible)
  {
    UISpriteCollection.Sprite sprite;
    if (!this.mSprites.TryGetValue(id, out sprite))
      return false;
    if (sprite.enabled != visible)
    {
      sprite.enabled = visible;
      this.mSprites[id] = sprite;
      if (!this.mChanged)
        this.MarkAsChanged();
    }
    return true;
  }

  public bool SetPosition(object id, Vector2 pos, bool visible = true)
  {
    UISpriteCollection.Sprite sprite;
    if (!this.mSprites.TryGetValue(id, out sprite))
      return false;
    if (sprite.pos != pos)
    {
      sprite.pos = pos;
      sprite.enabled = visible;
      this.mSprites[id] = sprite;
      if (!this.mChanged)
        this.MarkAsChanged();
    }
    else if (sprite.enabled != visible)
    {
      sprite.enabled = visible;
      this.mSprites[id] = sprite;
      if (!this.mChanged)
        this.MarkAsChanged();
    }
    return true;
  }

  private static Vector2 Rotate(Vector2 pos, float rot)
  {
    double f = (double) rot * (Math.PI / 180.0) * 0.5;
    float num1 = Mathf.Sin((float) f);
    double num2 = (double) Mathf.Cos((float) f);
    float num3 = num1 * 2f;
    float num4 = num1 * num3;
    double num5 = (double) num3;
    float num6 = (float) (num2 * num5);
    return new Vector2((float) ((1.0 - (double) num4) * (double) pos.x - (double) num6 * (double) pos.y), (float) ((double) num6 * (double) pos.x + (1.0 - (double) num4) * (double) pos.y));
  }

  public object GetCurrentSpriteID() => this.GetCurrentSpriteID(UICamera.lastWorldPosition);

  public UISpriteCollection.Sprite? GetCurrentSprite() => this.GetCurrentSprite(UICamera.lastWorldPosition);

  public object GetCurrentSpriteID(Vector3 worldPos)
  {
    Vector2 vector2 = (Vector2) this.mTrans.InverseTransformPoint(worldPos);
    foreach (KeyValuePair<object, UISpriteCollection.Sprite> mSprite in this.mSprites)
    {
      UISpriteCollection.Sprite sprite = mSprite.Value;
      Vector2 pos = vector2 - sprite.pos;
      if ((double) sprite.rot != 0.0)
        pos = UISpriteCollection.Rotate(pos, -sprite.rot);
      Vector4 drawingDimensions = sprite.GetDrawingDimensions(this.pixelSize);
      if ((double) pos.x >= (double) drawingDimensions.x && (double) pos.y >= (double) drawingDimensions.y && (double) pos.x <= (double) drawingDimensions.z && (double) pos.y <= (double) drawingDimensions.w)
        return mSprite.Key;
    }
    return (object) null;
  }

  public UISpriteCollection.Sprite? GetCurrentSprite(Vector3 worldPos)
  {
    Vector2 vector2 = (Vector2) this.mTrans.InverseTransformPoint(worldPos);
    foreach (KeyValuePair<object, UISpriteCollection.Sprite> mSprite in this.mSprites)
    {
      UISpriteCollection.Sprite sprite = mSprite.Value;
      Vector2 pos = vector2 - sprite.pos;
      if ((double) sprite.rot != 0.0)
        pos = UISpriteCollection.Rotate(pos, -sprite.rot);
      Vector4 drawingDimensions = sprite.GetDrawingDimensions(this.pixelSize);
      if ((double) pos.x >= (double) drawingDimensions.x && (double) pos.y >= (double) drawingDimensions.y && (double) pos.x <= (double) drawingDimensions.z && (double) pos.y <= (double) drawingDimensions.w)
        return new UISpriteCollection.Sprite?(mSprite.Value);
    }
    return new UISpriteCollection.Sprite?();
  }

  protected void OnClick()
  {
    if (this.onClick == null)
      return;
    object currentSpriteId = this.GetCurrentSpriteID();
    if (currentSpriteId == null)
      return;
    this.onClick(currentSpriteId);
  }

  protected void OnPress(bool isPressed)
  {
    if (this.onPress == null || isPressed && this.mLastPress != null)
      return;
    if (isPressed)
    {
      this.mLastPress = this.GetCurrentSpriteID();
      if (this.mLastPress == null)
        return;
      this.onPress(this.mLastPress, true);
    }
    else
    {
      if (this.mLastPress == null)
        return;
      this.onPress(this.mLastPress, false);
      this.mLastPress = (object) null;
    }
  }

  protected void OnHover(bool isOver)
  {
    if (this.onHover == null)
      return;
    if (isOver)
    {
      UICamera.onMouseMove += new UICamera.MoveDelegate(this.OnMove);
      this.OnMove(Vector2.zero);
    }
    else
      UICamera.onMouseMove -= new UICamera.MoveDelegate(this.OnMove);
  }

  protected void OnMove(Vector2 delta)
  {
    if (!(bool) (UnityEngine.Object) this || this.onHover == null)
      return;
    object currentSpriteId = this.GetCurrentSpriteID();
    if (this.mLastHover == currentSpriteId)
      return;
    if (this.mLastHover != null)
      this.onHover(this.mLastHover, false);
    this.mLastHover = currentSpriteId;
    if (this.mLastHover == null)
      return;
    this.onHover(this.mLastHover, true);
  }

  protected void OnDrag(Vector2 delta)
  {
    if (this.onDrag == null || this.mLastPress == null)
      return;
    this.onDrag(this.mLastPress, delta);
  }

  protected void OnTooltip(bool show)
  {
    if (this.onTooltip == null)
      return;
    if (show)
    {
      if (this.mLastTooltip != null)
        this.onTooltip(this.mLastTooltip, false);
      this.mLastTooltip = this.GetCurrentSpriteID();
      if (this.mLastTooltip == null)
        return;
      this.onTooltip(this.mLastTooltip, true);
    }
    else
    {
      this.onTooltip(this.mLastTooltip, false);
      this.mLastTooltip = (object) null;
    }
  }

  public struct Sprite
  {
    public UISpriteData sprite;
    public Vector2 pos;
    public float rot;
    public float width;
    public float height;
    public Color32 color;
    public Vector2 pivot;
    public UIBasicSprite.Type type;
    public UIBasicSprite.Flip flip;
    public bool enabled;

    public Vector4 GetDrawingDimensions(float pixelSize)
    {
      float x = -this.pivot.x * this.width;
      float y = -this.pivot.y * this.height;
      float z = x + this.width;
      float w = y + this.height;
      if (this.sprite != null && this.type != UIBasicSprite.Type.Tiled)
      {
        int paddingLeft = this.sprite.paddingLeft;
        int paddingBottom = this.sprite.paddingBottom;
        int paddingRight = this.sprite.paddingRight;
        int paddingTop = this.sprite.paddingTop;
        if (this.type != UIBasicSprite.Type.Simple && (double) pixelSize != 1.0)
        {
          paddingLeft = Mathf.RoundToInt(pixelSize * (float) paddingLeft);
          paddingBottom = Mathf.RoundToInt(pixelSize * (float) paddingBottom);
          paddingRight = Mathf.RoundToInt(pixelSize * (float) paddingRight);
          paddingTop = Mathf.RoundToInt(pixelSize * (float) paddingTop);
        }
        int num1 = this.sprite.width + paddingLeft + paddingRight;
        int num2 = this.sprite.height + paddingBottom + paddingTop;
        float num3 = 1f;
        float num4 = 1f;
        if (num1 > 0 && num2 > 0 && (this.type == UIBasicSprite.Type.Simple || this.type == UIBasicSprite.Type.Filled))
        {
          if ((num1 & 1) != 0)
            ++paddingRight;
          if ((num2 & 1) != 0)
            ++paddingTop;
          num3 = 1f / (float) num1 * this.width;
          num4 = 1f / (float) num2 * this.height;
        }
        if (this.flip == UIBasicSprite.Flip.Horizontally || this.flip == UIBasicSprite.Flip.Both)
        {
          x += (float) paddingRight * num3;
          z -= (float) paddingLeft * num3;
        }
        else
        {
          x += (float) paddingLeft * num3;
          z -= (float) paddingRight * num3;
        }
        if (this.flip == UIBasicSprite.Flip.Vertically || this.flip == UIBasicSprite.Flip.Both)
        {
          y += (float) paddingTop * num4;
          w -= (float) paddingBottom * num4;
        }
        else
        {
          y += (float) paddingBottom * num4;
          w -= (float) paddingTop * num4;
        }
      }
      return new Vector4(x, y, z, w);
    }
  }

  public delegate void OnHoverCB(object obj, bool isOver);

  public delegate void OnPressCB(object obj, bool isPressed);

  public delegate void OnClickCB(object obj);

  public delegate void OnDragCB(object obj, Vector2 delta);

  public delegate void OnTooltipCB(object obj, bool show);
}
