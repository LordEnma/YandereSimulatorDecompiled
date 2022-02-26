using System;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A53 RID: 6739 RVA: 0x001175F0 File Offset: 0x001157F0
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B0E RID: 11022
	public ParticleSystem Particles;
}
