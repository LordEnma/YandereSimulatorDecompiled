using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021C7 RID: 8647 RVA: 0x001ED4C8 File Offset: 0x001EB6C8
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

		// Token: 0x060021C8 RID: 8648 RVA: 0x001ED604 File Offset: 0x001EB804
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

		// Token: 0x040049FB RID: 18939
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x040049FC RID: 18940
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x040049FD RID: 18941
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x040049FE RID: 18942
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x040049FF RID: 18943
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004A00 RID: 18944
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004A01 RID: 18945
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004A02 RID: 18946
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004A03 RID: 18947
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004A04 RID: 18948
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004A05 RID: 18949
		private AudioSource m_WindSoundSource;

		// Token: 0x04004A06 RID: 18950
		private AeroplaneController m_Plane;

		// Token: 0x04004A07 RID: 18951
		private Rigidbody m_Rigidbody;

		// Token: 0x02000684 RID: 1668
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004FFD RID: 20477
			public float engineMinDistance = 50f;

			// Token: 0x04004FFE RID: 20478
			public float engineMaxDistance = 1000f;

			// Token: 0x04004FFF RID: 20479
			public float engineDopplerLevel = 1f;

			// Token: 0x04005000 RID: 20480
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04005001 RID: 20481
			public float windMinDistance = 10f;

			// Token: 0x04005002 RID: 20482
			public float windMaxDistance = 100f;

			// Token: 0x04005003 RID: 20483
			public float windDopplerLevel = 1f;

			// Token: 0x04005004 RID: 20484
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
