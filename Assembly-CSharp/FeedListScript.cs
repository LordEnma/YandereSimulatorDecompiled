using UnityEngine;

public class FeedListScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public Transform Highlight;

	public Transform FeedList;

	public PromptScript Prompt;

	public GameObject Line;

	public JsonScript JSON;

	public GameObject[] Lines;

	public UILabel[] Names;

	public string[] StudentNames;

	public int RowLimit = 23;

	public int Selected = 1;

	public int Column = 1;

	public int Row = 1;

	public int[] PositionX;

	public bool Show;

	private void Start()
	{
		FeedList.localPosition = new Vector3(0f, -1200f, 0f);
		for (int i = 1; i < 101; i++)
		{
			StudentNames[i] = JSON.Students[i].Name;
		}
		int week = DateGlobals.Week;
		for (int i = 2; i < 11; i++)
		{
			if (i > week)
			{
				StudentNames[10 + i] = "";
			}
		}
		Names[1].text = StudentNames[1] + "\n" + StudentNames[2] + "\n" + StudentNames[3] + "\n" + StudentNames[4] + "\n" + StudentNames[5] + "\n" + StudentNames[6] + "\n" + StudentNames[7] + "\n" + StudentNames[8] + "\n" + StudentNames[9] + "\n" + StudentNames[10] + "\n" + StudentNames[11] + "\n" + StudentNames[12] + "\n" + StudentNames[13] + "\n" + StudentNames[14] + "\n" + StudentNames[15] + "\n" + StudentNames[16] + "\n" + StudentNames[17] + "\n" + StudentNames[18] + "\n" + StudentNames[19] + "\n" + StudentNames[20] + "\n" + StudentNames[21] + "\n" + StudentNames[22] + "\n" + StudentNames[23];
		Names[2].text = StudentNames[24] + "\n" + StudentNames[25] + "\n" + StudentNames[26] + "\n" + StudentNames[27] + "\n" + StudentNames[28] + "\n" + StudentNames[29] + "\n" + StudentNames[30] + "\n" + StudentNames[31] + "\n" + StudentNames[32] + "\n" + StudentNames[33] + "\n" + StudentNames[34] + "\n" + StudentNames[35] + "\n" + StudentNames[36] + "\n" + StudentNames[37] + "\n" + StudentNames[38] + "\n" + StudentNames[39] + "\n" + StudentNames[40] + "\n" + StudentNames[41] + "\n" + StudentNames[42] + "\n" + StudentNames[43] + "\n" + StudentNames[44] + "\n" + StudentNames[45] + "\n" + StudentNames[46];
		Names[3].text = StudentNames[47] + "\n" + StudentNames[48] + "\n" + StudentNames[49] + "\n" + StudentNames[50] + "\n" + StudentNames[51] + "\n" + StudentNames[52] + "\n" + StudentNames[53] + "\n" + StudentNames[54] + "\n" + StudentNames[55] + "\n" + StudentNames[56] + "\n" + StudentNames[57] + "\n" + StudentNames[58] + "\n" + StudentNames[59] + "\n" + StudentNames[60] + "\n" + StudentNames[61] + "\n" + StudentNames[62] + "\n" + StudentNames[63] + "\n" + StudentNames[64] + "\n" + StudentNames[65] + "\n" + StudentNames[66] + "\n" + StudentNames[67] + "\n" + StudentNames[68] + "\n" + StudentNames[69];
		Names[4].text = StudentNames[70] + "\n" + StudentNames[71] + "\n" + StudentNames[72] + "\n" + StudentNames[73] + "\n" + StudentNames[74] + "\n" + StudentNames[75] + "\n" + StudentNames[76] + "\n" + StudentNames[77] + "\n" + StudentNames[78] + "\n" + StudentNames[79] + "\n" + StudentNames[80] + "\n" + StudentNames[81] + "\n" + StudentNames[82] + "\n" + StudentNames[83] + "\n" + StudentNames[84] + "\n" + StudentNames[85] + "\n" + StudentNames[86] + "\n" + StudentNames[87] + "\n" + StudentNames[88] + "\n" + StudentNames[89];
		int num = 1;
		Selected = 1;
		Column = 1;
		Row = 1;
		UpdateHighlight();
		while (num < 90)
		{
			GameObject gameObject = Object.Instantiate(Line, Highlight.position, Quaternion.identity);
			gameObject.transform.parent = Highlight.parent;
			gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			gameObject.SetActive(value: false);
			Lines[num] = gameObject;
			num++;
			if (num < 90)
			{
				Row++;
				if (Row > RowLimit)
				{
					if (Row > RowLimit)
					{
						Row = 1;
					}
					Column++;
				}
			}
			else
			{
				Column = 1;
				Row = 1;
			}
			UpdateHighlight();
		}
		CrossOutStudents();
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			PromptBar.Show = true;
			PromptBar.Label[0].text = "Cross Out";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Select";
			PromptBar.Label[5].text = "Select";
			PromptBar.UpdateButtons();
			Prompt.Circle[0].fillAmount = 1f;
			Time.timeScale = 0.0001f;
			Show = true;
		}
		if (Show)
		{
			FeedList.localPosition = Vector3.Lerp(FeedList.localPosition, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			if (InputManager.TappedDown)
			{
				Row++;
				if (Row > RowLimit)
				{
					Row = 1;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				Row--;
				if (Row == 0)
				{
					Row = RowLimit;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedRight)
			{
				Column++;
				if (Column > 4)
				{
					Column = 1;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				if (Column == 0)
				{
					Column = 4;
				}
				UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				if (StudentNames[Selected] != "")
				{
					Lines[Selected].SetActive(!Lines[Selected].activeInHierarchy);
				}
				CrossOutStudents();
			}
			if (!Input.GetButtonDown("B"))
			{
				return;
			}
			for (int i = 1; i < 90; i++)
			{
				if (Prompt.Yandere.StudentManager.Students[i] != null)
				{
					Prompt.Yandere.StudentManager.Students[i].DoNotFeed = Lines[i].activeInHierarchy;
					if (Lines[i].activeInHierarchy)
					{
						Debug.Log("Line #" + i + " was active.");
						Debug.Log("Student #" + i + "'s DoNotFeed variable is now: " + Prompt.Yandere.StudentManager.Students[i].DoNotFeed);
					}
				}
			}
			PromptBar.Show = false;
			PromptBar.ClearButtons();
			Time.timeScale = 1f;
			Show = false;
		}
		else if (FeedList.localPosition.y > -1199f)
		{
			FeedList.localPosition = Vector3.Lerp(FeedList.localPosition, new Vector3(0f, -1200f, 0f), Time.deltaTime * 10f);
		}
	}

	private void UpdateHighlight()
	{
		if (Column < 4)
		{
			RowLimit = 23;
		}
		else
		{
			RowLimit = 20;
		}
		if (Row > RowLimit)
		{
			Row = RowLimit;
		}
		Selected = (Column - 1) * 23 + Row;
		Highlight.localPosition = new Vector3(PositionX[Column], 475f - 36.8f * (float)Row, 0f);
	}

	private void CrossOutStudents()
	{
		Lines[21].SetActive(value: true);
		Lines[22].SetActive(value: true);
		Lines[23].SetActive(value: true);
		Lines[24].SetActive(value: true);
		Lines[25].SetActive(value: true);
		Lines[66].SetActive(value: true);
		Lines[67].SetActive(value: true);
		Lines[68].SetActive(value: true);
		Lines[69].SetActive(value: true);
		Lines[70].SetActive(value: true);
		Lines[76].SetActive(value: true);
		Lines[77].SetActive(value: true);
		Lines[78].SetActive(value: true);
		Lines[79].SetActive(value: true);
		Lines[80].SetActive(value: true);
		if (Prompt.Yandere.StudentManager.Eighties)
		{
			Lines[81].SetActive(value: true);
			Lines[82].SetActive(value: true);
			Lines[83].SetActive(value: true);
			Lines[84].SetActive(value: true);
			Lines[85].SetActive(value: true);
		}
	}
}
