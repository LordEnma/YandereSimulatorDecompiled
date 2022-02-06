using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x06001232 RID: 4658 RVA: 0x0008B874 File Offset: 0x00089A74
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016DB RID: 5851
	public ParticleSystem MyParticles;

	// Token: 0x040016DC RID: 5852
	public Texture Flower;
}
