using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	public class SFXController : MonoBehaviour
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002439 RID: 9273 RVA: 0x001F6554 File Offset: 0x001F4754
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

		// Token: 0x0600243A RID: 9274 RVA: 0x001F6572 File Offset: 0x001F4772
		private void Awake()
		{
			if (SFXController.Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x001F6598 File Offset: 0x001F4798
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

		// Token: 0x0600243C RID: 9276 RVA: 0x001F65E0 File Offset: 0x001F47E0
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

		// Token: 0x0600243D RID: 9277 RVA: 0x001F664C File Offset: 0x001F484C
		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = UnityEngine.Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}

		// Token: 0x04004BC6 RID: 19398
		private static SFXController instance;

		// Token: 0x04004BC7 RID: 19399
		[Reorderable]
		public SoundEmitters emitters;

		// Token: 0x020006DA RID: 1754
		public enum Sounds
		{
			// Token: 0x04005152 RID: 20818
			Countdown,
			// Token: 0x04005153 RID: 20819
			MenuBack,
			// Token: 0x04005154 RID: 20820
			MenuConfirm,
			// Token: 0x04005155 RID: 20821
			ClockTick,
			// Token: 0x04005156 RID: 20822
			DoorBell,
			// Token: 0x04005157 RID: 20823
			GameFail,
			// Token: 0x04005158 RID: 20824
			GameSuccess,
			// Token: 0x04005159 RID: 20825
			Plate,
			// Token: 0x0400515A RID: 20826
			PageTurn,
			// Token: 0x0400515B RID: 20827
			MenuSelect,
			// Token: 0x0400515C RID: 20828
			MaleCustomerGreet,
			// Token: 0x0400515D RID: 20829
			MaleCustomerThank,
			// Token: 0x0400515E RID: 20830
			MaleCustomerLeave,
			// Token: 0x0400515F RID: 20831
			FemaleCustomerGreet,
			// Token: 0x04005160 RID: 20832
			FemaleCustomerThank,
			// Token: 0x04005161 RID: 20833
			FemaleCustomerLeave,
			// Token: 0x04005162 RID: 20834
			MenuOpen
		}
	}
}
