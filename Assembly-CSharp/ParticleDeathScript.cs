using System;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A3A RID: 6714 RVA: 0x00115B20 File Offset: 0x00113D20
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AE1 RID: 10977
	public ParticleSystem Particles;
}
