using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000525 RID: 1317
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06002177 RID: 8567 RVA: 0x001E7535 File Offset: 0x001E5735
		// (set) Token: 0x06002178 RID: 8568 RVA: 0x001E753D File Offset: 0x001E573D
		public bool skidding { get; private set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06002179 RID: 8569 RVA: 0x001E7546 File Offset: 0x001E5746
		// (set) Token: 0x0600217A RID: 8570 RVA: 0x001E754E File Offset: 0x001E574E
		public bool PlayingAudio { get; private set; }

		// Token: 0x0600217B RID: 8571 RVA: 0x001E7558 File Offset: 0x001E5758
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

		// Token: 0x0600217C RID: 8572 RVA: 0x001E75E8 File Offset: 0x001E57E8
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x0600217D RID: 8573 RVA: 0x001E7651 File Offset: 0x001E5851
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x0600217E RID: 8574 RVA: 0x001E7665 File Offset: 0x001E5865
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x0600217F RID: 8575 RVA: 0x001E7679 File Offset: 0x001E5879
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

		// Token: 0x06002180 RID: 8576 RVA: 0x001E7688 File Offset: 0x001E5888
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

		// Token: 0x0400493A RID: 18746
		public Transform SkidTrailPrefab;

		// Token: 0x0400493B RID: 18747
		public static Transform skidTrailsDetachedParent;

		// Token: 0x0400493C RID: 18748
		public ParticleSystem skidParticles;

		// Token: 0x0400493F RID: 18751
		private AudioSource m_AudioSource;

		// Token: 0x04004940 RID: 18752
		private Transform m_SkidTrail;

		// Token: 0x04004941 RID: 18753
		private WheelCollider m_WheelCollider;
	}
}
