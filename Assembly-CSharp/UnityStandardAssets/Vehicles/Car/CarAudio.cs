using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x060021AE RID: 8622 RVA: 0x001EF968 File Offset: 0x001EDB68
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

		// Token: 0x060021AF RID: 8623 RVA: 0x001EF9DC File Offset: 0x001EDBDC
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x001EFA10 File Offset: 0x001EDC10
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

		// Token: 0x060021B1 RID: 8625 RVA: 0x001EFCC4 File Offset: 0x001EDEC4
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

		// Token: 0x060021B2 RID: 8626 RVA: 0x001EFD33 File Offset: 0x001EDF33
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004A34 RID: 18996
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004A35 RID: 18997
		public AudioClip lowAccelClip;

		// Token: 0x04004A36 RID: 18998
		public AudioClip lowDecelClip;

		// Token: 0x04004A37 RID: 18999
		public AudioClip highAccelClip;

		// Token: 0x04004A38 RID: 19000
		public AudioClip highDecelClip;

		// Token: 0x04004A39 RID: 19001
		public float pitchMultiplier = 1f;

		// Token: 0x04004A3A RID: 19002
		public float lowPitchMin = 1f;

		// Token: 0x04004A3B RID: 19003
		public float lowPitchMax = 6f;

		// Token: 0x04004A3C RID: 19004
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004A3D RID: 19005
		public float maxRolloffDistance = 500f;

		// Token: 0x04004A3E RID: 19006
		public float dopplerLevel = 1f;

		// Token: 0x04004A3F RID: 19007
		public bool useDoppler = true;

		// Token: 0x04004A40 RID: 19008
		private AudioSource m_LowAccel;

		// Token: 0x04004A41 RID: 19009
		private AudioSource m_LowDecel;

		// Token: 0x04004A42 RID: 19010
		private AudioSource m_HighAccel;

		// Token: 0x04004A43 RID: 19011
		private AudioSource m_HighDecel;

		// Token: 0x04004A44 RID: 19012
		private bool m_StartedSound;

		// Token: 0x04004A45 RID: 19013
		private CarController m_CarController;

		// Token: 0x0200068A RID: 1674
		public enum EngineAudioOptions
		{
			// Token: 0x04005086 RID: 20614
			Simple,
			// Token: 0x04005087 RID: 20615
			FourChannel
		}
	}
}
