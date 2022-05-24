using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AD0 RID: 6864 RVA: 0x00122BCC File Offset: 0x00120DCC
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

	// Token: 0x04002C9C RID: 11420
	public GameObject CrimeScene;

	// Token: 0x04002C9D RID: 11421
	public GameObject InvestigationPhotos;

	// Token: 0x04002C9E RID: 11422
	public GameObject ArtsyPhotos;

	// Token: 0x04002C9F RID: 11423
	public GameObject StraightTables;

	// Token: 0x04002CA0 RID: 11424
	public GameObject CrookedTables;
}
