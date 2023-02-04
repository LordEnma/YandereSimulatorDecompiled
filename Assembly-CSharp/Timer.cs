using System;
using UnityEngine;

[Serializable]
public class Timer
{
	[SerializeField]
	private float currentSeconds;

	[SerializeField]
	private float targetSeconds;

	public float CurrentSeconds => currentSeconds;

	public float TargetSeconds => targetSeconds;

	public bool IsDone => currentSeconds >= targetSeconds;

	public float Progress => Mathf.Clamp01(currentSeconds / targetSeconds);

	public Timer(float targetSeconds)
	{
		currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	public void Reset()
	{
		currentSeconds = 0f;
	}

	public void SubtractTarget()
	{
		currentSeconds -= targetSeconds;
	}

	public void Tick(float dt)
	{
		currentSeconds += dt;
	}
}
