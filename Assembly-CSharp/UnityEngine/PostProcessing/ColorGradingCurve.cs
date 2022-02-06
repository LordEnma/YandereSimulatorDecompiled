using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x06002393 RID: 9107 RVA: 0x001F4798 File Offset: 0x001F2998
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x06002394 RID: 9108 RVA: 0x001F47C4 File Offset: 0x001F29C4
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

		// Token: 0x06002395 RID: 9109 RVA: 0x001F4874 File Offset: 0x001F2A74
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

		// Token: 0x04004B34 RID: 19252
		public AnimationCurve curve;

		// Token: 0x04004B35 RID: 19253
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B36 RID: 19254
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B37 RID: 19255
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B38 RID: 19256
		private AnimationCurve m_InternalLoopingCurve;
	}
}
