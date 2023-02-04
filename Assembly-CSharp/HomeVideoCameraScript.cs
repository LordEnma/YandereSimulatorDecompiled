using UnityEngine;

public class HomeVideoCameraScript : MonoBehaviour
{
	public HomePrisonerChanScript HomePrisonerChan;

	public HomeDarknessScript HomeDarkness;

	public HomePrisonerScript HomePrisoner;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public PromptScript Prompt;

	public UILabel Subtitle;

	public bool AudioPlayed;

	public bool TextSet;

	public float Timer;

	private void Update()
	{
		if (!TextSet && !HomeGlobals.Night)
		{
			Prompt.Label[0].text = "     Only Available At Night";
		}
		if (!HomeGlobals.Night)
		{
			Prompt.Circle[0].fillAmount = 1f;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			HomeCamera.Destination = HomeCamera.Destinations[11];
			HomeCamera.Target = HomeCamera.Targets[11];
			HomeCamera.ID = 11;
			HomePrisonerChan.LookAhead = true;
			HomeYandere.CanMove = false;
			HomeYandere.gameObject.SetActive(value: false);
		}
		if (HomeCamera.ID == 11 && !HomePrisoner.Bantering)
		{
			Timer += Time.deltaTime;
			AudioSource component = GetComponent<AudioSource>();
			if (Timer > 2f && !AudioPlayed)
			{
				Subtitle.text = "...daddy...please...help...I'm scared...I don't wanna die...";
				AudioPlayed = true;
				component.Play();
			}
			if (Timer > 2f + component.clip.length)
			{
				Subtitle.text = string.Empty;
			}
			if (Timer > 3f + component.clip.length)
			{
				HomeDarkness.FadeSlow = true;
				HomeDarkness.FadeOut = true;
			}
		}
	}
}
