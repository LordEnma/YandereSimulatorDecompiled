using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06002188 RID: 8584 RVA: 0x001E8C69 File Offset: 0x001E6E69
		// (set) Token: 0x06002189 RID: 8585 RVA: 0x001E8C71 File Offset: 0x001E6E71
		public bool skidding { get; private set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600218A RID: 8586 RVA: 0x001E8C7A File Offset: 0x001E6E7A
		// (set) Token: 0x0600218B RID: 8587 RVA: 0x001E8C82 File Offset: 0x001E6E82
		public bool PlayingAudio { get; private set; }

		// Token: 0x0600218C RID: 8588 RVA: 0x001E8C8C File Offset: 0x001E6E8C
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

		// Token: 0x0600218D RID: 8589 RVA: 0x001E8D1C File Offset: 0x001E6F1C
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x001E8D85 File Offset: 0x001E6F85
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x001E8D99 File Offset: 0x001E6F99
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x06002190 RID: 8592 RVA: 0x001E8DAD File Offset: 0x001E6FAD
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

		// Token: 0x06002191 RID: 8593 RVA: 0x001E8DBC File Offset: 0x001E6FBC
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

		// Token: 0x04004979 RID: 18809
		public Transform SkidTrailPrefab;

		// Token: 0x0400497A RID: 18810
		public static Transform skidTrailsDetachedParent;

		// Token: 0x0400497B RID: 18811
		public ParticleSystem skidParticles;

		// Token: 0x0400497E RID: 18814
		private AudioSource m_AudioSource;

		// Token: 0x0400497F RID: 18815
		private Transform m_SkidTrail;

		// Token: 0x04004980 RID: 18816
		private WheelCollider m_WheelCollider;
	}
}
