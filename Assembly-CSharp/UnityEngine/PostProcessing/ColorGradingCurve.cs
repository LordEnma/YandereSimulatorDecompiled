using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000587 RID: 1415
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023F4 RID: 9204 RVA: 0x001FD540 File Offset: 0x001FB740
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x001FD56C File Offset: 0x001FB76C
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

		// Token: 0x060023F6 RID: 9206 RVA: 0x001FD61C File Offset: 0x001FB81C
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

		// Token: 0x04004C4E RID: 19534
		public AnimationCurve curve;

		// Token: 0x04004C4F RID: 19535
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004C50 RID: 19536
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004C51 RID: 19537
		[SerializeField]
		private float m_Range;

		// Token: 0x04004C52 RID: 19538
		private AnimationCurve m_InternalLoopingCurve;
	}
}
