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
			AudioGlobals.MusicVolume = 0.25f;
			AudioGlobals.VoiceVolume = 1f;
			AudioGlobals.VolumeInitialized = true;
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

	public static void PlayAudio(AudioType DesiredAudioType, AudioClip DesiredClip, float DesiredPitch, Vector3 Location)
	{
		Debug.Log("Spawning a sound effect using the AudioManager!");
		GameObject obj = Object.Instantiate(Self.AudioSourceObject);
		obj.transform.position = Location;
		AudioSourceScript component = obj.GetComponent<AudioSourceScript>();
		component.MyAudioType = DesiredAudioType;
		component.MyClip = DesiredClip;
		component.Pitch = DesiredPitch;
	}
}
