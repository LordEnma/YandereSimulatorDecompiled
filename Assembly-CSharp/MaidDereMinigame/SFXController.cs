using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600245E RID: 9310 RVA: 0x001FA188 File Offset: 0x001F8388
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

		// Token: 0x0600245F RID: 9311 RVA: 0x001FA1A6 File Offset: 0x001F83A6
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001FA1CC File Offset: 0x001F83CC
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

		// Token: 0x06002461 RID: 9313 RVA: 0x001FA214 File Offset: 0x001F8414
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

		// Token: 0x06002462 RID: 9314 RVA: 0x001FA280 File Offset: 0x001F8480
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C34 RID: 19508
		private static SFXController instance;

		// Token: 0x04004C35 RID: 19509
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DA RID: 1754
		public enum Sounds
		{
			// Token: 0x0400519E RID: 20894
			Countdown,
			// Token: 0x0400519F RID: 20895
			MenuBack,
			// Token: 0x040051A0 RID: 20896
			MenuConfirm,
			// Token: 0x040051A1 RID: 20897
			ClockTick,
			// Token: 0x040051A2 RID: 20898
			DoorBell,
			// Token: 0x040051A3 RID: 20899
			GameFail,
			// Token: 0x040051A4 RID: 20900
			GameSuccess,
			// Token: 0x040051A5 RID: 20901
			Plate,
			// Token: 0x040051A6 RID: 20902
			PageTurn,
			// Token: 0x040051A7 RID: 20903
			MenuSelect,
			// Token: 0x040051A8 RID: 20904
			MaleCustomerGreet,
			// Token: 0x040051A9 RID: 20905
			MaleCustomerThank,
			// Token: 0x040051AA RID: 20906
			MaleCustomerLeave,
			// Token: 0x040051AB RID: 20907
			FemaleCustomerGreet,
			// Token: 0x040051AC RID: 20908
			FemaleCustomerThank,
			// Token: 0x040051AD RID: 20909
			FemaleCustomerLeave,
			// Token: 0x040051AE RID: 20910
			MenuOpen
		}
	}
}
