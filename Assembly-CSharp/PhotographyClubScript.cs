using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A95 RID: 6805 RVA: 0x0011F224 File Offset: 0x0011D424
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

	// Token: 0x04002C00 RID: 11264
	public GameObject CrimeScene;

	// Token: 0x04002C01 RID: 11265
	public GameObject InvestigationPhotos;

	// Token: 0x04002C02 RID: 11266
	public GameObject ArtsyPhotos;

	// Token: 0x04002C03 RID: 11267
	public GameObject StraightTables;

	// Token: 0x04002C04 RID: 11268
	public GameObject CrookedTables;
}
