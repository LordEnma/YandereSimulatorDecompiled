using UnityEngine;

public class KnifeEdgeScript : MonoBehaviour
{
	public AudioSource MyAudioSource;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Timer < 18f)
		{
			MyAudioSource.pitch = Random.Range(0.95f, 1.05f);
			MyAudioSource.Play();
		}
	}
}
