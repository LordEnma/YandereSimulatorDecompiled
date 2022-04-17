using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052E RID: 1326
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x060021BD RID: 8637 RVA: 0x001F08F4 File Offset: 0x001EEAF4
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

		// Token: 0x060021BE RID: 8638 RVA: 0x001F0968 File Offset: 0x001EEB68
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x001F099C File Offset: 0x001EEB9C
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

		// Token: 0x060021C0 RID: 8640 RVA: 0x001F0C50 File Offset: 0x001EEE50
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

		// Token: 0x060021C1 RID: 8641 RVA: 0x001F0CBF File Offset: 0x001EEEBF
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004A4A RID: 19018
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004A4B RID: 19019
		public AudioClip lowAccelClip;

		// Token: 0x04004A4C RID: 19020
		public AudioClip lowDecelClip;

		// Token: 0x04004A4D RID: 19021
		public AudioClip highAccelClip;

		// Token: 0x04004A4E RID: 19022
		public AudioClip highDecelClip;

		// Token: 0x04004A4F RID: 19023
		public float pitchMultiplier = 1f;

		// Token: 0x04004A50 RID: 19024
		public float lowPitchMin = 1f;

		// Token: 0x04004A51 RID: 19025
		public float lowPitchMax = 6f;

		// Token: 0x04004A52 RID: 19026
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004A53 RID: 19027
		public float maxRolloffDistance = 500f;

		// Token: 0x04004A54 RID: 19028
		public float dopplerLevel = 1f;

		// Token: 0x04004A55 RID: 19029
		public bool useDoppler = true;

		// Token: 0x04004A56 RID: 19030
		private AudioSource m_LowAccel;

		// Token: 0x04004A57 RID: 19031
		private AudioSource m_LowDecel;

		// Token: 0x04004A58 RID: 19032
		private AudioSource m_HighAccel;

		// Token: 0x04004A59 RID: 19033
		private AudioSource m_HighDecel;

		// Token: 0x04004A5A RID: 19034
		private bool m_StartedSound;

		// Token: 0x04004A5B RID: 19035
		private CarController m_CarController;

		// Token: 0x0200068B RID: 1675
		public enum EngineAudioOptions
		{
			// Token: 0x0400509C RID: 20636
			Simple,
			// Token: 0x0400509D RID: 20637
			FourChannel
		}
	}
}
