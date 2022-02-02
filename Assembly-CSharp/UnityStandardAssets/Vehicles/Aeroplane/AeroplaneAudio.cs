using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021AC RID: 8620 RVA: 0x001EB540 File Offset: 0x001E9740
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

		// Token: 0x060021AD RID: 8621 RVA: 0x001EB67C File Offset: 0x001E987C
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

		// Token: 0x040049BC RID: 18876
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x040049BD RID: 18877
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x040049BE RID: 18878
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x040049BF RID: 18879
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x040049C0 RID: 18880
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x040049C1 RID: 18881
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x040049C2 RID: 18882
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x040049C3 RID: 18883
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x040049C4 RID: 18884
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x040049C5 RID: 18885
		private AudioSource m_EngineSoundSource;

		// Token: 0x040049C6 RID: 18886
		private AudioSource m_WindSoundSource;

		// Token: 0x040049C7 RID: 18887
		private AeroplaneController m_Plane;

		// Token: 0x040049C8 RID: 18888
		private Rigidbody m_Rigidbody;

		// Token: 0x0200067F RID: 1663
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004FB9 RID: 20409
			public float engineMinDistance = 50f;

			// Token: 0x04004FBA RID: 20410
			public float engineMaxDistance = 1000f;

			// Token: 0x04004FBB RID: 20411
			public float engineDopplerLevel = 1f;

			// Token: 0x04004FBC RID: 20412
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04004FBD RID: 20413
			public float windMinDistance = 10f;

			// Token: 0x04004FBE RID: 20414
			public float windMaxDistance = 100f;

			// Token: 0x04004FBF RID: 20415
			public float windDopplerLevel = 1f;

			// Token: 0x04004FC0 RID: 20416
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
