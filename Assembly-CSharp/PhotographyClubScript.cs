using System;
using UnityEngine;

// Token: 0x020003A4 RID: 932
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001AB2 RID: 6834 RVA: 0x00120F54 File Offset: 0x0011F154
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

	// Token: 0x04002C58 RID: 11352
	public GameObject CrimeScene;

	// Token: 0x04002C59 RID: 11353
	public GameObject InvestigationPhotos;

	// Token: 0x04002C5A RID: 11354
	public GameObject ArtsyPhotos;

	// Token: 0x04002C5B RID: 11355
	public GameObject StraightTables;

	// Token: 0x04002C5C RID: 11356
	public GameObject CrookedTables;
}
