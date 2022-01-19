using System;
using UnityEngine;

// Token: 0x0200048E RID: 1166
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F15 RID: 7957 RVA: 0x001B8037 File Offset: 0x001B6237
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B8040 File Offset: 0x001B6240
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
