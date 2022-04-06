using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AC1 RID: 6849 RVA: 0x001217A4 File Offset: 0x0011F9A4
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

	// Token: 0x04002C72 RID: 11378
	public GameObject CrimeScene;

	// Token: 0x04002C73 RID: 11379
	public GameObject InvestigationPhotos;

	// Token: 0x04002C74 RID: 11380
	public GameObject ArtsyPhotos;

	// Token: 0x04002C75 RID: 11381
	public GameObject StraightTables;

	// Token: 0x04002C76 RID: 11382
	public GameObject CrookedTables;
}
