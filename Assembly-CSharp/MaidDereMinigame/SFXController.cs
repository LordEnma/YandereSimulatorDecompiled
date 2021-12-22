using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x0600244A RID: 9290 RVA: 0x001F7C88 File Offset: 0x001F5E88
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

		// Token: 0x0600244B RID: 9291 RVA: 0x001F7CA6 File Offset: 0x001F5EA6
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600244C RID: 9292 RVA: 0x001F7CCC File Offset: 0x001F5ECC
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

		// Token: 0x0600244D RID: 9293 RVA: 0x001F7D14 File Offset: 0x001F5F14
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

		// Token: 0x0600244E RID: 9294 RVA: 0x001F7D80 File Offset: 0x001F5F80
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C05 RID: 19461
		private static SFXController instance;

		// Token: 0x04004C06 RID: 19462
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DD RID: 1757
		public enum Sounds
		{
			// Token: 0x0400519D RID: 20893
			Countdown,
			// Token: 0x0400519E RID: 20894
			MenuBack,
			// Token: 0x0400519F RID: 20895
			MenuConfirm,
			// Token: 0x040051A0 RID: 20896
			ClockTick,
			// Token: 0x040051A1 RID: 20897
			DoorBell,
			// Token: 0x040051A2 RID: 20898
			GameFail,
			// Token: 0x040051A3 RID: 20899
			GameSuccess,
			// Token: 0x040051A4 RID: 20900
			Plate,
			// Token: 0x040051A5 RID: 20901
			PageTurn,
			// Token: 0x040051A6 RID: 20902
			MenuSelect,
			// Token: 0x040051A7 RID: 20903
			MaleCustomerGreet,
			// Token: 0x040051A8 RID: 20904
			MaleCustomerThank,
			// Token: 0x040051A9 RID: 20905
			MaleCustomerLeave,
			// Token: 0x040051AA RID: 20906
			FemaleCustomerGreet,
			// Token: 0x040051AB RID: 20907
			FemaleCustomerThank,
			// Token: 0x040051AC RID: 20908
			FemaleCustomerLeave,
			// Token: 0x040051AD RID: 20909
			MenuOpen
		}
	}
}
