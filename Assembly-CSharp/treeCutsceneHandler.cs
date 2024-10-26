using UnityEngine;

public class treeCutsceneHandler : MonoBehaviour
{
	public ParticleSystem WaterDropsParticles;

	public void ParticleDelay()
	{
		WaterDropsParticles = GetComponent<ParticleSystem>();
		WaterDropsParticles.Stop();
		_ = WaterDropsParticles.main;
		WaterDropsParticles.startDelay = 1f;
		WaterDropsParticles.Play();
	}
}
