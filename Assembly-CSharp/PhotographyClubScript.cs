using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A9E RID: 6814 RVA: 0x0011F658 File Offset: 0x0011D858
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

	// Token: 0x04002C09 RID: 11273
	public GameObject CrimeScene;

	// Token: 0x04002C0A RID: 11274
	public GameObject InvestigationPhotos;

	// Token: 0x04002C0B RID: 11275
	public GameObject ArtsyPhotos;

	// Token: 0x04002C0C RID: 11276
	public GameObject StraightTables;

	// Token: 0x04002C0D RID: 11277
	public GameObject CrookedTables;
}
