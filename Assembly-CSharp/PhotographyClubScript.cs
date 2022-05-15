using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001ACF RID: 6863 RVA: 0x0012299C File Offset: 0x00120B9C
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

	// Token: 0x04002C95 RID: 11413
	public GameObject CrimeScene;

	// Token: 0x04002C96 RID: 11414
	public GameObject InvestigationPhotos;

	// Token: 0x04002C97 RID: 11415
	public GameObject ArtsyPhotos;

	// Token: 0x04002C98 RID: 11416
	public GameObject StraightTables;

	// Token: 0x04002C99 RID: 11417
	public GameObject CrookedTables;
}
