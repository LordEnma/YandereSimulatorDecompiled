using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06002479 RID: 9337 RVA: 0x001FC110 File Offset: 0x001FA310
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

		// Token: 0x0600247A RID: 9338 RVA: 0x001FC12E File Offset: 0x001FA32E
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x001FC154 File Offset: 0x001FA354
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

		// Token: 0x0600247C RID: 9340 RVA: 0x001FC19C File Offset: 0x001FA39C
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

		// Token: 0x0600247D RID: 9341 RVA: 0x001FC208 File Offset: 0x001FA408
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004C73 RID: 19571
		private static SFXController instance;

		// Token: 0x04004C74 RID: 19572
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DF RID: 1759
		public enum Sounds
		{
			// Token: 0x040051E2 RID: 20962
			Countdown,
			// Token: 0x040051E3 RID: 20963
			MenuBack,
			// Token: 0x040051E4 RID: 20964
			MenuConfirm,
			// Token: 0x040051E5 RID: 20965
			ClockTick,
			// Token: 0x040051E6 RID: 20966
			DoorBell,
			// Token: 0x040051E7 RID: 20967
			GameFail,
			// Token: 0x040051E8 RID: 20968
			GameSuccess,
			// Token: 0x040051E9 RID: 20969
			Plate,
			// Token: 0x040051EA RID: 20970
			PageTurn,
			// Token: 0x040051EB RID: 20971
			MenuSelect,
			// Token: 0x040051EC RID: 20972
			MaleCustomerGreet,
			// Token: 0x040051ED RID: 20973
			MaleCustomerThank,
			// Token: 0x040051EE RID: 20974
			MaleCustomerLeave,
			// Token: 0x040051EF RID: 20975
			FemaleCustomerGreet,
			// Token: 0x040051F0 RID: 20976
			FemaleCustomerThank,
			// Token: 0x040051F1 RID: 20977
			FemaleCustomerLeave,
			// Token: 0x040051F2 RID: 20978
			MenuOpen
		}
	}
}
