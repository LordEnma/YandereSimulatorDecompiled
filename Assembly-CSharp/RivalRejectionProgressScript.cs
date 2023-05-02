using UnityEngine;
using UnityEngine.SceneManagement;

public class RivalRejectionProgressScript : MonoBehaviour
{
	public UILabel PercentLabel;

	public UILabel Label;

	public Texture[] RivalHeads;

	public UITexture RivalHead;

	public UISprite Darkness;

	public float Timer;

	public int Phase = 1;

	private void Start()
	{
		Label.text = "You have sabotaged " + DatingGlobals.RivalSabotaged + " of your rival's interactions with Senpai. You must sabotage " + (5 - DatingGlobals.RivalSabotaged) + " more of their interactions in order to foil your rival's love confession on Friday.";
		PercentLabel.text = DatingGlobals.RivalSabotaged * 20 + "%";
		RivalHead.transform.localPosition = new Vector3(-700 + DatingGlobals.RivalSabotaged * 200, 0f, 0f);
		Darkness.alpha = 1f;
		Time.timeScale = 1f;
		if (GameGlobals.Eighties)
		{
			RivalHead.mainTexture = RivalHeads[DateGlobals.Week];
		}
	}

	private void Update()
	{
		if (Phase == 1)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f)
			{
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f)
			{
				if (!GameGlobals.JustKidnapped)
				{
					SceneManager.LoadScene("HomeScene");
				}
				else
				{
					GameGlobals.JustKidnapped = false;
					SceneManager.LoadScene("CalendarScene");
				}
			}
		}
		if (Phase > 1)
		{
			RivalHead.transform.localPosition = Vector3.Lerp(RivalHead.transform.localPosition, new Vector3(-500 + DatingGlobals.RivalSabotaged * 200, 0f, 0f), Time.deltaTime * 10f);
		}
	}
}
