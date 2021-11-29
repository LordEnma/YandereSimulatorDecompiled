using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051C RID: 1308
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002146 RID: 8518 RVA: 0x001E65D4 File Offset: 0x001E47D4
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

		// Token: 0x06002147 RID: 8519 RVA: 0x001E6648 File Offset: 0x001E4848
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002148 RID: 8520 RVA: 0x001E667C File Offset: 0x001E487C
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

		// Token: 0x06002149 RID: 8521 RVA: 0x001E6930 File Offset: 0x001E4B30
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

		// Token: 0x0600214A RID: 8522 RVA: 0x001E699F File Offset: 0x001E4B9F
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x040048F6 RID: 18678
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x040048F7 RID: 18679
		public AudioClip lowAccelClip;

		// Token: 0x040048F8 RID: 18680
		public AudioClip lowDecelClip;

		// Token: 0x040048F9 RID: 18681
		public AudioClip highAccelClip;

		// Token: 0x040048FA RID: 18682
		public AudioClip highDecelClip;

		// Token: 0x040048FB RID: 18683
		public float pitchMultiplier = 1f;

		// Token: 0x040048FC RID: 18684
		public float lowPitchMin = 1f;

		// Token: 0x040048FD RID: 18685
		public float lowPitchMax = 6f;

		// Token: 0x040048FE RID: 18686
		public float highPitchMultiplier = 0.25f;

		// Token: 0x040048FF RID: 18687
		public float maxRolloffDistance = 500f;

		// Token: 0x04004900 RID: 18688
		public float dopplerLevel = 1f;

		// Token: 0x04004901 RID: 18689
		public bool useDoppler = true;

		// Token: 0x04004902 RID: 18690
		private AudioSource m_LowAccel;

		// Token: 0x04004903 RID: 18691
		private AudioSource m_LowDecel;

		// Token: 0x04004904 RID: 18692
		private AudioSource m_HighAccel;

		// Token: 0x04004905 RID: 18693
		private AudioSource m_HighDecel;

		// Token: 0x04004906 RID: 18694
		private bool m_StartedSound;

		// Token: 0x04004907 RID: 18695
		private CarController m_CarController;

		// Token: 0x0200067C RID: 1660
		public enum EngineAudioOptions
		{
			// Token: 0x04004F65 RID: 20325
			Simple,
			// Token: 0x04004F66 RID: 20326
			FourChannel
		}
	}
}
