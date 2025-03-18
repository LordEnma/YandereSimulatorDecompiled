using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	[Serializable]
	public class LerpControlledBob
	{
		public float BobDuration;

		public float BobAmount;

		private float m_Offset;

		public float Offset()
		{
			return m_Offset;
		}

		public IEnumerator DoBobCycle()
		{
			float t = 0f;
			while (t < BobDuration)
			{
				m_Offset = Mathf.Lerp(0f, BobAmount, t / BobDuration);
				t += Time.deltaTime;
				yield return new WaitForFixedUpdate();
			}
			t = 0f;
			while (t < BobDuration)
			{
				m_Offset = Mathf.Lerp(BobAmount, 0f, t / BobDuration);
				t += Time.deltaTime;
				yield return new WaitForFixedUpdate();
			}
			m_Offset = 0f;
		}
	}
}
