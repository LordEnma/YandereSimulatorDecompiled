using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060024B0 RID: 9392 RVA: 0x00200874 File Offset: 0x001FEA74
		public static SFXController Instance
		{
			get
			{
				if (SFXController.instance == null)
				{
					SFXController.instance = UnityEngine.Object.FindObjectOfType<SFXController>();
				}
				return SFXController.instance;
			}
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x00200892 File Offset: 0x001FEA92
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x002008B8 File Offset: 0x001FEAB8
		public static void PlaySound(SFXController.Sounds sound)
		{
			SoundEmitter emitter = SFXController.Instance.GetEmitter(sound);
			AudioSource source = emitter.GetSource();
			if (!source.isPlaying || emitter.interupt)
			{
				source.clip = SFXController.Instance.GetRandomClip(emitter);
				source.Play();
			}
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00200900 File Offset: 0x001FEB00
		private SoundEmitter GetEmitter(SFXController.Sounds sound)
		{
			foreach (SoundEmitter soundEmitter in this.emitters)
			{
				if (soundEmitter.sound == sound)
				{
					return soundEmitter;
				}
			}
			Debug.Log(string.Format("There is no sound emitter created for {0}", sound), this);
			return null;
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x0020096C File Offset: 0x001FEB6C
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004D1A RID: 19738
		private static SFXController instance;

		// Token: 0x04004D1B RID: 19739
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006E9 RID: 1769
		public enum Sounds
		{
			// Token: 0x04005289 RID: 21129
			Countdown,
			// Token: 0x0400528A RID: 21130
			MenuBack,
			// Token: 0x0400528B RID: 21131
			MenuConfirm,
			// Token: 0x0400528C RID: 21132
			ClockTick,
			// Token: 0x0400528D RID: 21133
			DoorBell,
			// Token: 0x0400528E RID: 21134
			GameFail,
			// Token: 0x0400528F RID: 21135
			GameSuccess,
			// Token: 0x04005290 RID: 21136
			Plate,
			// Token: 0x04005291 RID: 21137
			PageTurn,
			// Token: 0x04005292 RID: 21138
			MenuSelect,
			// Token: 0x04005293 RID: 21139
			MaleCustomerGreet,
			// Token: 0x04005294 RID: 21140
			MaleCustomerThank,
			// Token: 0x04005295 RID: 21141
			MaleCustomerLeave,
			// Token: 0x04005296 RID: 21142
			FemaleCustomerGreet,
			// Token: 0x04005297 RID: 21143
			FemaleCustomerThank,
			// Token: 0x04005298 RID: 21144
			FemaleCustomerLeave,
			// Token: 0x04005299 RID: 21145
			MenuOpen
		}
	}
}
