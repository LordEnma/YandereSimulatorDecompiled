// Decompiled with JetBrains decompiler
// Type: NGUIAtlas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class NGUIAtlas : ScriptableObject, INGUIAtlas
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
      return replacement != null ? replacement.spriteList : this.mSprites;
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
    get => this.mReplacement == (UnityEngine.Object) null ? (INGUIAtlas) null : this.mReplacement as INGUIAtlas;
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

  private enum Coordinates
  {
    Pixels,
    TexCoords,
  }
}
