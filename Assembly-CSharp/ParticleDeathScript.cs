using System;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A32 RID: 6706 RVA: 0x001152F0 File Offset: 0x001134F0
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AB7 RID: 10935
	public ParticleSystem Particles;
}
