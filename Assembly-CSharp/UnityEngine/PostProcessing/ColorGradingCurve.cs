using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000585 RID: 1413
	[Serializable]
	public sealed class ColorGradingCurve
	{
		// Token: 0x060023E0 RID: 9184 RVA: 0x001FA968 File Offset: 0x001F8B68
		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			this.m_ZeroValue = zeroValue;
			this.m_Loop = loop;
			this.m_Range = bounds.magnitude;
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x001FA994 File Offset: 0x001F8B94
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

		// Token: 0x060023E2 RID: 9186 RVA: 0x001FAA44 File Offset: 0x001F8C44
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

		// Token: 0x04004C11 RID: 19473
		public AnimationCurve curve;

		// Token: 0x04004C12 RID: 19474
		[SerializeField]
		private bool m_Loop;

		// Token: 0x04004C13 RID: 19475
		[SerializeField]
		private float m_ZeroValue;

		// Token: 0x04004C14 RID: 19476
		[SerializeField]
		private float m_Range;

		// Token: 0x04004C15 RID: 19477
		private AnimationCurve m_InternalLoopingCurve;
	}
}
