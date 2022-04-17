using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000537 RID: 1335
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021EE RID: 8686 RVA: 0x001F1855 File Offset: 0x001EFA55
		// (set) Token: 0x060021EF RID: 8687 RVA: 0x001F185D File Offset: 0x001EFA5D
		public bool skidding { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021F0 RID: 8688 RVA: 0x001F1866 File Offset: 0x001EFA66
		// (set) Token: 0x060021F1 RID: 8689 RVA: 0x001F186E File Offset: 0x001EFA6E
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021F2 RID: 8690 RVA: 0x001F1878 File Offset: 0x001EFA78
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

		// Token: 0x060021F3 RID: 8691 RVA: 0x001F1908 File Offset: 0x001EFB08
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001F1971 File Offset: 0x001EFB71
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001F1985 File Offset: 0x001EFB85
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001F1999 File Offset: 0x001EFB99
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

		// Token: 0x060021F7 RID: 8695 RVA: 0x001F19A8 File Offset: 0x001EFBA8
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

		// Token: 0x04004A8E RID: 19086
		public Transform SkidTrailPrefab;

		// Token: 0x04004A8F RID: 19087
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004A90 RID: 19088
		public ParticleSystem skidParticles;

		// Token: 0x04004A93 RID: 19091
		private AudioSource m_AudioSource;

		// Token: 0x04004A94 RID: 19092
		private Transform m_SkidTrail;

		// Token: 0x04004A95 RID: 19093
		private WheelCollider m_WheelCollider;
	}
}
