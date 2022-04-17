using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AC5 RID: 6853 RVA: 0x00121AD0 File Offset: 0x0011FCD0
	private void Start()
	{
		this.InvestigationPhotos.SetActive(false);
		this.ArtsyPhotos.SetActive(true);
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			if (!GameGlobals.Eighties)
			{
				this.InvestigationPhotos.SetActive(true);
				this.ArtsyPhotos.SetActive(false);
			}
			this.CrimeScene.SetActive(true);
			this.StraightTables.SetActive(true);
			this.CrookedTables.SetActive(false);
			return;
		}
		this.CrimeScene.SetActive(false);
		this.StraightTables.SetActive(false);
		this.CrookedTables.SetActive(true);
	}

	// Token: 0x04002C7A RID: 11386
	public GameObject CrimeScene;

	// Token: 0x04002C7B RID: 11387
	public GameObject InvestigationPhotos;

	// Token: 0x04002C7C RID: 11388
	public GameObject ArtsyPhotos;

	// Token: 0x04002C7D RID: 11389
	public GameObject StraightTables;

	// Token: 0x04002C7E RID: 11390
	public GameObject CrookedTables;
}
