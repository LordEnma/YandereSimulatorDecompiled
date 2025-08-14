using System.Collections.Generic;
using UnityEngine;

public class WaterDrippingSFX : MonoBehaviour
{
	public ParticleSystem particleSystem;

	public AudioSource audioSource;

	[Header("Pitch Range")]
	[Tooltip("Pitch mínimo para o som aleatório.")]
	public float minPitch = 0.9f;

	[Tooltip("Pitch máximo para o som aleatório.")]
	public float maxPitch = 1.1f;

	private void OnParticleTrigger()
	{
		Debug.Log("Trigger event received.");
		if (!(particleSystem == null) && !(audioSource == null))
		{
			List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();
			if (particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles) > 0 && !audioSource.isPlaying)
			{
				float num = Mathf.Round(Random.Range(minPitch, maxPitch) * 100f) / 100f;
				audioSource.pitch = num;
				Debug.Log($"Playing dripping SFX. Selected pitch: {num:F2}");
				audioSource.Play();
			}
		}
	}
}
