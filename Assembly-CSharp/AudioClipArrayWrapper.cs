using System;
using UnityEngine;

// Token: 0x02000493 RID: 1171
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F41 RID: 8001 RVA: 0x001BB94B File Offset: 0x001B9B4B
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001BB954 File Offset: 0x001B9B54
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
