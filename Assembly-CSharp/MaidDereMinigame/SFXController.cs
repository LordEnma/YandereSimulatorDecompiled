using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600245A RID: 9306 RVA: 0x001F98E8 File Offset: 0x001F7AE8
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

		// Token: 0x0600245B RID: 9307 RVA: 0x001F9906 File Offset: 0x001F7B06
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x001F992C File Offset: 0x001F7B2C
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

		// Token: 0x0600245D RID: 9309 RVA: 0x001F9974 File Offset: 0x001F7B74
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

		// Token: 0x0600245E RID: 9310 RVA: 0x001F99E0 File Offset: 0x001F7BE0
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C29 RID: 19497
		private static SFXController instance;

		// Token: 0x04004C2A RID: 19498
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006E0 RID: 1760
		public enum Sounds
		{
			// Token: 0x040051C1 RID: 20929
			Countdown,
			// Token: 0x040051C2 RID: 20930
			MenuBack,
			// Token: 0x040051C3 RID: 20931
			MenuConfirm,
			// Token: 0x040051C4 RID: 20932
			ClockTick,
			// Token: 0x040051C5 RID: 20933
			DoorBell,
			// Token: 0x040051C6 RID: 20934
			GameFail,
			// Token: 0x040051C7 RID: 20935
			GameSuccess,
			// Token: 0x040051C8 RID: 20936
			Plate,
			// Token: 0x040051C9 RID: 20937
			PageTurn,
			// Token: 0x040051CA RID: 20938
			MenuSelect,
			// Token: 0x040051CB RID: 20939
			MaleCustomerGreet,
			// Token: 0x040051CC RID: 20940
			MaleCustomerThank,
			// Token: 0x040051CD RID: 20941
			MaleCustomerLeave,
			// Token: 0x040051CE RID: 20942
			FemaleCustomerGreet,
			// Token: 0x040051CF RID: 20943
			FemaleCustomerThank,
			// Token: 0x040051D0 RID: 20944
			FemaleCustomerLeave,
			// Token: 0x040051D1 RID: 20945
			MenuOpen
		}
	}
}
