using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052E RID: 1326
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x060021B6 RID: 8630 RVA: 0x001EFE98 File Offset: 0x001EE098
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

		// Token: 0x060021B7 RID: 8631 RVA: 0x001EFF0C File Offset: 0x001EE10C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x001EFF40 File Offset: 0x001EE140
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

		// Token: 0x060021B9 RID: 8633 RVA: 0x001F01F4 File Offset: 0x001EE3F4
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

		// Token: 0x060021BA RID: 8634 RVA: 0x001F0263 File Offset: 0x001EE463
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004A38 RID: 19000
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004A39 RID: 19001
		public AudioClip lowAccelClip;

		// Token: 0x04004A3A RID: 19002
		public AudioClip lowDecelClip;

		// Token: 0x04004A3B RID: 19003
		public AudioClip highAccelClip;

		// Token: 0x04004A3C RID: 19004
		public AudioClip highDecelClip;

		// Token: 0x04004A3D RID: 19005
		public float pitchMultiplier = 1f;

		// Token: 0x04004A3E RID: 19006
		public float lowPitchMin = 1f;

		// Token: 0x04004A3F RID: 19007
		public float lowPitchMax = 6f;

		// Token: 0x04004A40 RID: 19008
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004A41 RID: 19009
		public float maxRolloffDistance = 500f;

		// Token: 0x04004A42 RID: 19010
		public float dopplerLevel = 1f;

		// Token: 0x04004A43 RID: 19011
		public bool useDoppler = true;

		// Token: 0x04004A44 RID: 19012
		private AudioSource m_LowAccel;

		// Token: 0x04004A45 RID: 19013
		private AudioSource m_LowDecel;

		// Token: 0x04004A46 RID: 19014
		private AudioSource m_HighAccel;

		// Token: 0x04004A47 RID: 19015
		private AudioSource m_HighDecel;

		// Token: 0x04004A48 RID: 19016
		private bool m_StartedSound;

		// Token: 0x04004A49 RID: 19017
		private CarController m_CarController;

		// Token: 0x0200068B RID: 1675
		public enum EngineAudioOptions
		{
			// Token: 0x0400508A RID: 20618
			Simple,
			// Token: 0x0400508B RID: 20619
			FourChannel
		}
	}
}
