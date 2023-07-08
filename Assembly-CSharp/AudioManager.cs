using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public GameObject AudioSourceObject;

	public GameObject LatestAudioSource;

	public static AudioManager Instance;

	public void Start()
	{
		Instance = this;
	}

	public void PlayAudio(AudioClip Clip, AudioType Type, Vector3 Location)
	{
		GameObject gameObject = Object.Instantiate(AudioSourceObject, Location, Quaternion.identity);
		AudioSource component = gameObject.GetComponent<AudioSource>();
		switch (Type)
		{
		case AudioType.Voice:
			component.volume = 1f;
			break;
		case AudioType.SFX:
			component.volume = 1f;
			break;
		}
		LatestAudioSource = gameObject;
	}
}
