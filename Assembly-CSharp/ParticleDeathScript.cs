using System;
using UnityEngine;

// Token: 0x02000397 RID: 919
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A7A RID: 6778 RVA: 0x0011A06C File Offset: 0x0011826C
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B8F RID: 11151
	public ParticleSystem Particles;
}
