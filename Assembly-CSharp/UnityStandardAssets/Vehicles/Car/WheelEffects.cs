using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000539 RID: 1337
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06002202 RID: 8706 RVA: 0x001F442D File Offset: 0x001F262D
		// (set) Token: 0x06002203 RID: 8707 RVA: 0x001F4435 File Offset: 0x001F2635
		public bool skidding { get; private set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06002204 RID: 8708 RVA: 0x001F443E File Offset: 0x001F263E
		// (set) Token: 0x06002205 RID: 8709 RVA: 0x001F4446 File Offset: 0x001F2646
		public bool PlayingAudio { get; private set; }

		// Token: 0x06002206 RID: 8710 RVA: 0x001F4450 File Offset: 0x001F2650
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

		// Token: 0x06002207 RID: 8711 RVA: 0x001F44E0 File Offset: 0x001F26E0
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001F4549 File Offset: 0x001F2749
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001F455D File Offset: 0x001F275D
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001F4571 File Offset: 0x001F2771
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

		// Token: 0x0600220B RID: 8715 RVA: 0x001F4580 File Offset: 0x001F2780
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

		// Token: 0x04004ACB RID: 19147
		public Transform SkidTrailPrefab;

		// Token: 0x04004ACC RID: 19148
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004ACD RID: 19149
		public ParticleSystem skidParticles;

		// Token: 0x04004AD0 RID: 19152
		private AudioSource m_AudioSource;

		// Token: 0x04004AD1 RID: 19153
		private Transform m_SkidTrail;

		// Token: 0x04004AD2 RID: 19154
		private WheelCollider m_WheelCollider;
	}
}
