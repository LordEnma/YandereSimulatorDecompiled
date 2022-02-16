using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020000AE RID: 174
[AddComponentMenu("NGUI/UI/Text List")]
public class UITextList : MonoBehaviour
{
	// Token: 0x170001CA RID: 458
	// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00047754 File Offset: 0x00045954
	protected BetterList<UITextList.Paragraph> paragraphs
	{
		get
		{
			if (this.mParagraphs == null && !UITextList.mHistory.TryGetValue(base.name, out this.mParagraphs))
			{
				this.mParagraphs = new BetterList<UITextList.Paragraph>();
				UITextList.mHistory.Add(base.name, this.mParagraphs);
			}
			return this.mParagraphs;
		}
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x060008B3 RID: 2227 RVA: 0x000477A8 File Offset: 0x000459A8
	public int paragraphCount
	{
		get
		{
			return this.paragraphs.size;
		}
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x060008B4 RID: 2228 RVA: 0x000477B5 File Offset: 0x000459B5
	public bool isValid
	{
		get
		{
			return this.textLabel != null && this.textLabel.ambigiousFont != null;
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x060008B5 RID: 2229 RVA: 0x000477D8 File Offset: 0x000459D8
	// (set) Token: 0x060008B6 RID: 2230 RVA: 0x000477E0 File Offset: 0x000459E0
	public float scrollValue
	{
		get
		{
			return this.mScroll;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (this.isValid && this.mScroll != value)
			{
				if (this.scrollBar != null)
				{
					this.scrollBar.value = value;
					return;
				}
				this.mScroll = value;
				this.UpdateVisibleText();
			}
		}
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0004782E File Offset: 0x00045A2E
	protected float lineHeight
	{
		get
		{
			if (!(this.textLabel != null))
			{
				return 20f;
			}
			return (float)this.textLabel.fontSize + this.textLabel.effectiveSpacingY;
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x060008B8 RID: 2232 RVA: 0x0004785C File Offset: 0x00045A5C
	protected int scrollHeight
	{
		get
		{
			if (!this.isValid)
			{
				return 0;
			}
			int num = Mathf.FloorToInt((float)this.textLabel.height / this.lineHeight);
			return Mathf.Max(0, this.mTotalLines - num);
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x0004789A File Offset: 0x00045A9A
	public void Clear()
	{
		this.paragraphs.Clear();
		this.UpdateVisibleText();
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x000478B0 File Offset: 0x00045AB0
	private void Start()
	{
		if (this.textLabel == null)
		{
			this.textLabel = base.GetComponentInChildren<UILabel>();
		}
		if (this.scrollBar != null)
		{
			EventDelegate.Add(this.scrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
		}
		this.textLabel.overflowMethod = UILabel.Overflow.ClampContent;
		if (this.style == UITextList.Style.Chat)
		{
			this.textLabel.pivot = UIWidget.Pivot.BottomLeft;
			this.scrollValue = 1f;
			return;
		}
		this.textLabel.pivot = UIWidget.Pivot.TopLeft;
		this.scrollValue = 0f;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x00047946 File Offset: 0x00045B46
	private void Update()
	{
		if (this.isValid && (this.textLabel.width != this.mLastWidth || this.textLabel.height != this.mLastHeight))
		{
			this.Rebuild();
		}
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x0004797C File Offset: 0x00045B7C
	public void OnScroll(float val)
	{
		int scrollHeight = this.scrollHeight;
		if (scrollHeight != 0)
		{
			val *= this.lineHeight;
			this.scrollValue = this.mScroll - val / (float)scrollHeight;
		}
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x000479B0 File Offset: 0x00045BB0
	public void OnDrag(Vector2 delta)
	{
		int scrollHeight = this.scrollHeight;
		if (scrollHeight != 0)
		{
			float num = delta.y / this.lineHeight;
			this.scrollValue = this.mScroll + num / (float)scrollHeight;
		}
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x000479E6 File Offset: 0x00045BE6
	private void OnScrollBar()
	{
		this.mScroll = UIProgressBar.current.value;
		this.UpdateVisibleText();
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x000479FE File Offset: 0x00045BFE
	public void Add(string text)
	{
		this.Add(text, true);
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x00047A08 File Offset: 0x00045C08
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

	// Token: 0x060008C1 RID: 2241 RVA: 0x00047A68 File Offset: 0x00045C68
	protected void Rebuild()
	{
		if (this.isValid)
		{
			this.mLastWidth = this.textLabel.width;
			this.mLastHeight = this.textLabel.height;
			this.textLabel.UpdateNGUIText();
			NGUIText.rectHeight = 1000000;
			NGUIText.regionHeight = 1000000;
			this.mTotalLines = 0;
			for (int i = 0; i < this.paragraphs.size; i++)
			{
				UITextList.Paragraph paragraph = this.mParagraphs.buffer[i];
				string text;
				NGUIText.WrapText(paragraph.text, out text, false, true, false);
				paragraph.lines = text.Split(new char[]
				{
					'\n'
				});
				this.mTotalLines += paragraph.lines.Length;
			}
			this.mTotalLines = 0;
			int j = 0;
			int size = this.mParagraphs.size;
			while (j < size)
			{
				this.mTotalLines += this.mParagraphs.buffer[j].lines.Length;
				j++;
			}
			if (this.scrollBar != null)
			{
				UIScrollBar uiscrollBar = this.scrollBar as UIScrollBar;
				if (uiscrollBar != null)
				{
					uiscrollBar.barSize = ((this.mTotalLines == 0) ? 1f : (1f - (float)this.scrollHeight / (float)this.mTotalLines));
				}
			}
			this.UpdateVisibleText();
		}
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x00047BC4 File Offset: 0x00045DC4
	protected void UpdateVisibleText()
	{
		if (this.isValid)
		{
			if (this.mTotalLines == 0)
			{
				this.textLabel.text = "";
				return;
			}
			int num = Mathf.FloorToInt((float)this.textLabel.height / this.lineHeight);
			int num2 = Mathf.Max(0, this.mTotalLines - num);
			int num3 = Mathf.RoundToInt(this.mScroll * (float)num2);
			if (num3 < 0)
			{
				num3 = 0;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num4 = 0;
			int size = this.paragraphs.size;
			while (num > 0 && num4 < size)
			{
				UITextList.Paragraph paragraph = this.mParagraphs.buffer[num4];
				int num5 = 0;
				int num6 = paragraph.lines.Length;
				while (num > 0 && num5 < num6)
				{
					string value = paragraph.lines[num5];
					if (num3 > 0)
					{
						num3--;
					}
					else
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("\n");
						}
						stringBuilder.Append(value);
						num--;
					}
					num5++;
				}
				num4++;
			}
			this.textLabel.text = stringBuilder.ToString();
		}
	}

	// Token: 0x04000789 RID: 1929
	public UILabel textLabel;

	// Token: 0x0400078A RID: 1930
	public UIProgressBar scrollBar;

	// Token: 0x0400078B RID: 1931
	public UITextList.Style style;

	// Token: 0x0400078C RID: 1932
	public int paragraphHistory = 100;

	// Token: 0x0400078D RID: 1933
	protected char[] mSeparator = new char[]
	{
		'\n'
	};

	// Token: 0x0400078E RID: 1934
	protected float mScroll;

	// Token: 0x0400078F RID: 1935
	protected int mTotalLines;

	// Token: 0x04000790 RID: 1936
	protected int mLastWidth;

	// Token: 0x04000791 RID: 1937
	protected int mLastHeight;

	// Token: 0x04000792 RID: 1938
	private BetterList<UITextList.Paragraph> mParagraphs;

	// Token: 0x04000793 RID: 1939
	private static Dictionary<string, BetterList<UITextList.Paragraph>> mHistory = new Dictionary<string, BetterList<UITextList.Paragraph>>();

	// Token: 0x02000642 RID: 1602
	[DoNotObfuscateNGUI]
	public enum Style
	{
		// Token: 0x04004E85 RID: 20101
		Text,
		// Token: 0x04004E86 RID: 20102
		Chat
	}

	// Token: 0x02000643 RID: 1603
	protected class Paragraph
	{
		// Token: 0x04004E87 RID: 20103
		public string text;

		// Token: 0x04004E88 RID: 20104
		public string[] lines;
	}
}
