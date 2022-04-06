using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F53 RID: 8019 RVA: 0x001BD3DF File Offset: 0x001BB5DF
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x001BD3E8 File Offset: 0x001BB5E8
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
