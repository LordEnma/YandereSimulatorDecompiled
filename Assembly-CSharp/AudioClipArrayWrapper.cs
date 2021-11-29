using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001EFB RID: 7931 RVA: 0x001B5753 File Offset: 0x001B3953
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x001B575C File Offset: 0x001B395C
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
