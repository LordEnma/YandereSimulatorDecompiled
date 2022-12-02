using UnityEngine;

public class RestScript : MonoBehaviour
{
	public PortalScript Portal;

	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Portal.CanAttendClass = true;
		Portal.CheckForProblems();
		if (!Portal.CanAttendClass)
		{
			Prompt.Circle[0].fillAmount = 1f;
		}
		else if (Portal.Clock.Period < 5)
		{
			Portal.Reputation.PendingRep -= 10f;
			Portal.Reputation.UpdateRep();
			Prompt.Yandere.Resting = true;
			if (Portal.Police.PoisonScene || (Portal.Police.SuicideScene && Portal.Police.Corpses - Portal.Police.HiddenCorpses > 0) || Portal.Police.Corpses - Portal.Police.HiddenCorpses > 0 || Portal.Reputation.Reputation <= -100f)
			{
				Portal.EndDay();
				return;
			}
			Portal.ClassDarkness.enabled = true;
			Portal.Clock.StopTime = true;
			Portal.Transition = true;
			Portal.FadeOut = true;
			Prompt.Yandere.Character.GetComponent<Animation>().CrossFade(Prompt.Yandere.IdleAnim);
			Prompt.Yandere.YandereVision = false;
			Prompt.Yandere.CanMove = false;
			Portal.EndEvents();
			Prompt.Hide();
			Prompt.enabled = false;
		}
		else
		{
			Prompt.Yandere.Character.GetComponent<Animation>().CrossFade(Prompt.Yandere.IdleAnim);
			Prompt.Yandere.YandereVision = false;
			Prompt.Yandere.CanMove = false;
			Prompt.Yandere.Resting = true;
			Portal.EndDay();
		}
	}
}
