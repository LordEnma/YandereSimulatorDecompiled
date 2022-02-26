using System;
using UnityEngine;

// Token: 0x02000490 RID: 1168
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F2C RID: 7980 RVA: 0x001B9A2B File Offset: 0x001B7C2B
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x001B9A34 File Offset: 0x001B7C34
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
