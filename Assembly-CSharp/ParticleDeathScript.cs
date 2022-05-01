using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A73 RID: 6771 RVA: 0x00119548 File Offset: 0x00117748
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B76 RID: 11126
	public ParticleSystem Particles;
}
