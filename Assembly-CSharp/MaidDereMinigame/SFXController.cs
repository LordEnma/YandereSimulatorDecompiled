using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002463 RID: 9315 RVA: 0x001FA6A4 File Offset: 0x001F88A4
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

		// Token: 0x06002464 RID: 9316 RVA: 0x001FA6C2 File Offset: 0x001F88C2
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x001FA6E8 File Offset: 0x001F88E8
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

		// Token: 0x06002466 RID: 9318 RVA: 0x001FA730 File Offset: 0x001F8930
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

		// Token: 0x06002467 RID: 9319 RVA: 0x001FA79C File Offset: 0x001F899C
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C3D RID: 19517
		private static SFXController instance;

		// Token: 0x04004C3E RID: 19518
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DA RID: 1754
		public enum Sounds
		{
			// Token: 0x040051A7 RID: 20903
			Countdown,
			// Token: 0x040051A8 RID: 20904
			MenuBack,
			// Token: 0x040051A9 RID: 20905
			MenuConfirm,
			// Token: 0x040051AA RID: 20906
			ClockTick,
			// Token: 0x040051AB RID: 20907
			DoorBell,
			// Token: 0x040051AC RID: 20908
			GameFail,
			// Token: 0x040051AD RID: 20909
			GameSuccess,
			// Token: 0x040051AE RID: 20910
			Plate,
			// Token: 0x040051AF RID: 20911
			PageTurn,
			// Token: 0x040051B0 RID: 20912
			MenuSelect,
			// Token: 0x040051B1 RID: 20913
			MaleCustomerGreet,
			// Token: 0x040051B2 RID: 20914
			MaleCustomerThank,
			// Token: 0x040051B3 RID: 20915
			MaleCustomerLeave,
			// Token: 0x040051B4 RID: 20916
			FemaleCustomerGreet,
			// Token: 0x040051B5 RID: 20917
			FemaleCustomerThank,
			// Token: 0x040051B6 RID: 20918
			FemaleCustomerLeave,
			// Token: 0x040051B7 RID: 20919
			MenuOpen
		}
	}
}
