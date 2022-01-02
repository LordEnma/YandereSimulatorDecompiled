using System;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A3C RID: 6716 RVA: 0x00115DFC File Offset: 0x00113FFC
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AE5 RID: 10981
	public ParticleSystem Particles;
}
