using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002167 RID: 8551 RVA: 0x001E9968 File Offset: 0x001E7B68
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

		// Token: 0x06002168 RID: 8552 RVA: 0x001E99DC File Offset: 0x001E7BDC
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x001E9A10 File Offset: 0x001E7C10
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

		// Token: 0x0600216A RID: 8554 RVA: 0x001E9CC4 File Offset: 0x001E7EC4
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

		// Token: 0x0600216B RID: 8555 RVA: 0x001E9D33 File Offset: 0x001E7F33
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004959 RID: 18777
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x0400495A RID: 18778
		public AudioClip lowAccelClip;

		// Token: 0x0400495B RID: 18779
		public AudioClip lowDecelClip;

		// Token: 0x0400495C RID: 18780
		public AudioClip highAccelClip;

		// Token: 0x0400495D RID: 18781
		public AudioClip highDecelClip;

		// Token: 0x0400495E RID: 18782
		public float pitchMultiplier = 1f;

		// Token: 0x0400495F RID: 18783
		public float lowPitchMin = 1f;

		// Token: 0x04004960 RID: 18784
		public float lowPitchMax = 6f;

		// Token: 0x04004961 RID: 18785
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004962 RID: 18786
		public float maxRolloffDistance = 500f;

		// Token: 0x04004963 RID: 18787
		public float dopplerLevel = 1f;

		// Token: 0x04004964 RID: 18788
		public bool useDoppler = true;

		// Token: 0x04004965 RID: 18789
		private AudioSource m_LowAccel;

		// Token: 0x04004966 RID: 18790
		private AudioSource m_LowDecel;

		// Token: 0x04004967 RID: 18791
		private AudioSource m_HighAccel;

		// Token: 0x04004968 RID: 18792
		private AudioSource m_HighDecel;

		// Token: 0x04004969 RID: 18793
		private bool m_StartedSound;

		// Token: 0x0400496A RID: 18794
		private CarController m_CarController;

		// Token: 0x02000682 RID: 1666
		public enum EngineAudioOptions
		{
			// Token: 0x04004FD4 RID: 20436
			Simple,
			// Token: 0x04004FD5 RID: 20437
			FourChannel
		}
	}
}
