using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000587 RID: 1415
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023F5 RID: 9205 RVA: 0x001FDAA8 File Offset: 0x001FBCA8
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001FDAD4 File Offset: 0x001FBCD4
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

		// Token: 0x060023F7 RID: 9207 RVA: 0x001FDB84 File Offset: 0x001FBD84
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

		// Token: 0x04004C57 RID: 19543
		public AnimationCurve curve;

		// Token: 0x04004C58 RID: 19544
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004C59 RID: 19545
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004C5A RID: 19546
		[SerializeField]
		private float m_Range;

		// Token: 0x04004C5B RID: 19547
		private AnimationCurve m_InternalLoopingCurve;
	}
}
