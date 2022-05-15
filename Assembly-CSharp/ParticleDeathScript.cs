using System;
using UnityEngine;

// Token: 0x02000397 RID: 919
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A79 RID: 6777 RVA: 0x00119E3C File Offset: 0x0011803C
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B88 RID: 11144
	public ParticleSystem Particles;
}
