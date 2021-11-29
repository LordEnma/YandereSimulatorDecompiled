using System;
using UnityEngine;

// Token: 0x0200039F RID: 927
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A83 RID: 6787 RVA: 0x0011DD10 File Offset: 0x0011BF10
	private void Start()
	{
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			this.InvestigationPhotos.SetActive(true);
			this.ArtsyPhotos.SetActive(false);
			this.CrimeScene.SetActive(true);
			this.StraightTables.SetActive(true);
			this.CrookedTables.SetActive(false);
			return;
		}
		this.InvestigationPhotos.SetActive(false);
		this.ArtsyPhotos.SetActive(true);
		this.CrimeScene.SetActive(false);
		this.StraightTables.SetActive(false);
		this.CrookedTables.SetActive(true);
	}

	// Token: 0x04002BC2 RID: 11202
	public GameObject CrimeScene;

	// Token: 0x04002BC3 RID: 11203
	public GameObject InvestigationPhotos;

	// Token: 0x04002BC4 RID: 11204
	public GameObject ArtsyPhotos;

	// Token: 0x04002BC5 RID: 11205
	public GameObject StraightTables;

	// Token: 0x04002BC6 RID: 11206
	public GameObject CrookedTables;
}
