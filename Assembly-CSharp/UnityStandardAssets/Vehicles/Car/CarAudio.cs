using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200051E RID: 1310
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x0600215A RID: 8538 RVA: 0x001E82F8 File Offset: 0x001E64F8
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

		// Token: 0x0600215B RID: 8539 RVA: 0x001E836C File Offset: 0x001E656C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x0600215C RID: 8540 RVA: 0x001E83A0 File Offset: 0x001E65A0
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

		// Token: 0x0600215D RID: 8541 RVA: 0x001E8654 File Offset: 0x001E6854
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

		// Token: 0x0600215E RID: 8542 RVA: 0x001E86C3 File Offset: 0x001E68C3
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x0400493E RID: 18750
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x0400493F RID: 18751
		public AudioClip lowAccelClip;

		// Token: 0x04004940 RID: 18752
		public AudioClip lowDecelClip;

		// Token: 0x04004941 RID: 18753
		public AudioClip highAccelClip;

		// Token: 0x04004942 RID: 18754
		public AudioClip highDecelClip;

		// Token: 0x04004943 RID: 18755
		public float pitchMultiplier = 1f;

		// Token: 0x04004944 RID: 18756
		public float lowPitchMin = 1f;

		// Token: 0x04004945 RID: 18757
		public float lowPitchMax = 6f;

		// Token: 0x04004946 RID: 18758
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004947 RID: 18759
		public float maxRolloffDistance = 500f;

		// Token: 0x04004948 RID: 18760
		public float dopplerLevel = 1f;

		// Token: 0x04004949 RID: 18761
		public bool useDoppler = true;

		// Token: 0x0400494A RID: 18762
		private AudioSource m_LowAccel;

		// Token: 0x0400494B RID: 18763
		private AudioSource m_LowDecel;

		// Token: 0x0400494C RID: 18764
		private AudioSource m_HighAccel;

		// Token: 0x0400494D RID: 18765
		private AudioSource m_HighDecel;

		// Token: 0x0400494E RID: 18766
		private bool m_StartedSound;

		// Token: 0x0400494F RID: 18767
		private CarController m_CarController;

		// Token: 0x0200067F RID: 1663
		public enum EngineAudioOptions
		{
			// Token: 0x04004FB9 RID: 20409
			Simple,
			// Token: 0x04004FBA RID: 20410
			FourChannel
		}
	}
}
