using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000531 RID: 1329
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021CF RID: 8655 RVA: 0x001EF059 File Offset: 0x001ED259
		// (set) Token: 0x060021D0 RID: 8656 RVA: 0x001EF061 File Offset: 0x001ED261
		public bool skidding { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021D1 RID: 8657 RVA: 0x001EF06A File Offset: 0x001ED26A
		// (set) Token: 0x060021D2 RID: 8658 RVA: 0x001EF072 File Offset: 0x001ED272
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021D3 RID: 8659 RVA: 0x001EF07C File Offset: 0x001ED27C
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

		// Token: 0x060021D4 RID: 8660 RVA: 0x001EF10C File Offset: 0x001ED30C
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x001EF175 File Offset: 0x001ED375
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x001EF189 File Offset: 0x001ED389
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x001EF19D File Offset: 0x001ED39D
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

		// Token: 0x060021D8 RID: 8664 RVA: 0x001EF1AC File Offset: 0x001ED3AC
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

		// Token: 0x04004A46 RID: 19014
		public Transform SkidTrailPrefab;

		// Token: 0x04004A47 RID: 19015
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004A48 RID: 19016
		public ParticleSystem skidParticles;

		// Token: 0x04004A4B RID: 19019
		private AudioSource m_AudioSource;

		// Token: 0x04004A4C RID: 19020
		private Transform m_SkidTrail;

		// Token: 0x04004A4D RID: 19021
		private WheelCollider m_WheelCollider;
	}
}
