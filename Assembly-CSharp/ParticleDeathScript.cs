using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A54 RID: 6740 RVA: 0x001179C8 File Offset: 0x00115BC8
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B24 RID: 11044
	public ParticleSystem Particles;
}
