using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class HatredScript : MonoBehaviour
{
	// Token: 0x060009D1 RID: 2513 RVA: 0x00051FCE File Offset: 0x000501CE
	private void Start()
	{
		this.Character.SetActive(false);
	}

	// Token: 0x04000A44 RID: 2628
	public DepthOfFieldScatter DepthOfField;

	// Token: 0x04000A45 RID: 2629
	public HomeDarknessScript HomeDarkness;

	// Token: 0x04000A46 RID: 2630
	public HomeCameraScript HomeCamera;

	// Token: 0x04000A47 RID: 2631
	public GrayscaleEffect Grayscale;

	// Token: 0x04000A48 RID: 2632
	public Bloom Bloom;

	// Token: 0x04000A49 RID: 2633
	public GameObject CrackPanel;

	// Token: 0x04000A4A RID: 2634
	public AudioSource Voiceover;

	// Token: 0x04000A4B RID: 2635
	public GameObject SenpaiPhoto;

	// Token: 0x04000A4C RID: 2636
	public GameObject RivalPhotos;

	// Token: 0x04000A4D RID: 2637
	public GameObject Character;

	// Token: 0x04000A4E RID: 2638
	public GameObject Panties;

	// Token: 0x04000A4F RID: 2639
	public GameObject Yandere;

	// Token: 0x04000A50 RID: 2640
	public GameObject Shrine;

	// Token: 0x04000A51 RID: 2641
	public Transform AntennaeR;

	// Token: 0x04000A52 RID: 2642
	public Transform AntennaeL;

	// Token: 0x04000A53 RID: 2643
	public Transform Corkboard;

	// Token: 0x04000A54 RID: 2644
	public UISprite CrackDarkness;

	// Token: 0x04000A55 RID: 2645
	public UISprite Darkness;

	// Token: 0x04000A56 RID: 2646
	public UITexture Crack;

	// Token: 0x04000A57 RID: 2647
	public UITexture Logo;

	// Token: 0x04000A58 RID: 2648
	public bool Begin;

	// Token: 0x04000A59 RID: 2649
	public float Timer;

	// Token: 0x04000A5A RID: 2650
	public int Phase;

	// Token: 0x04000A5B RID: 2651
	public Texture[] CrackTexture;
}
