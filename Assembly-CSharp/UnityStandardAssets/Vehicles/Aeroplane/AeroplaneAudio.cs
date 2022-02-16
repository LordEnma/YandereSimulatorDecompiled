using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021B8 RID: 8632 RVA: 0x001EBF10 File Offset: 0x001EA110
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

		// Token: 0x060021B9 RID: 8633 RVA: 0x001EC04C File Offset: 0x001EA24C
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

		// Token: 0x040049CE RID: 18894
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x040049CF RID: 18895
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x040049D0 RID: 18896
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x040049D1 RID: 18897
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x040049D2 RID: 18898
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x040049D3 RID: 18899
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x040049D4 RID: 18900
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x040049D5 RID: 18901
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x040049D6 RID: 18902
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x040049D7 RID: 18903
		private AudioSource m_EngineSoundSource;

		// Token: 0x040049D8 RID: 18904
		private AudioSource m_WindSoundSource;

		// Token: 0x040049D9 RID: 18905
		private AeroplaneController m_Plane;

		// Token: 0x040049DA RID: 18906
		private Rigidbody m_Rigidbody;

		// Token: 0x02000680 RID: 1664
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004FCB RID: 20427
			public float engineMinDistance = 50f;

			// Token: 0x04004FCC RID: 20428
			public float engineMaxDistance = 1000f;

			// Token: 0x04004FCD RID: 20429
			public float engineDopplerLevel = 1f;

			// Token: 0x04004FCE RID: 20430
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04004FCF RID: 20431
			public float windMinDistance = 10f;

			// Token: 0x04004FD0 RID: 20432
			public float windMaxDistance = 100f;

			// Token: 0x04004FD1 RID: 20433
			public float windDopplerLevel = 1f;

			// Token: 0x04004FD2 RID: 20434
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
