using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021A8 RID: 8616 RVA: 0x001EACA0 File Offset: 0x001E8EA0
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

		// Token: 0x060021A9 RID: 8617 RVA: 0x001EADDC File Offset: 0x001E8FDC
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

		// Token: 0x040049B1 RID: 18865
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x040049B2 RID: 18866
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x040049B3 RID: 18867
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x040049B4 RID: 18868
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x040049B5 RID: 18869
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x040049B6 RID: 18870
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x040049B7 RID: 18871
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x040049B8 RID: 18872
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x040049B9 RID: 18873
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x040049BA RID: 18874
		private AudioSource m_EngineSoundSource;

		// Token: 0x040049BB RID: 18875
		private AudioSource m_WindSoundSource;

		// Token: 0x040049BC RID: 18876
		private AeroplaneController m_Plane;

		// Token: 0x040049BD RID: 18877
		private Rigidbody m_Rigidbody;

		// Token: 0x02000685 RID: 1669
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004FDC RID: 20444
			public float engineMinDistance = 50f;

			// Token: 0x04004FDD RID: 20445
			public float engineMaxDistance = 1000f;

			// Token: 0x04004FDE RID: 20446
			public float engineDopplerLevel = 1f;

			// Token: 0x04004FDF RID: 20447
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04004FE0 RID: 20448
			public float windMinDistance = 10f;

			// Token: 0x04004FE1 RID: 20449
			public float windMaxDistance = 100f;

			// Token: 0x04004FE2 RID: 20450
			public float windDopplerLevel = 1f;

			// Token: 0x04004FE3 RID: 20451
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
