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
		InvestigationPhotos.SetActive(value: false);
		ArtsyPhotos.SetActive(value: true);
		if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			if (!GameGlobals.Eighties)
			{
				InvestigationPhotos.SetActive(value: true);
				ArtsyPhotos.SetActive(value: false);
				CrimeScene.SetActive(value: true);
			}
			StraightTables.SetActive(value: true);
			CrookedTables.SetActive(value: false);
		}
		else
		{
			CrimeScene.SetActive(value: false);
			StraightTables.SetActive(value: false);
			CrookedTables.SetActive(value: true);
		}
	}
}
