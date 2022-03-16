using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000533 RID: 1331
	public class AeroplaneAudio : MonoBehaviour
	{
		// Token: 0x060021DF RID: 8671 RVA: 0x001EF430 File Offset: 0x001ED630
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

		// Token: 0x060021E0 RID: 8672 RVA: 0x001EF56C File Offset: 0x001ED76C
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

		// Token: 0x04004A5A RID: 19034
		[SerializeField]
		private AudioClip m_EngineSound;

		// Token: 0x04004A5B RID: 19035
		[SerializeField]
		private float m_EngineMinThrottlePitch = 0.4f;

		// Token: 0x04004A5C RID: 19036
		[SerializeField]
		private float m_EngineMaxThrottlePitch = 2f;

		// Token: 0x04004A5D RID: 19037
		[SerializeField]
		private float m_EngineFwdSpeedMultiplier = 0.002f;

		// Token: 0x04004A5E RID: 19038
		[SerializeField]
		private AudioClip m_WindSound;

		// Token: 0x04004A5F RID: 19039
		[SerializeField]
		private float m_WindBasePitch = 0.2f;

		// Token: 0x04004A60 RID: 19040
		[SerializeField]
		private float m_WindSpeedPitchFactor = 0.004f;

		// Token: 0x04004A61 RID: 19041
		[SerializeField]
		private float m_WindMaxSpeedVolume = 100f;

		// Token: 0x04004A62 RID: 19042
		[SerializeField]
		private AeroplaneAudio.AdvancedSetttings m_AdvancedSetttings = new AeroplaneAudio.AdvancedSetttings();

		// Token: 0x04004A63 RID: 19043
		private AudioSource m_EngineSoundSource;

		// Token: 0x04004A64 RID: 19044
		private AudioSource m_WindSoundSource;

		// Token: 0x04004A65 RID: 19045
		private AeroplaneController m_Plane;

		// Token: 0x04004A66 RID: 19046
		private Rigidbody m_Rigidbody;

		// Token: 0x02000688 RID: 1672
		[Serializable]
		public class AdvancedSetttings
		{
			// Token: 0x0400505C RID: 20572
			public float engineMinDistance = 50f;

			// Token: 0x0400505D RID: 20573
			public float engineMaxDistance = 1000f;

			// Token: 0x0400505E RID: 20574
			public float engineDopplerLevel = 1f;

			// Token: 0x0400505F RID: 20575
			[Range(0f, 1f)]
			public float engineMasterVolume = 0.5f;

			// Token: 0x04005060 RID: 20576
			public float windMinDistance = 10f;

			// Token: 0x04005061 RID: 20577
			public float windMaxDistance = 100f;

			// Token: 0x04005062 RID: 20578
			public float windDopplerLevel = 1f;

			// Token: 0x04005063 RID: 20579
			[Range(0f, 1f)]
			public float windMasterVolume = 0.5f;
		}
	}
}
