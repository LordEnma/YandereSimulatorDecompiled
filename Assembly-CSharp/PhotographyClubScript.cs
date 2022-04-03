using System;
using UnityEngine;

// Token: 0x020003A7 RID: 935
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001ABB RID: 6843 RVA: 0x001215F8 File Offset: 0x0011F7F8
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

	// Token: 0x04002C6F RID: 11375
	public GameObject CrimeScene;

	// Token: 0x04002C70 RID: 11376
	public GameObject InvestigationPhotos;

	// Token: 0x04002C71 RID: 11377
	public GameObject ArtsyPhotos;

	// Token: 0x04002C72 RID: 11378
	public GameObject StraightTables;

	// Token: 0x04002C73 RID: 11379
	public GameObject CrookedTables;
}
