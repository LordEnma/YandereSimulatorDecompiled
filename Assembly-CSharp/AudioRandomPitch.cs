using System.Threading;
using UnityEngine;

public class AudioRandomPitch : MonoBehaviour
{
	private AudioSource ObjAudioSource;

	public int Sleeptime;

	private void Start()
	{
		ObjAudioSource = GetComponent<AudioSource>();
	}

	private void AudioPlay()
	{
		ObjAudioSource.Play();
		Thread.Sleep(Sleeptime);
		ObjAudioSource.pitch = Random.Range(1f, 1.5f);
	}

	private void Update()
	{
	}
}
