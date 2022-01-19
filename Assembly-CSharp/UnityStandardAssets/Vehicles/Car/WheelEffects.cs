using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052A RID: 1322
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06002198 RID: 8600 RVA: 0x001EA8C9 File Offset: 0x001E8AC9
		// (set) Token: 0x06002199 RID: 8601 RVA: 0x001EA8D1 File Offset: 0x001E8AD1
		public bool skidding { get; private set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600219A RID: 8602 RVA: 0x001EA8DA File Offset: 0x001E8ADA
		// (set) Token: 0x0600219B RID: 8603 RVA: 0x001EA8E2 File Offset: 0x001E8AE2
		public bool PlayingAudio { get; private set; }

		// Token: 0x0600219C RID: 8604 RVA: 0x001EA8EC File Offset: 0x001E8AEC
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

		// Token: 0x0600219D RID: 8605 RVA: 0x001EA97C File Offset: 0x001E8B7C
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x0600219E RID: 8606 RVA: 0x001EA9E5 File Offset: 0x001E8BE5
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x001EA9F9 File Offset: 0x001E8BF9
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021A0 RID: 8608 RVA: 0x001EAA0D File Offset: 0x001E8C0D
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

		// Token: 0x060021A1 RID: 8609 RVA: 0x001EAA1C File Offset: 0x001E8C1C
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

		// Token: 0x0400499D RID: 18845
		public Transform SkidTrailPrefab;

		// Token: 0x0400499E RID: 18846
		public static Transform skidTrailsDetachedParent;

		// Token: 0x0400499F RID: 18847
		public ParticleSystem skidParticles;

		// Token: 0x040049A2 RID: 18850
		private AudioSource m_AudioSource;

		// Token: 0x040049A3 RID: 18851
		private Transform m_SkidTrail;

		// Token: 0x040049A4 RID: 18852
		private WheelCollider m_WheelCollider;
	}
}
