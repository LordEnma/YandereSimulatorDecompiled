// Decompiled with JetBrains decompiler
// Type: UIFont
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIFont : MonoBehaviour, INGUIFont
{
  [HideInInspector]
  [SerializeField]
  private Material mMat;
  [HideInInspector]
  [SerializeField]
  private Rect mUVRect = new Rect(0.0f, 0.0f, 1f, 1f);
  [HideInInspector]
  [SerializeField]
  private BMFont mFont = new BMFont();
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Object mAtlas;
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Object mReplacement;
  [HideInInspector]
  [SerializeField]
  private List<BMSymbol> mSymbols = new List<BMSymbol>();
  [HideInInspector]
  [SerializeField]
  private Font mDynamicFont;
  [HideInInspector]
  [SerializeField]
  private int mDynamicFontSize = 16;
  [HideInInspector]
  [SerializeField]
  private FontStyle mDynamicFontStyle;
  [NonSerialized]
  private UISpriteData mSprite;
  [NonSerialized]
  private int mPMA = -1;
  [NonSerialized]
  private int mPacked = -1;

  public BMFont bmFont
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement == null ? this.mFont : replacement.bmFont;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        replacement.bmFont = value;
      else
        this.mFont = value;
    }
  }

  public int texWidth
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.texWidth;
      return this.mFont == null ? 1 : this.mFont.texWidth;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.texWidth = value;
      }
      else
      {
        if (this.mFont == null)
          return;
        this.mFont.texWidth = value;
      }
    }
  }

  public int texHeight
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.texHeight;
      return this.mFont == null ? 1 : this.mFont.texHeight;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.texHeight = value;
      }
      else
      {
        if (this.mFont == null)
          return;
        this.mFont.texHeight = value;
      }
    }
  }

  public bool hasSymbols
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.hasSymbols;
      return this.mSymbols != null && this.mSymbols.Count != 0;
    }
  }

  public List<BMSymbol> symbols
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement == null ? this.mSymbols : replacement.symbols;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        replacement.symbols = value;
      else
        this.mSymbols = value;
    }
  }

  public INGUIAtlas atlas
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement != null ? replacement.atlas : this.mAtlas as INGUIAtlas;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.atlas = value;
      }
      else
      {
        if (this.mAtlas as INGUIAtlas == value)
          return;
        this.mPMA = -1;
        this.mAtlas = value as UnityEngine.Object;
        if (value != null)
        {
          this.mMat = value.spriteMaterial;
          if (this.sprite != null)
            this.mUVRect = this.uvRect;
        }
        else
        {
          this.mAtlas = (UnityEngine.Object) null;
          this.mMat = (Material) null;
        }
        this.MarkAsChanged();
      }
    }
  }

  public UISpriteData GetSprite(string spriteName) => this.atlas?.GetSprite(spriteName);

  public Material material
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.material;
      if (this.mAtlas is INGUIAtlas mAtlas)
        return mAtlas.spriteMaterial;
      if ((UnityEngine.Object) this.mMat != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.mDynamicFont != (UnityEngine.Object) null && (UnityEngine.Object) this.mMat != (UnityEngine.Object) this.mDynamicFont.material)
          this.mMat.mainTexture = this.mDynamicFont.material.mainTexture;
        return this.mMat;
      }
      return (UnityEngine.Object) this.mDynamicFont != (UnityEngine.Object) null ? this.mDynamicFont.material : (Material) null;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.material = value;
      }
      else
      {
        if (!((UnityEngine.Object) this.mMat != (UnityEngine.Object) value))
          return;
        this.mPMA = -1;
        this.mMat = value;
        this.MarkAsChanged();
      }
    }
  }

  [Obsolete("Use premultipliedAlphaShader instead")]
  public bool premultipliedAlpha => this.premultipliedAlphaShader;

  public bool premultipliedAlphaShader
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.premultipliedAlphaShader;
      if (this.mAtlas is INGUIAtlas mAtlas)
        return mAtlas.premultipliedAlpha;
      if (this.mPMA == -1)
      {
        Material material = this.material;
        this.mPMA = !((UnityEngine.Object) material != (UnityEngine.Object) null) || !((UnityEngine.Object) material.shader != (UnityEngine.Object) null) || !material.shader.name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
    }
  }

  public bool packedFontShader
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.packedFontShader;
      if (this.mAtlas != (UnityEngine.Object) null)
        return false;
      if (this.mPacked == -1)
      {
        Material material = this.material;
        this.mPacked = !((UnityEngine.Object) material != (UnityEngine.Object) null) || !((UnityEngine.Object) material.shader != (UnityEngine.Object) null) || !material.shader.name.Contains("Packed") ? 0 : 1;
      }
      return this.mPacked == 1;
    }
  }

  public Texture2D texture
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.texture;
      Material material = this.material;
      return !((UnityEngine.Object) material != (UnityEngine.Object) null) ? (Texture2D) null : material.mainTexture as Texture2D;
    }
  }

  public Rect uvRect
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.uvRect;
      return !(this.mAtlas != (UnityEngine.Object) null) || this.sprite == null ? new Rect(0.0f, 0.0f, 1f, 1f) : this.mUVRect;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.uvRect = value;
      }
      else
      {
        if (this.sprite != null || !(this.mUVRect != value))
          return;
        this.mUVRect = value;
        this.MarkAsChanged();
      }
    }
  }

  public string spriteName
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement == null ? this.mFont.spriteName : replacement.spriteName;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.spriteName = value;
      }
      else
      {
        if (!(this.mFont.spriteName != value))
          return;
        this.mFont.spriteName = value;
        this.MarkAsChanged();
      }
    }
  }

  public bool isValid => (UnityEngine.Object) this.mDynamicFont != (UnityEngine.Object) null || this.mFont.isValid;

  [Obsolete("Use defaultSize instead")]
  public int size
  {
    get => this.defaultSize;
    set => this.defaultSize = value;
  }

  public int defaultSize
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.defaultSize;
      return this.isDynamic || this.mFont == null ? this.mDynamicFontSize : this.mFont.charSize;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        replacement.defaultSize = value;
      else
        this.mDynamicFontSize = value;
    }
  }

  public UISpriteData sprite
  {
    get
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
        return replacement.sprite;
      INGUIAtlas mAtlas = this.mAtlas as INGUIAtlas;
      if (this.mSprite == null && mAtlas != null && this.mFont != null && !string.IsNullOrEmpty(this.mFont.spriteName))
      {
        this.mSprite = mAtlas.GetSprite(this.mFont.spriteName);
        if (this.mSprite == null)
          this.mSprite = mAtlas.GetSprite(this.name);
        if (this.mSprite == null)
          this.mFont.spriteName = (string) null;
        else
          this.UpdateUVRect();
        int index = 0;
        for (int count = this.mSymbols.Count; index < count; ++index)
          this.symbols[index].MarkAsChanged();
      }
      return this.mSprite;
    }
  }

  public INGUIFont replacement
  {
    get => this.mReplacement == (UnityEngine.Object) null ? (INGUIFont) null : this.mReplacement as INGUIFont;
    set
    {
      INGUIFont nguiFont = value;
      if (nguiFont == this)
        nguiFont = (INGUIFont) null;
      if (this.mReplacement as INGUIFont == nguiFont)
        return;
      if (nguiFont != null && nguiFont.replacement == this)
        nguiFont.replacement = (INGUIFont) null;
      if (this.mReplacement != (UnityEngine.Object) null)
        this.MarkAsChanged();
      this.mReplacement = nguiFont as UnityEngine.Object;
      if (nguiFont != null)
      {
        this.mPMA = -1;
        this.mMat = (Material) null;
        this.mFont = (BMFont) null;
        this.mDynamicFont = (Font) null;
      }
      this.MarkAsChanged();
    }
  }

  public INGUIFont finalFont
  {
    get
    {
      INGUIFont finalFont = (INGUIFont) this;
      for (int index = 0; index < 10; ++index)
      {
        INGUIFont replacement = finalFont.replacement;
        if (replacement != null)
          finalFont = replacement;
      }
      return finalFont;
    }
  }

  public bool isDynamic
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement == null ? (UnityEngine.Object) this.mDynamicFont != (UnityEngine.Object) null : replacement.isDynamic;
    }
  }

  public Font dynamicFont
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement == null ? this.mDynamicFont : replacement.dynamicFont;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.dynamicFont = value;
      }
      else
      {
        if (!((UnityEngine.Object) this.mDynamicFont != (UnityEngine.Object) value))
          return;
        if ((UnityEngine.Object) this.mDynamicFont != (UnityEngine.Object) null)
          this.material = (Material) null;
        this.mDynamicFont = value;
        this.MarkAsChanged();
      }
    }
  }

  public FontStyle dynamicFontStyle
  {
    get
    {
      INGUIFont replacement = this.replacement;
      return replacement == null ? this.mDynamicFontStyle : replacement.dynamicFontStyle;
    }
    set
    {
      INGUIFont replacement = this.replacement;
      if (replacement != null)
      {
        replacement.dynamicFontStyle = value;
      }
      else
      {
        if (this.mDynamicFontStyle == value)
          return;
        this.mDynamicFontStyle = value;
        this.MarkAsChanged();
      }
    }
  }

  private void Trim()
  {
    Texture texture = (Texture) null;
    if (this.mAtlas is INGUIAtlas mAtlas)
      texture = mAtlas.texture;
    if (!((UnityEngine.Object) texture != (UnityEngine.Object) null) || this.mSprite == null)
      return;
    Rect pixels = NGUIMath.ConvertToPixels(this.mUVRect, this.texture.width, this.texture.height, true);
    Rect rect = new Rect((float) this.mSprite.x, (float) this.mSprite.y, (float) this.mSprite.width, (float) this.mSprite.height);
    this.mFont.Trim(Mathf.RoundToInt(rect.xMin - pixels.xMin), Mathf.RoundToInt(rect.yMin - pixels.yMin), Mathf.RoundToInt(rect.xMax - pixels.xMin), Mathf.RoundToInt(rect.yMax - pixels.yMin));
  }

  public bool References(INGUIFont font)
  {
    if (font == null)
      return false;
    if (font == this)
      return true;
    INGUIFont replacement = this.replacement;
    return replacement != null && replacement.References(font);
  }

  public void MarkAsChanged()
  {
    this.replacement?.MarkAsChanged();
    this.mSprite = (UISpriteData) null;
    UILabel[] active = NGUITools.FindActive<UILabel>();
    int index1 = 0;
    for (int length = active.Length; index1 < length; ++index1)
    {
      UILabel uiLabel = active[index1];
      if (uiLabel.enabled && NGUITools.GetActive(uiLabel.gameObject) && NGUITools.CheckIfRelated((INGUIFont) this, uiLabel.bitmapFont))
      {
        INGUIFont bitmapFont = uiLabel.bitmapFont;
        uiLabel.bitmapFont = (INGUIFont) null;
        uiLabel.bitmapFont = bitmapFont;
      }
    }
    int index2 = 0;
    for (int count = this.symbols.Count; index2 < count; ++index2)
      this.symbols[index2].MarkAsChanged();
  }

  public void UpdateUVRect()
  {
    if (this.mAtlas == (UnityEngine.Object) null)
      return;
    Texture texture = (Texture) null;
    if (this.mAtlas is INGUIAtlas mAtlas)
      texture = mAtlas.texture;
    if (!((UnityEngine.Object) texture != (UnityEngine.Object) null))
      return;
    this.mUVRect = new Rect((float) (this.mSprite.x - this.mSprite.paddingLeft), (float) (this.mSprite.y - this.mSprite.paddingTop), (float) (this.mSprite.width + this.mSprite.paddingLeft + this.mSprite.paddingRight), (float) (this.mSprite.height + this.mSprite.paddingTop + this.mSprite.paddingBottom));
    this.mUVRect = NGUIMath.ConvertToTexCoords(this.mUVRect, texture.width, texture.height);
    if (!this.mSprite.hasPadding)
      return;
    this.Trim();
  }

  private BMSymbol GetSymbol(string sequence, bool createIfMissing)
  {
    int index = 0;
    for (int count = this.mSymbols.Count; index < count; ++index)
    {
      BMSymbol mSymbol = this.mSymbols[index];
      if (mSymbol.sequence == sequence)
        return mSymbol;
    }
    if (!createIfMissing)
      return (BMSymbol) null;
    BMSymbol symbol = new BMSymbol();
    symbol.sequence = sequence;
    this.mSymbols.Add(symbol);
    return symbol;
  }

  public BMSymbol MatchSymbol(string text, int offset, int textLength)
  {
    int count = this.mSymbols.Count;
    if (count == 0)
      return (BMSymbol) null;
    textLength -= offset;
    for (int index1 = 0; index1 < count; ++index1)
    {
      BMSymbol mSymbol = this.mSymbols[index1];
      int length = mSymbol.length;
      if (length != 0 && textLength >= length)
      {
        bool flag = true;
        for (int index2 = 0; index2 < length; ++index2)
        {
          if ((int) text[offset + index2] != (int) mSymbol.sequence[index2])
          {
            flag = false;
            break;
          }
        }
        if (flag && mSymbol.Validate(this.atlas))
          return mSymbol;
      }
    }
    return (BMSymbol) null;
  }

  public void AddSymbol(string sequence, string spriteName)
  {
    this.GetSymbol(sequence, true).spriteName = spriteName;
    this.MarkAsChanged();
  }

  public void RemoveSymbol(string sequence)
  {
    BMSymbol symbol = this.GetSymbol(sequence, false);
    if (symbol != null)
      this.symbols.Remove(symbol);
    this.MarkAsChanged();
  }

  public void RenameSymbol(string before, string after)
  {
    BMSymbol symbol = this.GetSymbol(before, false);
    if (symbol != null)
      symbol.sequence = after;
    this.MarkAsChanged();
  }

  public bool UsesSprite(string s)
  {
    if (!string.IsNullOrEmpty(s))
    {
      if (s.Equals(this.spriteName))
        return true;
      int index = 0;
      for (int count = this.symbols.Count; index < count; ++index)
      {
        BMSymbol symbol = this.symbols[index];
        if (s.Equals(symbol.spriteName))
          return true;
      }
    }
    return false;
  }
}
