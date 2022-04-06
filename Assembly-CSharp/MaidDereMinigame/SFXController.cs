using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class SFXController : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060024A9 RID: 9385 RVA: 0x001FFE18 File Offset: 0x001FE018
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

		// Token: 0x060024AA RID: 9386 RVA: 0x001FFE36 File Offset: 0x001FE036
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x001FFE5C File Offset: 0x001FE05C
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

		// Token: 0x060024AC RID: 9388 RVA: 0x001FFEA4 File Offset: 0x001FE0A4
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

		// Token: 0x060024AD RID: 9389 RVA: 0x001FFF10 File Offset: 0x001FE110
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004D08 RID: 19720
		private static SFXController instance;

		// Token: 0x04004D09 RID: 19721
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006E9 RID: 1769
		public enum Sounds
		{
			// Token: 0x04005277 RID: 21111
			Countdown,
			// Token: 0x04005278 RID: 21112
			MenuBack,
			// Token: 0x04005279 RID: 21113
			MenuConfirm,
			// Token: 0x0400527A RID: 21114
			ClockTick,
			// Token: 0x0400527B RID: 21115
			DoorBell,
			// Token: 0x0400527C RID: 21116
			GameFail,
			// Token: 0x0400527D RID: 21117
			GameSuccess,
			// Token: 0x0400527E RID: 21118
			Plate,
			// Token: 0x0400527F RID: 21119
			PageTurn,
			// Token: 0x04005280 RID: 21120
			MenuSelect,
			// Token: 0x04005281 RID: 21121
			MaleCustomerGreet,
			// Token: 0x04005282 RID: 21122
			MaleCustomerThank,
			// Token: 0x04005283 RID: 21123
			MaleCustomerLeave,
			// Token: 0x04005284 RID: 21124
			FemaleCustomerGreet,
			// Token: 0x04005285 RID: 21125
			FemaleCustomerThank,
			// Token: 0x04005286 RID: 21126
			FemaleCustomerLeave,
			// Token: 0x04005287 RID: 21127
			MenuOpen
		}
	}
}
