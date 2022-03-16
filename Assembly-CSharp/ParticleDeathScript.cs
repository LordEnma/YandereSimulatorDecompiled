using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A5E RID: 6750 RVA: 0x001184D8 File Offset: 0x001166D8
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B4D RID: 11085
	public ParticleSystem Particles;
}
