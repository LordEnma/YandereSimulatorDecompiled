using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600244D RID: 9293 RVA: 0x001F8278 File Offset: 0x001F6478
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

		// Token: 0x0600244E RID: 9294 RVA: 0x001F8296 File Offset: 0x001F6496
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001F82BC File Offset: 0x001F64BC
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

		// Token: 0x06002450 RID: 9296 RVA: 0x001F8304 File Offset: 0x001F6504
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

		// Token: 0x06002451 RID: 9297 RVA: 0x001F8370 File Offset: 0x001F6570
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C0E RID: 19470
		private static SFXController instance;

		// Token: 0x04004C0F RID: 19471
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DD RID: 1757
		public enum Sounds
		{
			// Token: 0x040051A6 RID: 20902
			Countdown,
			// Token: 0x040051A7 RID: 20903
			MenuBack,
			// Token: 0x040051A8 RID: 20904
			MenuConfirm,
			// Token: 0x040051A9 RID: 20905
			ClockTick,
			// Token: 0x040051AA RID: 20906
			DoorBell,
			// Token: 0x040051AB RID: 20907
			GameFail,
			// Token: 0x040051AC RID: 20908
			GameSuccess,
			// Token: 0x040051AD RID: 20909
			Plate,
			// Token: 0x040051AE RID: 20910
			PageTurn,
			// Token: 0x040051AF RID: 20911
			MenuSelect,
			// Token: 0x040051B0 RID: 20912
			MaleCustomerGreet,
			// Token: 0x040051B1 RID: 20913
			MaleCustomerThank,
			// Token: 0x040051B2 RID: 20914
			MaleCustomerLeave,
			// Token: 0x040051B3 RID: 20915
			FemaleCustomerGreet,
			// Token: 0x040051B4 RID: 20916
			FemaleCustomerThank,
			// Token: 0x040051B5 RID: 20917
			FemaleCustomerLeave,
			// Token: 0x040051B6 RID: 20918
			MenuOpen
		}
	}
}
