using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021C1 RID: 8641 RVA: 0x001ECAF0 File Offset: 0x001EACF0
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

		// Token: 0x060021C2 RID: 8642 RVA: 0x001ECC2C File Offset: 0x001EAE2C
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

		// Token: 0x040049DE RID: 18910
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x040049DF RID: 18911
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x040049E0 RID: 18912
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x040049E1 RID: 18913
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x040049E2 RID: 18914
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x040049E3 RID: 18915
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x040049E4 RID: 18916
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x040049E5 RID: 18917
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x040049E6 RID: 18918
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x040049E7 RID: 18919
		private AudioSource m_EngineSoundSource;

		// Token: 0x040049E8 RID: 18920
		private AudioSource m_WindSoundSource;

		// Token: 0x040049E9 RID: 18921
		private AeroplaneController m_Plane;

		// Token: 0x040049EA RID: 18922
		private Rigidbody m_Rigidbody;

		// Token: 0x02000683 RID: 1667
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004FE0 RID: 20448
			public float engineMinDistance = 50f;

			// Token: 0x04004FE1 RID: 20449
			public float engineMaxDistance = 1000f;

			// Token: 0x04004FE2 RID: 20450
			public float engineDopplerLevel = 1f;

			// Token: 0x04004FE3 RID: 20451
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04004FE4 RID: 20452
			public float windMinDistance = 10f;

			// Token: 0x04004FE5 RID: 20453
			public float windMaxDistance = 100f;

			// Token: 0x04004FE6 RID: 20454
			public float windDopplerLevel = 1f;

			// Token: 0x04004FE7 RID: 20455
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
