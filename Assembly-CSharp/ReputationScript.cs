using UnityEngine;

public class ReputationScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public ArmDetectorScript ArmDetector;

	public PortalScript Portal;

	public Transform CurrentRepMarker;

	public Transform PendingRepMarker;

	public UILabel PendingRepLabel;

	public UILabel RepUpdateLabel;

	public UILabel RepLabel;

	public ClockScript Clock;

	public float Reputation;

	public float LerpTimer;

	public float PreviousRep;

	public float PendingRep;

	public int CheckedRep = 1;

	public int Phase;

	public bool MissionMode;

	private void Start()
	{
		RepUpdateLabel.enabled = true;
		if (MissionModeGlobals.MissionMode)
		{
			RepUpdateLabel.enabled = false;
			MissionMode = true;
		}
		if (GameGlobals.Eighties)
		{
			BecomeEighties();
		}
		Reputation = PlayerGlobals.Reputation;
		string text = Reputation.ToString("F1");
		RepLabel.text = "REPUTATION: " + text;
	}

	private void Update()
	{
		switch (Phase)
		{
		case 1:
			if (Clock.PresentTime / 60f > 8.5f)
			{
				Phase++;
			}
			break;
		case 2:
			if (Clock.PresentTime / 60f > 13.5f)
			{
				Phase++;
			}
			break;
		case 3:
			if (Clock.PresentTime / 60f > 18f)
			{
				RepUpdateLabel.text = "REP WILL UPDATE AFTER SCHOOL";
				Phase++;
			}
			break;
		}
		if (CheckedRep < Phase && !StudentManager.Yandere.Struggling && !StudentManager.Yandere.DelinquentFighting && !StudentManager.Yandere.Pickpocketing && !StudentManager.Yandere.Noticed && !ArmDetector.SummonDemon)
		{
			UpdateRep();
			if (Reputation <= -100f)
			{
				Portal.EndDay();
			}
		}
		if (!MissionMode)
		{
			if (LerpTimer < 1f)
			{
				CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(CurrentRepMarker.localPosition.x, -830f + Reputation * 1.5f, Time.deltaTime * 10f), CurrentRepMarker.localPosition.y, CurrentRepMarker.localPosition.z);
				PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(PendingRepMarker.localPosition.x, CurrentRepMarker.transform.localPosition.x + PendingRep * 1.5f, Time.deltaTime * 10f), PendingRepMarker.localPosition.y, PendingRepMarker.localPosition.z);
				LerpTimer += Time.deltaTime;
			}
			if (PendingRep != PreviousRep)
			{
				UpdatePendingRepLabel();
			}
		}
		else
		{
			PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(PendingRepMarker.localPosition.x, -980f + PendingRep * -3f, Time.deltaTime * 10f), PendingRepMarker.localPosition.y, PendingRepMarker.localPosition.z);
			if (PendingRep < 0f)
			{
				PendingRepLabel.text = (0f - PendingRep).ToString("F1");
			}
			else
			{
				PendingRepLabel.text = string.Empty;
			}
		}
		if (CurrentRepMarker.localPosition.x < -980f)
		{
			CurrentRepMarker.localPosition = new Vector3(-980f, CurrentRepMarker.localPosition.y, CurrentRepMarker.localPosition.z);
		}
		if (PendingRepMarker.localPosition.x < -980f)
		{
			PendingRepMarker.localPosition = new Vector3(-980f, PendingRepMarker.localPosition.y, PendingRepMarker.localPosition.z);
		}
		if (CurrentRepMarker.localPosition.x > -680f)
		{
			CurrentRepMarker.localPosition = new Vector3(-680f, CurrentRepMarker.localPosition.y, CurrentRepMarker.localPosition.z);
		}
		if (PendingRepMarker.localPosition.x > -680f)
		{
			PendingRepMarker.localPosition = new Vector3(-680f, PendingRepMarker.localPosition.y, PendingRepMarker.localPosition.z);
		}
	}

	public void UpdateRep()
	{
		if (MissionMode)
		{
			return;
		}
		Reputation += PendingRep;
		PendingRep = 0f;
		CheckedRep++;
		if (StudentManager.Yandere.Club == ClubType.Delinquent)
		{
			if (Reputation > -33.33333f)
			{
				Reputation = -33.33333f;
			}
		}
		else if (Reputation > 100f)
		{
			Reputation = 100f;
		}
		StudentManager.WipePendingRep();
		string text = Reputation.ToString("F1");
		RepLabel.text = "REPUTATION: " + text;
	}

	public void BecomeEighties()
	{
		StudentManager.EightiesifyLabel(PendingRepLabel);
		StudentManager.EightiesifyLabel(RepUpdateLabel);
		StudentManager.EightiesifyLabel(RepLabel);
	}

	public void UpdatePendingRepLabel()
	{
		PreviousRep = PendingRep;
		LerpTimer = 0f;
		if (!MissionMode)
		{
			RepUpdateLabel.enabled = true;
		}
		if (PendingRep > 0f)
		{
			PendingRepLabel.text = "+" + PendingRep.ToString("F1");
		}
		else if (PendingRep < 0f)
		{
			StudentManager.TutorialWindow.ShowRepMessage = true;
			PendingRepLabel.text = PendingRep.ToString("F1");
		}
		else
		{
			RepUpdateLabel.enabled = false;
			PendingRepLabel.text = string.Empty;
		}
		string text = Reputation.ToString("F1");
		RepLabel.text = "REPUTATION: " + text;
	}
}
