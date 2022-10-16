// Decompiled with JetBrains decompiler
// Type: UITextList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Text List")]
public class UITextList : MonoBehaviour
{
  public UILabel textLabel;
  public UIProgressBar scrollBar;
  public UITextList.Style style;
  public int paragraphHistory = 100;
  protected char[] mSeparator = new char[1]{ '\n' };
  protected float mScroll;
  protected int mTotalLines;
  protected int mLastWidth;
  protected int mLastHeight;
  private BetterList<UITextList.Paragraph> mParagraphs;
  private static Dictionary<string, BetterList<UITextList.Paragraph>> mHistory = new Dictionary<string, BetterList<UITextList.Paragraph>>();

  protected BetterList<UITextList.Paragraph> paragraphs
  {
    get
    {
      if (this.mParagraphs == null && !UITextList.mHistory.TryGetValue(this.name, out this.mParagraphs))
      {
        this.mParagraphs = new BetterList<UITextList.Paragraph>();
        UITextList.mHistory.Add(this.name, this.mParagraphs);
      }
      return this.mParagraphs;
    }
  }

  public int paragraphCount => this.paragraphs.size;

  public bool isValid => (Object) this.textLabel != (Object) null && this.textLabel.ambigiousFont != (Object) null;

  public float scrollValue
  {
    get => this.mScroll;
    set
    {
      value = Mathf.Clamp01(value);
      if (!this.isValid || (double) this.mScroll == (double) value)
        return;
      if ((Object) this.scrollBar != (Object) null)
      {
        this.scrollBar.value = value;
      }
      else
      {
        this.mScroll = value;
        this.UpdateVisibleText();
      }
    }
  }

  protected float lineHeight => !((Object) this.textLabel != (Object) null) ? 20f : (float) this.textLabel.fontSize + this.textLabel.effectiveSpacingY;

  protected int scrollHeight => !this.isValid ? 0 : Mathf.Max(0, this.mTotalLines - Mathf.FloorToInt((float) this.textLabel.height / this.lineHeight));

  public void Clear()
  {
    this.paragraphs.Clear();
    this.UpdateVisibleText();
  }

  private void Start()
  {
    if ((Object) this.textLabel == (Object) null)
      this.textLabel = this.GetComponentInChildren<UILabel>();
    if ((Object) this.scrollBar != (Object) null)
      EventDelegate.Add(this.scrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
    this.textLabel.overflowMethod = UILabel.Overflow.ClampContent;
    if (this.style == UITextList.Style.Chat)
    {
      this.textLabel.pivot = UIWidget.Pivot.BottomLeft;
      this.scrollValue = 1f;
    }
    else
    {
      this.textLabel.pivot = UIWidget.Pivot.TopLeft;
      this.scrollValue = 0.0f;
    }
  }

  private void Update()
  {
    if (!this.isValid || this.textLabel.width == this.mLastWidth && this.textLabel.height == this.mLastHeight)
      return;
    this.Rebuild();
  }

  public void OnScroll(float val)
  {
    int scrollHeight = this.scrollHeight;
    if (scrollHeight == 0)
      return;
    val *= this.lineHeight;
    this.scrollValue = this.mScroll - val / (float) scrollHeight;
  }

  public void OnDrag(Vector2 delta)
  {
    int scrollHeight = this.scrollHeight;
    if (scrollHeight == 0)
      return;
    this.scrollValue = this.mScroll + delta.y / this.lineHeight / (float) scrollHeight;
  }

  private void OnScrollBar()
  {
    this.mScroll = UIProgressBar.current.value;
    this.UpdateVisibleText();
  }

  public void Add(string text) => this.Add(text, true);

  protected void Add(string text, bool updateVisible)
  {
    UITextList.Paragraph paragraph;
    if (this.paragraphs.size < this.paragraphHistory)
    {
      paragraph = new UITextList.Paragraph();
    }
    else
    {
      paragraph = this.mParagraphs.buffer[0];
      this.mParagraphs.RemoveAt(0);
    }
    paragraph.text = text;
    this.mParagraphs.Add(paragraph);
    this.Rebuild();
  }

  protected void Rebuild()
  {
    if (!this.isValid)
      return;
    this.mLastWidth = this.textLabel.width;
    this.mLastHeight = this.textLabel.height;
    this.textLabel.UpdateNGUIText();
    NGUIText.rectHeight = 1000000;
    NGUIText.regionHeight = 1000000;
    this.mTotalLines = 0;
    for (int index = 0; index < this.paragraphs.size; ++index)
    {
      UITextList.Paragraph paragraph = this.mParagraphs.buffer[index];
      string finalText;
      NGUIText.WrapText(paragraph.text, out finalText, false, true);
      paragraph.lines = finalText.Split('\n');
      this.mTotalLines += paragraph.lines.Length;
    }
    this.mTotalLines = 0;
    int index1 = 0;
    for (int size = this.mParagraphs.size; index1 < size; ++index1)
      this.mTotalLines += this.mParagraphs.buffer[index1].lines.Length;
    if ((Object) this.scrollBar != (Object) null)
    {
      UIScrollBar scrollBar = this.scrollBar as UIScrollBar;
      if ((Object) scrollBar != (Object) null)
        scrollBar.barSize = this.mTotalLines == 0 ? 1f : (float) (1.0 - (double) this.scrollHeight / (double) this.mTotalLines);
    }
    this.UpdateVisibleText();
  }

  protected void UpdateVisibleText()
  {
    if (!this.isValid)
      return;
    if (this.mTotalLines == 0)
    {
      this.textLabel.text = "";
    }
    else
    {
      int num1 = Mathf.FloorToInt((float) this.textLabel.height / this.lineHeight);
      int num2 = Mathf.RoundToInt(this.mScroll * (float) Mathf.Max(0, this.mTotalLines - num1));
      if (num2 < 0)
        num2 = 0;
      StringBuilder stringBuilder = new StringBuilder();
      int index1 = 0;
      for (int size = this.paragraphs.size; num1 > 0 && index1 < size; ++index1)
      {
        UITextList.Paragraph paragraph = this.mParagraphs.buffer[index1];
        int index2 = 0;
        for (int length = paragraph.lines.Length; num1 > 0 && index2 < length; ++index2)
        {
          string line = paragraph.lines[index2];
          if (num2 > 0)
          {
            --num2;
          }
          else
          {
            if (stringBuilder.Length > 0)
              stringBuilder.Append("\n");
            stringBuilder.Append(line);
            --num1;
          }
        }
      }
      this.textLabel.text = stringBuilder.ToString();
    }
  }

  [DoNotObfuscateNGUI]
  public enum Style
  {
    Text,
    Chat,
  }

  protected class Paragraph
  {
    public string text;
    public string[] lines;
  }
}
