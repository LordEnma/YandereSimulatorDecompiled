using UnityEngine;

public class PoisonScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public GameObject Bottle;

	public void Start()
	{
		Debug.Log("The poison bottle has been instructed to determine if Yandere-chan has enough Chemistry to find it.");
		if (Yandere.Class.ChemistryGrade + Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			Debug.Log("Yandere-chan doesn't have enough chemistry to find the poison bottle.");
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Debug.Log("Yandere-chan has enough chemistry to find the poison bottle!");
			base.gameObject.SetActive(value: true);
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
			base.transform.parent.gameObject.SetActive(value: false);
		}
	}
}
