using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023D1 RID: 9169 RVA: 0x001F99DC File Offset: 0x001F7BDC
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x001F9A08 File Offset: 0x001F7C08
		public void Cache()
		{
			if (!this.m_Loop)
			{
				return;
			}
			int length = this.curve.length;
			if (length < 2)
			{
				return;
			}
			if (this.m_InternalLoopingCurve == null)
			{
				this.m_InternalLoopingCurve = new AnimationCurve();
			}
			Keyframe key = this.curve[length - 1];
			key.time -= this.m_Range;
			Keyframe key2 = this.curve[0];
			key2.time += this.m_Range;
			this.m_InternalLoopingCurve.keys = this.curve.keys;
			this.m_InternalLoopingCurve.AddKey(key);
			this.m_InternalLoopingCurve.AddKey(key2);
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x001F9AB8 File Offset: 0x001F7CB8
		public float Evaluate(float t)
		{
			if (this.curve.length == 0)
			{
				return this.m_ZeroValue;
			}
			if (!this.m_Loop || this.curve.length == 1)
			{
				return this.curve.Evaluate(t);
			}
			return this.m_InternalLoopingCurve.Evaluate(t);
		}

		// Token: 0x04004BFB RID: 19451
		public AnimationCurve curve;

		// Token: 0x04004BFC RID: 19452
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004BFD RID: 19453
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004BFE RID: 19454
		[SerializeField]
		private float m_Range;

		// Token: 0x04004BFF RID: 19455
		private AnimationCurve m_InternalLoopingCurve;
	}
}
