using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class MissionModeMenuScript : MonoBehaviour
{
	public PostProcessingProfile Profile;

	public StudentManagerScript StudentManager;

	public NewMissionWindowScript MultiMission;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public JsonScript JSON;

	public UITexture CustomTargetPortrait;

	public UILabel CustomDifficultyLabel;

	public UILabel CustomPopulationLabel;

	public UILabel CustomNemesisLabel;

	public UITexture NemesisPortrait;

	public UITexture TargetPortrait;

	public UILabel LoadMissionLabel;

	public UILabel DescriptionLabel;

	public UILabel DifficultyLabel;

	public UILabel PopulationLabel;

	public UILabel NemesisLabel;

	public UILabel ErrorLabel;

	public UILabel Header;

	public UISprite Highlight;

	public UISprite Darkness;

	public Transform NemesisAggressionWindow;

	public Transform CustomMissionWindow;

	public Transform MultiMissionWindow;

	public Transform ObjectiveHighlight;

	public Transform LoadMissionWindow;

	public Transform MissionWindow;

	public Transform InfoChan;

	public Transform Options;

	public Transform Neck;

	public GameObject NowLoading;

	public string[] ConditionDescs;

	public int[] Conditions;

	public string[] ClothingNames;

	public string[] DisposalNames;

	public string[] WeaponNames;

	public int RequiredClothingID;

	public int RequiredDisposalID;

	public int RequiredWeaponID;

	public Transform[] CustomNemesisObjectives;

	public Transform[] NemesisObjectives;

	public UIPanel[] CustomObjectives;

	public Texture[] ConditionIcons;

	public Transform[] Objectives;

	public Transform[] Option;

	public UITexture[] Icons;

	public UILabel[] CustomDescs;

	public UILabel[] Descs;

	public Texture NemesisGraphic;

	public Texture BlankPortrait;

	public string MissionIDString = string.Empty;

	public string TargetName = string.Empty;

	public int NemesisDifficulty;

	public int CustomSelected = 1;

	public int Difficulty = 1;

	public int Selected = 1;

	public int TargetID;

	public int Phase;

	public int Column = 1;

	public int Row = 1;

	public float Rotation;

	public float Speed;

	public float Timer;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public AudioClip[] InfoLines;

	public bool[] InfoSpoke;

	public bool NemesisAggression;

	public bool Toggling;

	public bool Valid;

	public int TargetNumber;

	public int WeaponNumber;

	public int ClothingNumber;

	public int DisposalNumber;

	public int NemesisNumber;

	public int PopulationNumber;

	public int Condition5Number;

	public int Condition6Number;

	public int Condition7Number;

	public int Condition8Number;

	public int Condition9Number;

	public int Condition10Number;

	public int Condition11Number;

	public int Condition12Number;

	public int Condition13Number;

	public int Condition14Number;

	public int Condition15Number;

	public string TargetString = string.Empty;

	public string WeaponString = string.Empty;

	public string ClothingString = string.Empty;

	public string DisposalString = string.Empty;

	public string MissionID = string.Empty;

	public string[] ConditionString;

	public UILabel MissionIDLabel;

	public Font Arial;

	private void Start()
	{
		base.transform.position = new Vector3(0f, 0.95f, -4.266667f);
		ColorGradingModel.Settings settings = Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		settings3.bloom.threshold = 1f;
		settings3.bloom.softKnee = 1f;
		settings3.bloom.radius = 4f;
		Profile.bloom.settings = settings3;
		MissionModeGlobals.MultiMission = false;
		NemesisPortrait.transform.parent.localScale = Vector3.zero;
		CustomMissionWindow.transform.localScale = Vector3.zero;
		MultiMissionWindow.transform.localScale = Vector3.zero;
		LoadMissionWindow.transform.localScale = Vector3.zero;
		MissionWindow.transform.localScale = Vector3.zero;
		Options.transform.localPosition = new Vector3(-700f, Options.transform.localPosition.y, Options.transform.localPosition.z);
		Highlight.color = new Color(Highlight.color.r, Highlight.color.g, Highlight.color.b, 0f);
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 1f);
		Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, 0f);
		Time.timeScale = 1f;
		CustomDescs[2].text = ConditionDescs[1] + " " + WeaponNames[1];
		CustomDescs[3].text = ConditionDescs[2] + " " + ClothingNames[1];
		CustomDescs[4].text = ConditionDescs[3] + " " + DisposalNames[1];
		for (int i = 1; i < 6; i++)
		{
			Transform transform = Option[i].transform;
			transform.localPosition = new Vector3(-800f, transform.localPosition.y, transform.localPosition.z);
		}
		for (int j = 1; j < Objectives.Length; j++)
		{
			Objectives[j].localScale = Vector3.zero;
		}
		for (int k = 1; k < NemesisObjectives.Length; k++)
		{
			NemesisObjectives[k].localScale = Vector3.zero;
		}
		for (int l = 1; l < CustomObjectives.Length; l++)
		{
			if (CustomObjectives[l] != null)
			{
				CustomObjectives[l].alpha = 0.5f;
			}
		}
		CustomPopulationLabel.text = "";
		PopulationLabel.text = "";
		ChangeFont();
		for (int m = 0; m < 11; m++)
		{
			PlayerPrefs.SetInt("MissionModeTarget" + m, 0);
			PlayerPrefs.SetInt("MissionModeMethod" + m, 0);
		}
	}

	private void Update()
	{
		if (Phase == 1)
		{
			Speed += Time.deltaTime;
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, Speed * Time.deltaTime * 0.25f));
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime / 3f));
			if (Speed > 1f)
			{
				Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, Mathf.MoveTowards(Header.color.a, 1f, Time.deltaTime));
				if (Speed > 3f)
				{
					if (!InfoSpoke[0])
					{
						MyAudio.PlayOneShot(InfoLines[0]);
						InfoSpoke[0] = true;
					}
					InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, Mathf.Lerp(InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (Speed - 3f)), InfoChan.localEulerAngles.z);
					Transform transform = Option[1];
					transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, 0f, Time.deltaTime * 10f), transform.localPosition.y, transform.localPosition.z);
					if ((double)Speed > 3.25)
					{
						Transform transform2 = Option[2];
						transform2.localPosition = new Vector3(Mathf.Lerp(transform2.localPosition.x, 0f, Time.deltaTime * 10f), transform2.localPosition.y, transform2.localPosition.z);
						if (Speed > 3.5f)
						{
							Transform transform3 = Option[3];
							transform3.localPosition = new Vector3(Mathf.Lerp(transform3.localPosition.x, 0f, Time.deltaTime * 10f), transform3.localPosition.y, transform3.localPosition.z);
							if ((double)Speed > 3.75)
							{
								Transform transform4 = Option[4];
								transform4.localPosition = new Vector3(Mathf.Lerp(transform4.localPosition.x, 0f, Time.deltaTime * 10f), transform4.localPosition.y, transform4.localPosition.z);
								if (Speed > 4f)
								{
									Transform transform5 = Option[5];
									transform5.localPosition = new Vector3(Mathf.Lerp(transform5.localPosition.x, 0f, Time.deltaTime * 10f), transform5.localPosition.y, transform5.localPosition.z);
									if (Speed > 5f)
									{
										PromptBar.Label[0].text = "Accept";
										PromptBar.Label[4].text = "Choose";
										PromptBar.UpdateButtons();
										PromptBar.Show = true;
										Phase++;
									}
								}
							}
						}
					}
				}
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (!InfoSpoke[0])
				{
					MyAudio.PlayOneShot(InfoLines[0]);
					InfoSpoke[0] = true;
				}
				InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, 180f, InfoChan.localEulerAngles.z);
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 2f);
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, 0f);
				Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, 1f);
				Rotation = 0f;
				for (int i = 1; i < 6; i++)
				{
					Transform transform6 = Option[i];
					transform6.localPosition = new Vector3(0f, transform6.localPosition.y, transform6.localPosition.z);
				}
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Phase++;
			}
			return;
		}
		if (Phase == 2)
		{
			Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, Mathf.MoveTowards(Header.color.a, 1f, Time.deltaTime * 10f));
			InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, Mathf.Lerp(InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (Speed - 3f)), InfoChan.localEulerAngles.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, Speed * Time.deltaTime * 0.25f));
			CustomMissionWindow.localScale = Vector3.Lerp(CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			LoadMissionWindow.localScale = Vector3.Lerp(LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MissionWindow.localScale = Vector3.Lerp(MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MultiMissionWindow.localScale = Vector3.Lerp(MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			Options.localPosition = new Vector3(Mathf.Lerp(Options.localPosition.x, -700f, Time.deltaTime * 10f), Options.localPosition.y, Options.localPosition.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, Speed * Time.deltaTime * 0.25f));
			if (InputManager.TappedUp)
			{
				Selected--;
				UpdateHighlight();
			}
			if (InputManager.TappedDown)
			{
				Selected++;
				UpdateHighlight();
			}
			Highlight.transform.localPosition = new Vector3(Highlight.transform.localPosition.x, Mathf.Lerp(Highlight.transform.localPosition.y, 150f - 50f * (float)Selected, Time.deltaTime * 10f), Highlight.transform.localPosition.z);
			Highlight.color = new Color(Highlight.color.r, Highlight.color.g, Highlight.color.b, Mathf.MoveTowards(Highlight.color.a, 1f, Time.deltaTime));
			for (int j = 1; j < 6; j++)
			{
				if (j != Selected)
				{
					Transform transform7 = Option[j];
					transform7.localPosition = new Vector3(Mathf.Lerp(transform7.transform.localPosition.x, 0f, Time.deltaTime * 10f), transform7.localPosition.y, transform7.localPosition.z);
				}
			}
			Transform transform8 = Option[Selected];
			transform8.localPosition = new Vector3(Mathf.Lerp(transform8.transform.localPosition.x, 50f, Time.deltaTime * 10f), transform8.localPosition.y, transform8.localPosition.z);
			if (!Input.GetButtonDown(InputNames.Xbox_A))
			{
				return;
			}
			if (!InfoSpoke[Selected])
			{
				MyAudio.PlayOneShot(InfoLines[Selected]);
				InfoSpoke[Selected] = true;
			}
			if (Selected == 1)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Return";
				PromptBar.Label[2].text = "Generate";
				PromptBar.Label[3].text = "";
				PromptBar.Label[4].text = "Nemesis";
				PromptBar.Label[5].text = "Change Difficulty";
				PromptBar.UpdateButtons();
				for (int k = 1; k < Conditions.Length; k++)
				{
					Conditions[k] = 0;
				}
				if (TargetID == 0)
				{
					ChooseTarget();
				}
				RequiredClothingID = 0;
				RequiredDisposalID = 0;
				RequiredWeaponID = 0;
				NemesisDifficulty = 0;
				Difficulty = 1;
				UpdateNemesisDifficulty();
				UpdateDifficultyLabel();
				Phase++;
			}
			else if (Selected == 2)
			{
				Difficulty = 1;
				Phase = 5;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Toggle";
				PromptBar.Label[1].text = "Return";
				PromptBar.Label[2].text = "Change";
				PromptBar.Label[3].text = "";
				PromptBar.Label[4].text = "Selection";
				PromptBar.Label[5].text = "Selection";
				PromptBar.UpdateButtons();
				CustomDescs[2].text = ConditionDescs[1] + " " + WeaponNames[1];
				CustomDescs[3].text = ConditionDescs[2] + " " + ClothingNames[1];
				CustomDescs[4].text = ConditionDescs[3] + " " + DisposalNames[1];
				UpdateObjectiveHighlight();
				UpdateDifficultyLabel();
				RequiredClothingID = 1;
				RequiredDisposalID = 1;
				RequiredWeaponID = 1;
				TargetID = 2;
				ChooseTarget();
				CalculateMissionID();
			}
			else if (Selected == 3)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "";
				PromptBar.Label[1].text = "Return";
				PromptBar.Label[2].text = "Adjust Up";
				PromptBar.Label[3].text = "Adjust Down";
				PromptBar.Label[4].text = "Selection";
				PromptBar.Label[5].text = "Selection";
				PromptBar.UpdateButtons();
				MultiMission.enabled = true;
				MultiMission.Column = 1;
				MultiMission.Row = 1;
				MultiMission.UpdateHighlight();
				Phase = 6;
			}
			else if (Selected == 4)
			{
				Cursor.visible = true;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Confirm";
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
				Phase = 7;
			}
			else if (Selected == 5)
			{
				PromptBar.Show = false;
				Phase = 4;
				Speed = 0f;
			}
			return;
		}
		Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, Mathf.MoveTowards(Header.color.a, 0f, Time.deltaTime * 10f));
		if (Phase == 3)
		{
			InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, Mathf.Lerp(InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (Speed - 3f)), InfoChan.localEulerAngles.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, Speed * Time.deltaTime * 0.25f));
			CustomMissionWindow.localScale = Vector3.Lerp(CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			LoadMissionWindow.localScale = Vector3.Lerp(LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MissionWindow.localScale = Vector3.Lerp(MissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			MultiMissionWindow.localScale = Vector3.Lerp(MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			Options.localPosition = new Vector3(Mathf.Lerp(Options.localPosition.x, -1550f, Time.deltaTime * 10f), Options.localPosition.y, Options.localPosition.z);
			if (InputManager.TappedLeft)
			{
				Difficulty--;
				UpdateDifficulty();
			}
			if (InputManager.TappedRight)
			{
				Difficulty++;
				UpdateDifficulty();
			}
			if (InputManager.TappedUp)
			{
				NemesisDifficulty--;
				UpdateNemesisDifficulty();
			}
			if (InputManager.TappedDown)
			{
				NemesisDifficulty++;
				UpdateNemesisDifficulty();
			}
			for (int l = 1; l < Objectives.Length; l++)
			{
				Transform obj = Objectives[l];
				obj.localScale = Vector3.Lerp(obj.localScale, (l > Difficulty) ? Vector3.zero : Vector3.one, Time.deltaTime * 10f);
			}
			if (NemesisDifficulty == 0)
			{
				NemesisPortrait.transform.parent.localScale = Vector3.Lerp(NemesisPortrait.transform.parent.localScale, Vector3.zero, Time.deltaTime * 10f);
				NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
				NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else
			{
				NemesisPortrait.transform.parent.localScale = Vector3.Lerp(NemesisPortrait.transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (NemesisDifficulty == 1)
			{
				NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 2)
			{
				NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 3)
			{
				NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 4)
			{
				NemesisObjectives[1].localScale = Vector3.Lerp(NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				NemesisObjectives[2].localScale = Vector3.Lerp(NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				NemesisObjectives[3].localScale = Vector3.Lerp(NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				StartMission();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				Cursor.visible = false;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				TargetID = 0;
				Phase--;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				RequiredClothingID = 0;
				RequiredDisposalID = 0;
				RequiredWeaponID = 0;
				ChooseTarget();
				if (Difficulty > 1)
				{
					int difficulty = Difficulty;
					Difficulty = 1;
					while (Difficulty < difficulty)
					{
						Difficulty++;
						PickNewCondition();
					}
				}
				UpdateDifficultyLabel();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				UpdatePopulation();
			}
		}
		else if (Phase == 4)
		{
			Speed += Time.deltaTime;
			CustomMissionWindow.localScale = Vector3.Lerp(CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			LoadMissionWindow.localScale = Vector3.Lerp(LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MissionWindow.localScale = Vector3.Lerp(MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MultiMissionWindow.localScale = Vector3.Lerp(MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, Mathf.Lerp(InfoChan.localEulerAngles.y, 0f, Time.deltaTime * Speed), InfoChan.localEulerAngles.z);
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime * 0.5f));
			Transform parent = Option[1].parent;
			parent.localPosition = new Vector3(parent.localPosition.x - Speed * 1000f * Time.deltaTime, parent.localPosition.y, parent.localPosition.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, base.transform.position.z - Speed * Time.deltaTime);
			Jukebox.volume -= Time.deltaTime;
			Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, Header.color.a - Time.deltaTime);
			if (Darkness.color.a == 1f)
			{
				if (TargetID == 0 && !MissionModeGlobals.MultiMission)
				{
					SceneManager.LoadScene("NewTitleScene");
					return;
				}
				NowLoading.SetActive(value: true);
				SceneManager.LoadScene("SchoolScene");
			}
		}
		else if (Phase == 5)
		{
			InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, Mathf.Lerp(InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (Speed - 3f)), InfoChan.localEulerAngles.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, Speed * Time.deltaTime * 0.25f));
			CustomMissionWindow.localScale = Vector3.Lerp(CustomMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			LoadMissionWindow.localScale = Vector3.Lerp(LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MissionWindow.localScale = Vector3.Lerp(MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MultiMissionWindow.localScale = Vector3.Lerp(MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			Options.localPosition = new Vector3(Mathf.Lerp(Options.localPosition.x, -1550f, Time.deltaTime * 10f), Options.localPosition.y, Options.localPosition.z);
			if (InputManager.TappedUp)
			{
				Row--;
				UpdateObjectiveHighlight();
			}
			if (InputManager.TappedDown)
			{
				Row++;
				UpdateObjectiveHighlight();
			}
			if (InputManager.TappedRight)
			{
				Column++;
				UpdateObjectiveHighlight();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				UpdateObjectiveHighlight();
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (CustomSelected == 1)
				{
					TargetID++;
					ChooseTarget();
				}
				else if (CustomSelected == 6)
				{
					for (int m = 1; m < Conditions.Length; m++)
					{
						Conditions[m] = 0;
					}
					int num = 2;
					for (int n = 2; n < CustomObjectives.Length; n++)
					{
						if (CustomObjectives[n] != null && CustomObjectives[n].alpha == 1f)
						{
							if (n < 6)
							{
								Conditions[num] = n - 1;
							}
							else if (n < 12)
							{
								Conditions[num] = n - 2;
							}
							else
							{
								Conditions[num] = n - 3;
							}
							num++;
						}
					}
					StartMission();
				}
				else if (CustomSelected == 12)
				{
					NemesisDifficulty++;
					UpdateNemesisDifficulty();
				}
				if (Toggling)
				{
					if (CustomObjectives[CustomSelected].alpha == 0.5f)
					{
						if (Difficulty < 10)
						{
							Difficulty++;
							UpdateDifficultyLabel();
							CustomObjectives[CustomSelected].alpha = 1f;
						}
					}
					else
					{
						Difficulty--;
						UpdateDifficultyLabel();
						CustomObjectives[CustomSelected].alpha = 0.5f;
					}
				}
				CalculateMissionID();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				Cursor.visible = false;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				for (int num2 = 1; num2 < CustomObjectives.Length; num2++)
				{
					if (CustomObjectives[num2] != null)
					{
						CustomObjectives[num2].alpha = 0.5f;
					}
				}
				NemesisDifficulty = 0;
				UpdateNemesisDifficulty();
				Difficulty = 1;
				TargetID = 0;
				Phase = 2;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				if (CustomSelected == 1)
				{
					TargetID--;
					ChooseTarget();
					CalculateMissionID();
				}
				else if (CustomSelected == 2)
				{
					RequiredWeaponID++;
					if (RequiredWeaponID > WeaponNames.Length - 1)
					{
						RequiredWeaponID = 1;
					}
					while (WeaponNames[RequiredWeaponID] == "")
					{
						RequiredWeaponID++;
					}
					CustomDescs[2].text = ConditionDescs[1] + " " + WeaponNames[RequiredWeaponID];
				}
				else if (CustomSelected == 3)
				{
					RequiredClothingID++;
					if (RequiredClothingID > ClothingNames.Length - 1)
					{
						RequiredClothingID = 1;
					}
					CustomDescs[3].text = ConditionDescs[2] + " " + ClothingNames[RequiredClothingID];
				}
				else if (CustomSelected == 4)
				{
					RequiredDisposalID++;
					if (RequiredDisposalID > DisposalNames.Length - 1)
					{
						RequiredDisposalID = 1;
					}
					CustomDescs[4].text = ConditionDescs[3] + " " + DisposalNames[RequiredDisposalID];
				}
				else if (CustomSelected == 12)
				{
					NemesisDifficulty--;
					UpdateNemesisDifficulty();
				}
				CalculateMissionID();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y) && CustomSelected == 12)
			{
				NemesisAggression = !NemesisAggression;
			}
			if (NemesisDifficulty == 0)
			{
				CustomNemesisObjectives[1].localScale = Vector3.Lerp(CustomNemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
				CustomNemesisObjectives[2].localScale = Vector3.Lerp(CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				CustomNemesisObjectives[3].localScale = Vector3.Lerp(CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 1)
			{
				CustomNemesisObjectives[1].localScale = Vector3.Lerp(CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				CustomNemesisObjectives[2].localScale = Vector3.Lerp(CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				CustomNemesisObjectives[3].localScale = Vector3.Lerp(CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 2)
			{
				CustomNemesisObjectives[1].localScale = Vector3.Lerp(CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				CustomNemesisObjectives[2].localScale = Vector3.Lerp(CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				CustomNemesisObjectives[3].localScale = Vector3.Lerp(CustomNemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 3)
			{
				CustomNemesisObjectives[1].localScale = Vector3.Lerp(CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				CustomNemesisObjectives[2].localScale = Vector3.Lerp(CustomNemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
				CustomNemesisObjectives[3].localScale = Vector3.Lerp(CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			else if (NemesisDifficulty == 4)
			{
				CustomNemesisObjectives[1].localScale = Vector3.Lerp(CustomNemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				CustomNemesisObjectives[2].localScale = Vector3.Lerp(CustomNemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				CustomNemesisObjectives[3].localScale = Vector3.Lerp(CustomNemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (NemesisAggression)
			{
				NemesisAggressionWindow.localScale = Vector3.Lerp(NemesisAggressionWindow.localScale, new Vector3(0.749f, 0.749f, 0.749f), Time.deltaTime * 10f);
			}
			else
			{
				NemesisAggressionWindow.localScale = Vector3.Lerp(NemesisAggressionWindow.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			}
			MissionIDLabel.gameObject.GetComponent<UIInput>().value = MissionID;
		}
		else if (Phase == 6)
		{
			CustomMissionWindow.localScale = Vector3.Lerp(CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			LoadMissionWindow.localScale = Vector3.Lerp(LoadMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MissionWindow.localScale = Vector3.Lerp(MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MultiMissionWindow.localScale = Vector3.Lerp(MultiMissionWindow.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			Options.localPosition = new Vector3(Mathf.Lerp(Options.localPosition.x, -1550f, Time.deltaTime * 10f), Options.localPosition.y, Options.localPosition.z);
		}
		else
		{
			if (Phase != 7)
			{
				return;
			}
			InfoChan.localEulerAngles = new Vector3(InfoChan.localEulerAngles.x, Mathf.Lerp(InfoChan.localEulerAngles.y, 180f, Time.deltaTime * (Speed - 3f)), InfoChan.localEulerAngles.z);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 2f, Speed * Time.deltaTime * 0.25f));
			CustomMissionWindow.localScale = Vector3.Lerp(CustomMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			LoadMissionWindow.localScale = Vector3.Lerp(LoadMissionWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			MissionWindow.localScale = Vector3.Lerp(MissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			MultiMissionWindow.localScale = Vector3.Lerp(MultiMissionWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
			Options.localPosition = new Vector3(Mathf.Lerp(Options.localPosition.x, -1550f, Time.deltaTime * 10f), Options.localPosition.y, Options.localPosition.z);
			if (!Input.anyKey)
			{
				MissionIDString = LoadMissionLabel.text;
				if (MissionIDString.Length < 19)
				{
					ErrorLabel.text = "A Mission ID must be 19 numbers long.";
				}
				else if (MissionIDString[0] != '-')
				{
					Valid = false;
					GetNumbers();
					bool flag = false;
					if ((TargetNumber > 11 && TargetNumber < 21) || TargetNumber > 89)
					{
						flag = true;
					}
					if (TargetNumber == 0)
					{
						ErrorLabel.text = "Invalid Mission ID (No target specified)";
						return;
					}
					if (TargetNumber == 1)
					{
						ErrorLabel.text = "Invalid Mission ID (Target cannot be Senpai)";
						return;
					}
					if (flag)
					{
						ErrorLabel.text = "Invalid Mission ID (That student has not been implemented yet)";
						return;
					}
					if (WeaponNumber == 11 || WeaponNumber == 17 || WeaponNumber == 26 || WeaponNumber == 27)
					{
						ErrorLabel.text = "Invalid Mission ID (Weapon does not apply to Mission Mode)";
						return;
					}
					if (WeaponNumber > 31)
					{
						ErrorLabel.text = "Invalid Mission ID (Weapon does not exist)";
						return;
					}
					if (ClothingNumber > 6)
					{
						ErrorLabel.text = "Invalid Mission ID (Clothing does not exist)";
						return;
					}
					if (DisposalNumber > 5)
					{
						ErrorLabel.text = "Invalid Mission ID (Disposal method does not exist)";
						return;
					}
					if (NemesisNumber > 4)
					{
						ErrorLabel.text = "Invalid Mission ID (Nemesis level too high)";
						return;
					}
					if (PopulationNumber > 0)
					{
						ErrorLabel.text = "Invalid Mission ID (Final digit must be '0')";
						return;
					}
					if (Condition5Number > 1 || Condition6Number > 1 || Condition7Number > 1 || Condition8Number > 1 || Condition9Number > 1 || Condition10Number > 1 || Condition11Number > 1 || Condition12Number > 1 || Condition13Number > 1 || Condition14Number > 1 || Condition15Number > 1)
					{
						ErrorLabel.text = "Invalid Mission ID (One of those conditions should be 1 or 0)";
						return;
					}
					ErrorLabel.text = "Valid Mission ID!";
					Valid = true;
				}
				else
				{
					ErrorLabel.text = "Invalid Mission ID (Cannot be negative number)";
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Valid)
				{
					Debug.Log("Target ID is: " + TargetNumber + " and Weapon ID is: " + WeaponNumber);
					TargetID = TargetNumber;
					Difficulty = 1;
					if (WeaponNumber > 0)
					{
						Difficulty++;
						Conditions[Difficulty] = 2;
						CustomObjectives[2].alpha = 1f;
						RequiredWeaponID = WeaponNumber;
						CustomDescs[2].text = ConditionDescs[1] + " " + WeaponNames[RequiredWeaponID];
					}
					else
					{
						CustomObjectives[2].alpha = 0.5f;
						CustomDescs[2].text = ConditionDescs[1] + " " + WeaponNames[1];
					}
					if (ClothingNumber > 0)
					{
						Difficulty++;
						Conditions[Difficulty] = 3;
						CustomObjectives[3].alpha = 1f;
						RequiredClothingID = ClothingNumber;
						CustomDescs[3].text = ConditionDescs[2] + " " + ClothingNames[RequiredClothingID];
					}
					else
					{
						CustomObjectives[3].alpha = 0.5f;
						CustomDescs[3].text = ConditionDescs[2] + " " + ClothingNames[1];
					}
					if (DisposalNumber > 0)
					{
						Difficulty++;
						Conditions[Difficulty] = 4;
						CustomObjectives[4].alpha = 1f;
						RequiredDisposalID = DisposalNumber;
						CustomDescs[4].text = ConditionDescs[3] + " " + DisposalNames[RequiredDisposalID];
					}
					else
					{
						CustomObjectives[4].alpha = 0.5f;
						CustomDescs[4].text = ConditionDescs[3] + " " + DisposalNames[1];
					}
					if (Difficulty < 10 && Condition5Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 5;
						CustomObjectives[5].alpha = 1f;
					}
					if (Difficulty < 10 && Condition6Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 6;
						CustomObjectives[7].alpha = 1f;
					}
					if (Difficulty < 10 && Condition7Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 7;
						CustomObjectives[8].alpha = 1f;
					}
					if (Difficulty < 10 && Condition8Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 8;
						CustomObjectives[9].alpha = 1f;
					}
					if (Difficulty < 10 && Condition9Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 9;
						CustomObjectives[10].alpha = 1f;
					}
					if (Difficulty < 10 && Condition10Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 10;
						CustomObjectives[11].alpha = 1f;
					}
					if (Difficulty < 10 && Condition11Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 11;
						CustomObjectives[13].alpha = 1f;
					}
					if (Difficulty < 10 && Condition12Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 12;
						CustomObjectives[14].alpha = 1f;
					}
					if (Difficulty < 10 && Condition13Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 13;
						CustomObjectives[15].alpha = 1f;
					}
					if (Difficulty < 10 && Condition14Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 14;
						CustomObjectives[16].alpha = 1f;
					}
					if (Difficulty < 10 && Condition15Number == 1)
					{
						Difficulty++;
						Conditions[Difficulty] = 15;
						CustomObjectives[17].alpha = 1f;
					}
					NemesisDifficulty = NemesisNumber;
					SchoolGlobals.Population = PopulationNumber;
					Phase = 5;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Toggle";
					PromptBar.Label[1].text = "Return";
					PromptBar.Label[2].text = "Change";
					PromptBar.Label[3].text = "";
					PromptBar.Label[4].text = "Selection";
					PromptBar.Label[5].text = "Selection";
					PromptBar.UpdateButtons();
					UpdateObjectiveHighlight();
					UpdateNemesisDifficulty();
					UpdateDifficultyLabel();
					CalculateMissionID();
					ChooseTarget();
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				Cursor.visible = false;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				TargetID = 0;
				Phase = 2;
			}
		}
	}

	private void GetNumbers()
	{
		TargetNumber = (int)char.GetNumericValue(MissionIDString[0]) * 10 + (int)char.GetNumericValue(MissionIDString[1]);
		WeaponNumber = (int)char.GetNumericValue(MissionIDString[2]) * 10 + (int)char.GetNumericValue(MissionIDString[3]);
		ClothingNumber = (int)char.GetNumericValue(MissionIDString[4]);
		DisposalNumber = (int)char.GetNumericValue(MissionIDString[5]);
		Condition5Number = (int)char.GetNumericValue(MissionIDString[6]);
		Condition6Number = (int)char.GetNumericValue(MissionIDString[7]);
		Condition7Number = (int)char.GetNumericValue(MissionIDString[8]);
		Condition8Number = (int)char.GetNumericValue(MissionIDString[9]);
		Condition9Number = (int)char.GetNumericValue(MissionIDString[10]);
		Condition10Number = (int)char.GetNumericValue(MissionIDString[11]);
		Condition11Number = (int)char.GetNumericValue(MissionIDString[12]);
		Condition12Number = (int)char.GetNumericValue(MissionIDString[13]);
		Condition13Number = (int)char.GetNumericValue(MissionIDString[14]);
		Condition14Number = (int)char.GetNumericValue(MissionIDString[15]);
		Condition15Number = (int)char.GetNumericValue(MissionIDString[16]);
		NemesisNumber = (int)char.GetNumericValue(MissionIDString[17]);
		PopulationNumber = (int)char.GetNumericValue(MissionIDString[18]);
	}

	private void LateUpdate()
	{
		if (Speed > 3f)
		{
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * (Speed - 3f));
		}
		Neck.transform.localEulerAngles = new Vector3(Neck.transform.localEulerAngles.x + Rotation, Neck.transform.localEulerAngles.y, Neck.transform.localEulerAngles.z);
	}

	private void UpdateHighlight()
	{
		if (Selected == 0)
		{
			Selected = 5;
		}
		else if (Selected == 6)
		{
			Selected = 1;
		}
	}

	private void ChooseTarget()
	{
		if (Phase != 5)
		{
			TargetID = Random.Range(2, 90);
			if (TargetNumber > 11 && TargetNumber < 21)
			{
				ChooseTarget();
			}
		}
		else
		{
			if (TargetNumber > 11 && TargetNumber < 21)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					TargetID++;
				}
				else
				{
					TargetID--;
				}
				ChooseTarget();
			}
			if (TargetID > 89)
			{
				TargetID = 2;
			}
			else if (TargetID < 2)
			{
				TargetID = 89;
			}
		}
		WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + TargetID + ".png");
		if (TargetNumber > 11 && TargetNumber < 21)
		{
			TargetPortrait.mainTexture = BlankPortrait;
		}
		else
		{
			TargetPortrait.mainTexture = wWW.texture;
		}
		CustomTargetPortrait.mainTexture = TargetPortrait.mainTexture;
		if (JSON.Students[TargetID].Name == "Random" || JSON.Students[TargetID].Name == "Unknown")
		{
			TargetName = StudentManager.FirstNames[Random.Range(0, StudentManager.FirstNames.Length)] + " " + StudentManager.LastNames[Random.Range(0, StudentManager.LastNames.Length)];
		}
		else
		{
			TargetName = JSON.Students[TargetID].Name;
		}
		CustomDescs[1].text = "Kill " + TargetName + ".";
		Descs[1].text = "Kill " + TargetName + ".";
		if (TargetID > 11 && TargetID < 21)
		{
			if (Phase == 5)
			{
				TargetID += (Input.GetButtonDown(InputNames.Xbox_A) ? 1 : (-1));
			}
			ChooseTarget();
		}
	}

	private void UpdateDifficulty()
	{
		if (Difficulty < 1)
		{
			Difficulty = 1;
		}
		else if (Difficulty > 10)
		{
			Difficulty = 10;
		}
		if (InputManager.TappedRight)
		{
			PickNewCondition();
		}
		else
		{
			ErasePreviousCondition();
		}
	}

	private void UpdateDifficultyLabel()
	{
		CustomDifficultyLabel.text = "Difficulty Level - " + Difficulty;
		DifficultyLabel.text = "Difficulty Level - " + Difficulty;
		string text = "Kill " + TargetName + ".";
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		empty = ((RequiredWeaponID != 0) ? ("You must kill the target with a " + WeaponNames[RequiredWeaponID]) : "You can kill the target with any weapon.");
		empty2 = ((RequiredClothingID != 0) ? ("You must kill the target while wearing " + ClothingNames[RequiredClothingID]) : "You can kill the target wearing any clothing.");
		empty3 = ((RequiredDisposalID != 0) ? ("You must dispose of the target's corpse by " + DisposalNames[RequiredDisposalID]) : "It is not necessary to dispose of the target's corpse.");
		DescriptionLabel.text = text + "\n\n" + empty + "\n\n" + empty2 + "\n\n" + empty3;
	}

	private void UpdateNemesisDifficulty()
	{
		if (NemesisDifficulty < 0)
		{
			NemesisDifficulty = 4;
		}
		else if (NemesisDifficulty > 4)
		{
			NemesisDifficulty = 0;
		}
		if (NemesisDifficulty == 0)
		{
			CustomNemesisLabel.text = "Nemesis: Off";
			NemesisLabel.text = "Nemesis: Off";
		}
		else
		{
			CustomNemesisLabel.text = "Nemesis: On";
			NemesisLabel.text = "Nemesis: On";
			NemesisPortrait.mainTexture = ((NemesisDifficulty > 2) ? BlankPortrait : NemesisGraphic);
		}
	}

	private void PickNewCondition()
	{
		int num = Random.Range(1, ConditionDescs.Length);
		Conditions[Difficulty] = num;
		Descs[Difficulty].text = ConditionDescs[num];
		Icons[Difficulty].mainTexture = ConditionIcons[num];
		bool flag = false;
		for (int i = 2; i < Difficulty; i++)
		{
			if (num == Conditions[i])
			{
				flag = true;
			}
		}
		if (flag)
		{
			PickNewCondition();
		}
		else if (num > 3)
		{
			Descs[Difficulty].text = ConditionDescs[num];
		}
		else
		{
			switch (num)
			{
			case 1:
				RequiredWeaponID = 11;
				while (RequiredWeaponID == 11 || RequiredWeaponID == 17 || RequiredWeaponID == 26 || RequiredWeaponID == 32)
				{
					RequiredWeaponID = Random.Range(1, WeaponNames.Length);
				}
				Descs[Difficulty].text = ConditionDescs[num] + " " + WeaponNames[RequiredWeaponID];
				break;
			case 2:
				RequiredClothingID = Random.Range(1, ClothingNames.Length);
				Descs[Difficulty].text = ConditionDescs[num] + " " + ClothingNames[RequiredClothingID];
				break;
			case 3:
				RequiredDisposalID = Random.Range(1, DisposalNames.Length);
				Descs[Difficulty].text = ConditionDescs[num] + " " + DisposalNames[RequiredDisposalID];
				break;
			}
		}
		UpdateDifficultyLabel();
	}

	private void ErasePreviousCondition()
	{
		if (Conditions[Difficulty + 1] == 1)
		{
			RequiredWeaponID = 0;
		}
		else if (Conditions[Difficulty + 1] == 2)
		{
			RequiredClothingID = 0;
		}
		else if (Conditions[Difficulty + 1] == 3)
		{
			RequiredDisposalID = 0;
		}
		Conditions[Difficulty + 1] = 0;
		UpdateDifficultyLabel();
	}

	public void UpdateGraphics()
	{
		TargetID = MissionModeGlobals.MissionTarget;
		if (TargetNumber > 11 && TargetNumber < 21)
		{
			TargetPortrait.mainTexture = BlankPortrait;
			TargetName = MissionModeGlobals.MissionTargetName;
		}
		else
		{
			WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + MissionModeGlobals.MissionTarget + ".png");
			Icons[1].mainTexture = wWW.texture;
			TargetName = JSON.Students[MissionModeGlobals.MissionTarget].Name;
		}
		Descs[1].text = "Kill " + TargetName + ".";
		ChangeLabel(Descs[1]);
		for (int i = 2; i < Objectives.Length; i++)
		{
			Objectives[i].gameObject.SetActive(value: false);
		}
		if (MissionModeGlobals.MissionDifficulty <= 1)
		{
			return;
		}
		for (int j = 2; j < MissionModeGlobals.MissionDifficulty + 1; j++)
		{
			Objectives[j].gameObject.SetActive(value: true);
			Icons[j].mainTexture = ConditionIcons[MissionModeGlobals.GetMissionCondition(j)];
			ChangeLabel(Descs[j]);
			if (MissionModeGlobals.GetMissionCondition(j) > 3)
			{
				Descs[j].text = ConditionDescs[MissionModeGlobals.GetMissionCondition(j)];
			}
			else if (MissionModeGlobals.GetMissionCondition(j) == 1)
			{
				for (RequiredWeaponID = 11; RequiredWeaponID == 11; RequiredWeaponID = Random.Range(1, WeaponNames.Length))
				{
				}
				Descs[j].text = ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + WeaponNames[MissionModeGlobals.MissionRequiredWeapon];
			}
			else if (MissionModeGlobals.GetMissionCondition(j) == 2)
			{
				RequiredClothingID = Random.Range(0, ClothingNames.Length);
				Descs[j].text = ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + ClothingNames[MissionModeGlobals.MissionRequiredClothing];
			}
			else if (MissionModeGlobals.GetMissionCondition(j) == 3)
			{
				RequiredDisposalID = Random.Range(1, DisposalNames.Length);
				Descs[j].text = ConditionDescs[MissionModeGlobals.GetMissionCondition(j)] + " " + DisposalNames[MissionModeGlobals.MissionRequiredDisposal];
			}
		}
	}

	private void UpdatePopulation()
	{
		CustomPopulationLabel.text = "";
		PopulationLabel.text = "";
		OptionGlobals.HighPopulation = false;
	}

	private void UpdateObjectiveHighlight()
	{
		if (Row < 1)
		{
			Row = 6;
		}
		else if (Row > 6)
		{
			Row = 1;
		}
		else if (Column < 1)
		{
			Column = 3;
		}
		else if (Column > 3)
		{
			Column = 1;
		}
		if (Row == 6 && Column == 3)
		{
			Column = 1;
		}
		int num = 0;
		if (Row == 6)
		{
			num = 75;
		}
		PromptBar.Label[2].text = (((Column == 1 && Row < 5) || (Column == 2 && Row == 6)) ? "Change" : string.Empty);
		ObjectiveHighlight.localPosition = new Vector3(-1050f + 650f * (float)Column, 450f - 150f * (float)Row - (float)num, ObjectiveHighlight.localPosition.z);
		CustomSelected = Row + (Column - 1) * 6;
		Toggling = false;
		if (CustomSelected == 1 || CustomSelected == 12)
		{
			PromptBar.Label[0].text = "Forward";
		}
		else if (CustomSelected == 6)
		{
			PromptBar.Label[0].text = "Start";
		}
		else
		{
			PromptBar.Label[0].text = "Toggle";
			Toggling = true;
		}
		if (CustomSelected == 1 || CustomSelected == 12)
		{
			PromptBar.Label[2].text = "Backward";
		}
		else if (CustomSelected > 4)
		{
			PromptBar.Label[2].text = string.Empty;
		}
		else
		{
			PromptBar.Label[2].text = "Change";
		}
		if (CustomSelected == 12)
		{
			PromptBar.Label[3].text = "Aggression";
		}
		else
		{
			PromptBar.Label[3].text = "";
		}
		PromptBar.UpdateButtons();
	}

	private void CalculateMissionID()
	{
		TargetString = ((TargetID < 10) ? "0" : "") + TargetID;
		if (CustomObjectives[2].alpha == 1f)
		{
			WeaponString = ((RequiredWeaponID < 10) ? "0" : "") + RequiredWeaponID;
		}
		else
		{
			WeaponString = "00";
		}
		ClothingString = ((CustomObjectives[3].alpha == 1f) ? RequiredClothingID.ToString() : "0");
		DisposalString = ((CustomObjectives[4].alpha == 1f) ? RequiredDisposalID.ToString() : "0");
		for (int i = 1; i < CustomObjectives.Length; i++)
		{
			if (CustomObjectives[i] != null)
			{
				ConditionString[i] = ((CustomObjectives[i].alpha == 1f) ? "1" : "0");
			}
		}
		MissionID = TargetString + WeaponString + ClothingString + DisposalString + ConditionString[5] + ConditionString[6] + ConditionString[7] + ConditionString[8] + ConditionString[9] + ConditionString[10] + ConditionString[11] + ConditionString[12] + ConditionString[13] + ConditionString[14] + ConditionString[15] + ConditionString[16] + ConditionString[17] + NemesisDifficulty + "0";
		MissionIDLabel.text = MissionID;
	}

	private void StartMission()
	{
		MyAudio.PlayOneShot(InfoLines[6]);
		Debug.Log("Switching GameGlobals.Profile to 4, since we are beginning a Mission Mode mission, and nothing we do in here should carry over to any of the player's other save files.");
		GameGlobals.Profile = 4;
		Globals.DeleteAll();
		OptionGlobals.TutorialsOff = true;
		SchoolGlobals.SchoolAtmosphere = 1f - (float)Difficulty * 0.1f;
		MissionModeGlobals.NemesisDifficulty = NemesisDifficulty;
		MissionModeGlobals.NemesisAggression = NemesisAggression;
		MissionModeGlobals.MissionTargetName = TargetName;
		MissionModeGlobals.MissionDifficulty = Difficulty;
		MissionModeGlobals.MissionTarget = TargetID;
		SchoolGlobals.SchoolAtmosphereSet = true;
		MissionModeGlobals.MissionMode = true;
		ClassGlobals.BiologyGrade = 1;
		ClassGlobals.ChemistryGrade = 1;
		ClassGlobals.LanguageGrade = 1;
		ClassGlobals.PhysicalGrade = 1;
		ClassGlobals.PsychologyGrade = 1;
		if (Difficulty > 1)
		{
			for (int i = 2; i < Difficulty + 1; i++)
			{
				if (Conditions[i] == 1)
				{
					MissionModeGlobals.MissionRequiredWeapon = RequiredWeaponID;
				}
				else if (Conditions[i] == 2)
				{
					MissionModeGlobals.MissionRequiredClothing = RequiredClothingID;
				}
				else if (Conditions[i] == 3)
				{
					MissionModeGlobals.MissionRequiredDisposal = RequiredDisposalID;
				}
				MissionModeGlobals.SetMissionCondition(i, Conditions[i]);
			}
		}
		PromptBar.Show = false;
		Speed = 0f;
		Phase = 4;
	}

	private void ChangeFont()
	{
		UILabel[] array = Object.FindObjectsOfType<UILabel>();
		foreach (UILabel uILabel in array)
		{
			uILabel.trueTypeFont = Arial;
			uILabel.fontSize += 10;
			if (uILabel.height == 150)
			{
				uILabel.height = 100;
			}
		}
	}

	private void ChangeLabel(UILabel Text)
	{
		Text.trueTypeFont = Arial;
	}
}
