using System;
using UnityEngine;

// Token: 0x02000499 RID: 1177
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F6C RID: 8044 RVA: 0x001C040B File Offset: 0x001BE60B
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F6D RID: 8045 RVA: 0x001C0414 File Offset: 0x001BE614
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
