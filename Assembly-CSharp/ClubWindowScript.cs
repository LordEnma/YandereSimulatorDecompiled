using UnityEngine;

public class ClubWindowScript : MonoBehaviour
{
	public ClubManagerScript ClubManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public Transform ActivityWindow;

	public GameObject ClubInfo;

	public GameObject Window;

	public GameObject Warning;

	public string[] ActivityDescs;

	public string[] ClubNames;

	public string[] ClubDescs;

	public string MedAtmosphereDesc;

	public string LowAtmosphereDesc;

	public UILabel ActivityLabel;

	public UILabel BottomLabel;

	public UILabel ClubName;

	public UILabel ClubDesc;

	public bool PerformingActivity;

	public bool Activity;

	public bool Quitting;

	public float Timer;

	public ClubType Club;

	private void Start()
	{
		Window.SetActive(false);
		if (GameGlobals.Eighties)
		{
			ActivityDescs[7] = "The Photography Club review each others' photographs and share advice on how to improve.";
			ClubDescs[7] = "If you join the Photography Club, you will gain access to a camera, and the Photography Club will not consider you to be a potential suspect if they are searching for a killer at school.";
			ClubDescs[8] = "If you join the Science Club, you will have easy access to an emergency shower that can be used for changing out of a bloody outfit, and a vat of acid that can be used for disposing of corpses.";
		}
		if (SchoolGlobals.SchoolAtmosphere <= 0.9f)
		{
			ActivityDescs[7] = LowAtmosphereDesc;
		}
		else if (SchoolGlobals.SchoolAtmosphere <= 0.8f)
		{
			ActivityDescs[7] = MedAtmosphereDesc;
		}
	}

	private void Update()
	{
		if (Window.activeInHierarchy)
		{
			if (Timer > 0.5f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (!Quitting && !Activity)
					{
						Yandere.Club = Club;
						Yandere.ClubAccessory();
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
						ClubManager.ActivateClubBenefit();
					}
					else if (Quitting)
					{
						ClubManager.DeactivateClubBenefit();
						ClubManager.QuitClub[(int)Club] = true;
						Yandere.Club = ClubType.None;
						Yandere.ClubAccessory();
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
						Quitting = false;
						Yandere.StudentManager.UpdateBooths();
					}
					else if (Activity)
					{
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
					}
					Yandere.TargetStudent.TalkTimer = 100f;
					Yandere.TargetStudent.ClubPhase = 2;
					PromptBar.ClearButtons();
					PromptBar.Show = false;
					Window.SetActive(false);
				}
				if (Input.GetButtonDown("B"))
				{
					if (!Quitting && !Activity)
					{
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
					}
					else if (Quitting)
					{
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
						Quitting = false;
					}
					else if (Activity)
					{
						Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
						Activity = false;
					}
					Yandere.TargetStudent.TalkTimer = 100f;
					Yandere.TargetStudent.ClubPhase = 3;
					PromptBar.ClearButtons();
					PromptBar.Show = false;
					Window.SetActive(false);
				}
				if (Input.GetButtonDown("X") && !Quitting && !Activity)
				{
					if (!Warning.activeInHierarchy)
					{
						ClubInfo.SetActive(false);
						Warning.SetActive(true);
					}
					else
					{
						ClubInfo.SetActive(true);
						Warning.SetActive(false);
					}
				}
			}
			Timer += Time.deltaTime;
		}
		if (PerformingActivity)
		{
			ActivityWindow.localScale = Vector3.Lerp(ActivityWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else if (ActivityWindow.localScale.x > 0.1f)
		{
			ActivityWindow.localScale = Vector3.Lerp(ActivityWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (ActivityWindow.localScale.x != 0f)
		{
			ActivityWindow.localScale = Vector3.zero;
		}
	}

	public void UpdateWindow()
	{
		ClubName.text = ClubNames[(int)Club];
		if (!Quitting && !Activity)
		{
			ClubDesc.text = ClubDescs[(int)Club];
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Refuse";
			PromptBar.Label[2].text = "More Info";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			BottomLabel.text = "Will you join the " + ClubNames[(int)Club] + "?";
		}
		else if (Activity)
		{
			ClubDesc.text = "Club activities last until 6:00 PM. If you choose to participate in club activities now, the day will end.\n\nIf you don't join by 5:30 PM, you won't be able to participate in club activities today.\n\nIf you don't participate in club activities at least once a week, you will be removed from the club.";
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Yes";
			PromptBar.Label[1].text = "No";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			BottomLabel.text = "Will you participate in club activities?";
		}
		else if (Quitting)
		{
			ClubDesc.text = "Are you sure you want to quit this club? If you quit, you will never be allowed to return.";
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Confirm";
			PromptBar.Label[1].text = "Deny";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			BottomLabel.text = "Will you quit the " + ClubNames[(int)Club] + "?";
		}
		ClubInfo.SetActive(true);
		Warning.SetActive(false);
		Window.SetActive(true);
		Timer = 0f;
	}
}
