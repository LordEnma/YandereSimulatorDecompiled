using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(UILabel))]
[AddComponentMenu("NGUI/Interaction/Typewriter Effect")]
public class TypewriterEffect : MonoBehaviour
{
	private struct FadeEntry
	{
		public int index;

		public string text;

		public float alpha;
	}

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

	private BetterList<FadeEntry> mFade = new BetterList<FadeEntry>();

	public bool isActive
	{
		get
		{
			return mActive;
		}
	}

	public void ResetToBeginning()
	{
		Finish();
		mReset = true;
		mActive = true;
		mNextChar = 0f;
		mCurrentOffset = 0;
		Update();
	}

	public void Finish()
	{
		if (mActive)
		{
			mActive = false;
			if (!mReset)
			{
				mCurrentOffset = mFullText.Length;
				mFade.Clear();
				mLabel.text = mFullText;
			}
			if (keepFullDimensions && scrollView != null)
			{
				scrollView.UpdatePosition();
			}
			current = this;
			EventDelegate.Execute(onFinished);
			current = null;
		}
	}

	private void OnEnable()
	{
		mReset = true;
		mActive = true;
	}

	private void OnDisable()
	{
		Finish();
	}

	private void Update()
	{
		if (!mActive)
		{
			return;
		}
		if (mReset)
		{
			mCurrentOffset = 0;
			mReset = false;
			mLabel = GetComponent<UILabel>();
			mFullText = mLabel.processedText;
			mFade.Clear();
			if (keepFullDimensions && scrollView != null)
			{
				scrollView.UpdatePosition();
			}
		}
		if (string.IsNullOrEmpty(mFullText))
		{
			return;
		}
		int length = mFullText.Length;
		while (mCurrentOffset < length && mNextChar <= RealTime.time)
		{
			int num = mCurrentOffset;
			charsPerSecond = Mathf.Max(1, charsPerSecond);
			if (mLabel.supportEncoding)
			{
				while (NGUIText.ParseSymbol(mFullText, ref mCurrentOffset))
				{
				}
			}
			mCurrentOffset++;
			if (mCurrentOffset > length)
			{
				break;
			}
			float num2 = 1f / (float)charsPerSecond;
			char c = ((num < length) ? mFullText[num] : '\n');
			if (c == '\n')
			{
				num2 += delayOnNewLine;
			}
			else if (num + 1 == length || mFullText[num + 1] <= ' ')
			{
				switch (c)
				{
				case '.':
					if (num + 2 < length && mFullText[num + 1] == '.' && mFullText[num + 2] == '.')
					{
						num2 += delayOnPeriod * 3f;
						num += 2;
					}
					else
					{
						num2 += delayOnPeriod;
					}
					break;
				case '!':
				case '?':
					num2 += delayOnPeriod;
					break;
				}
			}
			if (mNextChar == 0f)
			{
				mNextChar = RealTime.time + num2;
			}
			else
			{
				mNextChar += num2;
			}
			if (fadeInTime != 0f)
			{
				FadeEntry item = default(FadeEntry);
				item.index = num;
				item.alpha = 0f;
				item.text = mFullText.Substring(num, mCurrentOffset - num);
				mFade.Add(item);
			}
			else
			{
				mLabel.text = (keepFullDimensions ? (mFullText.Substring(0, mCurrentOffset) + "[00]" + mFullText.Substring(mCurrentOffset)) : mFullText.Substring(0, mCurrentOffset));
				if (!keepFullDimensions && scrollView != null)
				{
					scrollView.UpdatePosition();
				}
			}
		}
		if (mCurrentOffset >= length && mFade.size == 0)
		{
			mLabel.text = mFullText;
			current = this;
			EventDelegate.Execute(onFinished);
			current = null;
			mActive = false;
		}
		else
		{
			if (mFade.size == 0)
			{
				return;
			}
			int num3 = 0;
			while (num3 < mFade.size)
			{
				FadeEntry fadeEntry = mFade.buffer[num3];
				fadeEntry.alpha += RealTime.deltaTime / fadeInTime;
				if (fadeEntry.alpha < 1f)
				{
					mFade.buffer[num3] = fadeEntry;
					num3++;
				}
				else
				{
					mFade.RemoveAt(num3);
				}
			}
			if (mFade.size == 0)
			{
				if (keepFullDimensions)
				{
					mLabel.text = mFullText.Substring(0, mCurrentOffset) + "[00]" + mFullText.Substring(mCurrentOffset);
				}
				else
				{
					mLabel.text = mFullText.Substring(0, mCurrentOffset);
				}
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < mFade.size; i++)
			{
				FadeEntry fadeEntry2 = mFade.buffer[i];
				if (i == 0)
				{
					stringBuilder.Append(mFullText.Substring(0, fadeEntry2.index));
				}
				stringBuilder.Append('[');
				stringBuilder.Append(NGUIText.EncodeAlpha(fadeEntry2.alpha));
				stringBuilder.Append(']');
				stringBuilder.Append(fadeEntry2.text);
			}
			if (keepFullDimensions)
			{
				stringBuilder.Append("[00]");
				stringBuilder.Append(mFullText.Substring(mCurrentOffset));
			}
			mLabel.text = stringBuilder.ToString();
		}
	}
}
