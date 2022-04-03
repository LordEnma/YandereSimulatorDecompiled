using System;
using UnityEngine;

// Token: 0x02000395 RID: 917
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A65 RID: 6757 RVA: 0x00118B38 File Offset: 0x00116D38
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B62 RID: 11106
	public ParticleSystem Particles;
}
