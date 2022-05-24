using System;
using UnityEngine;

// Token: 0x02000499 RID: 1177
[Serializable]
public class AudioClipArrayWrapper : ArrayWrapper<AudioClip>
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x001C0887 File Offset: 0x001BEA87
	public AudioClipArrayWrapper(int size) : base(size)
	{
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x001C0890 File Offset: 0x001BEA90
	public AudioClipArrayWrapper(AudioClip[] elements) : base(elements)
	{
	}
}
