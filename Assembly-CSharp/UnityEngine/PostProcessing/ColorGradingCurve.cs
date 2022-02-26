using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023A3 RID: 9123 RVA: 0x001F582C File Offset: 0x001F3A2C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023A4 RID: 9124 RVA: 0x001F5858 File Offset: 0x001F3A58
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

		// Token: 0x060023A5 RID: 9125 RVA: 0x001F5908 File Offset: 0x001F3B08
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

		// Token: 0x04004B4D RID: 19277
		public AnimationCurve curve;

		// Token: 0x04004B4E RID: 19278
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B4F RID: 19279
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B50 RID: 19280
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B51 RID: 19281
		private AnimationCurve m_InternalLoopingCurve;
	}
}
