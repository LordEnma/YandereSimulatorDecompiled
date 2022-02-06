using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A43 RID: 6723 RVA: 0x001168B8 File Offset: 0x00114AB8
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AF8 RID: 11000
	public ParticleSystem Particles;
}
