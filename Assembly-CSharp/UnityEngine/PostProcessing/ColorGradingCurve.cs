using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000586 RID: 1414
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023E9 RID: 9193 RVA: 0x001FBDF4 File Offset: 0x001F9FF4
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x001FBE20 File Offset: 0x001FA020
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

		// Token: 0x060023EB RID: 9195 RVA: 0x001FBED0 File Offset: 0x001FA0D0
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

		// Token: 0x04004C27 RID: 19495
		public AnimationCurve curve;

		// Token: 0x04004C28 RID: 19496
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004C29 RID: 19497
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004C2A RID: 19498
		[SerializeField]
		private float m_Range;

		// Token: 0x04004C2B RID: 19499
		private AnimationCurve m_InternalLoopingCurve;
	}
}
