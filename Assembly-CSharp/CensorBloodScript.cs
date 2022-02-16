using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x06001233 RID: 4659 RVA: 0x0008B940 File Offset: 0x00089B40
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016DC RID: 5852
	public ParticleSystem MyParticles;

	// Token: 0x040016DD RID: 5853
	public Texture Flower;
}
