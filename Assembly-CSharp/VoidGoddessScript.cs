using System;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
public class VoidGoddessScript : MonoBehaviour
{
	// Token: 0x06001F71 RID: 8049 RVA: 0x001B7A78 File Offset: 0x001B5C78
	public void Start()
	{
		if (!this.Initialized)
		{
			if (base.gameObject.activeInHierarchy)
			{
				this.Legs[1]["SpiderLegWiggle"].speed = 1f;
				this.Legs[2]["SpiderLegWiggle"].speed = 0.95f;
				this.Legs[3]["SpiderLegWiggle"].speed = 0.9f;
				this.Legs[4]["SpiderLegWiggle"].speed = 0.85f;
				this.Legs[5]["SpiderLegWiggle"].speed = 0.8f;
				this.Legs[6]["SpiderLegWiggle"].speed = 0.75f;
				this.Legs[7]["SpiderLegWiggle"].speed = 0.7f;
				this.Legs[8]["SpiderLegWiggle"].speed = 0.65f;
			}
			string text = "";
			if (GameGlobals.Eighties)
			{
				text = "1989";
			}
			this.ID = 1;
			while (this.ID < 101)
			{
				this.NewPortrait = UnityEngine.Object.Instantiate<GameObject>(this.Portrait, base.transform.position, Quaternion.identity);
				this.NewPortrait.transform.parent = this.Window;
				this.NewPortrait.transform.localScale = new Vector3(1f, 1f, 1f);
				this.NewPortrait.transform.localPosition = new Vector3((float)(-450 + this.Column * 100), (float)(450 - this.Row * 100), 0f);
				this.Portraits[this.ID] = this.NewPortrait.GetComponent<UITexture>();
				if (!this.StudentManager.Eighties && this.ID > 11 && this.ID < 21)
				{
					this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Prompt.Yandere.PauseScreen.StudentInfoMenu.RivalPortraits[this.ID];
				}
				else if (this.ID < 98)
				{
					WWW www = new WWW(string.Concat(new string[]
					{
						"file:///",
						Application.streamingAssetsPath,
						"/Portraits",
						text,
						"/Student_",
						this.ID.ToString(),
						".png"
					}));
					this.NewPortrait.GetComponent<UITexture>().mainTexture = www.texture;
				}
				else if (this.ID == 98)
				{
					this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Counselor;
				}
				else if (this.ID == 99)
				{
					this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Headmaster;
				}
				else if (this.ID == 100)
				{
					this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Infochan;
				}
				this.Column++;
				if (this.Column == 10)
				{
					this.Column = 0;
					this.Row++;
				}
				this.ID++;
			}
			this.Window.parent.gameObject.SetActive(false);
			this.Selected = 1;
			this.Column = 0;
			this.Row = 0;
			this.UpdatePortraits();
			this.Initialized = true;
		}
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x001B7DF4 File Offset: 0x001B5FF4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Goddess.activeInHierarchy)
			{
				this.Prompt.Yandere.Police.Invalid = true;
				this.Prompt.Label[0].text = "     Pass Judgement";
				this.Prompt.Label[1].text = "     Dismiss";
				this.Prompt.Label[2].text = "     Follow";
				this.Prompt.HideButton[1] = false;
				this.Prompt.HideButton[2] = false;
				this.Prompt.OffsetX[0] = 0f;
				this.Goddess.SetActive(true);
			}
			else
			{
				this.Window.parent.gameObject.SetActive(true);
				this.Prompt.Yandere.CanMove = false;
				this.PassingJudgement = true;
			}
		}
		if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Label[0].text = "     Summon An Ancient Evil";
			this.Prompt.Label[1].text = "";
			this.Prompt.Label[2].text = "";
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.OffsetX[0] = 0f;
			base.transform.position = new Vector3(-9.5f, 1f, -75f);
			this.Goddess.SetActive(false);
			this.Follow = false;
		}
		if (this.Prompt.Circle[2].fillAmount == 0f)
		{
			this.Prompt.Circle[2].fillAmount = 1f;
			this.Follow = !this.Follow;
		}
		if (this.Follow && Vector3.Distance(this.Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), base.transform.position) > 1f)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, this.Prompt.Yandere.transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime);
		}
		if (this.PassingJudgement)
		{
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedDown)
			{
				this.Row++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedRight)
			{
				this.Column++;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				this.StudentManager.DisableStudent(this.Selected);
				this.UpdatePortraits();
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				if (!this.Disabled)
				{
					this.StudentManager.DisableEveryone();
					this.Disabled = true;
				}
				else
				{
					this.ID = 1;
					while (this.ID < 101)
					{
						this.StudentManager.DisableStudent(this.ID);
						this.ID++;
					}
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				this.ID = 1;
				while (this.ID < 11)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				this.ID = 11;
				while (this.ID < 21)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				this.ID = 21;
				while (this.ID < 26)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				this.ID = 26;
				while (this.ID < 31)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				this.ID = 31;
				while (this.ID < 36)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				this.ID = 36;
				while (this.ID < 41)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				this.ID = 41;
				while (this.ID < 46)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				this.ID = 46;
				while (this.ID < 51)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				this.ID = 51;
				while (this.ID < 56)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("-"))
			{
				this.ID = 56;
				while (this.ID < 61)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("="))
			{
				this.ID = 61;
				while (this.ID < 66)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("r"))
			{
				this.ID = 66;
				while (this.ID < 71)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("t"))
			{
				this.ID = 71;
				while (this.ID < 76)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("y"))
			{
				this.ID = 76;
				while (this.ID < 81)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("u"))
			{
				this.ID = 81;
				while (this.ID < 86)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("i"))
			{
				this.ID = 86;
				while (this.ID < 90)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("o"))
			{
				this.ID = 90;
				while (this.ID < 98)
				{
					this.StudentManager.DisableStudent(this.ID);
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("p"))
			{
				this.ID = 1;
				while (this.ID < 101)
				{
					if (this.ID != 21 && this.ID != 26 && this.ID != 31 && this.ID != 36 && this.ID != 41 && this.ID != 46 && this.ID != 51 && this.ID != 56 && this.ID != 61 && this.ID != 66 && this.ID != 71)
					{
						this.StudentManager.DisableStudent(this.ID);
					}
					this.ID++;
				}
				this.UpdatePortraits();
			}
			else if (Input.GetKeyDown("space"))
			{
				this.ID = 2;
				while (this.ID < 101)
				{
					if (this.ID != 1 && this.ID != 2 && this.ID != 3 && this.ID != 6 && this.ID != 10 && this.ID != 11 && this.ID != 26 && this.ID != 36 && this.ID != 39 && this.ID != 41 && this.ID != 42 && this.ID != 43 && this.ID != 44 && this.ID != 45 && this.ID != 46 && this.ID != 47 && this.ID != 48 && this.ID != 49 && this.ID != 50 && this.ID != 71 && this.ID != 81 && this.ID != 82 && this.ID != 83 && this.ID != 84 && this.ID != 85)
					{
						this.StudentManager.DisableStudent(this.ID);
					}
					this.ID++;
				}
				if (this.StudentManager.Students[7].gameObject.activeInHierarchy)
				{
					this.StudentManager.DisableStudent(7);
				}
				this.UpdatePortraits();
			}
			if (Input.GetButtonDown("B"))
			{
				this.Window.parent.gameObject.SetActive(false);
				this.Prompt.Yandere.CanMove = true;
				this.Prompt.Yandere.Shoved = false;
				this.PassingJudgement = false;
			}
			if (Input.GetKeyDown(KeyCode.Z))
			{
				this.StudentManager.Students[this.Selected].transform.position = this.Prompt.Yandere.transform.position + this.Prompt.Yandere.transform.forward;
				Physics.SyncTransforms();
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				this.StudentManager.Students[this.Selected].BecomeRagdoll();
				this.StudentManager.Students[this.Selected].Ragdoll.NeckSnapped = true;
			}
		}
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x001B89D4 File Offset: 0x001B6BD4
	private void UpdateHighlight()
	{
		if (this.Row < 0)
		{
			this.Row = 9;
		}
		else if (this.Row > 9)
		{
			this.Row = 0;
		}
		if (this.Column < 0)
		{
			this.Column = 9;
		}
		else if (this.Column > 9)
		{
			this.Column = 0;
		}
		this.Highlight.localPosition = new Vector3((float)(-450 + 100 * this.Column), (float)(450 - 100 * this.Row), this.Highlight.localPosition.z);
		this.Selected = 1 + this.Row * 10 + this.Column;
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x001B8A84 File Offset: 0x001B6C84
	public void UpdatePortraits()
	{
		this.ID = 1;
		while (this.ID < 98)
		{
			if (this.Portraits[this.ID] != null)
			{
				if (this.StudentManager.Students[this.ID] != null)
				{
					if (this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
					{
						this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 1f);
					}
					else
					{
						this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 0.5f);
					}
				}
				else
				{
					this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
			this.ID++;
		}
	}

	// Token: 0x0400415D RID: 16733
	public StudentManagerScript StudentManager;

	// Token: 0x0400415E RID: 16734
	public InputManagerScript InputManager;

	// Token: 0x0400415F RID: 16735
	public PromptScript Prompt;

	// Token: 0x04004160 RID: 16736
	public GameObject BloodyUniform;

	// Token: 0x04004161 RID: 16737
	public GameObject SeveredLimb;

	// Token: 0x04004162 RID: 16738
	public GameObject NewPortrait;

	// Token: 0x04004163 RID: 16739
	public GameObject BloodPool;

	// Token: 0x04004164 RID: 16740
	public GameObject Portrait;

	// Token: 0x04004165 RID: 16741
	public GameObject Goddess;

	// Token: 0x04004166 RID: 16742
	public Transform BloodParent;

	// Token: 0x04004167 RID: 16743
	public Transform Highlight;

	// Token: 0x04004168 RID: 16744
	public Transform Window;

	// Token: 0x04004169 RID: 16745
	public Transform Head;

	// Token: 0x0400416A RID: 16746
	public UITexture[] Portraits;

	// Token: 0x0400416B RID: 16747
	public Animation[] Legs;

	// Token: 0x0400416C RID: 16748
	public bool PassingJudgement;

	// Token: 0x0400416D RID: 16749
	public bool Initialized;

	// Token: 0x0400416E RID: 16750
	public bool Disabled;

	// Token: 0x0400416F RID: 16751
	public bool Follow;

	// Token: 0x04004170 RID: 16752
	public int Selected;

	// Token: 0x04004171 RID: 16753
	public int Column;

	// Token: 0x04004172 RID: 16754
	public int Row;

	// Token: 0x04004173 RID: 16755
	public int ID;

	// Token: 0x04004174 RID: 16756
	public Texture Headmaster;

	// Token: 0x04004175 RID: 16757
	public Texture Counselor;

	// Token: 0x04004176 RID: 16758
	public Texture Infochan;
}
