using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052A RID: 1322
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060021A1 RID: 8609 RVA: 0x001EB685 File Offset: 0x001E9885
		// (set) Token: 0x060021A2 RID: 8610 RVA: 0x001EB68D File Offset: 0x001E988D
		public bool skidding { get; private set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021A3 RID: 8611 RVA: 0x001EB696 File Offset: 0x001E9896
		// (set) Token: 0x060021A4 RID: 8612 RVA: 0x001EB69E File Offset: 0x001E989E
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021A5 RID: 8613 RVA: 0x001EB6A8 File Offset: 0x001E98A8
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

		// Token: 0x060021A6 RID: 8614 RVA: 0x001EB738 File Offset: 0x001E9938
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021A7 RID: 8615 RVA: 0x001EB7A1 File Offset: 0x001E99A1
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021A8 RID: 8616 RVA: 0x001EB7B5 File Offset: 0x001E99B5
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021A9 RID: 8617 RVA: 0x001EB7C9 File Offset: 0x001E99C9
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

		// Token: 0x060021AA RID: 8618 RVA: 0x001EB7D8 File Offset: 0x001E99D8
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

		// Token: 0x040049B1 RID: 18865
		public Transform SkidTrailPrefab;

		// Token: 0x040049B2 RID: 18866
		public static Transform skidTrailsDetachedParent;

		// Token: 0x040049B3 RID: 18867
		public ParticleSystem skidParticles;

		// Token: 0x040049B6 RID: 18870
		private AudioSource m_AudioSource;

		// Token: 0x040049B7 RID: 18871
		private Transform m_SkidTrail;

		// Token: 0x040049B8 RID: 18872
		private WheelCollider m_WheelCollider;
	}
}
