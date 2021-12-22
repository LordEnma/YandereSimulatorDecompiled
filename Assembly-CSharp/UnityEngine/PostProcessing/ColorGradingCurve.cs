using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x0600237A RID: 9082 RVA: 0x001F1D7C File Offset: 0x001EFF7C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x001F1DA8 File Offset: 0x001EFFA8
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

		// Token: 0x0600237C RID: 9084 RVA: 0x001F1E58 File Offset: 0x001F0058
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

		// Token: 0x04004AFC RID: 19196
		public AnimationCurve curve;

		// Token: 0x04004AFD RID: 19197
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004AFE RID: 19198
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004AFF RID: 19199
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B00 RID: 19200
		private AnimationCurve m_InternalLoopingCurve;
	}
}
