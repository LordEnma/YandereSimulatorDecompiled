using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000529 RID: 1321
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06002196 RID: 8598 RVA: 0x001E9BF9 File Offset: 0x001E7DF9
		// (set) Token: 0x06002197 RID: 8599 RVA: 0x001E9C01 File Offset: 0x001E7E01
		public bool skidding { get; private set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06002198 RID: 8600 RVA: 0x001E9C0A File Offset: 0x001E7E0A
		// (set) Token: 0x06002199 RID: 8601 RVA: 0x001E9C12 File Offset: 0x001E7E12
		public bool PlayingAudio { get; private set; }

		// Token: 0x0600219A RID: 8602 RVA: 0x001E9C1C File Offset: 0x001E7E1C
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

		// Token: 0x0600219B RID: 8603 RVA: 0x001E9CAC File Offset: 0x001E7EAC
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x001E9D15 File Offset: 0x001E7F15
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x001E9D29 File Offset: 0x001E7F29
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x0600219E RID: 8606 RVA: 0x001E9D3D File Offset: 0x001E7F3D
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

		// Token: 0x0600219F RID: 8607 RVA: 0x001E9D4C File Offset: 0x001E7F4C
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

		// Token: 0x04004996 RID: 18838
		public Transform SkidTrailPrefab;

		// Token: 0x04004997 RID: 18839
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004998 RID: 18840
		public ParticleSystem skidParticles;

		// Token: 0x0400499B RID: 18843
		private AudioSource m_AudioSource;

		// Token: 0x0400499C RID: 18844
		private Transform m_SkidTrail;

		// Token: 0x0400499D RID: 18845
		private WheelCollider m_WheelCollider;
	}
}
