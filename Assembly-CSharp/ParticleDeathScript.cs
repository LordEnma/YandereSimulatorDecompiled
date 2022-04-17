using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A6F RID: 6767 RVA: 0x00118FAC File Offset: 0x001171AC
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B6D RID: 11117
	public ParticleSystem Particles;
}
