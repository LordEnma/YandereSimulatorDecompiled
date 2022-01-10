using System;
using UnityEngine;

// Token: 0x02000391 RID: 913
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A40 RID: 6720 RVA: 0x00116138 File Offset: 0x00114338
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002AEB RID: 10987
	public ParticleSystem Particles;
}
