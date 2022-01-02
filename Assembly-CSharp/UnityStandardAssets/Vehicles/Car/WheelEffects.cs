using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600218B RID: 8587 RVA: 0x001E9259 File Offset: 0x001E7459
		// (set) Token: 0x0600218C RID: 8588 RVA: 0x001E9261 File Offset: 0x001E7461
		public bool skidding { get; private set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x0600218D RID: 8589 RVA: 0x001E926A File Offset: 0x001E746A
		// (set) Token: 0x0600218E RID: 8590 RVA: 0x001E9272 File Offset: 0x001E7472
		public bool PlayingAudio { get; private set; }

		// Token: 0x0600218F RID: 8591 RVA: 0x001E927C File Offset: 0x001E747C
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

		// Token: 0x06002190 RID: 8592 RVA: 0x001E930C File Offset: 0x001E750C
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x06002191 RID: 8593 RVA: 0x001E9375 File Offset: 0x001E7575
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x06002192 RID: 8594 RVA: 0x001E9389 File Offset: 0x001E7589
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x06002193 RID: 8595 RVA: 0x001E939D File Offset: 0x001E759D
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

		// Token: 0x06002194 RID: 8596 RVA: 0x001E93AC File Offset: 0x001E75AC
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

		// Token: 0x04004982 RID: 18818
		public Transform SkidTrailPrefab;

		// Token: 0x04004983 RID: 18819
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004984 RID: 18820
		public ParticleSystem skidParticles;

		// Token: 0x04004987 RID: 18823
		private AudioSource m_AudioSource;

		// Token: 0x04004988 RID: 18824
		private Transform m_SkidTrail;

		// Token: 0x04004989 RID: 18825
		private WheelCollider m_WheelCollider;
	}
}
