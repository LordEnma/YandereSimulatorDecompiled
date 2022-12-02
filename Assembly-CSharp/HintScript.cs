using UnityEngine;

public class HintScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public AudioSource MyAudio;

	public float Speed = 10f;

	public float Timer;

	public int QuickID;

	public bool DisplayTutorial;

	public bool Show;

	public UIPanel MyPanel;

	private void Start()
	{
		base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
		if (DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.gameObject.SetActive(false);
		}
		if (OptionGlobals.HintsOff)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (MyPanel.alpha != 1f)
		{
			return;
		}
		if (Show)
		{
			if (Speed == 5f)
			{
				MyAudio.Play();
				Speed = 0f;
			}
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 0f, 1f), Time.deltaTime * 10f);
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				Show = false;
			}
			if (Input.GetButtonDown("Start") && !PauseScreen.Yandere.Shutter.Snapping && !PauseScreen.Yandere.TimeSkipping && !PauseScreen.Yandere.Talking && !PauseScreen.Yandere.Noticed && !PauseScreen.Yandere.InClass && !PauseScreen.Yandere.Struggling && !PauseScreen.Yandere.Won && !PauseScreen.Yandere.Dismembering && !PauseScreen.Yandere.Attacked && PauseScreen.Yandere.CanMove && !PauseScreen.Yandere.Chased && PauseScreen.Yandere.Chasers == 0 && !PauseScreen.Yandere.YandereVision && Time.timeScale > 0.0001f && !PauseScreen.Schedule.gameObject.activeInHierarchy)
			{
				if (DisplayTutorial)
				{
					PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
					DisplayTutorial = false;
				}
				else
				{
					PauseScreen.ShowScheduleScreen();
					PauseScreen.Sideways = true;
					PauseScreen.Schedule.JumpToEvent(QuickID);
				}
				base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
				Show = false;
				Speed = 5f;
				Timer = 0f;
			}
		}
		else
		{
			if (!(Speed < 5f))
			{
				return;
			}
			Timer = 0f;
			Speed = Mathf.MoveTowards(Speed, 5f, Time.deltaTime);
			base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, new Vector3(0.2043f, 0f, 1f), Speed * Time.deltaTime * 0.0166666f);
			if (Speed == 5f)
			{
				base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
				DisplayTutorial = false;
			}
			if (Input.GetButtonDown("Start") && !PauseScreen.Yandere.Shutter.Snapping && !PauseScreen.Yandere.TimeSkipping && !PauseScreen.Yandere.Talking && !PauseScreen.Yandere.Noticed && !PauseScreen.Yandere.InClass && !PauseScreen.Yandere.Struggling && !PauseScreen.Yandere.Won && !PauseScreen.Yandere.Dismembering && !PauseScreen.Yandere.Attacked && PauseScreen.Yandere.CanMove && !PauseScreen.Yandere.Chased && PauseScreen.Yandere.Chasers == 0 && !PauseScreen.Yandere.YandereVision && Time.timeScale > 0.0001f && !PauseScreen.Schedule.gameObject.activeInHierarchy)
			{
				if (DisplayTutorial)
				{
					PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
					DisplayTutorial = false;
				}
				else
				{
					PauseScreen.ShowScheduleScreen();
					PauseScreen.Sideways = true;
					PauseScreen.Schedule.JumpToEvent(QuickID);
				}
				base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
				Speed = 5f;
			}
		}
	}
}
