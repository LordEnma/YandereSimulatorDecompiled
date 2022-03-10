using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AA8 RID: 6824 RVA: 0x00120444 File Offset: 0x0011E644
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

	// Token: 0x04002C2F RID: 11311
	public GameObject CrimeScene;

	// Token: 0x04002C30 RID: 11312
	public GameObject InvestigationPhotos;

	// Token: 0x04002C31 RID: 11313
	public GameObject ArtsyPhotos;

	// Token: 0x04002C32 RID: 11314
	public GameObject StraightTables;

	// Token: 0x04002C33 RID: 11315
	public GameObject CrookedTables;
}
