using UnityEngine;

public class PhotographyClubScript : MonoBehaviour
{
	public GameObject CrimeScene;

	public GameObject InvestigationPhotos;

	public GameObject ArtsyPhotos;

	public GameObject StraightTables;

	public GameObject CrookedTables;

	private void Start()
	{
		InvestigationPhotos.SetActive(false);
		ArtsyPhotos.SetActive(true);
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			if (!GameGlobals.Eighties)
			{
				InvestigationPhotos.SetActive(true);
				ArtsyPhotos.SetActive(false);
			}
			CrimeScene.SetActive(true);
			StraightTables.SetActive(true);
			CrookedTables.SetActive(false);
		}
		else
		{
			CrimeScene.SetActive(false);
			StraightTables.SetActive(false);
			CrookedTables.SetActive(true);
		}
	}
}
