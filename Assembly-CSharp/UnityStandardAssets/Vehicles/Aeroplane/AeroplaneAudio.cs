using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053B RID: 1339
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x06002212 RID: 8722 RVA: 0x001F4804 File Offset: 0x001F2A04
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

		// Token: 0x06002213 RID: 8723 RVA: 0x001F4940 File Offset: 0x001F2B40
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

		// Token: 0x04004ADF RID: 19167
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004AE0 RID: 19168
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004AE1 RID: 19169
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004AE2 RID: 19170
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004AE3 RID: 19171
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004AE4 RID: 19172
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004AE5 RID: 19173
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004AE6 RID: 19174
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004AE7 RID: 19175
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004AE8 RID: 19176
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004AE9 RID: 19177
		private AudioSource m_WindSoundSource;

		// Token: 0x04004AEA RID: 19178
		private AeroplaneController m_Plane;

		// Token: 0x04004AEB RID: 19179
		private Rigidbody m_Rigidbody;

		// Token: 0x02000690 RID: 1680
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x040050E9 RID: 20713
			public float engineMinDistance = 50f;

			// Token: 0x040050EA RID: 20714
			public float engineMaxDistance = 1000f;

			// Token: 0x040050EB RID: 20715
			public float engineDopplerLevel = 1f;

			// Token: 0x040050EC RID: 20716
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x040050ED RID: 20717
			public float windMinDistance = 10f;

			// Token: 0x040050EE RID: 20718
			public float windMaxDistance = 100f;

			// Token: 0x040050EF RID: 20719
			public float windDopplerLevel = 1f;

			// Token: 0x040050F0 RID: 20720
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
