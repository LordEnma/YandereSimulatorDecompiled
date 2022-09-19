// Decompiled with JetBrains decompiler
// Type: UI2DSpriteAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class UI2DSpriteAnimation : MonoBehaviour
{
  public int frameIndex;
  [SerializeField]
  protected int framerate = 20;
  public bool ignoreTimeScale = true;
  public bool loop = true;
  public UnityEngine.Sprite[] frames;
  private SpriteRenderer mUnitySprite;
  private UI2DSprite mNguiSprite;
  private float mUpdate;

  public bool isPlaying => this.enabled;

  public int framesPerSecond
  {
    get => this.framerate;
    set => this.framerate = value;
  }

  public void Play()
  {
    if (this.frames == null || this.frames.Length == 0)
      return;
    if (!this.enabled && !this.loop)
    {
      int num = this.framerate > 0 ? this.frameIndex + 1 : this.frameIndex - 1;
      if (num < 0 || num >= this.frames.Length)
        this.frameIndex = this.framerate < 0 ? this.frames.Length - 1 : 0;
    }
    this.enabled = true;
    this.UpdateSprite();
  }

  public void Pause() => this.enabled = false;

  public void ResetToBeginning()
  {
    this.frameIndex = this.framerate < 0 ? this.frames.Length - 1 : 0;
    this.UpdateSprite();
  }

  private void Start() => this.Play();

  private void Update()
  {
    if (this.frames == null || this.frames.Length == 0)
    {
      this.enabled = false;
    }
    else
    {
      if (this.framerate == 0)
        return;
      float num = this.ignoreTimeScale ? RealTime.time : Time.time;
      if ((double) this.mUpdate >= (double) num)
        return;
      this.mUpdate = num;
      int val = this.framerate > 0 ? this.frameIndex + 1 : this.frameIndex - 1;
      if (!this.loop && (val < 0 || val >= this.frames.Length))
      {
        this.enabled = false;
      }
      else
      {
        this.frameIndex = NGUIMath.RepeatIndex(val, this.frames.Length);
        this.UpdateSprite();
      }
    }
  }

  private void UpdateSprite()
  {
    if ((Object) this.mUnitySprite == (Object) null && (Object) this.mNguiSprite == (Object) null)
    {
      this.mUnitySprite = this.GetComponent<SpriteRenderer>();
      this.mNguiSprite = this.GetComponent<UI2DSprite>();
      if ((Object) this.mUnitySprite == (Object) null && (Object) this.mNguiSprite == (Object) null)
      {
        this.enabled = false;
        return;
      }
    }
    float num = this.ignoreTimeScale ? RealTime.time : Time.time;
    if (this.framerate != 0)
      this.mUpdate = num + Mathf.Abs(1f / (float) this.framerate);
    if ((Object) this.mUnitySprite != (Object) null)
    {
      this.mUnitySprite.sprite = this.frames[this.frameIndex];
    }
    else
    {
      if (!((Object) this.mNguiSprite != (Object) null))
        return;
      this.mNguiSprite.nextSprite = this.frames[this.frameIndex];
    }
  }
}
