using UnityEngine;

public class CheerScript : MonoBehaviour
{
	public StudentScript Student;

	public AudioSource MyAudio;

	public AudioClip[] Cheers;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 5f)
		{
			MyAudio.clip = Cheers[Random.Range(1, Cheers.Length)];
			MyAudio.Play();
			Timer = 0f;
		}
	}
}
