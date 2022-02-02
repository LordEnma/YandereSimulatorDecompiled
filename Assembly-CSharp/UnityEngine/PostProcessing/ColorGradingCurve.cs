using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x0600238E RID: 9102 RVA: 0x001F427C File Offset: 0x001F247C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x001F42A8 File Offset: 0x001F24A8
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

		// Token: 0x06002390 RID: 9104 RVA: 0x001F4358 File Offset: 0x001F2558
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

		// Token: 0x04004B2B RID: 19243
		public AnimationCurve curve;

		// Token: 0x04004B2C RID: 19244
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B2D RID: 19245
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B2E RID: 19246
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B2F RID: 19247
		private AnimationCurve m_InternalLoopingCurve;
	}
}
