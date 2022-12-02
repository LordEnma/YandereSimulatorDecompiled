using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour
{
	public float Strength1;

	public float Strength2;

	public float TimeLimit;

	public float Timer;

	private void Start()
	{
		GamePad.SetVibration(PlayerIndex.One, Strength1, Strength2);
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > TimeLimit)
		{
			GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
			base.enabled = false;
		}
	}
}
