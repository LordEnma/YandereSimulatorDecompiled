using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000539 RID: 1337
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021F7 RID: 8695 RVA: 0x001F11D0 File Offset: 0x001EF3D0
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

		// Token: 0x060021F8 RID: 8696 RVA: 0x001F130C File Offset: 0x001EF50C
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

		// Token: 0x04004A90 RID: 19088
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004A91 RID: 19089
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004A92 RID: 19090
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004A93 RID: 19091
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004A94 RID: 19092
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004A95 RID: 19093
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004A96 RID: 19094
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004A97 RID: 19095
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004A98 RID: 19096
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004A99 RID: 19097
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004A9A RID: 19098
		private AudioSource m_WindSoundSource;

		// Token: 0x04004A9B RID: 19099
		private AeroplaneController m_Plane;

		// Token: 0x04004A9C RID: 19100
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068E RID: 1678
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04005092 RID: 20626
			public float engineMinDistance = 50f;

			// Token: 0x04005093 RID: 20627
			public float engineMaxDistance = 1000f;

			// Token: 0x04005094 RID: 20628
			public float engineDopplerLevel = 1f;

			// Token: 0x04005095 RID: 20629
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04005096 RID: 20630
			public float windMinDistance = 10f;

			// Token: 0x04005097 RID: 20631
			public float windMaxDistance = 100f;

			// Token: 0x04005098 RID: 20632
			public float windDopplerLevel = 1f;

			// Token: 0x04005099 RID: 20633
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
