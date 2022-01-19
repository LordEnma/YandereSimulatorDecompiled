using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x0600238A RID: 9098 RVA: 0x001F39DC File Offset: 0x001F1BDC
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x001F3A08 File Offset: 0x001F1C08
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

		// Token: 0x0600238C RID: 9100 RVA: 0x001F3AB8 File Offset: 0x001F1CB8
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

		// Token: 0x04004B20 RID: 19232
		public AnimationCurve curve;

		// Token: 0x04004B21 RID: 19233
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B22 RID: 19234
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B23 RID: 19235
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B24 RID: 19236
		private AnimationCurve m_InternalLoopingCurve;
	}
}
