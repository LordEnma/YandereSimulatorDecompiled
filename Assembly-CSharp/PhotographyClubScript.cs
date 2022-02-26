using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AA7 RID: 6823 RVA: 0x0012006C File Offset: 0x0011E26C
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

	// Token: 0x04002C19 RID: 11289
	public GameObject CrimeScene;

	// Token: 0x04002C1A RID: 11290
	public GameObject InvestigationPhotos;

	// Token: 0x04002C1B RID: 11291
	public GameObject ArtsyPhotos;

	// Token: 0x04002C1C RID: 11292
	public GameObject StraightTables;

	// Token: 0x04002C1D RID: 11293
	public GameObject CrookedTables;
}
