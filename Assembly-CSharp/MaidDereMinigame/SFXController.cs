using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060024A1 RID: 9377 RVA: 0x001FF8E8 File Offset: 0x001FDAE8
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

		// Token: 0x060024A2 RID: 9378 RVA: 0x001FF906 File Offset: 0x001FDB06
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FF92C File Offset: 0x001FDB2C
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

		// Token: 0x060024A4 RID: 9380 RVA: 0x001FF974 File Offset: 0x001FDB74
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

		// Token: 0x060024A5 RID: 9381 RVA: 0x001FF9E0 File Offset: 0x001FDBE0
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004D04 RID: 19716
		private static SFXController instance;

		// Token: 0x04004D05 RID: 19717
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006E8 RID: 1768
		public enum Sounds
		{
			// Token: 0x04005273 RID: 21107
			Countdown,
			// Token: 0x04005274 RID: 21108
			MenuBack,
			// Token: 0x04005275 RID: 21109
			MenuConfirm,
			// Token: 0x04005276 RID: 21110
			ClockTick,
			// Token: 0x04005277 RID: 21111
			DoorBell,
			// Token: 0x04005278 RID: 21112
			GameFail,
			// Token: 0x04005279 RID: 21113
			GameSuccess,
			// Token: 0x0400527A RID: 21114
			Plate,
			// Token: 0x0400527B RID: 21115
			PageTurn,
			// Token: 0x0400527C RID: 21116
			MenuSelect,
			// Token: 0x0400527D RID: 21117
			MaleCustomerGreet,
			// Token: 0x0400527E RID: 21118
			MaleCustomerThank,
			// Token: 0x0400527F RID: 21119
			MaleCustomerLeave,
			// Token: 0x04005280 RID: 21120
			FemaleCustomerGreet,
			// Token: 0x04005281 RID: 21121
			FemaleCustomerThank,
			// Token: 0x04005282 RID: 21122
			FemaleCustomerLeave,
			// Token: 0x04005283 RID: 21123
			MenuOpen
		}
	}
}
