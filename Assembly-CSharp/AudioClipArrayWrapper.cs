using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F23 RID: 7971 RVA: 0x001B8EDF File Offset: 0x001B70DF
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B8EE8 File Offset: 0x001B70E8
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
