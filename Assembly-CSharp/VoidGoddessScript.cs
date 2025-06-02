using UnityEngine;

public class VoidGoddessScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptScript Prompt;

	public Renderer SenpaiPortraitRenderer;

	public GameObject SenpaiPortrait;

	public GameObject BloodyUniform;

	public GameObject NewPortrait;

	public GameObject SeveredLimb;

	public GameObject WaterPuddle;

	public GameObject BloodPool;

	public GameObject Portrait;

	public GameObject Goddess;

	public Transform BloodParent;

	public Transform Highlight;

	public Transform Window;

	public Transform Head;

	public UITexture[] Portraits;

	public Animation[] Legs;

	public bool PassingJudgement;

	public bool Initialized;

	public bool CustomMode;

	public bool Disabled;

	public bool Follow;

	public int Selected;

	public int Column;

	public int Row;

	public int ID;

	public Texture BlankPortrait;

	public Texture Headmaster;

	public Texture Counselor;

	public Texture Infochan;

	public int CurrentTarget = 2;

	public Transform RightAngle;

	public void Start()
	{
		Window.parent.gameObject.SetActive(value: false);
		if (Initialized)
		{
			return;
		}
		if (base.gameObject.activeInHierarchy)
		{
			Legs[1]["SpiderLegWiggle"].speed = 1f;
			Legs[2]["SpiderLegWiggle"].speed = 0.95f;
			Legs[3]["SpiderLegWiggle"].speed = 0.9f;
			Legs[4]["SpiderLegWiggle"].speed = 0.85f;
			Legs[5]["SpiderLegWiggle"].speed = 0.8f;
			Legs[6]["SpiderLegWiggle"].speed = 0.75f;
			Legs[7]["SpiderLegWiggle"].speed = 0.7f;
			Legs[8]["SpiderLegWiggle"].speed = 0.65f;
		}
		string text = "";
		if (GameGlobals.Eighties)
		{
			text = "1989";
			if (GameGlobals.CustomMode)
			{
				text = "Custom";
				CustomMode = true;
			}
		}
		for (ID = 1; ID < 101; ID++)
		{
			NewPortrait = Object.Instantiate(Portrait, base.transform.position, Quaternion.identity);
			if (ID == 1)
			{
				SenpaiPortrait = NewPortrait;
			}
			NewPortrait.transform.parent = Window;
			NewPortrait.transform.localScale = new Vector3(1f, 1f, 1f);
			NewPortrait.transform.localPosition = new Vector3(-450 + Column * 100, 450 - Row * 100, 0f);
			Portraits[ID] = NewPortrait.GetComponent<UITexture>();
			if (!StudentManager.Eighties && ID > 12 && ID < 21)
			{
				NewPortrait.GetComponent<UITexture>().mainTexture = Prompt.Yandere.PauseScreen.StudentInfoMenu.RivalPortraits[ID];
			}
			else if (ID < 98)
			{
				WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + text + "/Student_" + ID + ".png");
				NewPortrait.GetComponent<UITexture>().mainTexture = wWW.texture;
			}
			else if (ID == 98)
			{
				NewPortrait.GetComponent<UITexture>().mainTexture = Counselor;
			}
			else if (ID == 99)
			{
				NewPortrait.GetComponent<UITexture>().mainTexture = Headmaster;
			}
			else if (ID == 100)
			{
				NewPortrait.GetComponent<UITexture>().mainTexture = Infochan;
			}
			Column++;
			if (Column == 10)
			{
				Column = 0;
				Row++;
			}
		}
		if (CustomMode)
		{
			SenpaiPortraitRenderer.material.mainTexture = SenpaiPortrait.GetComponent<UITexture>().mainTexture;
		}
		Selected = 1;
		Column = 0;
		Row = 0;
		UpdatePortraits();
		Initialized = true;
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Goddess.activeInHierarchy)
			{
				Prompt.Yandere.Police.Invalid = true;
				Prompt.Label[0].text = "     Pass Judgement";
				Prompt.Label[1].text = "     Dismiss";
				Prompt.Label[2].text = "     Follow";
				Prompt.HideButton[1] = false;
				Prompt.HideButton[2] = false;
				Prompt.OffsetX[0] = 0f;
				Goddess.SetActive(value: true);
			}
			else
			{
				Window.parent.gameObject.SetActive(value: true);
				Window.gameObject.SetActive(value: true);
				Prompt.Yandere.CanMove = false;
				PassingJudgement = true;
			}
		}
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Label[0].text = "     Summon An Ancient Evil";
			Prompt.Label[1].text = "";
			Prompt.Label[2].text = "";
			Prompt.HideButton[1] = true;
			Prompt.HideButton[2] = true;
			Prompt.OffsetX[0] = 0f;
			base.transform.position = new Vector3(-9.5f, 1f, -75f);
			Goddess.SetActive(value: false);
			Follow = false;
		}
		if (Prompt.Circle[2].fillAmount == 0f)
		{
			Prompt.Circle[2].fillAmount = 1f;
			Follow = !Follow;
		}
		if (Follow && Vector3.Distance(Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position) > 1f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime);
		}
		if (!PassingJudgement)
		{
			return;
		}
		if (InputManager.TappedUp)
		{
			Row--;
			UpdateHighlight();
		}
		else if (InputManager.TappedDown)
		{
			Row++;
			UpdateHighlight();
		}
		if (InputManager.TappedLeft)
		{
			Column--;
			UpdateHighlight();
		}
		else if (InputManager.TappedRight)
		{
			Column++;
			UpdateHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			StudentManager.DisableStudent(Selected);
			UpdatePortraits();
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (!Disabled)
			{
				StudentManager.DisableEveryone();
				Disabled = true;
			}
			else
			{
				for (ID = 1; ID < 101; ID++)
				{
					StudentManager.DisableStudent(ID);
				}
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			for (ID = 1; ID < 11; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			for (ID = 11; ID < 21; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			for (ID = 21; ID < 26; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			for (ID = 26; ID < 31; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			for (ID = 31; ID < 36; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			for (ID = 36; ID < 41; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			for (ID = 41; ID < 46; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			for (ID = 46; ID < 51; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			for (ID = 51; ID < 56; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("-"))
		{
			for (ID = 56; ID < 61; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("="))
		{
			for (ID = 61; ID < 66; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("r"))
		{
			for (ID = 66; ID < 71; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("t"))
		{
			for (ID = 71; ID < 76; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("y"))
		{
			for (ID = 76; ID < 81; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("u"))
		{
			for (ID = 81; ID < 86; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("i"))
		{
			for (ID = 86; ID < 90; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("o"))
		{
			for (ID = 90; ID < 98; ID++)
			{
				StudentManager.DisableStudent(ID);
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("p"))
		{
			for (ID = 1; ID < 101; ID++)
			{
				if (ID != 21 && ID != 26 && ID != 31 && ID != 36 && ID != 41 && ID != 46 && ID != 51 && ID != 56 && ID != 61 && ID != 66 && ID != 71)
				{
					StudentManager.DisableStudent(ID);
				}
			}
			UpdatePortraits();
		}
		else if (Input.GetKeyDown("space"))
		{
			for (ID = 2; ID < 101; ID++)
			{
				if (ID != 1 && ID != 10 && ID != 11)
				{
					StudentManager.DisableStudent(ID);
				}
			}
			if (StudentManager.Students[7].gameObject.activeInHierarchy)
			{
				StudentManager.DisableStudent(7);
			}
			UpdatePortraits();
		}
		if (Input.GetButtonDown("B"))
		{
			Window.parent.gameObject.SetActive(value: false);
			Prompt.Yandere.CanMove = true;
			Prompt.Yandere.Shoved = false;
			PassingJudgement = false;
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			StudentManager.Students[Selected].transform.position = Prompt.Yandere.transform.position + Prompt.Yandere.transform.forward;
			Physics.SyncTransforms();
		}
		if (Input.GetKeyDown(KeyCode.X) && Selected > 1)
		{
			StudentManager.Students[Selected].BecomeRagdoll();
			StudentManager.Students[Selected].Ragdoll.NeckSnapped = true;
		}
	}

	private void UpdateHighlight()
	{
		if (Row < 0)
		{
			Row = 9;
		}
		else if (Row > 9)
		{
			Row = 0;
		}
		if (Column < 0)
		{
			Column = 9;
		}
		else if (Column > 9)
		{
			Column = 0;
		}
		Highlight.localPosition = new Vector3(-450 + 100 * Column, 450 - 100 * Row, Highlight.localPosition.z);
		Selected = 1 + Row * 10 + Column;
	}

	public void UpdatePortraits()
	{
		for (ID = 1; ID < 98; ID++)
		{
			if (Portraits[ID] != null)
			{
				if (StudentManager.Students[ID] != null)
				{
					if (StudentManager.Students[ID].gameObject.activeInHierarchy)
					{
						Portraits[ID].color = new Color(1f, 1f, 1f, 1f);
					}
					else
					{
						Portraits[ID].color = new Color(1f, 1f, 1f, 0.5f);
					}
				}
				else
				{
					Portraits[ID].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
		}
		if (StudentManager.Eighties && Portraits[100] != null)
		{
			if (StudentManager.Journalist.activeInHierarchy)
			{
				Portraits[100].color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				Portraits[100].color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
	}
}
