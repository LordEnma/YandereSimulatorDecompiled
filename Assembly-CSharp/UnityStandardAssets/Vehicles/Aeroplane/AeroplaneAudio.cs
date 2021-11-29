using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000527 RID: 1319
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x06002187 RID: 8583 RVA: 0x001E790C File Offset: 0x001E5B0C
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

		// Token: 0x06002188 RID: 8584 RVA: 0x001E7A48 File Offset: 0x001E5C48
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

		// Token: 0x0400494E RID: 18766
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x0400494F RID: 18767
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004950 RID: 18768
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004951 RID: 18769
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004952 RID: 18770
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004953 RID: 18771
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004954 RID: 18772
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004955 RID: 18773
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004956 RID: 18774
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004957 RID: 18775
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004958 RID: 18776
		private AudioSource m_WindSoundSource;

		// Token: 0x04004959 RID: 18777
		private AeroplaneController m_Plane;

		// Token: 0x0400495A RID: 18778
		private Rigidbody m_Rigidbody;

		// Token: 0x0200067F RID: 1663
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004F6D RID: 20333
			public float engineMinDistance = 50f;

			// Token: 0x04004F6E RID: 20334
			public float engineMaxDistance = 1000f;

			// Token: 0x04004F6F RID: 20335
			public float engineDopplerLevel = 1f;

			// Token: 0x04004F70 RID: 20336
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04004F71 RID: 20337
			public float windMinDistance = 10f;

			// Token: 0x04004F72 RID: 20338
			public float windMaxDistance = 100f;

			// Token: 0x04004F73 RID: 20339
			public float windDopplerLevel = 1f;

			// Token: 0x04004F74 RID: 20340
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
