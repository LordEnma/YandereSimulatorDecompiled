using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	public class SFXController : MonoBehaviour
	{
		public enum Sounds
		{
			Countdown = 0,
			MenuBack = 1,
			MenuConfirm = 2,
			ClockTick = 3,
			DoorBell = 4,
			GameFail = 5,
			GameSuccess = 6,
			Plate = 7,
			PageTurn = 8,
			MenuSelect = 9,
			MaleCustomerGreet = 10,
			MaleCustomerThank = 11,
			MaleCustomerLeave = 12,
			FemaleCustomerGreet = 13,
			FemaleCustomerThank = 14,
			FemaleCustomerLeave = 15,
			MenuOpen = 16
		}

		private static SFXController instance;

		[Reorderable]
		public SoundEmitters emitters;

		public static SFXController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<SFXController>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			if (Instance != this)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		public static void PlaySound(Sounds sound)
		{
			SoundEmitter emitter = Instance.GetEmitter(sound);
			AudioSource source = emitter.GetSource();
			if (!source.isPlaying || emitter.interupt)
			{
				source.clip = Instance.GetRandomClip(emitter);
				source.Play();
			}
		}

		private SoundEmitter GetEmitter(Sounds sound)
		{
			foreach (SoundEmitter emitter in emitters)
			{
				if (emitter.sound == sound)
				{
					return emitter;
				}
			}
			Debug.Log(string.Format("There is no sound emitter created for {0}", sound), this);
			return null;
		}

		private AudioClip GetRandomClip(SoundEmitter emitter)
		{
			int index = Random.Range(0, emitter.clips.Count);
			return emitter.clips[index];
		}
	}
}
