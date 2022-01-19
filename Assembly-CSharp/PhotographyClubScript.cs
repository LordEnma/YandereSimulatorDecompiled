using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A94 RID: 6804 RVA: 0x0011ECDC File Offset: 0x0011CEDC
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

	// Token: 0x04002BF9 RID: 11257
	public GameObject CrimeScene;

	// Token: 0x04002BFA RID: 11258
	public GameObject InvestigationPhotos;

	// Token: 0x04002BFB RID: 11259
	public GameObject ArtsyPhotos;

	// Token: 0x04002BFC RID: 11260
	public GameObject StraightTables;

	// Token: 0x04002BFD RID: 11261
	public GameObject CrookedTables;
}
