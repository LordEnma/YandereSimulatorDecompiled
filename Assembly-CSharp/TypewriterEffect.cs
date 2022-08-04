// Decompiled with JetBrains decompiler
// Type: TypewriterEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof (UILabel))]
[AddComponentMenu("NGUI/Interaction/Typewriter Effect")]
public class TypewriterEffect : MonoBehaviour
{
  public static TypewriterEffect current;
  public int charsPerSecond = 20;
  public float fadeInTime;
  public float delayOnPeriod;
  public float delayOnNewLine;
  public UIScrollView scrollView;
  public bool keepFullDimensions;
  public List<EventDelegate> onFinished = new List<EventDelegate>();
  public UILabel mLabel;
  public string mFullText = "";
  public int mCurrentOffset;
  private float mNextChar;
  private bool mReset = true;
  public bool mActive;
  public bool delayOnComma;
  private BetterList<TypewriterEffect.FadeEntry> mFade = new BetterList<TypewriterEffect.FadeEntry>();

  public bool isActive => this.mActive;

  public void ResetToBeginning()
  {
    this.Finish();
    this.mReset = true;
    this.mActive = true;
    this.mNextChar = 0.0f;
    this.mCurrentOffset = 0;
    this.Update();
  }

  public void Finish()
  {
    if (!this.mActive)
      return;
    this.mActive = false;
    if (!this.mReset)
    {
      this.mCurrentOffset = this.mFullText.Length;
      this.mFade.Clear();
      this.mLabel.text = this.mFullText;
    }
    if (this.keepFullDimensions && (Object) this.scrollView != (Object) null)
      this.scrollView.UpdatePosition();
    TypewriterEffect.current = this;
    EventDelegate.Execute(this.onFinished);
    TypewriterEffect.current = (TypewriterEffect) null;
  }

  private void OnEnable()
  {
    this.mReset = true;
    this.mActive = true;
  }

  private void OnDisable() => this.Finish();

  private void Update()
  {
    if (!this.mActive)
      return;
    if (this.mReset)
    {
      this.mCurrentOffset = 0;
      this.mReset = false;
      this.mLabel = this.GetComponent<UILabel>();
      this.mFullText = this.mLabel.processedText;
      this.mFade.Clear();
      if (this.keepFullDimensions && (Object) this.scrollView != (Object) null)
        this.scrollView.UpdatePosition();
    }
    if (string.IsNullOrEmpty(this.mFullText))
      return;
    int length = this.mFullText.Length;
    while (this.mCurrentOffset < length && (double) this.mNextChar <= (double) RealTime.time)
    {
      int mCurrentOffset = this.mCurrentOffset;
      this.charsPerSecond = Mathf.Max(1, this.charsPerSecond);
      if (this.mLabel.supportEncoding)
      {
        while (NGUIText.ParseSymbol(this.mFullText, ref this.mCurrentOffset))
          ;
      }
      ++this.mCurrentOffset;
      if (this.mCurrentOffset <= length)
      {
        float num = 1f / (float) this.charsPerSecond;
        char ch = mCurrentOffset < length ? this.mFullText[mCurrentOffset] : '\n';
        if (ch == '\n')
          num += this.delayOnNewLine;
        else if (mCurrentOffset + 1 == length || this.mFullText[mCurrentOffset + 1] <= ' ')
        {
          switch (ch)
          {
            case '!':
            case '?':
              num += this.delayOnPeriod;
              break;
            case '.':
              if (mCurrentOffset + 2 < length && this.mFullText[mCurrentOffset + 1] == '.' && this.mFullText[mCurrentOffset + 2] == '.')
              {
                num += this.delayOnPeriod * 3f;
                mCurrentOffset += 2;
                break;
              }
              num += this.delayOnPeriod;
              break;
          }
        }
        if ((double) this.mNextChar == 0.0)
          this.mNextChar = RealTime.time + num;
        else
          this.mNextChar += num;
        if ((double) this.fadeInTime != 0.0)
        {
          this.mFade.Add(new TypewriterEffect.FadeEntry()
          {
            index = mCurrentOffset,
            alpha = 0.0f,
            text = this.mFullText.Substring(mCurrentOffset, this.mCurrentOffset - mCurrentOffset)
          });
        }
        else
        {
          this.mLabel.text = this.keepFullDimensions ? this.mFullText.Substring(0, this.mCurrentOffset) + "[00]" + this.mFullText.Substring(this.mCurrentOffset) : this.mFullText.Substring(0, this.mCurrentOffset);
          if (!this.keepFullDimensions && (Object) this.scrollView != (Object) null)
            this.scrollView.UpdatePosition();
        }
      }
      else
        break;
    }
    if (this.mCurrentOffset >= length && this.mFade.size == 0)
    {
      this.mLabel.text = this.mFullText;
      TypewriterEffect.current = this;
      EventDelegate.Execute(this.onFinished);
      TypewriterEffect.current = (TypewriterEffect) null;
      this.mActive = false;
    }
    else
    {
      if (this.mFade.size == 0)
        return;
      int index1 = 0;
      while (index1 < this.mFade.size)
      {
        TypewriterEffect.FadeEntry fadeEntry = this.mFade.buffer[index1];
        fadeEntry.alpha += RealTime.deltaTime / this.fadeInTime;
        if ((double) fadeEntry.alpha < 1.0)
        {
          this.mFade.buffer[index1] = fadeEntry;
          ++index1;
        }
        else
          this.mFade.RemoveAt(index1);
      }
      if (this.mFade.size == 0)
      {
        if (this.keepFullDimensions)
          this.mLabel.text = this.mFullText.Substring(0, this.mCurrentOffset) + "[00]" + this.mFullText.Substring(this.mCurrentOffset);
        else
          this.mLabel.text = this.mFullText.Substring(0, this.mCurrentOffset);
      }
      else
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index2 = 0; index2 < this.mFade.size; ++index2)
        {
          TypewriterEffect.FadeEntry fadeEntry = this.mFade.buffer[index2];
          if (index2 == 0)
            stringBuilder.Append(this.mFullText.Substring(0, fadeEntry.index));
          stringBuilder.Append('[');
          stringBuilder.Append(NGUIText.EncodeAlpha(fadeEntry.alpha));
          stringBuilder.Append(']');
          stringBuilder.Append(fadeEntry.text);
        }
        if (this.keepFullDimensions)
        {
          stringBuilder.Append("[00]");
          stringBuilder.Append(this.mFullText.Substring(this.mCurrentOffset));
        }
        this.mLabel.text = stringBuilder.ToString();
      }
    }
  }

  private struct FadeEntry
  {
    public int index;
    public string text;
    public float alpha;
  }
}
