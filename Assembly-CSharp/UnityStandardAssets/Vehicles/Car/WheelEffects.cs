using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000539 RID: 1337
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06002203 RID: 8707 RVA: 0x001F4995 File Offset: 0x001F2B95
		// (set) Token: 0x06002204 RID: 8708 RVA: 0x001F499D File Offset: 0x001F2B9D
		public bool skidding { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06002205 RID: 8709 RVA: 0x001F49A6 File Offset: 0x001F2BA6
		// (set) Token: 0x06002206 RID: 8710 RVA: 0x001F49AE File Offset: 0x001F2BAE
		public bool PlayingAudio { get; private set; }

		// Token: 0x06002207 RID: 8711 RVA: 0x001F49B8 File Offset: 0x001F2BB8
		private void Start()
		{
			this.skidParticles = base.transform.root.GetComponentInChildren<ParticleSystem>();
			if (this.skidParticles == null)
			{
				Debug.LogWarning(" no particle system found on car to generate smoke particles", base.gameObject);
			}
			else
			{
				this.skidParticles.Stop();
			}
			this.m_WheelCollider = base.GetComponent<WheelCollider>();
			this.m_AudioSource = base.GetComponent<AudioSource>();
			this.PlayingAudio = false;
			if (WheelEffects.skidTrailsDetachedParent == null)
			{
				WheelEffects.skidTrailsDetachedParent = new GameObject("Skid Trails - Detached").transform;
			}
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001F4A48 File Offset: 0x001F2C48
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001F4AB1 File Offset: 0x001F2CB1
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001F4AC5 File Offset: 0x001F2CC5
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001F4AD9 File Offset: 0x001F2CD9
		public IEnumerator StartSkidTrail()
		{
			this.skidding = true;
			this.m_SkidTrail = UnityEngine.Object.Instantiate<Transform>(this.SkidTrailPrefab);
			while (this.m_SkidTrail == null)
			{
				yield return null;
			}
			this.m_SkidTrail.parent = base.transform;
			this.m_SkidTrail.localPosition = -Vector3.up * this.m_WheelCollider.radius;
			yield break;
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001F4AE8 File Offset: 0x001F2CE8
		public void EndSkidTrail()
		{
			if (!this.skidding)
			{
				return;
			}
			this.skidding = false;
			this.m_SkidTrail.parent = WheelEffects.skidTrailsDetachedParent;
			UnityEngine.Object.Destroy(this.m_SkidTrail.gameObject, 10f);
		}

		// Token: 0x04004AD4 RID: 19156
		public Transform SkidTrailPrefab;

		// Token: 0x04004AD5 RID: 19157
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004AD6 RID: 19158
		public ParticleSystem skidParticles;

		// Token: 0x04004AD9 RID: 19161
		private AudioSource m_AudioSource;

		// Token: 0x04004ADA RID: 19162
		private Transform m_SkidTrail;

		// Token: 0x04004ADB RID: 19163
		private WheelCollider m_WheelCollider;
	}
}
