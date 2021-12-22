using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051E RID: 1310
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002157 RID: 8535 RVA: 0x001E7D08 File Offset: 0x001E5F08
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

		// Token: 0x06002158 RID: 8536 RVA: 0x001E7D7C File Offset: 0x001E5F7C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x001E7DB0 File Offset: 0x001E5FB0
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

		// Token: 0x0600215A RID: 8538 RVA: 0x001E8064 File Offset: 0x001E6264
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

		// Token: 0x0600215B RID: 8539 RVA: 0x001E80D3 File Offset: 0x001E62D3
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004935 RID: 18741
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004936 RID: 18742
		public AudioClip lowAccelClip;

		// Token: 0x04004937 RID: 18743
		public AudioClip lowDecelClip;

		// Token: 0x04004938 RID: 18744
		public AudioClip highAccelClip;

		// Token: 0x04004939 RID: 18745
		public AudioClip highDecelClip;

		// Token: 0x0400493A RID: 18746
		public float pitchMultiplier = 1f;

		// Token: 0x0400493B RID: 18747
		public float lowPitchMin = 1f;

		// Token: 0x0400493C RID: 18748
		public float lowPitchMax = 6f;

		// Token: 0x0400493D RID: 18749
		public float highPitchMultiplier = 0.25f;

		// Token: 0x0400493E RID: 18750
		public float maxRolloffDistance = 500f;

		// Token: 0x0400493F RID: 18751
		public float dopplerLevel = 1f;

		// Token: 0x04004940 RID: 18752
		public bool useDoppler = true;

		// Token: 0x04004941 RID: 18753
		private AudioSource m_LowAccel;

		// Token: 0x04004942 RID: 18754
		private AudioSource m_LowDecel;

		// Token: 0x04004943 RID: 18755
		private AudioSource m_HighAccel;

		// Token: 0x04004944 RID: 18756
		private AudioSource m_HighDecel;

		// Token: 0x04004945 RID: 18757
		private bool m_StartedSound;

		// Token: 0x04004946 RID: 18758
		private CarController m_CarController;

		// Token: 0x0200067F RID: 1663
		public enum EngineAudioOptions
		{
			// Token: 0x04004FB0 RID: 20400
			Simple,
			// Token: 0x04004FB1 RID: 20401
			FourChannel
		}
	}
}
