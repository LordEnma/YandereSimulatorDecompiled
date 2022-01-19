using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class HatredScript : MonoBehaviour
{
	// Token: 0x060009D1 RID: 2513 RVA: 0x00051CDE File Offset: 0x0004FEDE
	private void Start()
	{
		this.Character.SetActive(false);
	}

	// Token: 0x04000A37 RID: 2615
	public DepthOfFieldScatter DepthOfField;

	// Token: 0x04000A38 RID: 2616
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04000A39 RID: 2617
	public HomeCameraScript HomeCamera;

	// Token: 0x04000A3A RID: 2618
	public GrayscaleEffect Grayscale;

	// Token: 0x04000A3B RID: 2619
	public Bloom Bloom;

	// Token: 0x04000A3C RID: 2620
	public GameObject CrackPanel;

	// Token: 0x04000A3D RID: 2621
	public AudioSource Voiceover;

	// Token: 0x04000A3E RID: 2622
	public GameObject SenpaiPhoto;

	// Token: 0x04000A3F RID: 2623
	public GameObject RivalPhotos;

	// Token: 0x04000A40 RID: 2624
	public GameObject Character;

	// Token: 0x04000A41 RID: 2625
	public GameObject Panties;

	// Token: 0x04000A42 RID: 2626
	public GameObject Yandere;

	// Token: 0x04000A43 RID: 2627
	public GameObject Shrine;

	// Token: 0x04000A44 RID: 2628
	public Transform AntennaeR;

	// Token: 0x04000A45 RID: 2629
	public Transform AntennaeL;

	// Token: 0x04000A46 RID: 2630
	public Transform Corkboard;

	// Token: 0x04000A47 RID: 2631
	public UISprite CrackDarkness;

	// Token: 0x04000A48 RID: 2632
	public UISprite Darkness;

	// Token: 0x04000A49 RID: 2633
	public UITexture Crack;

	// Token: 0x04000A4A RID: 2634
	public UITexture Logo;

	// Token: 0x04000A4B RID: 2635
	public bool Begin;

	// Token: 0x04000A4C RID: 2636
	public float Timer;

	// Token: 0x04000A4D RID: 2637
	public int Phase;

	// Token: 0x04000A4E RID: 2638
	public Texture[] CrackTexture;
}
