using System;
using UnityEngine;

// Token: 0x02000392 RID: 914
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A4A RID: 6730 RVA: 0x00116BDC File Offset: 0x00114DDC
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AFE RID: 11006
	public ParticleSystem Particles;
}
