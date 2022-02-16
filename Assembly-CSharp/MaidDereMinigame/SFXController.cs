using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600246A RID: 9322 RVA: 0x001FAB58 File Offset: 0x001F8D58
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

		// Token: 0x0600246B RID: 9323 RVA: 0x001FAB76 File Offset: 0x001F8D76
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x001FAB9C File Offset: 0x001F8D9C
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

		// Token: 0x0600246D RID: 9325 RVA: 0x001FABE4 File Offset: 0x001F8DE4
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

		// Token: 0x0600246E RID: 9326 RVA: 0x001FAC50 File Offset: 0x001F8E50
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C46 RID: 19526
		private static SFXController instance;

		// Token: 0x04004C47 RID: 19527
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DB RID: 1755
		public enum Sounds
		{
			// Token: 0x040051B0 RID: 20912
			Countdown,
			// Token: 0x040051B1 RID: 20913
			MenuBack,
			// Token: 0x040051B2 RID: 20914
			MenuConfirm,
			// Token: 0x040051B3 RID: 20915
			ClockTick,
			// Token: 0x040051B4 RID: 20916
			DoorBell,
			// Token: 0x040051B5 RID: 20917
			GameFail,
			// Token: 0x040051B6 RID: 20918
			GameSuccess,
			// Token: 0x040051B7 RID: 20919
			Plate,
			// Token: 0x040051B8 RID: 20920
			PageTurn,
			// Token: 0x040051B9 RID: 20921
			MenuSelect,
			// Token: 0x040051BA RID: 20922
			MaleCustomerGreet,
			// Token: 0x040051BB RID: 20923
			MaleCustomerThank,
			// Token: 0x040051BC RID: 20924
			MaleCustomerLeave,
			// Token: 0x040051BD RID: 20925
			FemaleCustomerGreet,
			// Token: 0x040051BE RID: 20926
			FemaleCustomerThank,
			// Token: 0x040051BF RID: 20927
			FemaleCustomerLeave,
			// Token: 0x040051C0 RID: 20928
			MenuOpen
		}
	}
}
