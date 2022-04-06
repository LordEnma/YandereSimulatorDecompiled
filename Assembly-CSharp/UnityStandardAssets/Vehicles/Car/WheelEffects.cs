using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000537 RID: 1335
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021E7 RID: 8679 RVA: 0x001F0DF9 File Offset: 0x001EEFF9
		// (set) Token: 0x060021E8 RID: 8680 RVA: 0x001F0E01 File Offset: 0x001EF001
		public bool skidding { get; private set; }

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021E9 RID: 8681 RVA: 0x001F0E0A File Offset: 0x001EF00A
		// (set) Token: 0x060021EA RID: 8682 RVA: 0x001F0E12 File Offset: 0x001EF012
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021EB RID: 8683 RVA: 0x001F0E1C File Offset: 0x001EF01C
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

		// Token: 0x060021EC RID: 8684 RVA: 0x001F0EAC File Offset: 0x001EF0AC
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001F0F15 File Offset: 0x001EF115
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001F0F29 File Offset: 0x001EF129
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001F0F3D File Offset: 0x001EF13D
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

		// Token: 0x060021F0 RID: 8688 RVA: 0x001F0F4C File Offset: 0x001EF14C
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

		// Token: 0x04004A7C RID: 19068
		public Transform SkidTrailPrefab;

		// Token: 0x04004A7D RID: 19069
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004A7E RID: 19070
		public ParticleSystem skidParticles;

		// Token: 0x04004A81 RID: 19073
		private AudioSource m_AudioSource;

		// Token: 0x04004A82 RID: 19074
		private Transform m_SkidTrail;

		// Token: 0x04004A83 RID: 19075
		private WheelCollider m_WheelCollider;
	}
}
