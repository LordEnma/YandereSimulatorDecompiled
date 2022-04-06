using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class ParticleDeathScript : MonoBehaviour
{
	// Token: 0x06001A6B RID: 6763 RVA: 0x00118CA4 File Offset: 0x00116EA4
	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002B65 RID: 11109
	public ParticleSystem Particles;
}
