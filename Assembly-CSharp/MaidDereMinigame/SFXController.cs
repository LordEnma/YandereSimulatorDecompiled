using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060024B9 RID: 9401 RVA: 0x00201D50 File Offset: 0x001FFF50
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

		// Token: 0x060024BA RID: 9402 RVA: 0x00201D6E File Offset: 0x001FFF6E
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x00201D94 File Offset: 0x001FFF94
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

		// Token: 0x060024BC RID: 9404 RVA: 0x00201DDC File Offset: 0x001FFFDC
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

		// Token: 0x060024BD RID: 9405 RVA: 0x00201E48 File Offset: 0x00200048
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004D33 RID: 19763
		private static SFXController instance;

		// Token: 0x04004D34 RID: 19764
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006EA RID: 1770
		public enum Sounds
		{
			// Token: 0x040052A7 RID: 21159
			Countdown,
			// Token: 0x040052A8 RID: 21160
			MenuBack,
			// Token: 0x040052A9 RID: 21161
			MenuConfirm,
			// Token: 0x040052AA RID: 21162
			ClockTick,
			// Token: 0x040052AB RID: 21163
			DoorBell,
			// Token: 0x040052AC RID: 21164
			GameFail,
			// Token: 0x040052AD RID: 21165
			GameSuccess,
			// Token: 0x040052AE RID: 21166
			Plate,
			// Token: 0x040052AF RID: 21167
			PageTurn,
			// Token: 0x040052B0 RID: 21168
			MenuSelect,
			// Token: 0x040052B1 RID: 21169
			MaleCustomerGreet,
			// Token: 0x040052B2 RID: 21170
			MaleCustomerThank,
			// Token: 0x040052B3 RID: 21171
			MaleCustomerLeave,
			// Token: 0x040052B4 RID: 21172
			FemaleCustomerGreet,
			// Token: 0x040052B5 RID: 21173
			FemaleCustomerThank,
			// Token: 0x040052B6 RID: 21174
			FemaleCustomerLeave,
			// Token: 0x040052B7 RID: 21175
			MenuOpen
		}
	}
}
