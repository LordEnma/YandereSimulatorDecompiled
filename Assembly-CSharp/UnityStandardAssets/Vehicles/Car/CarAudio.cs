using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000523 RID: 1315
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002180 RID: 8576 RVA: 0x001EB7B8 File Offset: 0x001E99B8
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

		// Token: 0x06002181 RID: 8577 RVA: 0x001EB82C File Offset: 0x001E9A2C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002182 RID: 8578 RVA: 0x001EB860 File Offset: 0x001E9A60
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

		// Token: 0x06002183 RID: 8579 RVA: 0x001EBB14 File Offset: 0x001E9D14
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

		// Token: 0x06002184 RID: 8580 RVA: 0x001EBB83 File Offset: 0x001E9D83
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004986 RID: 18822
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004987 RID: 18823
		public AudioClip lowAccelClip;

		// Token: 0x04004988 RID: 18824
		public AudioClip lowDecelClip;

		// Token: 0x04004989 RID: 18825
		public AudioClip highAccelClip;

		// Token: 0x0400498A RID: 18826
		public AudioClip highDecelClip;

		// Token: 0x0400498B RID: 18827
		public float pitchMultiplier = 1f;

		// Token: 0x0400498C RID: 18828
		public float lowPitchMin = 1f;

		// Token: 0x0400498D RID: 18829
		public float lowPitchMax = 6f;

		// Token: 0x0400498E RID: 18830
		public float highPitchMultiplier = 0.25f;

		// Token: 0x0400498F RID: 18831
		public float maxRolloffDistance = 500f;

		// Token: 0x04004990 RID: 18832
		public float dopplerLevel = 1f;

		// Token: 0x04004991 RID: 18833
		public bool useDoppler = true;

		// Token: 0x04004992 RID: 18834
		private AudioSource m_LowAccel;

		// Token: 0x04004993 RID: 18835
		private AudioSource m_LowDecel;

		// Token: 0x04004994 RID: 18836
		private AudioSource m_HighAccel;

		// Token: 0x04004995 RID: 18837
		private AudioSource m_HighDecel;

		// Token: 0x04004996 RID: 18838
		private bool m_StartedSound;

		// Token: 0x04004997 RID: 18839
		private CarController m_CarController;

		// Token: 0x02000680 RID: 1664
		public enum EngineAudioOptions
		{
			// Token: 0x04004FD8 RID: 20440
			Simple,
			// Token: 0x04004FD9 RID: 20441
			FourChannel
		}
	}
}
