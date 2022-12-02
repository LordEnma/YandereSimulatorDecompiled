using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	[Serializable]
	public class SoundEmitter
	{
		public SFXController.Sounds sound;

		public bool interupt;

		[Reorderable]
		public AudioSources sources;

		[Reorderable]
		public AudioClips clips;

		public AudioSource GetSource()
		{
			for (int i = 0; i < sources.Count; i++)
			{
				if (!sources[i].isPlaying)
				{
					return sources[i];
				}
			}
			return sources[0];
		}
	}
}
