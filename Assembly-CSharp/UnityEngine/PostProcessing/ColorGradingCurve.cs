using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057F RID: 1407
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023C1 RID: 9153 RVA: 0x001F816C File Offset: 0x001F636C
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x001F8198 File Offset: 0x001F6398
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

		// Token: 0x060023C3 RID: 9155 RVA: 0x001F8248 File Offset: 0x001F6448
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

		// Token: 0x04004BC9 RID: 19401
		public AnimationCurve curve;

		// Token: 0x04004BCA RID: 19402
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004BCB RID: 19403
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004BCC RID: 19404
		[SerializeField]
		private float m_Range;

		// Token: 0x04004BCD RID: 19405
		private AnimationCurve m_InternalLoopingCurve;
	}
}
