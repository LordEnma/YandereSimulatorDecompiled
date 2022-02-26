using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	[Serializable]
	public class SoundEmitter
	{
		// Token: 0x0600247A RID: 9338 RVA: 0x001FB86C File Offset: 0x001F9A6C
		public AudioSource GetSource()
		{
			for (int i = 0; i < this.sources.Count; i++)
			{
				if (!this.sources[i].isPlaying)
				{
					return this.sources[i];
				}
			}
			return this.sources[0];
		}

		// Token: 0x04004C58 RID: 19544
		public SFXController.Sounds sound;

		// Token: 0x04004C59 RID: 19545
		public bool interupt;

		// Token: 0x04004C5A RID: 19546
		[Reorderable]
		public AudioSources sources;

		// Token: 0x04004C5B RID: 19547
		[Reorderable]
		public AudioClips clips;
	}
}
