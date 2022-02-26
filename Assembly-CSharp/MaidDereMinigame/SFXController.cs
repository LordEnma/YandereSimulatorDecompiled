using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059F RID: 1439
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06002473 RID: 9331 RVA: 0x001FB738 File Offset: 0x001F9938
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

		// Token: 0x06002474 RID: 9332 RVA: 0x001FB756 File Offset: 0x001F9956
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x001FB77C File Offset: 0x001F997C
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

		// Token: 0x06002476 RID: 9334 RVA: 0x001FB7C4 File Offset: 0x001F99C4
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

		// Token: 0x06002477 RID: 9335 RVA: 0x001FB830 File Offset: 0x001F9A30
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C56 RID: 19542
		private static SFXController instance;

		// Token: 0x04004C57 RID: 19543
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DE RID: 1758
		public enum Sounds
		{
			// Token: 0x040051C5 RID: 20933
			Countdown,
			// Token: 0x040051C6 RID: 20934
			MenuBack,
			// Token: 0x040051C7 RID: 20935
			MenuConfirm,
			// Token: 0x040051C8 RID: 20936
			ClockTick,
			// Token: 0x040051C9 RID: 20937
			DoorBell,
			// Token: 0x040051CA RID: 20938
			GameFail,
			// Token: 0x040051CB RID: 20939
			GameSuccess,
			// Token: 0x040051CC RID: 20940
			Plate,
			// Token: 0x040051CD RID: 20941
			PageTurn,
			// Token: 0x040051CE RID: 20942
			MenuSelect,
			// Token: 0x040051CF RID: 20943
			MaleCustomerGreet,
			// Token: 0x040051D0 RID: 20944
			MaleCustomerThank,
			// Token: 0x040051D1 RID: 20945
			MaleCustomerLeave,
			// Token: 0x040051D2 RID: 20946
			FemaleCustomerGreet,
			// Token: 0x040051D3 RID: 20947
			FemaleCustomerThank,
			// Token: 0x040051D4 RID: 20948
			FemaleCustomerLeave,
			// Token: 0x040051D5 RID: 20949
			MenuOpen
		}
	}
}
