using UnityEngine;

public class ShoePairScript : MonoBehaviour
{
	public PoliceScript Police;

	public PromptScript Prompt;

	public GameObject Note;

	private void Start()
	{
		Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		Note.SetActive(value: false);
	}

	private void Update()
	{
		if (Prompt.Yandere.Class.LanguageGrade + Prompt.Yandere.Class.LanguageBonus < 1)
		{
			Prompt.enabled = false;
		}
		else
		{
			Prompt.enabled = true;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			Police.SuicideNote = true;
			Note.SetActive(value: true);
			base.enabled = false;
		}
	}
}
