using UnityEngine;

public class TitleScreenOsanaScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public Animation SuicideCorpseAnimation;

	public Animation SuicideHairAnimation;

	public GameObject BloodPool;

	public GameObject[] DeadOsanas;

	public int Week;

	private void Start()
	{
		SuicideCorpseAnimation["SwingingOsana"].speed = 0.5f;
		SuicideHairAnimation["OsanaHairSwing"].speed = 0.5f;
		if (GameGlobals.SpecificEliminationID > 0)
		{
			NewTitleScreen.ExtrasLabel.alpha = 1f;
			DeadOsanas[GameGlobals.SpecificEliminationID].SetActive(value: true);
		}
		if (DateGlobals.Week != Week)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
