using UnityEngine;

public class CensorBloodScript : MonoBehaviour
{
	public ParticleSystem MyParticles;

	public Texture Flower;

	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			ParticleSystem.MainModule main = MyParticles.main;
			main.startColor = new Color(1f, 1f, 1f, 1f);
			ParticleSystem.ColorOverLifetimeModule colorOverLifetime = MyParticles.colorOverLifetime;
			colorOverLifetime.enabled = false;
			MyParticles.GetComponent<Renderer>().material.mainTexture = Flower;
		}
	}
}
