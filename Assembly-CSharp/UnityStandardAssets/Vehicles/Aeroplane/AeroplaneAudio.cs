using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000529 RID: 1321
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x0600219B RID: 8603 RVA: 0x001E9630 File Offset: 0x001E7830
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

		// Token: 0x0600219C RID: 8604 RVA: 0x001E976C File Offset: 0x001E796C
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

		// Token: 0x04004996 RID: 18838
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004997 RID: 18839
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004998 RID: 18840
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004999 RID: 18841
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x0400499A RID: 18842
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x0400499B RID: 18843
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x0400499C RID: 18844
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x0400499D RID: 18845
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x0400499E RID: 18846
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x0400499F RID: 18847
		private AudioSource m_EngineSoundSource;

		// Token: 0x040049A0 RID: 18848
		private AudioSource m_WindSoundSource;

		// Token: 0x040049A1 RID: 18849
		private AeroplaneController m_Plane;

		// Token: 0x040049A2 RID: 18850
		private Rigidbody m_Rigidbody;

		// Token: 0x02000682 RID: 1666
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x04004FC1 RID: 20417
			public float engineMinDistance = 50f;

			// Token: 0x04004FC2 RID: 20418
			public float engineMaxDistance = 1000f;

			// Token: 0x04004FC3 RID: 20419
			public float engineDopplerLevel = 1f;

			// Token: 0x04004FC4 RID: 20420
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04004FC5 RID: 20421
			public float windMinDistance = 10f;

			// Token: 0x04004FC6 RID: 20422
			public float windMaxDistance = 100f;

			// Token: 0x04004FC7 RID: 20423
			public float windDopplerLevel = 1f;

			// Token: 0x04004FC8 RID: 20424
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
