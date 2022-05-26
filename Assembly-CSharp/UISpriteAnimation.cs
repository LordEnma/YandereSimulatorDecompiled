// Decompiled with JetBrains decompiler
// Type: UISpriteAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation")]
public class UISpriteAnimation : MonoBehaviour
{
  public int frameIndex;
  [HideInInspector]
  [SerializeField]
  protected int mFPS = 30;
  [HideInInspector]
  [SerializeField]
  protected string mPrefix = "";
  [HideInInspector]
  [SerializeField]
  protected bool mLoop = true;
  [HideInInspector]
  [SerializeField]
  protected bool mSnap = true;
  protected UISprite mSprite;
  protected float mDelta;
  protected bool mActive = true;
  protected List<string> mSpriteNames = new List<string>();

  public int frames => this.mSpriteNames.Count;

  public int framesPerSecond
  {
    get => this.mFPS;
    set => this.mFPS = value;
  }

  public string namePrefix
  {
    get => this.mPrefix;
    set
    {
      if (!(this.mPrefix != value))
        return;
      this.mPrefix = value;
      this.RebuildSpriteList();
    }
  }

  public bool loop
  {
    get => this.mLoop;
    set => this.mLoop = value;
  }

  public bool isPlaying => this.mActive;

  protected virtual void Start() => this.RebuildSpriteList();

  protected virtual void Update()
  {
    if (!this.mActive || this.mSpriteNames.Count <= 1 || !Application.isPlaying || this.mFPS <= 0)
      return;
    this.mDelta += Mathf.Min(1f, RealTime.deltaTime);
    float num = 1f / (float) this.mFPS;
    while ((double) num < (double) this.mDelta)
    {
      this.mDelta = (double) num > 0.0 ? this.mDelta - num : 0.0f;
      if (++this.frameIndex >= this.mSpriteNames.Count)
      {
        this.frameIndex = 0;
        this.mActive = this.mLoop;
      }
      if (this.mActive)
      {
        this.mSprite.spriteName = this.mSpriteNames[this.frameIndex];
        if (this.mSnap)
          this.mSprite.MakePixelPerfect();
      }
    }
  }

  public void RebuildSpriteList()
  {
    if ((Object) this.mSprite == (Object) null)
      this.mSprite = this.GetComponent<UISprite>();
    this.mSpriteNames.Clear();
    if (!((Object) this.mSprite != (Object) null))
      return;
    INGUIAtlas atlas = this.mSprite.atlas;
    if (atlas == null)
      return;
    List<UISpriteData> spriteList = atlas.spriteList;
    int index = 0;
    for (int count = spriteList.Count; index < count; ++index)
    {
      UISpriteData uiSpriteData = spriteList[index];
      if (string.IsNullOrEmpty(this.mPrefix) || uiSpriteData.name.StartsWith(this.mPrefix))
        this.mSpriteNames.Add(uiSpriteData.name);
    }
    this.mSpriteNames.Sort();
  }

  public void Play() => this.mActive = true;

  public void Pause() => this.mActive = false;

  public void ResetToBeginning()
  {
    this.mActive = true;
    this.frameIndex = 0;
    if (!((Object) this.mSprite != (Object) null) || this.mSpriteNames.Count <= 0)
      return;
    this.mSprite.spriteName = this.mSpriteNames[this.frameIndex];
    if (!this.mSnap)
      return;
    this.mSprite.MakePixelPerfect();
  }
}
