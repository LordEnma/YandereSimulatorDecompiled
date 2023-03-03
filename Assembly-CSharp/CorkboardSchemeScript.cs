using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CorkboardSchemeScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public UISprite SchemeSelectWindow;

	public UISprite Darkness;

	public VideoPlayer Video;

	public UIPanel ExplanationPanel;

	public PromptBarScript PromptBar;

	public GameObject CorkboardPhotos;

	public GameObject CorkboardLight;

	public AudioSource Jukebox;

	public float Rotation;

	public float Speed;

	public float Timer;

	public int Phase;

	public string[] MethodNames;

	public string[] MethodDescs;

	public int[] MethodDifficulties;

	public int[] SchemeIDs;

	public UILabel MethodName;

	public UILabel MethodDesc;

	public Transform ScrollBar;

	public Transform IconPanel;

	public Transform Highlight;

	public Transform Reference;

	public GameObject[] Hearts;

	public bool NoChangeHeight;

	public int TargetHeight;

	public int MethodID;

	public int Column;

	public int Row;

	private void Start()
	{
		if (!HomeGlobals.Night || GameGlobals.Eighties)
		{
			Debug.Log("Disabling the Corkboard cutscene because it's daytime, or because we're in the 80s.");
			GameGlobals.CorkboardScene = true;
			base.gameObject.SetActive(value: false);
		}
		else if (!GameGlobals.CorkboardScene)
		{
			Debug.Log("CorkboardCutscene acknowledges that it should be running.");
			Video.transform.parent.localScale = Vector3.zero;
			CorkboardPhotos.SetActive(value: true);
			CorkboardLight.SetActive(value: true);
			SchemeSelectWindow.alpha = 0f;
			ExplanationPanel.alpha = 0f;
			Darkness.enabled = true;
			Darkness.alpha = 1f;
			UpdateHighlight();
		}
		else
		{
			Debug.Log("Disabling the Corkboard cutscene because we've already seen it.");
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 1f, Time.deltaTime);
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f || Input.GetButtonDown("A"))
			{
				Darkness.alpha = 0f;
				Jukebox.volume = 1f;
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			Speed += Time.deltaTime * 0.1f;
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-0.9f, 1.5f, -1.5f), Time.deltaTime * Speed);
			Rotation = Mathf.Lerp(Rotation, -165f, Time.deltaTime * Speed);
			base.transform.eulerAngles = new Vector3(0f, Rotation, 0f);
			if (Speed > 1.2f || Input.GetButtonDown("A"))
			{
				base.transform.position = new Vector3(-0.9f, 1.5f, -1.5f);
				base.transform.eulerAngles = new Vector3(0f, -165f, 0f);
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			SchemeSelectWindow.alpha = Mathf.MoveTowards(SchemeSelectWindow.alpha, 1f, Time.deltaTime);
			if (SchemeSelectWindow.alpha == 1f || Input.GetButtonDown("A"))
			{
				SchemeSelectWindow.alpha = 1f;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			ExplanationPanel.alpha = Mathf.MoveTowards(ExplanationPanel.alpha, 1f, Time.deltaTime);
			if (ExplanationPanel.alpha == 1f || Input.GetButtonDown("A"))
			{
				Video.enabled = true;
				ExplanationPanel.alpha = 1f;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Okay";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Video.transform.parent.localScale = Vector3.Lerp(Video.transform.parent.localScale, new Vector3(0.00075f, 0.00075f, 0f), Time.deltaTime * 10f);
			if (Input.GetButtonDown("A"))
			{
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Video.transform.parent.localScale = Vector3.Lerp(Video.transform.parent.localScale, Vector3.zero, Time.deltaTime * 10f);
			ExplanationPanel.alpha = Mathf.MoveTowards(ExplanationPanel.alpha, 0f, Time.deltaTime);
			if (ExplanationPanel.alpha == 0f || Input.GetButtonDown("A"))
			{
				Video.transform.parent.localScale = Vector3.zero;
				Video.enabled = false;
				ExplanationPanel.alpha = 0f;
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Choose";
				PromptBar.Label[4].text = "Select";
				PromptBar.Label[5].text = "Select";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			if (InputManager.TappedRight)
			{
				Column++;
				if (Column > 3)
				{
					Column = 1;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				if (Column < 1)
				{
					Column = 3;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedDown)
			{
				Row++;
				if (Row > 7)
				{
					NoChangeHeight = true;
					TargetHeight = 0;
					Row = 1;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				Row--;
				if (Row < 1)
				{
					NoChangeHeight = true;
					TargetHeight = 4;
					Row = 7;
				}
				UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				PromptBar.Show = false;
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			SchemeSelectWindow.alpha = Mathf.MoveTowards(SchemeSelectWindow.alpha, 0f, Time.deltaTime);
			if (SchemeSelectWindow.alpha == 0f || Input.GetButtonDown("A"))
			{
				SchemeSelectWindow.alpha = 0f;
				Phase++;
			}
		}
		else if (Phase == 8)
		{
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0f, Time.deltaTime);
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha == 1f || Input.GetButtonDown("A"))
			{
				if (MethodID == 10)
				{
					SchemeGlobals.SetSchemeUnlocked(1, value: true);
					SchemeGlobals.SetSchemeUnlocked(2, value: true);
					SchemeGlobals.SetSchemeUnlocked(3, value: true);
					SchemeGlobals.SetSchemeUnlocked(4, value: true);
					SchemeGlobals.SetSchemeUnlocked(5, value: true);
					SchemeGlobals.SetSchemeStage(1, 1);
					SchemeGlobals.CurrentScheme = 1;
				}
				else if (MethodID == 19)
				{
					SchemeGlobals.SetSchemeUnlocked(21, value: true);
					SchemeGlobals.SetSchemeUnlocked(22, value: true);
					SchemeGlobals.SetSchemeUnlocked(23, value: true);
					SchemeGlobals.SetSchemeUnlocked(24, value: true);
					SchemeGlobals.SetSchemeUnlocked(25, value: true);
					SchemeGlobals.SetSchemeStage(21, 1);
					SchemeGlobals.CurrentScheme = 21;
				}
				else
				{
					SchemeGlobals.SetSchemeUnlocked(SchemeIDs[MethodID], value: true);
					SchemeGlobals.SetSchemeStage(SchemeIDs[MethodID], 1);
					SchemeGlobals.CurrentScheme = SchemeIDs[MethodID];
				}
				GameGlobals.CorkboardScene = true;
				Darkness.alpha = 1f;
				Jukebox.volume = 0f;
				HomeGlobals.Night = false;
				DateGlobals.Weekday = DayOfWeek.Sunday;
				if (DateGlobals.PassDays < 1)
				{
					DateGlobals.PassDays = 1;
				}
				SceneManager.LoadScene("CalendarScene");
			}
		}
		IconPanel.localPosition = Vector3.Lerp(IconPanel.localPosition, new Vector3(0f, 300 * TargetHeight, 0f), Time.deltaTime * 10f);
		ScrollBar.localPosition = Vector3.Lerp(ScrollBar.localPosition, new Vector3(-477.5f, 410f - (float)(Row - 1) * 136.66666f), Time.deltaTime * 10f);
	}

	public void UpdateHighlight()
	{
		GameObject[] hearts = Hearts;
		foreach (GameObject gameObject in hearts)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
		MethodID = Column + (Row - 1) * 3;
		Highlight.localPosition = new Vector3(-600 + 300 * Column, 600 - 300 * Row, 0f);
		MethodName.text = MethodNames[MethodID];
		MethodDesc.text = MethodDescs[MethodID];
		MethodDesc.text = MethodDesc.text.Replace("`", "\n\n");
		if (MethodID > 1)
		{
			for (int num = MethodDifficulties[MethodID]; num > 0; num--)
			{
				Hearts[num].SetActive(value: true);
			}
		}
		if (NoChangeHeight)
		{
			NoChangeHeight = false;
		}
		else if (Highlight.position.y < Reference.position.y - 0.5f)
		{
			TargetHeight++;
		}
		else if (Highlight.position.y > Reference.position.y + 0.5f)
		{
			TargetHeight--;
		}
		TargetHeight = Mathf.Clamp(TargetHeight, 0, 4);
	}
}
