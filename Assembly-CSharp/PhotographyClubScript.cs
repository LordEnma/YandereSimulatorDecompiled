using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AC9 RID: 6857 RVA: 0x00122038 File Offset: 0x00120238
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

	// Token: 0x04002C83 RID: 11395
	public GameObject CrimeScene;

	// Token: 0x04002C84 RID: 11396
	public GameObject InvestigationPhotos;

	// Token: 0x04002C85 RID: 11397
	public GameObject ArtsyPhotos;

	// Token: 0x04002C86 RID: 11398
	public GameObject StraightTables;

	// Token: 0x04002C87 RID: 11399
	public GameObject CrookedTables;
}
