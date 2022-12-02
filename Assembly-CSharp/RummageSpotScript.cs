using System;
using UnityEngine;

public class RummageSpotScript : MonoBehaviour
{
	public GameObject AlarmDisc;

	public DoorGapScript DoorGap;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Transform Target;

	public int Phase;

	public int ID;

	private void Start()
	{
		if (ID == 1)
		{
			if (GameGlobals.AnswerSheetUnavailable)
			{
				Debug.Log("The answer sheet is no longer available, due to events on a previous day.");
				Prompt.Hide();
				Prompt.enabled = false;
				base.gameObject.SetActive(false);
			}
			else if (DateGlobals.Weekday == DayOfWeek.Friday && Clock.HourTime > 13.5f)
			{
				Prompt.Hide();
				Prompt.enabled = false;
				base.gameObject.SetActive(false);
			}
		}
	}

	private void Update()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				Yandere.EmptyHands();
				Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
				Yandere.ProgressBar.transform.parent.gameObject.SetActive(true);
				Yandere.RummageSpot = this;
				Yandere.Rummaging = true;
				Yandere.CanMove = false;
				component.Play();
			}
		}
		if (Yandere.Rummaging)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(AlarmDisc, base.transform.position, Quaternion.identity);
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
			gameObject.transform.localScale = new Vector3(750f, gameObject.transform.localScale.y, 750f);
		}
		if (Yandere.Noticed)
		{
			component.Stop();
		}
	}

	public void GetReward()
	{
		if (ID == 1)
		{
			if (Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				Schemes.UpdateInstructions();
				Yandere.Inventory.AnswerSheet = true;
				Prompt.Hide();
				Prompt.enabled = false;
				DoorGap.Prompt.enabled = true;
				Phase++;
			}
			else if (Phase == 2)
			{
				SchemeGlobals.SetSchemeStage(5, 8);
				Schemes.UpdateInstructions();
				Prompt.Yandere.Inventory.AnswerSheet = false;
				Prompt.Hide();
				Prompt.enabled = false;
				base.gameObject.SetActive(false);
				Phase++;
			}
		}
	}
}
