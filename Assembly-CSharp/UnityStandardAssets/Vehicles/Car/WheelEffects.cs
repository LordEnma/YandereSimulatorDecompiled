using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000536 RID: 1334
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021DF RID: 8671 RVA: 0x001F08C9 File Offset: 0x001EEAC9
		// (set) Token: 0x060021E0 RID: 8672 RVA: 0x001F08D1 File Offset: 0x001EEAD1
		public bool skidding { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021E1 RID: 8673 RVA: 0x001F08DA File Offset: 0x001EEADA
		// (set) Token: 0x060021E2 RID: 8674 RVA: 0x001F08E2 File Offset: 0x001EEAE2
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021E3 RID: 8675 RVA: 0x001F08EC File Offset: 0x001EEAEC
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

		// Token: 0x060021E4 RID: 8676 RVA: 0x001F097C File Offset: 0x001EEB7C
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001F09E5 File Offset: 0x001EEBE5
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001F09F9 File Offset: 0x001EEBF9
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001F0A0D File Offset: 0x001EEC0D
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

		// Token: 0x060021E8 RID: 8680 RVA: 0x001F0A1C File Offset: 0x001EEC1C
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

		// Token: 0x04004A78 RID: 19064
		public Transform SkidTrailPrefab;

		// Token: 0x04004A79 RID: 19065
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004A7A RID: 19066
		public ParticleSystem skidParticles;

		// Token: 0x04004A7D RID: 19069
		private AudioSource m_AudioSource;

		// Token: 0x04004A7E RID: 19070
		private Transform m_SkidTrail;

		// Token: 0x04004A7F RID: 19071
		private WheelCollider m_WheelCollider;
	}
}
