using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024C4 RID: 9412 RVA: 0x0020349C File Offset: 0x0020169C
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

		// Token: 0x060024C5 RID: 9413 RVA: 0x002034BA File Offset: 0x002016BA
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x002034E0 File Offset: 0x002016E0
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

		// Token: 0x060024C7 RID: 9415 RVA: 0x00203528 File Offset: 0x00201728
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

		// Token: 0x060024C8 RID: 9416 RVA: 0x00203594 File Offset: 0x00201794
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004D5A RID: 19802
		private static SFXController instance;

		// Token: 0x04004D5B RID: 19803
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006EB RID: 1771
		public enum Sounds
		{
			// Token: 0x040052CE RID: 21198
			Countdown,
			// Token: 0x040052CF RID: 21199
			MenuBack,
			// Token: 0x040052D0 RID: 21200
			MenuConfirm,
			// Token: 0x040052D1 RID: 21201
			ClockTick,
			// Token: 0x040052D2 RID: 21202
			DoorBell,
			// Token: 0x040052D3 RID: 21203
			GameFail,
			// Token: 0x040052D4 RID: 21204
			GameSuccess,
			// Token: 0x040052D5 RID: 21205
			Plate,
			// Token: 0x040052D6 RID: 21206
			PageTurn,
			// Token: 0x040052D7 RID: 21207
			MenuSelect,
			// Token: 0x040052D8 RID: 21208
			MaleCustomerGreet,
			// Token: 0x040052D9 RID: 21209
			MaleCustomerThank,
			// Token: 0x040052DA RID: 21210
			MaleCustomerLeave,
			// Token: 0x040052DB RID: 21211
			FemaleCustomerGreet,
			// Token: 0x040052DC RID: 21212
			FemaleCustomerThank,
			// Token: 0x040052DD RID: 21213
			FemaleCustomerLeave,
			// Token: 0x040052DE RID: 21214
			MenuOpen
		}
	}
}
