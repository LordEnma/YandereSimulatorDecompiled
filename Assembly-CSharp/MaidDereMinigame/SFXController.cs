using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002458 RID: 9304 RVA: 0x001F8C18 File Offset: 0x001F6E18
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

		// Token: 0x06002459 RID: 9305 RVA: 0x001F8C36 File Offset: 0x001F6E36
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001F8C5C File Offset: 0x001F6E5C
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

		// Token: 0x0600245B RID: 9307 RVA: 0x001F8CA4 File Offset: 0x001F6EA4
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

		// Token: 0x0600245C RID: 9308 RVA: 0x001F8D10 File Offset: 0x001F6F10
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C22 RID: 19490
		private static SFXController instance;

		// Token: 0x04004C23 RID: 19491
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DF RID: 1759
		public enum Sounds
		{
			// Token: 0x040051BA RID: 20922
			Countdown,
			// Token: 0x040051BB RID: 20923
			MenuBack,
			// Token: 0x040051BC RID: 20924
			MenuConfirm,
			// Token: 0x040051BD RID: 20925
			ClockTick,
			// Token: 0x040051BE RID: 20926
			DoorBell,
			// Token: 0x040051BF RID: 20927
			GameFail,
			// Token: 0x040051C0 RID: 20928
			GameSuccess,
			// Token: 0x040051C1 RID: 20929
			Plate,
			// Token: 0x040051C2 RID: 20930
			PageTurn,
			// Token: 0x040051C3 RID: 20931
			MenuSelect,
			// Token: 0x040051C4 RID: 20932
			MaleCustomerGreet,
			// Token: 0x040051C5 RID: 20933
			MaleCustomerThank,
			// Token: 0x040051C6 RID: 20934
			MaleCustomerLeave,
			// Token: 0x040051C7 RID: 20935
			FemaleCustomerGreet,
			// Token: 0x040051C8 RID: 20936
			FemaleCustomerThank,
			// Token: 0x040051C9 RID: 20937
			FemaleCustomerLeave,
			// Token: 0x040051CA RID: 20938
			MenuOpen
		}
	}
}
