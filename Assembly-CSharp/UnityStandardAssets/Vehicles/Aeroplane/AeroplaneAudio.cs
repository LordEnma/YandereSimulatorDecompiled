using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000538 RID: 1336
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021EF RID: 8687 RVA: 0x001F0CA0 File Offset: 0x001EEEA0
		private void Awake()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_EngineSoundSource = base.gameObject.AddComponent<AudioSource>();
			this.m_EngineSoundSource.playOnAwake = false;
			this.m_WindSoundSource = base.gameObject.AddComponent<AudioSource>();
			this.m_WindSoundSource.playOnAwake = false;
			this.m_EngineSoundSource.clip = this.m_EngineSound;
			this.m_WindSoundSource.clip = this.m_WindSound;
			this.m_EngineSoundSource.minDistance = this.m_AdvancedSetttings.engineMinDistance;
			this.m_EngineSoundSource.maxDistance = this.m_AdvancedSetttings.engineMaxDistance;
			this.m_EngineSoundSource.loop = true;
			this.m_EngineSoundSource.dopplerLevel = this.m_AdvancedSetttings.engineDopplerLevel;
			this.m_WindSoundSource.minDistance = this.m_AdvancedSetttings.windMinDistance;
			this.m_WindSoundSource.maxDistance = this.m_AdvancedSetttings.windMaxDistance;
			this.m_WindSoundSource.loop = true;
			this.m_WindSoundSource.dopplerLevel = this.m_AdvancedSetttings.windDopplerLevel;
			this.Update();
			this.m_EngineSoundSource.Play();
			this.m_WindSoundSource.Play();
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001F0DDC File Offset: 0x001EEFDC
		private void Update()
		{
			float t = Mathf.InverseLerp(0f, this.m_Plane.MaxEnginePower, this.m_Plane.EnginePower);
			this.m_EngineSoundSource.pitch = Mathf.Lerp(this.m_EngineMinThrottlePitch, this.m_EngineMaxThrottlePitch, t);
			this.m_EngineSoundSource.pitch += this.m_Plane.ForwardSpeed * this.m_EngineFwdSpeedMultiplier;
			this.m_EngineSoundSource.volume = Mathf.InverseLerp(0f, this.m_Plane.MaxEnginePower * this.m_AdvancedSetttings.engineMasterVolume, this.m_Plane.EnginePower);
			float magnitude = this.m_Rigidbody.velocity.magnitude;
			this.m_WindSoundSource.pitch = this.m_WindBasePitch + magnitude * this.m_WindSpeedPitchFactor;
			this.m_WindSoundSource.volume = Mathf.InverseLerp(0f, this.m_WindMaxSpeedVolume, magnitude) * this.m_AdvancedSetttings.windMasterVolume;
		}

		// Token: 0x04004A8C RID: 19084
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004A8D RID: 19085
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004A8E RID: 19086
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004A8F RID: 19087
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004A90 RID: 19088
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004A91 RID: 19089
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004A92 RID: 19090
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004A93 RID: 19091
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004A94 RID: 19092
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004A95 RID: 19093
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004A96 RID: 19094
		private AudioSource m_WindSoundSource;

		// Token: 0x04004A97 RID: 19095
		private AeroplaneController m_Plane;

		// Token: 0x04004A98 RID: 19096
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068D RID: 1677
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x0400508E RID: 20622
			public float engineMinDistance = 50f;

			// Token: 0x0400508F RID: 20623
			public float engineMaxDistance = 1000f;

			// Token: 0x04005090 RID: 20624
			public float engineDopplerLevel = 1f;

			// Token: 0x04005091 RID: 20625
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04005092 RID: 20626
			public float windMinDistance = 10f;

			// Token: 0x04005093 RID: 20627
			public float windMaxDistance = 100f;

			// Token: 0x04005094 RID: 20628
			public float windDopplerLevel = 1f;

			// Token: 0x04005095 RID: 20629
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
