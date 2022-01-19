using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A40 RID: 6720 RVA: 0x001162A0 File Offset: 0x001144A0
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AEE RID: 10990
	public ParticleSystem Particles;
}
