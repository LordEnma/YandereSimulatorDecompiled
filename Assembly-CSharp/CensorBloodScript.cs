using System;
using UnityEngine;

// Token: 0x02000239 RID: 569
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x0600122F RID: 4655 RVA: 0x0008B5F8 File Offset: 0x000897F8
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016D4 RID: 5844
	public ParticleSystem MyParticles;

	// Token: 0x040016D5 RID: 5845
	public Texture Flower;
}
