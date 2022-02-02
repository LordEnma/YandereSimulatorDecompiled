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
		// (get) Token: 0x0600219C RID: 8604 RVA: 0x001EB169 File Offset: 0x001E9369
		// (set) Token: 0x0600219D RID: 8605 RVA: 0x001EB171 File Offset: 0x001E9371
		public bool skidding { get; private set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600219E RID: 8606 RVA: 0x001EB17A File Offset: 0x001E937A
		// (set) Token: 0x0600219F RID: 8607 RVA: 0x001EB182 File Offset: 0x001E9382
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021A0 RID: 8608 RVA: 0x001EB18C File Offset: 0x001E938C
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

		// Token: 0x060021A1 RID: 8609 RVA: 0x001EB21C File Offset: 0x001E941C
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021A2 RID: 8610 RVA: 0x001EB285 File Offset: 0x001E9485
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x001EB299 File Offset: 0x001E9499
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021A4 RID: 8612 RVA: 0x001EB2AD File Offset: 0x001E94AD
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

		// Token: 0x060021A5 RID: 8613 RVA: 0x001EB2BC File Offset: 0x001E94BC
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

		// Token: 0x040049A8 RID: 18856
		public Transform SkidTrailPrefab;

		// Token: 0x040049A9 RID: 18857
		public static Transform skidTrailsDetachedParent;

		// Token: 0x040049AA RID: 18858
		public ParticleSystem skidParticles;

		// Token: 0x040049AD RID: 18861
		private AudioSource m_AudioSource;

		// Token: 0x040049AE RID: 18862
		private Transform m_SkidTrail;

		// Token: 0x040049AF RID: 18863
		private WheelCollider m_WheelCollider;
	}
}
