using UnityEngine;

public class MinimalistManagerScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public GameObject Watermark;

	public bool Minimize;

	public UISprite ClockPanel;

	public ClockScript Clock;

	public bool ShowClock;

	public float ClockTimer;

	public float LastTime;

	public int LastPeriod;

	public UILabel SanityLabel;

	public YandereScript Yandere;

	public bool ShowSanity;

	public float SanityTimer;

	public float LastSanity;

	public UISprite RepPanel;

	public ReputationScript Reputation;

	public bool ShowRep;

	public float RepTimer;

	public float LastRep;

	public void Start()
	{
		Minimize = OptionGlobals.MinimalistHUD;
		Reset();
	}

	public void Reset()
	{
		ClockPanel.alpha = 1f;
		SanityLabel.alpha = 1f;
		RepPanel.alpha = 1f;
		if (!Minimize)
		{
			SanityLabel.transform.localPosition = new Vector3(827f, -540f, 0f);
			RepPanel.transform.localPosition = new Vector3(-15f, 25f, 0f);
			Watermark.SetActive(value: true);
		}
		else
		{
			Watermark.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (!Minimize)
		{
			return;
		}
		if (PauseScreen.Show)
		{
			ClockPanel.alpha = Mathf.MoveTowards(ClockPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
			SanityLabel.alpha = Mathf.MoveTowards(SanityLabel.alpha, 1f, Time.unscaledDeltaTime * 10f);
			RepPanel.alpha = Mathf.MoveTowards(RepPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
			SanityLabel.transform.localPosition = Vector3.Lerp(SanityLabel.transform.localPosition, new Vector3(827f, -445f, 0f), Time.unscaledDeltaTime * 10f);
			RepPanel.transform.localPosition = Vector3.Lerp(RepPanel.transform.localPosition, new Vector3(-15f, 100f, 0f), Time.unscaledDeltaTime * 10f);
		}
		else
		{
			if (SanityLabel.transform.localPosition.y > -539f)
			{
				SanityLabel.transform.localPosition = Vector3.Lerp(SanityLabel.transform.localPosition, new Vector3(827f, -540f, 0f), Time.unscaledDeltaTime * 10f);
				if (SanityLabel.transform.localPosition.y < -539f)
				{
					SanityLabel.transform.localPosition = new Vector3(827f, -540f, 0f);
				}
			}
			if (RepPanel.transform.localPosition.y > 26f)
			{
				RepPanel.transform.localPosition = Vector3.Lerp(RepPanel.transform.localPosition, new Vector3(-15f, 25f, 0f), Time.unscaledDeltaTime * 10f);
				if (RepPanel.transform.localPosition.y < -26f)
				{
					RepPanel.transform.localPosition = new Vector3(-15f, 25f, 0f);
				}
			}
			if (ShowClock)
			{
				ClockPanel.alpha = Mathf.MoveTowards(ClockPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
				ClockTimer += Time.deltaTime;
				if (ClockTimer > 6f)
				{
					ShowClock = false;
				}
			}
			else
			{
				ClockPanel.alpha = Mathf.MoveTowards(ClockPanel.alpha, 0f, Time.unscaledDeltaTime);
			}
			if (ShowSanity)
			{
				SanityLabel.alpha = Mathf.MoveTowards(SanityLabel.alpha, 1f, Time.unscaledDeltaTime * 10f);
				SanityTimer += Time.deltaTime;
				if (SanityTimer > 6f)
				{
					ShowSanity = false;
				}
			}
			else
			{
				SanityLabel.alpha = Mathf.MoveTowards(SanityLabel.alpha, 0f, Time.unscaledDeltaTime);
			}
			if (ShowRep)
			{
				RepPanel.alpha = Mathf.MoveTowards(RepPanel.alpha, 1f, Time.unscaledDeltaTime * 10f);
				RepTimer += Time.deltaTime;
				if (RepTimer > 6f)
				{
					ShowRep = false;
				}
			}
			else
			{
				RepPanel.alpha = Mathf.MoveTowards(RepPanel.alpha, 0f, Time.unscaledDeltaTime);
			}
		}
		if (Clock.Period > LastPeriod || Clock.HourTime > LastTime + 0.5f)
		{
			LastTime = Clock.HourTime;
			LastTime = Mathf.Round(LastTime * 2f) * 0.5f;
			LastPeriod = Clock.Period;
			ShowClock = true;
			ClockTimer = 0f;
		}
		if (Yandere.Sanity != LastSanity)
		{
			LastSanity = Yandere.Sanity;
			ShowSanity = true;
			SanityTimer = 0f;
		}
		if (Reputation.PendingRep != LastRep || Yandere.StudentManager.DialogueWheel.Show)
		{
			LastRep = Reputation.PendingRep;
			ShowRep = true;
			RepTimer = 0f;
		}
	}
}
