using UnityEngine;

public class MatchmakingResultsWindowScript : MonoBehaviour
{
	public AdviceWindowScript AdviceWindow;

	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			AdviceWindow.Yandere.PromptParent.gameObject.SetActive(true);
			AdviceWindow.HUDElement[1].SetActive(true);
			AdviceWindow.HUDElement[2].SetActive(true);
			AdviceWindow.HUDElement[3].SetActive(true);
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}
