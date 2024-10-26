using UnityEngine;

public class HeartBeatEffects : MonoBehaviour
{
	public float CurrentHeartSpeed;

	private Animator anim;

	public AudioSource ObjSourceHeatbeat1;

	public AudioSource ObjSourceHeatbeat2;

	public AudioClip HeartBeat1;

	public AudioClip HeartBeat2;

	private void PlayHeatbeat1()
	{
		ObjSourceHeatbeat1.PlayOneShot(HeartBeat1);
	}

	private void PlayHeatbeat2()
	{
		ObjSourceHeatbeat2.PlayOneShot(HeartBeat2);
	}

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		anim.speed = CurrentHeartSpeed;
	}

	public void SpeedupHeartBeat()
	{
		if (CurrentHeartSpeed == 1f)
		{
			CurrentHeartSpeed = 1.9f;
		}
		else
		{
			CurrentHeartSpeed = 1f;
		}
	}
}
