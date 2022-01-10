using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A94 RID: 6804 RVA: 0x0011EB74 File Offset: 0x0011CD74
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

	// Token: 0x04002BF6 RID: 11254
	public GameObject CrimeScene;

	// Token: 0x04002BF7 RID: 11255
	public GameObject InvestigationPhotos;

	// Token: 0x04002BF8 RID: 11256
	public GameObject ArtsyPhotos;

	// Token: 0x04002BF9 RID: 11257
	public GameObject StraightTables;

	// Token: 0x04002BFA RID: 11258
	public GameObject CrookedTables;
}
