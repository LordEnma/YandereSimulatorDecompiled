using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour
{
	public ParticleSystem Particles;

	public float Strength1;

	public float Strength2;

	public float TimeLimit;

	public float Timer;

	private void Start()
	{
		if (Particles == null)
		{
			GamePad.SetVibration(PlayerIndex.One, Strength1, Strength2);
		}
	}

	private void Update()
	{
		if (Particles == null)
		{
			Timer += Time.deltaTime;
			if (Timer > TimeLimit)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				base.enabled = false;
			}
			return;
		}
		if (Particles.isPlaying)
		{
			Timer = 0f;
		}
		if (Timer < TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			Timer += Time.deltaTime;
		}
	}
}
