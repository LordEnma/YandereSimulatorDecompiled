using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhotographyClubScript : MonoBehaviour
{
	// Token: 0x06001A8B RID: 6795 RVA: 0x0011E550 File Offset: 0x0011C750
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

	// Token: 0x04002BEC RID: 11244
	public GameObject CrimeScene;

	// Token: 0x04002BED RID: 11245
	public GameObject InvestigationPhotos;

	// Token: 0x04002BEE RID: 11246
	public GameObject ArtsyPhotos;

	// Token: 0x04002BEF RID: 11247
	public GameObject StraightTables;

	// Token: 0x04002BF0 RID: 11248
	public GameObject CrookedTables;
}
