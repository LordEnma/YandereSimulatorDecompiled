using System.Collections;
using UnityEngine;

public class TaskListScript : MonoBehaviour
{
	public TutorialWindowScript TutorialWindow;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public TaskWindowScript TaskWindow;

	public JsonScript JSON;

	public GameObject MainMenu;

	public UITexture StudentIcon;

	public UITexture TaskIcon;

	public UILabel TaskDesc;

	public Texture QuestionMark;

	public Transform Highlight;

	public Texture Silhouette;

	public UILabel[] TaskNameLabels;

	public UISprite[] Checkmarks;

	public Texture[] TutorialTextures;

	public string[] TutorialDescs;

	public string[] TutorialNames;

	public float HeldDown;

	public float HeldUp;

	public int ListPosition;

	public int Limit = 84;

	public int ID = 1;

	public bool Tutorials;

	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			TaskDesc.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	private void Update()
	{
		if (InputManager.DPadUp || InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
		{
			HeldUp += Time.unscaledDeltaTime;
		}
		else
		{
			HeldUp = 0f;
		}
		if (InputManager.DPadDown || InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
		{
			HeldDown += Time.unscaledDeltaTime;
		}
		else
		{
			HeldDown = 0f;
		}
		if (InputManager.TappedUp || HeldUp > 0.5f)
		{
			if (HeldUp > 0.5f)
			{
				HeldUp = 0.45f;
			}
			if (ID == 1)
			{
				ListPosition--;
				if (ListPosition < 0)
				{
					ListPosition = Limit - 16;
					ID = 16;
				}
			}
			else
			{
				ID--;
			}
			UpdateTaskList();
			StartCoroutine(UpdateTaskInfo());
		}
		if (InputManager.TappedDown || HeldDown > 0.5f)
		{
			if (HeldDown > 0.5f)
			{
				HeldDown = 0.45f;
			}
			if (ID == 16)
			{
				ListPosition++;
				if (ID + ListPosition > Limit)
				{
					ListPosition = 0;
					ID = 1;
				}
			}
			else
			{
				ID++;
			}
			UpdateTaskList();
			StartCoroutine(UpdateTaskInfo());
		}
		if (Tutorials)
		{
			if (!TutorialWindow.Hide && !TutorialWindow.Show)
			{
				if (Input.GetButtonDown("A"))
				{
					OptionGlobals.TutorialsOff = false;
					TutorialWindow.ForceID = ListPosition + ID;
					TutorialWindow.ShowTutorial();
					TutorialWindow.enabled = true;
					TutorialWindow.SummonWindow();
					PauseScreen.PromptBar.Show = false;
				}
				else if (Input.GetButtonDown("B"))
				{
					Exit();
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			Exit();
		}
	}

	public void UpdateTaskList()
	{
		if (!TaskWindow.TaskManager.Initialized)
		{
			TaskWindow.TaskManager.Start();
		}
		if (Tutorials)
		{
			for (int i = 1; i < TaskNameLabels.Length; i++)
			{
				TaskNameLabels[i].text = TutorialNames[i + ListPosition];
			}
			return;
		}
		for (int j = 1; j < TaskNameLabels.Length; j++)
		{
			if (TaskWindow.TaskManager.TaskStatus[j + ListPosition] == 0)
			{
				TaskNameLabels[j].text = "Undiscovered Task #" + (j + ListPosition);
			}
			else
			{
				TaskNameLabels[j].text = JSON.Students[j + ListPosition].Name + "'s Task";
			}
			Checkmarks[j].enabled = TaskWindow.TaskManager.TaskStatus[j + ListPosition] == 3;
		}
	}

	public IEnumerator UpdateTaskInfo()
	{
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 200f - 25f * (float)ID, Highlight.localPosition.z);
		if (Tutorials)
		{
			TaskIcon.mainTexture = TutorialTextures[ID + ListPosition];
			TaskDesc.text = "This tutorial will teach you about the topic of ''" + TutorialNames[ID + ListPosition] + "''.";
			yield break;
		}
		string text = "";
		if (GameGlobals.Eighties)
		{
			text = "1989";
		}
		if (TaskWindow.TaskManager.TaskStatus[ID + ListPosition] == 0)
		{
			StudentIcon.mainTexture = Silhouette;
			TaskIcon.mainTexture = QuestionMark;
			TaskDesc.text = "This task has not been discovered yet.";
			yield break;
		}
		string url = "file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + (ID + ListPosition) + ".png";
		WWW www = new WWW(url);
		yield return www;
		StudentIcon.mainTexture = www.texture;
		TaskWindow.AltGenericCheck(ID + ListPosition);
		if (TaskWindow.Generic)
		{
			TaskIcon.mainTexture = TaskWindow.Icons[0];
			TaskDesc.text = TaskWindow.Descriptions[0];
		}
		else
		{
			TaskIcon.mainTexture = TaskWindow.Icons[ID + ListPosition];
			TaskDesc.text = TaskWindow.Descriptions[ID + ListPosition];
		}
	}

	public void Exit()
	{
		PauseScreen.PromptBar.ClearButtons();
		PauseScreen.PromptBar.Label[0].text = "Accept";
		PauseScreen.PromptBar.Label[1].text = "Back";
		PauseScreen.PromptBar.Label[4].text = "Choose";
		PauseScreen.PromptBar.Label[5].text = "Choose";
		PauseScreen.PromptBar.UpdateButtons();
		PauseScreen.Sideways = false;
		PauseScreen.PressedB = true;
		MainMenu.SetActive(value: true);
		base.gameObject.SetActive(value: false);
	}
}
