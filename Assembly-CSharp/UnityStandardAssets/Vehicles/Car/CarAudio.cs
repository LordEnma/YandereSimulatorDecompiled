using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000520 RID: 1312
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002165 RID: 8549 RVA: 0x001E8C98 File Offset: 0x001E6E98
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

		// Token: 0x06002166 RID: 8550 RVA: 0x001E8D0C File Offset: 0x001E6F0C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002167 RID: 8551 RVA: 0x001E8D40 File Offset: 0x001E6F40
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

		// Token: 0x06002168 RID: 8552 RVA: 0x001E8FF4 File Offset: 0x001E71F4
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

		// Token: 0x06002169 RID: 8553 RVA: 0x001E9063 File Offset: 0x001E7263
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004952 RID: 18770
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004953 RID: 18771
		public AudioClip lowAccelClip;

		// Token: 0x04004954 RID: 18772
		public AudioClip lowDecelClip;

		// Token: 0x04004955 RID: 18773
		public AudioClip highAccelClip;

		// Token: 0x04004956 RID: 18774
		public AudioClip highDecelClip;

		// Token: 0x04004957 RID: 18775
		public float pitchMultiplier = 1f;

		// Token: 0x04004958 RID: 18776
		public float lowPitchMin = 1f;

		// Token: 0x04004959 RID: 18777
		public float lowPitchMax = 6f;

		// Token: 0x0400495A RID: 18778
		public float highPitchMultiplier = 0.25f;

		// Token: 0x0400495B RID: 18779
		public float maxRolloffDistance = 500f;

		// Token: 0x0400495C RID: 18780
		public float dopplerLevel = 1f;

		// Token: 0x0400495D RID: 18781
		public bool useDoppler = true;

		// Token: 0x0400495E RID: 18782
		private AudioSource m_LowAccel;

		// Token: 0x0400495F RID: 18783
		private AudioSource m_LowDecel;

		// Token: 0x04004960 RID: 18784
		private AudioSource m_HighAccel;

		// Token: 0x04004961 RID: 18785
		private AudioSource m_HighDecel;

		// Token: 0x04004962 RID: 18786
		private bool m_StartedSound;

		// Token: 0x04004963 RID: 18787
		private CarController m_CarController;

		// Token: 0x02000681 RID: 1665
		public enum EngineAudioOptions
		{
			// Token: 0x04004FCD RID: 20429
			Simple,
			// Token: 0x04004FCE RID: 20430
			FourChannel
		}
	}
}
