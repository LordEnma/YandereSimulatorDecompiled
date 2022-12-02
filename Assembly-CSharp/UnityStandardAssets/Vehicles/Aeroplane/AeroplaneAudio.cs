using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	public class AeroplaneAudio : MonoBehaviour
	{
		[Serializable]
		public class AdvancedSetttings
		{
			public float engineMinDistance = 50f;

			public float engineMaxDistance = 1000f;

			public float engineDopplerLevel = 1f;

			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			public float windMinDistance = 10f;

			public float windMaxDistance = 100f;

			public float windDopplerLevel = 1f;

			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}

		[SerializeField]
		private AudioClip m_EngineSound;

		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		[SerializeField]
		private AudioClip m_WindSound;

		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		[SerializeField]
		private AdvancedSetttings m_AdvancedSetttings = new AdvancedSetttings();

		private AudioSource m_EngineSoundSource;

		private AudioSource m_WindSoundSource;

		private AeroplaneController m_Plane;

		private Rigidbody m_Rigidbody;

		private void Awake()
		{
			m_Plane = GetComponent<AeroplaneController>();
			m_Rigidbody = GetComponent<Rigidbody>();
			m_EngineSoundSource = base.gameObject.AddComponent<AudioSource>();
			m_EngineSoundSource.playOnAwake = false;
			m_WindSoundSource = base.gameObject.AddComponent<AudioSource>();
			m_WindSoundSource.playOnAwake = false;
			m_EngineSoundSource.clip = m_EngineSound;
			m_WindSoundSource.clip = m_WindSound;
			m_EngineSoundSource.minDistance = m_AdvancedSetttings.engineMinDistance;
			m_EngineSoundSource.maxDistance = m_AdvancedSetttings.engineMaxDistance;
			m_EngineSoundSource.loop = true;
			m_EngineSoundSource.dopplerLevel = m_AdvancedSetttings.engineDopplerLevel;
			m_WindSoundSource.minDistance = m_AdvancedSetttings.windMinDistance;
			m_WindSoundSource.maxDistance = m_AdvancedSetttings.windMaxDistance;
			m_WindSoundSource.loop = true;
			m_WindSoundSource.dopplerLevel = m_AdvancedSetttings.windDopplerLevel;
			Update();
			m_EngineSoundSource.Play();
			m_WindSoundSource.Play();
		}

		private void Update()
		{
			float t = Mathf.InverseLerp(0f, m_Plane.MaxEnginePower, m_Plane.EnginePower);
			m_EngineSoundSource.pitch = Mathf.Lerp(m_EngineMinThrottlePitch, m_EngineMaxThrottlePitch, t);
			m_EngineSoundSource.pitch += m_Plane.ForwardSpeed * m_EngineFwdSpeedMultiplier;
			m_EngineSoundSource.volume = Mathf.InverseLerp(0f, m_Plane.MaxEnginePower * m_AdvancedSetttings.engineMasterVolume, m_Plane.EnginePower);
			float magnitude = m_Rigidbody.velocity.magnitude;
			m_WindSoundSource.pitch = m_WindBasePitch + magnitude * m_WindSpeedPitchFactor;
			m_WindSoundSource.volume = Mathf.InverseLerp(0f, m_WindMaxSpeedVolume, magnitude) * m_AdvancedSetttings.windMasterVolume;
		}
	}
}
