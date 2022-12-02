using UnityEngine;

public class PoisonScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject Bottle;

	public void Start()
	{
		if (Yandere.Class.ChemistryGrade + Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			base.gameObject.SetActive(true);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.Inventory.LethalPoisons++;
			Yandere.StudentManager.UpdateAllBentos();
			Prompt.Hide();
			Prompt.enabled = false;
			base.transform.parent.gameObject.SetActive(false);
		}
	}
}
