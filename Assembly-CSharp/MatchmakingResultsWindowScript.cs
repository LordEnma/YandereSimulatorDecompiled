using UnityEngine;

public class MatchmakingResultsWindowScript : MonoBehaviour
{
	public AdviceWindowScript AdviceWindow;

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			if (AdviceWindow.StudentManager.Students[AdviceWindow.StudentManager.RivalID].Persona == PersonaType.Sleuth && !AdviceWindow.StudentManager.Students[AdviceWindow.StudentManager.RivalID].Phoneless)
			{
				AdviceWindow.StudentManager.Students[AdviceWindow.StudentManager.RivalID].SmartPhone.SetActive(value: true);
			}
			AdviceWindow.Yandere.PromptParent.gameObject.SetActive(value: true);
			AdviceWindow.HUDElement[1].SetActive(value: true);
			AdviceWindow.HUDElement[2].SetActive(value: true);
			AdviceWindow.HUDElement[3].SetActive(value: true);
			base.gameObject.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}
}
