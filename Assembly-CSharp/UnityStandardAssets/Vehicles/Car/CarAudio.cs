using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		public enum EngineAudioOptions
		{
			Simple = 0,
			FourChannel = 1
		}

		public EngineAudioOptions engineSoundStyle = EngineAudioOptions.FourChannel;

		public AudioClip lowAccelClip;

		public AudioClip lowDecelClip;

		public AudioClip highAccelClip;

		public AudioClip highDecelClip;

		public float pitchMultiplier = 1f;

		public float lowPitchMin = 1f;

		public float lowPitchMax = 6f;

		public float highPitchMultiplier = 0.25f;

		public float maxRolloffDistance = 500f;

		public float dopplerLevel = 1f;

		public bool useDoppler = true;

		private AudioSource m_LowAccel;

		private AudioSource m_LowDecel;

		private AudioSource m_HighAccel;

		private AudioSource m_HighDecel;

		private bool m_StartedSound;

		private CarController m_CarController;

		private void StartSound()
		{
			m_CarController = GetComponent<CarController>();
			m_HighAccel = SetUpEngineAudioSource(highAccelClip);
			if (engineSoundStyle == EngineAudioOptions.FourChannel)
			{
				m_LowAccel = SetUpEngineAudioSource(lowAccelClip);
				m_LowDecel = SetUpEngineAudioSource(lowDecelClip);
				m_HighDecel = SetUpEngineAudioSource(highDecelClip);
			}
			m_StartedSound = true;
		}

		private void StopSound()
		{
			AudioSource[] components = GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				Object.Destroy(components[i]);
			}
			m_StartedSound = false;
		}

		private void Update()
		{
			float sqrMagnitude = (Camera.main.transform.position - base.transform.position).sqrMagnitude;
			if (m_StartedSound && sqrMagnitude > maxRolloffDistance * maxRolloffDistance)
			{
				StopSound();
			}
			if (!m_StartedSound && sqrMagnitude < maxRolloffDistance * maxRolloffDistance)
			{
				StartSound();
			}
			if (m_StartedSound)
			{
				float b = ULerp(lowPitchMin, lowPitchMax, m_CarController.Revs);
				b = Mathf.Min(lowPitchMax, b);
				if (engineSoundStyle == EngineAudioOptions.Simple)
				{
					m_HighAccel.pitch = b * pitchMultiplier * highPitchMultiplier;
					m_HighAccel.dopplerLevel = (useDoppler ? dopplerLevel : 0f);
					m_HighAccel.volume = 1f;
					return;
				}
				m_LowAccel.pitch = b * pitchMultiplier;
				m_LowDecel.pitch = b * pitchMultiplier;
				m_HighAccel.pitch = b * highPitchMultiplier * pitchMultiplier;
				m_HighDecel.pitch = b * highPitchMultiplier * pitchMultiplier;
				float num = Mathf.Abs(m_CarController.AccelInput);
				float num2 = 1f - num;
				float num3 = Mathf.InverseLerp(0.2f, 0.8f, m_CarController.Revs);
				float num4 = 1f - num3;
				num3 = 1f - (1f - num3) * (1f - num3);
				num4 = 1f - (1f - num4) * (1f - num4);
				num = 1f - (1f - num) * (1f - num);
				num2 = 1f - (1f - num2) * (1f - num2);
				m_LowAccel.volume = num4 * num;
				m_LowDecel.volume = num4 * num2;
				m_HighAccel.volume = num3 * num;
				m_HighDecel.volume = num3 * num2;
				m_HighAccel.dopplerLevel = (useDoppler ? dopplerLevel : 0f);
				m_LowAccel.dopplerLevel = (useDoppler ? dopplerLevel : 0f);
				m_HighDecel.dopplerLevel = (useDoppler ? dopplerLevel : 0f);
				m_LowDecel.dopplerLevel = (useDoppler ? dopplerLevel : 0f);
			}
		}

		private AudioSource SetUpEngineAudioSource(AudioClip clip)
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.volume = 0f;
			audioSource.loop = true;
			audioSource.time = Random.Range(0f, clip.length);
			audioSource.Play();
			audioSource.minDistance = 5f;
			audioSource.maxDistance = maxRolloffDistance;
			audioSource.dopplerLevel = 0f;
			return audioSource;
		}

		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}
	}
}
