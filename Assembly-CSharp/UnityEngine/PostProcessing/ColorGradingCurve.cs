using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x0600239A RID: 9114 RVA: 0x001F4C4C File Offset: 0x001F2E4C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x0600239B RID: 9115 RVA: 0x001F4C78 File Offset: 0x001F2E78
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

		// Token: 0x0600239C RID: 9116 RVA: 0x001F4D28 File Offset: 0x001F2F28
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

		// Token: 0x04004B3D RID: 19261
		public AnimationCurve curve;

		// Token: 0x04004B3E RID: 19262
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004B3F RID: 19263
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004B40 RID: 19264
		[SerializeField]
		private float m_Range;

		// Token: 0x04004B41 RID: 19265
		private AnimationCurve m_InternalLoopingCurve;
	}
}
