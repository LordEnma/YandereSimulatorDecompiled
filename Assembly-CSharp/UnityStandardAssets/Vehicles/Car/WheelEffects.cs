using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000538 RID: 1336
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060021F7 RID: 8695 RVA: 0x001F2CE1 File Offset: 0x001F0EE1
		// (set) Token: 0x060021F8 RID: 8696 RVA: 0x001F2CE9 File Offset: 0x001F0EE9
		public bool skidding { get; private set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060021F9 RID: 8697 RVA: 0x001F2CF2 File Offset: 0x001F0EF2
		// (set) Token: 0x060021FA RID: 8698 RVA: 0x001F2CFA File Offset: 0x001F0EFA
		public bool PlayingAudio { get; private set; }

		// Token: 0x060021FB RID: 8699 RVA: 0x001F2D04 File Offset: 0x001F0F04
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

		// Token: 0x060021FC RID: 8700 RVA: 0x001F2D94 File Offset: 0x001F0F94
		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001F2DFD File Offset: 0x001F0FFD
		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001F2E11 File Offset: 0x001F1011
		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001F2E25 File Offset: 0x001F1025
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

		// Token: 0x06002200 RID: 8704 RVA: 0x001F2E34 File Offset: 0x001F1034
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

		// Token: 0x04004AA4 RID: 19108
		public Transform SkidTrailPrefab;

		// Token: 0x04004AA5 RID: 19109
		public static Transform skidTrailsDetachedParent;

		// Token: 0x04004AA6 RID: 19110
		public ParticleSystem skidParticles;

		// Token: 0x04004AA9 RID: 19113
		private AudioSource m_AudioSource;

		// Token: 0x04004AAA RID: 19114
		private Transform m_SkidTrail;

		// Token: 0x04004AAB RID: 19115
		private WheelCollider m_WheelCollider;
	}
}
