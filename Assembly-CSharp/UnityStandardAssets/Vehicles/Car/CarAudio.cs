using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x0600216B RID: 8555 RVA: 0x001EA208 File Offset: 0x001E8408
		private void StartSound()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_HighAccel = this.SetUpEngineAudioSource(this.highAccelClip);
			if (this.engineSoundStyle == CarAudio.EngineAudioOptions.FourChannel)
			{
				this.m_LowAccel = this.SetUpEngineAudioSource(this.lowAccelClip);
				this.m_LowDecel = this.SetUpEngineAudioSource(this.lowDecelClip);
				this.m_HighDecel = this.SetUpEngineAudioSource(this.highDecelClip);
			}
			this.m_StartedSound = true;
		}

		// Token: 0x0600216C RID: 8556 RVA: 0x001EA27C File Offset: 0x001E847C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x001EA2B0 File Offset: 0x001E84B0
		private void Update()
		{
			float sqrMagnitude = (Camera.main.transform.position - base.transform.position).sqrMagnitude;
			if (this.m_StartedSound && sqrMagnitude > this.maxRolloffDistance * this.maxRolloffDistance)
			{
				this.StopSound();
			}
			if (!this.m_StartedSound && sqrMagnitude < this.maxRolloffDistance * this.maxRolloffDistance)
			{
				this.StartSound();
			}
			if (this.m_StartedSound)
			{
				float num = CarAudio.ULerp(this.lowPitchMin, this.lowPitchMax, this.m_CarController.Revs);
				num = Mathf.Min(this.lowPitchMax, num);
				if (this.engineSoundStyle == CarAudio.EngineAudioOptions.Simple)
				{
					this.m_HighAccel.pitch = num * this.pitchMultiplier * this.highPitchMultiplier;
					this.m_HighAccel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
					this.m_HighAccel.volume = 1f;
					return;
				}
				this.m_LowAccel.pitch = num * this.pitchMultiplier;
				this.m_LowDecel.pitch = num * this.pitchMultiplier;
				this.m_HighAccel.pitch = num * this.highPitchMultiplier * this.pitchMultiplier;
				this.m_HighDecel.pitch = num * this.highPitchMultiplier * this.pitchMultiplier;
				float num2 = Mathf.Abs(this.m_CarController.AccelInput);
				float num3 = 1f - num2;
				float num4 = Mathf.InverseLerp(0.2f, 0.8f, this.m_CarController.Revs);
				float num5 = 1f - num4;
				num4 = 1f - (1f - num4) * (1f - num4);
				num5 = 1f - (1f - num5) * (1f - num5);
				num2 = 1f - (1f - num2) * (1f - num2);
				num3 = 1f - (1f - num3) * (1f - num3);
				this.m_LowAccel.volume = num5 * num2;
				this.m_LowDecel.volume = num5 * num3;
				this.m_HighAccel.volume = num4 * num2;
				this.m_HighDecel.volume = num4 * num3;
				this.m_HighAccel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
				this.m_LowAccel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
				this.m_HighDecel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
				this.m_LowDecel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
			}
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x001EA564 File Offset: 0x001E8764
		private AudioSource SetUpEngineAudioSource(AudioClip clip)
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.volume = 0f;
			audioSource.loop = true;
			audioSource.time = UnityEngine.Random.Range(0f, clip.length);
			audioSource.Play();
			audioSource.minDistance = 5f;
			audioSource.maxDistance = this.maxRolloffDistance;
			audioSource.dopplerLevel = 0f;
			return audioSource;
		}

		// Token: 0x0600216F RID: 8559 RVA: 0x001EA5D3 File Offset: 0x001E87D3
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004964 RID: 18788
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004965 RID: 18789
		public AudioClip lowAccelClip;

		// Token: 0x04004966 RID: 18790
		public AudioClip lowDecelClip;

		// Token: 0x04004967 RID: 18791
		public AudioClip highAccelClip;

		// Token: 0x04004968 RID: 18792
		public AudioClip highDecelClip;

		// Token: 0x04004969 RID: 18793
		public float pitchMultiplier = 1f;

		// Token: 0x0400496A RID: 18794
		public float lowPitchMin = 1f;

		// Token: 0x0400496B RID: 18795
		public float lowPitchMax = 6f;

		// Token: 0x0400496C RID: 18796
		public float highPitchMultiplier = 0.25f;

		// Token: 0x0400496D RID: 18797
		public float maxRolloffDistance = 500f;

		// Token: 0x0400496E RID: 18798
		public float dopplerLevel = 1f;

		// Token: 0x0400496F RID: 18799
		public bool useDoppler = true;

		// Token: 0x04004970 RID: 18800
		private AudioSource m_LowAccel;

		// Token: 0x04004971 RID: 18801
		private AudioSource m_LowDecel;

		// Token: 0x04004972 RID: 18802
		private AudioSource m_HighAccel;

		// Token: 0x04004973 RID: 18803
		private AudioSource m_HighDecel;

		// Token: 0x04004974 RID: 18804
		private bool m_StartedSound;

		// Token: 0x04004975 RID: 18805
		private CarController m_CarController;

		// Token: 0x0200067C RID: 1660
		public enum EngineAudioOptions
		{
			// Token: 0x04004FB1 RID: 20401
			Simple,
			// Token: 0x04004FB2 RID: 20402
			FourChannel
		}
	}
}
