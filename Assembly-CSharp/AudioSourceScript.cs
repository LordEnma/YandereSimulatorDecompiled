using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
	public AudioType MyAudioType;

	public AudioSource MyAudioSource;

	public AudioClip MyClip;

	public float Offset;

	public float Pitch = 1f;

	private void Start()
	{
		switch (MyAudioType)
		{
		case AudioType.Effect:
			MyAudioSource.volume = AudioGlobals.EffectVolume;
			break;
		case AudioType.Music:
			MyAudioSource.volume = AudioGlobals.MusicVolume;
			break;
		case AudioType.Voice:
			MyAudioSource.volume = AudioGlobals.VoiceVolume;
			break;
		}
		MyAudioSource.pitch = Pitch;
		MyAudioSource.clip = MyClip;
		MyAudioSource.Play();
		MyAudioSource.time = Offset;
		if (MyClip != null)
		{
			_ = MyClip.length;
			_ = 0f;
		}
		else
		{
			Debug.Log("Uh, something went wrong. This AudioSource's clip was null?");
		}
	}

	private void Update()
	{
		MyAudioSource.pitch = Pitch * Time.timeScale;
		if (!MyAudioSource.isPlaying)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
