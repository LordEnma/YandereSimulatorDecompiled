using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A41 RID: 6721 RVA: 0x001167A0 File Offset: 0x001149A0
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AF5 RID: 10997
	public ParticleSystem Particles;
}
