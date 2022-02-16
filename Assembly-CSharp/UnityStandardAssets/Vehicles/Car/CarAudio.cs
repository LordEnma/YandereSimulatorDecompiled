using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000522 RID: 1314
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002177 RID: 8567 RVA: 0x001EABD8 File Offset: 0x001E8DD8
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

		// Token: 0x06002178 RID: 8568 RVA: 0x001EAC4C File Offset: 0x001E8E4C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002179 RID: 8569 RVA: 0x001EAC80 File Offset: 0x001E8E80
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

		// Token: 0x0600217A RID: 8570 RVA: 0x001EAF34 File Offset: 0x001E9134
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

		// Token: 0x0600217B RID: 8571 RVA: 0x001EAFA3 File Offset: 0x001E91A3
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004976 RID: 18806
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004977 RID: 18807
		public AudioClip lowAccelClip;

		// Token: 0x04004978 RID: 18808
		public AudioClip lowDecelClip;

		// Token: 0x04004979 RID: 18809
		public AudioClip highAccelClip;

		// Token: 0x0400497A RID: 18810
		public AudioClip highDecelClip;

		// Token: 0x0400497B RID: 18811
		public float pitchMultiplier = 1f;

		// Token: 0x0400497C RID: 18812
		public float lowPitchMin = 1f;

		// Token: 0x0400497D RID: 18813
		public float lowPitchMax = 6f;

		// Token: 0x0400497E RID: 18814
		public float highPitchMultiplier = 0.25f;

		// Token: 0x0400497F RID: 18815
		public float maxRolloffDistance = 500f;

		// Token: 0x04004980 RID: 18816
		public float dopplerLevel = 1f;

		// Token: 0x04004981 RID: 18817
		public bool useDoppler = true;

		// Token: 0x04004982 RID: 18818
		private AudioSource m_LowAccel;

		// Token: 0x04004983 RID: 18819
		private AudioSource m_LowDecel;

		// Token: 0x04004984 RID: 18820
		private AudioSource m_HighAccel;

		// Token: 0x04004985 RID: 18821
		private AudioSource m_HighDecel;

		// Token: 0x04004986 RID: 18822
		private bool m_StartedSound;

		// Token: 0x04004987 RID: 18823
		private CarController m_CarController;

		// Token: 0x0200067D RID: 1661
		public enum EngineAudioOptions
		{
			// Token: 0x04004FC3 RID: 20419
			Simple,
			// Token: 0x04004FC4 RID: 20420
			FourChannel
		}
	}
}
