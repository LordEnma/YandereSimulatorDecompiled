using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052F RID: 1327
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x060021C7 RID: 8647 RVA: 0x001F1E7C File Offset: 0x001F007C
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

		// Token: 0x060021C8 RID: 8648 RVA: 0x001F1EF0 File Offset: 0x001F00F0
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x001F1F24 File Offset: 0x001F0124
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

		// Token: 0x060021CA RID: 8650 RVA: 0x001F21D8 File Offset: 0x001F03D8
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

		// Token: 0x060021CB RID: 8651 RVA: 0x001F2247 File Offset: 0x001F0447
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004A60 RID: 19040
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004A61 RID: 19041
		public AudioClip lowAccelClip;

		// Token: 0x04004A62 RID: 19042
		public AudioClip lowDecelClip;

		// Token: 0x04004A63 RID: 19043
		public AudioClip highAccelClip;

		// Token: 0x04004A64 RID: 19044
		public AudioClip highDecelClip;

		// Token: 0x04004A65 RID: 19045
		public float pitchMultiplier = 1f;

		// Token: 0x04004A66 RID: 19046
		public float lowPitchMin = 1f;

		// Token: 0x04004A67 RID: 19047
		public float lowPitchMax = 6f;

		// Token: 0x04004A68 RID: 19048
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004A69 RID: 19049
		public float maxRolloffDistance = 500f;

		// Token: 0x04004A6A RID: 19050
		public float dopplerLevel = 1f;

		// Token: 0x04004A6B RID: 19051
		public bool useDoppler = true;

		// Token: 0x04004A6C RID: 19052
		private AudioSource m_LowAccel;

		// Token: 0x04004A6D RID: 19053
		private AudioSource m_LowDecel;

		// Token: 0x04004A6E RID: 19054
		private AudioSource m_HighAccel;

		// Token: 0x04004A6F RID: 19055
		private AudioSource m_HighDecel;

		// Token: 0x04004A70 RID: 19056
		private bool m_StartedSound;

		// Token: 0x04004A71 RID: 19057
		private CarController m_CarController;

		// Token: 0x0200068C RID: 1676
		public enum EngineAudioOptions
		{
			// Token: 0x040050BA RID: 20666
			Simple,
			// Token: 0x040050BB RID: 20667
			FourChannel
		}
	}
}
