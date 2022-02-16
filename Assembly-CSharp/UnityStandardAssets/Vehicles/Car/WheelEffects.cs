using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052B RID: 1323
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021A8 RID: 8616 RVA: 0x001EBB39 File Offset: 0x001E9D39
		// (set) Token: 0x060021A9 RID: 8617 RVA: 0x001EBB41 File Offset: 0x001E9D41
		public bool skidding { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021AA RID: 8618 RVA: 0x001EBB4A File Offset: 0x001E9D4A
		// (set) Token: 0x060021AB RID: 8619 RVA: 0x001EBB52 File Offset: 0x001E9D52
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021AC RID: 8620 RVA: 0x001EBB5C File Offset: 0x001E9D5C
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

		// Token: 0x060021AD RID: 8621 RVA: 0x001EBBEC File Offset: 0x001E9DEC
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021AE RID: 8622 RVA: 0x001EBC55 File Offset: 0x001E9E55
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021AF RID: 8623 RVA: 0x001EBC69 File Offset: 0x001E9E69
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x001EBC7D File Offset: 0x001E9E7D
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

		// Token: 0x060021B1 RID: 8625 RVA: 0x001EBC8C File Offset: 0x001E9E8C
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

		// Token: 0x040049BA RID: 18874
		public Transform SkidTrailPrefab;

		// Token: 0x040049BB RID: 18875
		public static Transform skidTrailsDetachedParent;

		// Token: 0x040049BC RID: 18876
		public ParticleSystem skidParticles;

		// Token: 0x040049BF RID: 18879
		private AudioSource m_AudioSource;

		// Token: 0x040049C0 RID: 18880
		private Transform m_SkidTrail;

		// Token: 0x040049C1 RID: 18881
		private WheelCollider m_WheelCollider;
	}
}
