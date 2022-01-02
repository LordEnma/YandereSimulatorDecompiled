using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A8D RID: 6797 RVA: 0x0011E82C File Offset: 0x0011CA2C
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

	// Token: 0x04002BF0 RID: 11248
	public GameObject CrimeScene;

	// Token: 0x04002BF1 RID: 11249
	public GameObject InvestigationPhotos;

	// Token: 0x04002BF2 RID: 11250
	public GameObject ArtsyPhotos;

	// Token: 0x04002BF3 RID: 11251
	public GameObject StraightTables;

	// Token: 0x04002BF4 RID: 11252
	public GameObject CrookedTables;
}
