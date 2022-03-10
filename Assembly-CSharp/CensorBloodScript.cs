using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x06001233 RID: 4659 RVA: 0x0008BB9C File Offset: 0x00089D9C
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016E5 RID: 5861
	public ParticleSystem MyParticles;

	// Token: 0x040016E6 RID: 5862
	public Texture Flower;
}
