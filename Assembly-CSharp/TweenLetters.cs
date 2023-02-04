using System;
using System.Collections.Generic;
using UnityEngine;

public class TweenLetters : UITweener
{
	[DoNotObfuscateNGUI]
	public enum AnimationLetterOrder
	{
		Forward = 0,
		Reverse = 1,
		Random = 2
	}

	private class LetterProperties
	{
		public float start;

		public float duration;

		public Vector2 offset;
	}

	[Serializable]
	public class AnimationProperties
	{
		public AnimationLetterOrder animationOrder = AnimationLetterOrder.Random;

		[Range(0f, 1f)]
		public float overlap = 0.5f;

		public bool randomDurations;

		[MinMaxRange(0f, 1f)]
		public Vector2 randomness = new Vector2(0.25f, 0.75f);

		public Vector2 offsetRange = Vector2.zero;

		public Vector3 pos = Vector3.zero;

		public Vector3 rot = Vector3.zero;

		public Vector3 scale = Vector3.one;

		public float alpha = 1f;
	}

	public AnimationProperties hoverOver;

	public AnimationProperties hoverOut;

	private UILabel mLabel;

	private int mVertexCount = -1;

	private int[] mLetterOrder;

	private LetterProperties[] mLetter;

	private AnimationProperties mCurrent;

	private void OnEnable()
	{
		mVertexCount = -1;
		UILabel uILabel = mLabel;
		uILabel.onPostFill = (UIWidget.OnPostFillCallback)Delegate.Combine(uILabel.onPostFill, new UIWidget.OnPostFillCallback(OnPostFill));
	}

	private void OnDisable()
	{
		UILabel uILabel = mLabel;
		uILabel.onPostFill = (UIWidget.OnPostFillCallback)Delegate.Remove(uILabel.onPostFill, new UIWidget.OnPostFillCallback(OnPostFill));
	}

	private void Awake()
	{
		mLabel = GetComponent<UILabel>();
		mCurrent = hoverOver;
	}

	public override void Play(bool forward)
	{
		mCurrent = (forward ? hoverOver : hoverOut);
		base.Play(forward);
	}

	private void OnPostFill(UIWidget widget, int bufferOffset, List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		if (verts == null)
		{
			return;
		}
		int count = verts.Count;
		if (verts == null || count == 0 || mLabel == null)
		{
			return;
		}
		try
		{
			int quadsPerCharacter = mLabel.quadsPerCharacter;
			int num = count / quadsPerCharacter / 4;
			_ = mLabel.printedText;
			if (mVertexCount != count)
			{
				mVertexCount = count;
				SetLetterOrder(num);
				GetLetterDuration(num);
			}
			Matrix4x4 identity = Matrix4x4.identity;
			Vector3 zero = Vector3.zero;
			Quaternion identity2 = Quaternion.identity;
			Vector3 one = Vector3.one;
			float num2 = 1f;
			Vector3 zero2 = Vector3.zero;
			Quaternion a = Quaternion.Euler(mCurrent.rot);
			Vector3 zero3 = Vector3.zero;
			Color clear = Color.clear;
			float num3 = base.tweenFactor * duration;
			for (int i = 0; i < quadsPerCharacter; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int num4 = mLetterOrder[j];
					int num5 = i * num * 4 + num4 * 4;
					if (num5 < count)
					{
						float start = mLetter[num4].start;
						float time = Mathf.Clamp(num3 - start, 0f, mLetter[num4].duration) / mLetter[num4].duration;
						time = animationCurve.Evaluate(time);
						zero2 = GetCenter(verts, num5, 4);
						Vector2 offset = mLetter[num4].offset;
						zero = Vector3.LerpUnclamped(mCurrent.pos + new Vector3(offset.x, offset.y, 0f), Vector3.zero, time);
						identity2 = Quaternion.SlerpUnclamped(a, Quaternion.identity, time);
						one = Vector3.LerpUnclamped(mCurrent.scale, Vector3.one, time);
						num2 = Mathf.LerpUnclamped(mCurrent.alpha, 1f, time);
						identity.SetTRS(zero, identity2, one);
						for (int k = num5; k < num5 + 4; k++)
						{
							zero3 = verts[k];
							zero3 -= zero2;
							zero3 = identity.MultiplyPoint3x4(zero3);
							zero3 += zero2;
							verts[k] = zero3;
							clear = cols[k];
							clear.a *= num2;
							cols[k] = clear;
						}
					}
				}
			}
		}
		catch (Exception)
		{
			base.enabled = false;
		}
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
		mLabel.MarkAsChanged();
	}

	private void SetLetterOrder(int letterCount)
	{
		if (letterCount == 0)
		{
			mLetter = null;
			mLetterOrder = null;
			return;
		}
		mLetterOrder = new int[letterCount];
		mLetter = new LetterProperties[letterCount];
		for (int i = 0; i < letterCount; i++)
		{
			mLetterOrder[i] = ((mCurrent.animationOrder == AnimationLetterOrder.Reverse) ? (letterCount - 1 - i) : i);
			int num = mLetterOrder[i];
			mLetter[num] = new LetterProperties();
			mLetter[num].offset = new Vector2(UnityEngine.Random.Range(0f - mCurrent.offsetRange.x, mCurrent.offsetRange.x), UnityEngine.Random.Range(0f - mCurrent.offsetRange.y, mCurrent.offsetRange.y));
		}
		if (mCurrent.animationOrder == AnimationLetterOrder.Random)
		{
			System.Random random = new System.Random();
			int num2 = letterCount;
			while (num2 > 1)
			{
				int num3 = random.Next(--num2 + 1);
				int num4 = mLetterOrder[num3];
				mLetterOrder[num3] = mLetterOrder[num2];
				mLetterOrder[num2] = num4;
			}
		}
	}

	private void GetLetterDuration(int letterCount)
	{
		if (mCurrent.randomDurations)
		{
			for (int i = 0; i < mLetter.Length; i++)
			{
				mLetter[i].start = UnityEngine.Random.Range(0f, mCurrent.randomness.x * duration);
				float num = UnityEngine.Random.Range(mCurrent.randomness.y * duration, duration);
				mLetter[i].duration = num - mLetter[i].start;
			}
			return;
		}
		float num2 = duration / (float)letterCount;
		float num3 = 1f - mCurrent.overlap;
		float num4 = num2 * (float)letterCount * num3;
		float num5 = ScaleRange(num2, num4 + num2 * mCurrent.overlap, duration);
		float num6 = 0f;
		for (int j = 0; j < mLetter.Length; j++)
		{
			int num7 = mLetterOrder[j];
			mLetter[num7].start = num6;
			mLetter[num7].duration = num5;
			num6 += mLetter[num7].duration * num3;
		}
	}

	private float ScaleRange(float value, float baseMax, float limitMax)
	{
		return limitMax * value / baseMax;
	}

	private static Vector3 GetCenter(List<Vector3> verts, int firstVert, int length)
	{
		Vector3 vector = verts[firstVert];
		for (int i = firstVert + 1; i < firstVert + length; i++)
		{
			vector += verts[i];
		}
		return vector / length;
	}
}
