using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053A RID: 1338
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x06002208 RID: 8712 RVA: 0x001F31B4 File Offset: 0x001F13B4
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

		// Token: 0x06002209 RID: 8713 RVA: 0x001F32F0 File Offset: 0x001F14F0
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

		// Token: 0x04004AB8 RID: 19128
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004AB9 RID: 19129
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004ABA RID: 19130
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004ABB RID: 19131
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004ABC RID: 19132
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004ABD RID: 19133
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004ABE RID: 19134
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004ABF RID: 19135
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004AC0 RID: 19136
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004AC1 RID: 19137
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004AC2 RID: 19138
		private AudioSource m_WindSoundSource;

		// Token: 0x04004AC3 RID: 19139
		private AeroplaneController m_Plane;

		// Token: 0x04004AC4 RID: 19140
		private Rigidbody m_Rigidbody;

		// Token: 0x0200068F RID: 1679
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x040050C2 RID: 20674
			public float engineMinDistance = 50f;

			// Token: 0x040050C3 RID: 20675
			public float engineMaxDistance = 1000f;

			// Token: 0x040050C4 RID: 20676
			public float engineDopplerLevel = 1f;

			// Token: 0x040050C5 RID: 20677
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x040050C6 RID: 20678
			public float windMinDistance = 10f;

			// Token: 0x040050C7 RID: 20679
			public float windMaxDistance = 100f;

			// Token: 0x040050C8 RID: 20680
			public float windDopplerLevel = 1f;

			// Token: 0x040050C9 RID: 20681
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
