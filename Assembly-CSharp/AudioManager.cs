using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Self;

	public GameObject AudioSourceObject;

	private void Start()
	{
		if (!AudioGlobals.VolumeInitialized)
		{
			AudioGlobals.EffectVolume = 1f;
			AudioGlobals.MusicVolume = 1f;
			AudioGlobals.VoiceVolume = 1f;
		}
		if (Self != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		Self = this;
	}

	public void Update()
	{
		if (Self == null)
		{
			Self = this;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	public void Test()
	{
		Debug.Log("[X-TEMP] This is a test");
	}

	public static void PlayAudio(AudioType DesiredAudioType, AudioClip DesiredClip, float DesiredPitch)
	{
		Debug.Log("Spawning a sound effect using the AudioManager!");
		AudioSourceScript component = Object.Instantiate(Self.AudioSourceObject).GetComponent<AudioSourceScript>();
		component.MyAudioType = DesiredAudioType;
		component.MyClip = DesiredClip;
		component.Pitch = DesiredPitch;
	}
}
