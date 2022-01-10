using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x06002388 RID: 9096 RVA: 0x001F2D0C File Offset: 0x001F0F0C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x06002389 RID: 9097 RVA: 0x001F2D38 File Offset: 0x001F0F38
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

		// Token: 0x0600238A RID: 9098 RVA: 0x001F2DE8 File Offset: 0x001F0FE8
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

		// Token: 0x04004B19 RID: 19225
		public AnimationCurve curve;

		// Token: 0x04004B1A RID: 19226
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B1B RID: 19227
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B1C RID: 19228
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B1D RID: 19229
		private AnimationCurve m_InternalLoopingCurve;
	}
}
