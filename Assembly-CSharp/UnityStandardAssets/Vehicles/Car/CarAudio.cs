using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000524 RID: 1316
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002186 RID: 8582 RVA: 0x001EC190 File Offset: 0x001EA390
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

		// Token: 0x06002187 RID: 8583 RVA: 0x001EC204 File Offset: 0x001EA404
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x001EC238 File Offset: 0x001EA438
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

		// Token: 0x06002189 RID: 8585 RVA: 0x001EC4EC File Offset: 0x001EA6EC
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

		// Token: 0x0600218A RID: 8586 RVA: 0x001EC55B File Offset: 0x001EA75B
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x040049A3 RID: 18851
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x040049A4 RID: 18852
		public AudioClip lowAccelClip;

		// Token: 0x040049A5 RID: 18853
		public AudioClip lowDecelClip;

		// Token: 0x040049A6 RID: 18854
		public AudioClip highAccelClip;

		// Token: 0x040049A7 RID: 18855
		public AudioClip highDecelClip;

		// Token: 0x040049A8 RID: 18856
		public float pitchMultiplier = 1f;

		// Token: 0x040049A9 RID: 18857
		public float lowPitchMin = 1f;

		// Token: 0x040049AA RID: 18858
		public float lowPitchMax = 6f;

		// Token: 0x040049AB RID: 18859
		public float highPitchMultiplier = 0.25f;

		// Token: 0x040049AC RID: 18860
		public float maxRolloffDistance = 500f;

		// Token: 0x040049AD RID: 18861
		public float dopplerLevel = 1f;

		// Token: 0x040049AE RID: 18862
		public bool useDoppler = true;

		// Token: 0x040049AF RID: 18863
		private AudioSource m_LowAccel;

		// Token: 0x040049B0 RID: 18864
		private AudioSource m_LowDecel;

		// Token: 0x040049B1 RID: 18865
		private AudioSource m_HighAccel;

		// Token: 0x040049B2 RID: 18866
		private AudioSource m_HighDecel;

		// Token: 0x040049B3 RID: 18867
		private bool m_StartedSound;

		// Token: 0x040049B4 RID: 18868
		private CarController m_CarController;

		// Token: 0x02000681 RID: 1665
		public enum EngineAudioOptions
		{
			// Token: 0x04004FF5 RID: 20469
			Simple,
			// Token: 0x04004FF6 RID: 20470
			FourChannel
		}
	}
}
