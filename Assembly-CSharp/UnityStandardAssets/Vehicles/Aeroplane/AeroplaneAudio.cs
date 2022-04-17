using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000539 RID: 1337
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021FE RID: 8702 RVA: 0x001F1C2C File Offset: 0x001EFE2C
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

		// Token: 0x060021FF RID: 8703 RVA: 0x001F1D68 File Offset: 0x001EFF68
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

		// Token: 0x04004AA2 RID: 19106
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004AA3 RID: 19107
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004AA4 RID: 19108
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004AA5 RID: 19109
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004AA6 RID: 19110
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004AA7 RID: 19111
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004AA8 RID: 19112
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004AA9 RID: 19113
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004AAA RID: 19114
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004AAB RID: 19115
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004AAC RID: 19116
		private AudioSource m_WindSoundSource;

		// Token: 0x04004AAD RID: 19117
		private AeroplaneController m_Plane;

		// Token: 0x04004AAE RID: 19118
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068E RID: 1678
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x040050A4 RID: 20644
			public float engineMinDistance = 50f;

			// Token: 0x040050A5 RID: 20645
			public float engineMaxDistance = 1000f;

			// Token: 0x040050A6 RID: 20646
			public float engineDopplerLevel = 1f;

			// Token: 0x040050A7 RID: 20647
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x040050A8 RID: 20648
			public float windMinDistance = 10f;

			// Token: 0x040050A9 RID: 20649
			public float windMaxDistance = 100f;

			// Token: 0x040050AA RID: 20650
			public float windDopplerLevel = 1f;

			// Token: 0x040050AB RID: 20651
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
