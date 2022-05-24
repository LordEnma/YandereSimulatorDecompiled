using System;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x06001237 RID: 4663 RVA: 0x0008C5C8 File Offset: 0x0008A7C8
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016F5 RID: 5877
	public ParticleSystem MyParticles;

	// Token: 0x040016F6 RID: 5878
	public Texture Flower;
}
