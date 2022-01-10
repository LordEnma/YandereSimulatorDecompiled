using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F13 RID: 7955 RVA: 0x001B7367 File Offset: 0x001B5567
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x001B7370 File Offset: 0x001B5570
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
