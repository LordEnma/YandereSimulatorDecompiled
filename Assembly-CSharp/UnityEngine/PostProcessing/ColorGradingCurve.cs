using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023A9 RID: 9129 RVA: 0x001F6204 File Offset: 0x001F4404
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023AA RID: 9130 RVA: 0x001F6230 File Offset: 0x001F4430
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

		// Token: 0x060023AB RID: 9131 RVA: 0x001F62E0 File Offset: 0x001F44E0
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

		// Token: 0x04004B6A RID: 19306
		public AnimationCurve curve;

		// Token: 0x04004B6B RID: 19307
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B6C RID: 19308
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B6D RID: 19309
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B6E RID: 19310
		private AnimationCurve m_InternalLoopingCurve;
	}
}
