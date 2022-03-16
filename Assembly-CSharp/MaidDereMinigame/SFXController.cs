using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002491 RID: 9361 RVA: 0x001FE078 File Offset: 0x001FC278
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

		// Token: 0x06002492 RID: 9362 RVA: 0x001FE096 File Offset: 0x001FC296
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x001FE0BC File Offset: 0x001FC2BC
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

		// Token: 0x06002494 RID: 9364 RVA: 0x001FE104 File Offset: 0x001FC304
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

		// Token: 0x06002495 RID: 9365 RVA: 0x001FE170 File Offset: 0x001FC370
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004CD2 RID: 19666
		private static SFXController instance;

		// Token: 0x04004CD3 RID: 19667
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006E3 RID: 1763
		public enum Sounds
		{
			// Token: 0x04005241 RID: 21057
			Countdown,
			// Token: 0x04005242 RID: 21058
			MenuBack,
			// Token: 0x04005243 RID: 21059
			MenuConfirm,
			// Token: 0x04005244 RID: 21060
			ClockTick,
			// Token: 0x04005245 RID: 21061
			DoorBell,
			// Token: 0x04005246 RID: 21062
			GameFail,
			// Token: 0x04005247 RID: 21063
			GameSuccess,
			// Token: 0x04005248 RID: 21064
			Plate,
			// Token: 0x04005249 RID: 21065
			PageTurn,
			// Token: 0x0400524A RID: 21066
			MenuSelect,
			// Token: 0x0400524B RID: 21067
			MaleCustomerGreet,
			// Token: 0x0400524C RID: 21068
			MaleCustomerThank,
			// Token: 0x0400524D RID: 21069
			MaleCustomerLeave,
			// Token: 0x0400524E RID: 21070
			FemaleCustomerGreet,
			// Token: 0x0400524F RID: 21071
			FemaleCustomerThank,
			// Token: 0x04005250 RID: 21072
			FemaleCustomerLeave,
			// Token: 0x04005251 RID: 21073
			MenuOpen
		}
	}
}
