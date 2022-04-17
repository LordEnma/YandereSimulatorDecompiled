using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200008E RID: 142
public class TweenLetters : UITweener
{
	// Token: 0x06000591 RID: 1425 RVA: 0x000348FA File Offset: 0x00032AFA
	private void OnEnable()
	{
		this.mVertexCount = -1;
		UILabel uilabel = this.mLabel;
		uilabel.onPostFill = (UIWidget.OnPostFillCallback)Delegate.Combine(uilabel.onPostFill, new UIWidget.OnPostFillCallback(this.OnPostFill));
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x0003492A File Offset: 0x00032B2A
	private void OnDisable()
	{
		UILabel uilabel = this.mLabel;
		uilabel.onPostFill = (UIWidget.OnPostFillCallback)Delegate.Remove(uilabel.onPostFill, new UIWidget.OnPostFillCallback(this.OnPostFill));
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x00034953 File Offset: 0x00032B53
	private void Awake()
	{
		this.mLabel = base.GetComponent<UILabel>();
		this.mCurrent = this.hoverOver;
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x0003496D File Offset: 0x00032B6D
	public override void Play(bool forward)
	{
		this.mCurrent = (forward ? this.hoverOver : this.hoverOut);
		base.Play(forward);
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00034990 File Offset: 0x00032B90
	private void OnPostFill(UIWidget widget, int bufferOffset, List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		if (verts == null)
		{
			return;
		}
		int count = verts.Count;
		if (verts == null || count == 0)
		{
			return;
		}
		if (this.mLabel == null)
		{
			return;
		}
		try
		{
			int quadsPerCharacter = this.mLabel.quadsPerCharacter;
			int num = count / quadsPerCharacter / 4;
			string printedText = this.mLabel.printedText;
			if (this.mVertexCount != count)
			{
				this.mVertexCount = count;
				this.SetLetterOrder(num);
				this.GetLetterDuration(num);
			}
			Matrix4x4 identity = Matrix4x4.identity;
			Vector3 pos = Vector3.zero;
			Quaternion q = Quaternion.identity;
			Vector3 s = Vector3.one;
			Vector3 b = Vector3.zero;
			Quaternion a = Quaternion.Euler(this.mCurrent.rot);
			Vector3 vector = Vector3.zero;
			Color value = Color.clear;
			float num2 = base.tweenFactor * this.duration;
			for (int i = 0; i < quadsPerCharacter; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int num3 = this.mLetterOrder[j];
					int num4 = i * num * 4 + num3 * 4;
					if (num4 < count)
					{
						float start = this.mLetter[num3].start;
						float num5 = Mathf.Clamp(num2 - start, 0f, this.mLetter[num3].duration) / this.mLetter[num3].duration;
						num5 = this.animationCurve.Evaluate(num5);
						b = TweenLetters.GetCenter(verts, num4, 4);
						Vector2 offset = this.mLetter[num3].offset;
						pos = Vector3.LerpUnclamped(this.mCurrent.pos + new Vector3(offset.x, offset.y, 0f), Vector3.zero, num5);
						q = Quaternion.SlerpUnclamped(a, Quaternion.identity, num5);
						s = Vector3.LerpUnclamped(this.mCurrent.scale, Vector3.one, num5);
						float num6 = Mathf.LerpUnclamped(this.mCurrent.alpha, 1f, num5);
						identity.SetTRS(pos, q, s);
						for (int k = num4; k < num4 + 4; k++)
						{
							vector = verts[k];
							vector -= b;
							vector = identity.MultiplyPoint3x4(vector);
							vector += b;
							verts[k] = vector;
							value = cols[k];
							value.a *= num6;
							cols[k] = value;
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

	// Token: 0x06000596 RID: 1430 RVA: 0x00034C20 File Offset: 0x00032E20
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.mLabel.MarkAsChanged();
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x00034C30 File Offset: 0x00032E30
	private void SetLetterOrder(int letterCount)
	{
		if (letterCount == 0)
		{
			this.mLetter = null;
			this.mLetterOrder = null;
			return;
		}
		this.mLetterOrder = new int[letterCount];
		this.mLetter = new TweenLetters.LetterProperties[letterCount];
		for (int i = 0; i < letterCount; i++)
		{
			this.mLetterOrder[i] = ((this.mCurrent.animationOrder == TweenLetters.AnimationLetterOrder.Reverse) ? (letterCount - 1 - i) : i);
			int num = this.mLetterOrder[i];
			this.mLetter[num] = new TweenLetters.LetterProperties();
			this.mLetter[num].offset = new Vector2(UnityEngine.Random.Range(-this.mCurrent.offsetRange.x, this.mCurrent.offsetRange.x), UnityEngine.Random.Range(-this.mCurrent.offsetRange.y, this.mCurrent.offsetRange.y));
		}
		if (this.mCurrent.animationOrder == TweenLetters.AnimationLetterOrder.Random)
		{
			System.Random random = new System.Random();
			int j = letterCount;
			while (j > 1)
			{
				int num2 = random.Next(--j + 1);
				int num3 = this.mLetterOrder[num2];
				this.mLetterOrder[num2] = this.mLetterOrder[j];
				this.mLetterOrder[j] = num3;
			}
		}
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x00034D5C File Offset: 0x00032F5C
	private void GetLetterDuration(int letterCount)
	{
		if (this.mCurrent.randomDurations)
		{
			for (int i = 0; i < this.mLetter.Length; i++)
			{
				this.mLetter[i].start = UnityEngine.Random.Range(0f, this.mCurrent.randomness.x * this.duration);
				float num = UnityEngine.Random.Range(this.mCurrent.randomness.y * this.duration, this.duration);
				this.mLetter[i].duration = num - this.mLetter[i].start;
			}
			return;
		}
		float num2 = this.duration / (float)letterCount;
		float num3 = 1f - this.mCurrent.overlap;
		float num4 = num2 * (float)letterCount * num3;
		float duration = this.ScaleRange(num2, num4 + num2 * this.mCurrent.overlap, this.duration);
		float num5 = 0f;
		for (int j = 0; j < this.mLetter.Length; j++)
		{
			int num6 = this.mLetterOrder[j];
			this.mLetter[num6].start = num5;
			this.mLetter[num6].duration = duration;
			num5 += this.mLetter[num6].duration * num3;
		}
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00034E9B File Offset: 0x0003309B
	private float ScaleRange(float value, float baseMax, float limitMax)
	{
		return limitMax * value / baseMax;
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x00034EA4 File Offset: 0x000330A4
	private static Vector3 GetCenter(List<Vector3> verts, int firstVert, int length)
	{
		Vector3 a = verts[firstVert];
		for (int i = firstVert + 1; i < firstVert + length; i++)
		{
			a += verts[i];
		}
		return a / (float)length;
	}

	// Token: 0x040005CA RID: 1482
	public TweenLetters.AnimationProperties hoverOver;

	// Token: 0x040005CB RID: 1483
	public TweenLetters.AnimationProperties hoverOut;

	// Token: 0x040005CC RID: 1484
	private UILabel mLabel;

	// Token: 0x040005CD RID: 1485
	private int mVertexCount = -1;

	// Token: 0x040005CE RID: 1486
	private int[] mLetterOrder;

	// Token: 0x040005CF RID: 1487
	private TweenLetters.LetterProperties[] mLetter;

	// Token: 0x040005D0 RID: 1488
	private TweenLetters.AnimationProperties mCurrent;

	// Token: 0x02000612 RID: 1554
	[DoNotObfuscateNGUI]
	public enum AnimationLetterOrder
	{
		// Token: 0x04004EAA RID: 20138
		Forward,
		// Token: 0x04004EAB RID: 20139
		Reverse,
		// Token: 0x04004EAC RID: 20140
		Random
	}

	// Token: 0x02000613 RID: 1555
	private class LetterProperties
	{
		// Token: 0x04004EAD RID: 20141
		public float start;

		// Token: 0x04004EAE RID: 20142
		public float duration;

		// Token: 0x04004EAF RID: 20143
		public Vector2 offset;
	}

	// Token: 0x02000614 RID: 1556
	[Serializable]
	public class AnimationProperties
	{
		// Token: 0x04004EB0 RID: 20144
		public TweenLetters.AnimationLetterOrder animationOrder = TweenLetters.AnimationLetterOrder.Random;

		// Token: 0x04004EB1 RID: 20145
		[Range(0f, 1f)]
		public float overlap = 0.5f;

		// Token: 0x04004EB2 RID: 20146
		public bool randomDurations;

		// Token: 0x04004EB3 RID: 20147
		[MinMaxRange(0f, 1f)]
		public Vector2 randomness = new Vector2(0.25f, 0.75f);

		// Token: 0x04004EB4 RID: 20148
		public Vector2 offsetRange = Vector2.zero;

		// Token: 0x04004EB5 RID: 20149
		public Vector3 pos = Vector3.zero;

		// Token: 0x04004EB6 RID: 20150
		public Vector3 rot = Vector3.zero;

		// Token: 0x04004EB7 RID: 20151
		public Vector3 scale = Vector3.one;

		// Token: 0x04004EB8 RID: 20152
		public float alpha = 1f;
	}
}
