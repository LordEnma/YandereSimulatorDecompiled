using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F08 RID: 7944 RVA: 0x001B69E7 File Offset: 0x001B4BE7
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F09 RID: 7945 RVA: 0x001B69F0 File Offset: 0x001B4BF0
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
