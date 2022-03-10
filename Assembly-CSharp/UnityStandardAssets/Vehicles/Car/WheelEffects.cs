using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021B7 RID: 8631 RVA: 0x001ED0F1 File Offset: 0x001EB2F1
		// (set) Token: 0x060021B8 RID: 8632 RVA: 0x001ED0F9 File Offset: 0x001EB2F9
		public bool skidding { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021B9 RID: 8633 RVA: 0x001ED102 File Offset: 0x001EB302
		// (set) Token: 0x060021BA RID: 8634 RVA: 0x001ED10A File Offset: 0x001EB30A
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021BB RID: 8635 RVA: 0x001ED114 File Offset: 0x001EB314
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

		// Token: 0x060021BC RID: 8636 RVA: 0x001ED1A4 File Offset: 0x001EB3A4
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x001ED20D File Offset: 0x001EB40D
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x001ED221 File Offset: 0x001EB421
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x001ED235 File Offset: 0x001EB435
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

		// Token: 0x060021C0 RID: 8640 RVA: 0x001ED244 File Offset: 0x001EB444
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

		// Token: 0x040049E7 RID: 18919
		public Transform SkidTrailPrefab;

		// Token: 0x040049E8 RID: 18920
		public static Transform skidTrailsDetachedParent;

		// Token: 0x040049E9 RID: 18921
		public ParticleSystem skidParticles;

		// Token: 0x040049EC RID: 18924
		private AudioSource m_AudioSource;

		// Token: 0x040049ED RID: 18925
		private Transform m_SkidTrail;

		// Token: 0x040049EE RID: 18926
		private WheelCollider m_WheelCollider;
	}
}
