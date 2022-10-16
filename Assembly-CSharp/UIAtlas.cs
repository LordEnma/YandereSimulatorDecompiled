// Decompiled with JetBrains decompiler
// Type: UIAtlas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class UIAtlas : MonoBehaviour, INGUIAtlas
{
  [HideInInspector]
  [SerializeField]
  private Material material;
  [HideInInspector]
  [SerializeField]
  private List<UISpriteData> mSprites = new List<UISpriteData>();
  [HideInInspector]
  [SerializeField]
  private float mPixelSize = 1f;
  [HideInInspector]
  [SerializeField]
  private UnityEngine.Object mReplacement;
  [HideInInspector]
  [SerializeField]
  private UIAtlas.Coordinates mCoordinates;
  [HideInInspector]
  [SerializeField]
  private List<UIAtlas.Sprite> sprites = new List<UIAtlas.Sprite>();
  [NonSerialized]
  private int mPMA = -1;
  [NonSerialized]
  private Dictionary<string, int> mSpriteIndices = new Dictionary<string, int>();

  public Material spriteMaterial
  {
    get
    {
      INGUIAtlas replacement = this.replacement;
      return replacement == null ? this.material : replacement.spriteMaterial;
    }
    set
    {
      INGUIAtlas replacement = this.replacement;
      if (replacement != null)
        replacement.spriteMaterial = value;
      else if ((UnityEngine.Object) this.material == (UnityEngine.Object) null)
      {
        this.mPMA = 0;
        this.material = value;
      }
      else
      {
        this.MarkAsChanged();
        this.mPMA = -1;
        this.material = value;
        this.MarkAsChanged();
      }
    }
  }

  public bool premultipliedAlpha
  {
    get
    {
      INGUIAtlas replacement = this.replacement;
      if (replacement != null)
        return replacement.premultipliedAlpha;
      if (this.mPMA == -1)
      {
        Material spriteMaterial = this.spriteMaterial;
        this.mPMA = !((UnityEngine.Object) spriteMaterial != (UnityEngine.Object) null) || !((UnityEngine.Object) spriteMaterial.shader != (UnityEngine.Object) null) || !spriteMaterial.shader.name.Contains("Premultiplied") ? 0 : 1;
      }
      return this.mPMA == 1;
    }
  }

  public List<UISpriteData> spriteList
  {
    get
    {
      INGUIAtlas replacement = this.replacement;
      if (replacement != null)
        return replacement.spriteList;
      if (this.mSprites.Count == 0)
        this.Upgrade();
      return this.mSprites;
    }
    set
    {
      INGUIAtlas replacement = this.replacement;
      if (replacement != null)
        replacement.spriteList = value;
      else
        this.mSprites = value;
    }
  }

  public Texture texture
  {
    get
    {
      INGUIAtlas replacement = this.replacement;
      if (replacement != null)
        return replacement.texture;
      return !((UnityEngine.Object) this.material != (UnityEngine.Object) null) ? (Texture) null : this.material.mainTexture;
    }
  }

  public float pixelSize
  {
    get
    {
      INGUIAtlas replacement = this.replacement;
      return replacement == null ? this.mPixelSize : replacement.pixelSize;
    }
    set
    {
      INGUIAtlas replacement = this.replacement;
      if (replacement != null)
      {
        replacement.pixelSize = value;
      }
      else
      {
        float num = Mathf.Clamp(value, 0.25f, 4f);
        if ((double) this.mPixelSize == (double) num)
          return;
        this.mPixelSize = num;
        this.MarkAsChanged();
      }
    }
  }

  public INGUIAtlas replacement
  {
    get => this.mReplacement as INGUIAtlas;
    set
    {
      INGUIAtlas nguiAtlas = value;
      if (nguiAtlas == this)
        nguiAtlas = (INGUIAtlas) null;
      if (this.mReplacement as INGUIAtlas == nguiAtlas)
        return;
      if (nguiAtlas != null && nguiAtlas.replacement == this)
        nguiAtlas.replacement = (INGUIAtlas) null;
      if (this.mReplacement != (UnityEngine.Object) null)
        this.MarkAsChanged();
      this.mReplacement = nguiAtlas as UnityEngine.Object;
      if (nguiAtlas != null)
        this.material = (Material) null;
      this.MarkAsChanged();
    }
  }

  public UISpriteData GetSprite(string name)
  {
    INGUIAtlas replacement = this.replacement;
    if (replacement != null)
      return replacement.GetSprite(name);
    if (!string.IsNullOrEmpty(name))
    {
      if (this.mSprites.Count == 0)
        this.Upgrade();
      if (this.mSprites.Count == 0)
        return (UISpriteData) null;
      if (this.mSpriteIndices.Count != this.mSprites.Count)
        this.MarkSpriteListAsChanged();
      int index1;
      if (this.mSpriteIndices.TryGetValue(name, out index1))
      {
        if (index1 > -1 && index1 < this.mSprites.Count)
          return this.mSprites[index1];
        this.MarkSpriteListAsChanged();
        return !this.mSpriteIndices.TryGetValue(name, out index1) ? (UISpriteData) null : this.mSprites[index1];
      }
      int index2 = 0;
      for (int count = this.mSprites.Count; index2 < count; ++index2)
      {
        UISpriteData mSprite = this.mSprites[index2];
        if (!string.IsNullOrEmpty(mSprite.name) && name == mSprite.name)
        {
          this.MarkSpriteListAsChanged();
          return mSprite;
        }
      }
    }
    return (UISpriteData) null;
  }

  public void MarkSpriteListAsChanged()
  {
    this.mSpriteIndices.Clear();
    int index = 0;
    for (int count = this.mSprites.Count; index < count; ++index)
      this.mSpriteIndices[this.mSprites[index].name] = index;
  }

  public void SortAlphabetically() => this.mSprites.Sort((Comparison<UISpriteData>) ((s1, s2) => s1.name.CompareTo(s2.name)));

  public BetterList<string> GetListOfSprites()
  {
    INGUIAtlas replacement = this.replacement;
    if (replacement != null)
      return replacement.GetListOfSprites();
    if (this.mSprites.Count == 0)
      this.Upgrade();
    BetterList<string> listOfSprites = new BetterList<string>();
    int index = 0;
    for (int count = this.mSprites.Count; index < count; ++index)
    {
      UISpriteData mSprite = this.mSprites[index];
      if (mSprite != null && !string.IsNullOrEmpty(mSprite.name))
        listOfSprites.Add(mSprite.name);
    }
    return listOfSprites;
  }

  public BetterList<string> GetListOfSprites(string match)
  {
    INGUIAtlas replacement = this.replacement;
    if (replacement != null)
      return replacement.GetListOfSprites(match);
    if (string.IsNullOrEmpty(match))
      return this.GetListOfSprites();
    if (this.mSprites.Count == 0)
      this.Upgrade();
    BetterList<string> listOfSprites = new BetterList<string>();
    int index1 = 0;
    for (int count = this.mSprites.Count; index1 < count; ++index1)
    {
      UISpriteData mSprite = this.mSprites[index1];
      if (mSprite != null && !string.IsNullOrEmpty(mSprite.name) && string.Equals(match, mSprite.name, StringComparison.OrdinalIgnoreCase))
      {
        listOfSprites.Add(mSprite.name);
        return listOfSprites;
      }
    }
    string[] strArray = match.Split(new char[1]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
    for (int index2 = 0; index2 < strArray.Length; ++index2)
      strArray[index2] = strArray[index2].ToLower();
    int index3 = 0;
    for (int count = this.mSprites.Count; index3 < count; ++index3)
    {
      UISpriteData mSprite = this.mSprites[index3];
      if (mSprite != null && !string.IsNullOrEmpty(mSprite.name))
      {
        string lower = mSprite.name.ToLower();
        int num = 0;
        for (int index4 = 0; index4 < strArray.Length; ++index4)
        {
          if (lower.Contains(strArray[index4]))
            ++num;
        }
        if (num == strArray.Length)
          listOfSprites.Add(mSprite.name);
      }
    }
    return listOfSprites;
  }

  public bool References(INGUIAtlas atlas)
  {
    if (atlas == null)
      return false;
    if (atlas == this)
      return true;
    INGUIAtlas replacement = this.replacement;
    return replacement != null && replacement.References(atlas);
  }

  public void MarkAsChanged()
  {
    this.replacement?.MarkAsChanged();
    UISprite[] active1 = NGUITools.FindActive<UISprite>();
    int index1 = 0;
    for (int length = active1.Length; index1 < length; ++index1)
    {
      UISprite uiSprite = active1[index1];
      if (NGUITools.CheckIfRelated((INGUIAtlas) this, uiSprite.atlas))
      {
        INGUIAtlas atlas = uiSprite.atlas;
        uiSprite.atlas = (INGUIAtlas) null;
        uiSprite.atlas = atlas;
      }
    }
    NGUIFont[] objectsOfTypeAll1 = Resources.FindObjectsOfTypeAll<NGUIFont>();
    int index2 = 0;
    for (int length = objectsOfTypeAll1.Length; index2 < length; ++index2)
    {
      NGUIFont nguiFont = objectsOfTypeAll1[index2];
      if (nguiFont.atlas != null && NGUITools.CheckIfRelated((INGUIAtlas) this, nguiFont.atlas))
      {
        INGUIAtlas atlas = nguiFont.atlas;
        nguiFont.atlas = (INGUIAtlas) null;
        nguiFont.atlas = atlas;
      }
    }
    UIFont[] objectsOfTypeAll2 = Resources.FindObjectsOfTypeAll<UIFont>();
    int index3 = 0;
    for (int length = objectsOfTypeAll2.Length; index3 < length; ++index3)
    {
      UIFont uiFont = objectsOfTypeAll2[index3];
      if (NGUITools.CheckIfRelated((INGUIAtlas) this, uiFont.atlas))
      {
        INGUIAtlas atlas = uiFont.atlas;
        uiFont.atlas = (INGUIAtlas) null;
        uiFont.atlas = atlas;
      }
    }
    UILabel[] active2 = NGUITools.FindActive<UILabel>();
    int index4 = 0;
    for (int length = active2.Length; index4 < length; ++index4)
    {
      UILabel uiLabel = active2[index4];
      if (uiLabel.atlas != null && NGUITools.CheckIfRelated((INGUIAtlas) this, uiLabel.atlas))
      {
        INGUIAtlas atlas = uiLabel.atlas;
        INGUIFont bitmapFont = uiLabel.bitmapFont;
        uiLabel.bitmapFont = (INGUIFont) null;
        uiLabel.bitmapFont = bitmapFont;
      }
    }
  }

  private bool Upgrade()
  {
    INGUIAtlas replacement = this.replacement;
    if (replacement != null)
    {
      UIAtlas uiAtlas = replacement as UIAtlas;
      if ((UnityEngine.Object) uiAtlas != (UnityEngine.Object) null)
        return uiAtlas.Upgrade();
    }
    if (this.mSprites.Count != 0 || this.sprites.Count <= 0 || !(bool) (UnityEngine.Object) this.material)
      return false;
    Texture mainTexture = this.material.mainTexture;
    int width = (UnityEngine.Object) mainTexture != (UnityEngine.Object) null ? mainTexture.width : 512;
    int height = (UnityEngine.Object) mainTexture != (UnityEngine.Object) null ? mainTexture.height : 512;
    for (int index = 0; index < this.sprites.Count; ++index)
    {
      UIAtlas.Sprite sprite = this.sprites[index];
      Rect outer = sprite.outer;
      Rect inner = sprite.inner;
      if (this.mCoordinates == UIAtlas.Coordinates.TexCoords)
      {
        NGUIMath.ConvertToPixels(outer, width, height, true);
        NGUIMath.ConvertToPixels(inner, width, height, true);
      }
      this.mSprites.Add(new UISpriteData()
      {
        name = sprite.name,
        x = Mathf.RoundToInt(outer.xMin),
        y = Mathf.RoundToInt(outer.yMin),
        width = Mathf.RoundToInt(outer.width),
        height = Mathf.RoundToInt(outer.height),
        paddingLeft = Mathf.RoundToInt(sprite.paddingLeft * outer.width),
        paddingRight = Mathf.RoundToInt(sprite.paddingRight * outer.width),
        paddingBottom = Mathf.RoundToInt(sprite.paddingBottom * outer.height),
        paddingTop = Mathf.RoundToInt(sprite.paddingTop * outer.height),
        borderLeft = Mathf.RoundToInt(inner.xMin - outer.xMin),
        borderRight = Mathf.RoundToInt(outer.xMax - inner.xMax),
        borderBottom = Mathf.RoundToInt(outer.yMax - inner.yMax),
        borderTop = Mathf.RoundToInt(inner.yMin - outer.yMin)
      });
    }
    this.sprites.Clear();
    return true;
  }

  [Serializable]
  private class Sprite
  {
    public string name = "Unity Bug";
    public Rect outer = new Rect(0.0f, 0.0f, 1f, 1f);
    public Rect inner = new Rect(0.0f, 0.0f, 1f, 1f);
    public bool rotated;
    public float paddingLeft;
    public float paddingRight;
    public float paddingTop;
    public float paddingBottom;

    public bool hasPadding => (double) this.paddingLeft != 0.0 || (double) this.paddingRight != 0.0 || (double) this.paddingTop != 0.0 || (double) this.paddingBottom != 0.0;
  }

  private enum Coordinates
  {
    Pixels,
    TexCoords,
  }
}
