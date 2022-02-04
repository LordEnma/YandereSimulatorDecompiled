using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06002460 RID: 9312 RVA: 0x001FA4A0 File Offset: 0x001F86A0
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

		// Token: 0x06002461 RID: 9313 RVA: 0x001FA4BE File Offset: 0x001F86BE
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x001FA4E4 File Offset: 0x001F86E4
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

		// Token: 0x06002463 RID: 9315 RVA: 0x001FA52C File Offset: 0x001F872C
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

		// Token: 0x06002464 RID: 9316 RVA: 0x001FA598 File Offset: 0x001F8798
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C3A RID: 19514
		private static SFXController instance;

		// Token: 0x04004C3B RID: 19515
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DA RID: 1754
		public enum Sounds
		{
			// Token: 0x040051A4 RID: 20900
			Countdown,
			// Token: 0x040051A5 RID: 20901
			MenuBack,
			// Token: 0x040051A6 RID: 20902
			MenuConfirm,
			// Token: 0x040051A7 RID: 20903
			ClockTick,
			// Token: 0x040051A8 RID: 20904
			DoorBell,
			// Token: 0x040051A9 RID: 20905
			GameFail,
			// Token: 0x040051AA RID: 20906
			GameSuccess,
			// Token: 0x040051AB RID: 20907
			Plate,
			// Token: 0x040051AC RID: 20908
			PageTurn,
			// Token: 0x040051AD RID: 20909
			MenuSelect,
			// Token: 0x040051AE RID: 20910
			MaleCustomerGreet,
			// Token: 0x040051AF RID: 20911
			MaleCustomerThank,
			// Token: 0x040051B0 RID: 20912
			MaleCustomerLeave,
			// Token: 0x040051B1 RID: 20913
			FemaleCustomerGreet,
			// Token: 0x040051B2 RID: 20914
			FemaleCustomerThank,
			// Token: 0x040051B3 RID: 20915
			FemaleCustomerLeave,
			// Token: 0x040051B4 RID: 20916
			MenuOpen
		}
	}
}
