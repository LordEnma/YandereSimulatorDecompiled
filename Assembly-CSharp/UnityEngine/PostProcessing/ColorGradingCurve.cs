using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x0600237D RID: 9085 RVA: 0x001F236C File Offset: 0x001F056C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x0600237E RID: 9086 RVA: 0x001F2398 File Offset: 0x001F0598
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

		// Token: 0x0600237F RID: 9087 RVA: 0x001F2448 File Offset: 0x001F0648
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

		// Token: 0x04004B05 RID: 19205
		public AnimationCurve curve;

		// Token: 0x04004B06 RID: 19206
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B07 RID: 19207
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B08 RID: 19208
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B09 RID: 19209
		private AnimationCurve m_InternalLoopingCurve;
	}
}
