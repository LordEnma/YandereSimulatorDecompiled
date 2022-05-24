using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024C5 RID: 9413 RVA: 0x00203A04 File Offset: 0x00201C04
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

		// Token: 0x060024C6 RID: 9414 RVA: 0x00203A22 File Offset: 0x00201C22
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x00203A48 File Offset: 0x00201C48
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

		// Token: 0x060024C8 RID: 9416 RVA: 0x00203A90 File Offset: 0x00201C90
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

		// Token: 0x060024C9 RID: 9417 RVA: 0x00203AFC File Offset: 0x00201CFC
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004D63 RID: 19811
		private static SFXController instance;

		// Token: 0x04004D64 RID: 19812
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006EB RID: 1771
		public enum Sounds
		{
			// Token: 0x040052D7 RID: 21207
			Countdown,
			// Token: 0x040052D8 RID: 21208
			MenuBack,
			// Token: 0x040052D9 RID: 21209
			MenuConfirm,
			// Token: 0x040052DA RID: 21210
			ClockTick,
			// Token: 0x040052DB RID: 21211
			DoorBell,
			// Token: 0x040052DC RID: 21212
			GameFail,
			// Token: 0x040052DD RID: 21213
			GameSuccess,
			// Token: 0x040052DE RID: 21214
			Plate,
			// Token: 0x040052DF RID: 21215
			PageTurn,
			// Token: 0x040052E0 RID: 21216
			MenuSelect,
			// Token: 0x040052E1 RID: 21217
			MaleCustomerGreet,
			// Token: 0x040052E2 RID: 21218
			MaleCustomerThank,
			// Token: 0x040052E3 RID: 21219
			MaleCustomerLeave,
			// Token: 0x040052E4 RID: 21220
			FemaleCustomerGreet,
			// Token: 0x040052E5 RID: 21221
			FemaleCustomerThank,
			// Token: 0x040052E6 RID: 21222
			FemaleCustomerLeave,
			// Token: 0x040052E7 RID: 21223
			MenuOpen
		}
	}
}
