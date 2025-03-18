using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ParticleSystemMultiplier : MonoBehaviour
	{
		public float multiplier = 1f;

		private void Start()
		{
			ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
			foreach (ParticleSystem obj in componentsInChildren)
			{
				ParticleSystem.MainModule main = obj.main;
				main.startSizeMultiplier *= multiplier;
				main.startSpeedMultiplier *= multiplier;
				main.startLifetimeMultiplier *= Mathf.Lerp(multiplier, 1f, 0.5f);
				obj.Clear();
				obj.Play();
			}
		}
	}
}
