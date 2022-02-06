using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A97 RID: 6807 RVA: 0x0011F33C File Offset: 0x0011D53C
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

	// Token: 0x04002C03 RID: 11267
	public GameObject CrimeScene;

	// Token: 0x04002C04 RID: 11268
	public GameObject InvestigationPhotos;

	// Token: 0x04002C05 RID: 11269
	public GameObject ArtsyPhotos;

	// Token: 0x04002C06 RID: 11270
	public GameObject StraightTables;

	// Token: 0x04002C07 RID: 11271
	public GameObject CrookedTables;
}
