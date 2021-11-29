using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x06002369 RID: 9065 RVA: 0x001F0648 File Offset: 0x001EE848
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x0600236A RID: 9066 RVA: 0x001F0674 File Offset: 0x001EE874
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

		// Token: 0x0600236B RID: 9067 RVA: 0x001F0724 File Offset: 0x001EE924
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

		// Token: 0x04004ABD RID: 19133
		public AnimationCurve curve;

		// Token: 0x04004ABE RID: 19134
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004ABF RID: 19135
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004AC0 RID: 19136
		[SerializeField]
		private float m_Range;

		// Token: 0x04004AC1 RID: 19137
		private AnimationCurve m_InternalLoopingCurve;
	}
}
