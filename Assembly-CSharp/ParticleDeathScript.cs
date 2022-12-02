using UnityEngine;

public class ParticleDeathScript : MonoBehaviour
{
	public ParticleSystem Particles;

	private void LateUpdate()
	{
		if (Particles.isPlaying && Particles.particleCount == 0)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
