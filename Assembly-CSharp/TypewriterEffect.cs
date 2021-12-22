using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000042 RID: 66
[RequireComponent(typeof(UILabel))]
[AddComponentMenu("NGUI/Interaction/Typewriter Effect")]
public class TypewriterEffect : MonoBehaviour
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000108 RID: 264 RVA: 0x000132B8 File Offset: 0x000114B8
	public bool isActive
	{
		get
		{
			return this.mActive;
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x000132C0 File Offset: 0x000114C0
	public void ResetToBeginning()
	{
		this.Finish();
		this.mReset = true;
		this.mActive = true;
		this.mNextChar = 0f;
		this.mCurrentOffset = 0;
		this.Update();
	}

	// Token: 0x0600010A RID: 266 RVA: 0x000132F0 File Offset: 0x000114F0
	public void Finish()
	{
		if (this.mActive)
		{
			this.mActive = false;
			if (!this.mReset)
			{
				this.mCurrentOffset = this.mFullText.Length;
				this.mFade.Clear();
				this.mLabel.text = this.mFullText;
			}
			if (this.keepFullDimensions && this.scrollView != null)
			{
				this.scrollView.UpdatePosition();
			}
			TypewriterEffect.current = this;
			EventDelegate.Execute(this.onFinished);
			TypewriterEffect.current = null;
		}
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00013379 File Offset: 0x00011579
	private void OnEnable()
	{
		this.mReset = true;
		this.mActive = true;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00013389 File Offset: 0x00011589
	private void OnDisable()
	{
		this.Finish();
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00013394 File Offset: 0x00011594
	private void Update()
	{
		if (!this.mActive)
		{
			return;
		}
		if (this.mReset)
		{
			this.mCurrentOffset = 0;
			this.mReset = false;
			this.mLabel = base.GetComponent<UILabel>();
			this.mFullText = this.mLabel.processedText;
			this.mFade.Clear();
			if (this.keepFullDimensions && this.scrollView != null)
			{
				this.scrollView.UpdatePosition();
			}
		}
		if (string.IsNullOrEmpty(this.mFullText))
		{
			return;
		}
		int length = this.mFullText.Length;
		while (this.mCurrentOffset < length && this.mNextChar <= RealTime.time)
		{
			int num = this.mCurrentOffset;
			this.charsPerSecond = Mathf.Max(1, this.charsPerSecond);
			if (this.mLabel.supportEncoding)
			{
				while (NGUIText.ParseSymbol(this.mFullText, ref this.mCurrentOffset))
				{
				}
			}
			this.mCurrentOffset++;
			if (this.mCurrentOffset > length)
			{
				break;
			}
			float num2 = 1f / (float)this.charsPerSecond;
			char c = (num < length) ? this.mFullText[num] : '\n';
			if (c == '\n')
			{
				num2 += this.delayOnNewLine;
			}
			else if (num + 1 == length || this.mFullText[num + 1] <= ' ')
			{
				if (c == '.')
				{
					if (num + 2 < length && this.mFullText[num + 1] == '.' && this.mFullText[num + 2] == '.')
					{
						num2 += this.delayOnPeriod * 3f;
						num += 2;
					}
					else
					{
						num2 += this.delayOnPeriod;
					}
				}
				else if (c == '!' || c == '?')
				{
					num2 += this.delayOnPeriod;
				}
			}
			if (this.mNextChar == 0f)
			{
				this.mNextChar = RealTime.time + num2;
			}
			else
			{
				this.mNextChar += num2;
			}
			if (this.fadeInTime != 0f)
			{
				TypewriterEffect.FadeEntry item = default(TypewriterEffect.FadeEntry);
				item.index = num;
				item.alpha = 0f;
				item.text = this.mFullText.Substring(num, this.mCurrentOffset - num);
				this.mFade.Add(item);
			}
			else
			{
				this.mLabel.text = (this.keepFullDimensions ? (this.mFullText.Substring(0, this.mCurrentOffset) + "[00]" + this.mFullText.Substring(this.mCurrentOffset)) : this.mFullText.Substring(0, this.mCurrentOffset));
				if (!this.keepFullDimensions && this.scrollView != null)
				{
					this.scrollView.UpdatePosition();
				}
			}
		}
		if (this.mCurrentOffset >= length && this.mFade.size == 0)
		{
			this.mLabel.text = this.mFullText;
			TypewriterEffect.current = this;
			EventDelegate.Execute(this.onFinished);
			TypewriterEffect.current = null;
			this.mActive = false;
			return;
		}
		if (this.mFade.size != 0)
		{
			int i = 0;
			while (i < this.mFade.size)
			{
				TypewriterEffect.FadeEntry fadeEntry = this.mFade.buffer[i];
				fadeEntry.alpha += RealTime.deltaTime / this.fadeInTime;
				if (fadeEntry.alpha < 1f)
				{
					this.mFade.buffer[i] = fadeEntry;
					i++;
				}
				else
				{
					this.mFade.RemoveAt(i);
				}
			}
			if (this.mFade.size == 0)
			{
				if (this.keepFullDimensions)
				{
					this.mLabel.text = this.mFullText.Substring(0, this.mCurrentOffset) + "[00]" + this.mFullText.Substring(this.mCurrentOffset);
					return;
				}
				this.mLabel.text = this.mFullText.Substring(0, this.mCurrentOffset);
				return;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < this.mFade.size; j++)
				{
					TypewriterEffect.FadeEntry fadeEntry2 = this.mFade.buffer[j];
					if (j == 0)
					{
						stringBuilder.Append(this.mFullText.Substring(0, fadeEntry2.index));
					}
					stringBuilder.Append('[');
					stringBuilder.Append(NGUIText.EncodeAlpha(fadeEntry2.alpha));
					stringBuilder.Append(']');
					stringBuilder.Append(fadeEntry2.text);
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

	// Token: 0x040002CC RID: 716
	public static TypewriterEffect current;

	// Token: 0x040002CD RID: 717
	public int charsPerSecond = 20;

	// Token: 0x040002CE RID: 718
	public float fadeInTime;

	// Token: 0x040002CF RID: 719
	public float delayOnPeriod;

	// Token: 0x040002D0 RID: 720
	public float delayOnNewLine;

	// Token: 0x040002D1 RID: 721
	public UIScrollView scrollView;

	// Token: 0x040002D2 RID: 722
	public bool keepFullDimensions;

	// Token: 0x040002D3 RID: 723
	public List<EventDelegate> onFinished = new List<EventDelegate>();

	// Token: 0x040002D4 RID: 724
	public UILabel mLabel;

	// Token: 0x040002D5 RID: 725
	public string mFullText = "";

	// Token: 0x040002D6 RID: 726
	public int mCurrentOffset;

	// Token: 0x040002D7 RID: 727
	private float mNextChar;

	// Token: 0x040002D8 RID: 728
	private bool mReset = true;

	// Token: 0x040002D9 RID: 729
	public bool mActive;

	// Token: 0x040002DA RID: 730
	public bool delayOnComma;

	// Token: 0x040002DB RID: 731
	private BetterList<TypewriterEffect.FadeEntry> mFade = new BetterList<TypewriterEffect.FadeEntry>();

	// Token: 0x020005C4 RID: 1476
	private struct FadeEntry
	{
		// Token: 0x04004CF6 RID: 19702
		public int index;

		// Token: 0x04004CF7 RID: 19703
		public string text;

		// Token: 0x04004CF8 RID: 19704
		public float alpha;
	}
}
