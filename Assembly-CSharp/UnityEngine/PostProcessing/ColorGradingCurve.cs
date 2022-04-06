using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000585 RID: 1413
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023D9 RID: 9177 RVA: 0x001F9F0C File Offset: 0x001F810C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x001F9F38 File Offset: 0x001F8138
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

		// Token: 0x060023DB RID: 9179 RVA: 0x001F9FE8 File Offset: 0x001F81E8
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

		// Token: 0x04004BFF RID: 19455
		public AnimationCurve curve;

		// Token: 0x04004C00 RID: 19456
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004C01 RID: 19457
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004C02 RID: 19458
		[SerializeField]
		private float m_Range;

		// Token: 0x04004C03 RID: 19459
		private AnimationCurve m_InternalLoopingCurve;
	}
}
