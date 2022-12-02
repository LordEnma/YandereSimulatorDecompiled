using System;

namespace UnityEngine.PostProcessing
{
	[Serializable]
	public sealed class ColorGradingCurve
	{
		public AnimationCurve curve;

		[SerializeField]
		private bool m_Loop;

		[SerializeField]
		private float m_ZeroValue;

		[SerializeField]
		private float m_Range;

		private AnimationCurve m_InternalLoopingCurve;

		public ColorGradingCurve(AnimationCurve curve, float zeroValue, bool loop, Vector2 bounds)
		{
			this.curve = curve;
			m_ZeroValue = zeroValue;
			m_Loop = loop;
			m_Range = bounds.magnitude;
		}

		public void Cache()
		{
			if (!m_Loop)
			{
				return;
			}
			int length = curve.length;
			if (length >= 2)
			{
				if (m_InternalLoopingCurve == null)
				{
					m_InternalLoopingCurve = new AnimationCurve();
				}
				Keyframe key = curve[length - 1];
				key.time -= m_Range;
				Keyframe key2 = curve[0];
				key2.time += m_Range;
				m_InternalLoopingCurve.keys = curve.keys;
				m_InternalLoopingCurve.AddKey(key);
				m_InternalLoopingCurve.AddKey(key2);
			}
		}

		public float Evaluate(float t)
		{
			if (curve.length == 0)
			{
				return m_ZeroValue;
			}
			if (!m_Loop || curve.length == 1)
			{
				return curve.Evaluate(t);
			}
			return m_InternalLoopingCurve.Evaluate(t);
		}
	}
}
