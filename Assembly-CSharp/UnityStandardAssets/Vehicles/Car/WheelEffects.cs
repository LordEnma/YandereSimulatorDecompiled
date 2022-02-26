using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052C RID: 1324
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060021B1 RID: 8625 RVA: 0x001EC719 File Offset: 0x001EA919
		// (set) Token: 0x060021B2 RID: 8626 RVA: 0x001EC721 File Offset: 0x001EA921
		public bool skidding { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060021B3 RID: 8627 RVA: 0x001EC72A File Offset: 0x001EA92A
		// (set) Token: 0x060021B4 RID: 8628 RVA: 0x001EC732 File Offset: 0x001EA932
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021B5 RID: 8629 RVA: 0x001EC73C File Offset: 0x001EA93C
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

		// Token: 0x060021B6 RID: 8630 RVA: 0x001EC7CC File Offset: 0x001EA9CC
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021B7 RID: 8631 RVA: 0x001EC835 File Offset: 0x001EAA35
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x001EC849 File Offset: 0x001EAA49
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x001EC85D File Offset: 0x001EAA5D
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

		// Token: 0x060021BA RID: 8634 RVA: 0x001EC86C File Offset: 0x001EAA6C
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

		// Token: 0x040049CA RID: 18890
		public Transform SkidTrailPrefab;

		// Token: 0x040049CB RID: 18891
		public static Transform skidTrailsDetachedParent;

		// Token: 0x040049CC RID: 18892
		public ParticleSystem skidParticles;

		// Token: 0x040049CF RID: 18895
		private AudioSource m_AudioSource;

		// Token: 0x040049D0 RID: 18896
		private Transform m_SkidTrail;

		// Token: 0x040049D1 RID: 18897
		private WheelCollider m_WheelCollider;
	}
}
