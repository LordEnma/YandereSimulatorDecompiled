using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x06001235 RID: 4661 RVA: 0x0008BF64 File Offset: 0x0008A164
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016EB RID: 5867
	public ParticleSystem MyParticles;

	// Token: 0x040016EC RID: 5868
	public Texture Flower;
}
