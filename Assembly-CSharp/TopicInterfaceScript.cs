using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001F11 RID: 7953 RVA: 0x001B7158 File Offset: 0x001B5358
	private void Start()
	{
		if (this.Student == null)
		{
			base.gameObject.SetActive(false);
		}
		if (GameGlobals.Eighties)
		{
			this.EmbarassingLabel.text = "(You will also mention the embarassing information you found in her diary.)";
			this.TopicNames[14] = "jokes";
		}
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x001B71A4 File Offset: 0x001B53A4
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Row--;
			this.UpdateTopicHighlight();
		}
		else if (this.InputManager.TappedDown)
		{
			this.Row++;
			this.UpdateTopicHighlight();
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column--;
			this.UpdateTopicHighlight();
		}
		else if (this.InputManager.TappedRight)
		{
			this.Column++;
			this.UpdateTopicHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.Socializing)
			{
				this.Yandere.Interaction = YandereInteractionType.Compliment;
				this.Yandere.TalkTimer = 5f;
			}
			else
			{
				this.Yandere.Interaction = YandereInteractionType.Gossip;
				this.Yandere.TalkTimer = 5f;
			}
			this.Yandere.PromptBar.Show = false;
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
			return;
		}
		if (Input.GetButtonDown("X"))
		{
			this.Positive = !this.Positive;
			this.UpdateTopicHighlight();
			return;
		}
		if (Input.GetButtonDown("B"))
		{
			this.Yandere.Interaction = YandereInteractionType.Bye;
			this.Yandere.TalkTimer = 2f;
			this.Yandere.PromptBar.Show = false;
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x001B7320 File Offset: 0x001B5520
	public void UpdateTopicHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 1;
		}
		if (this.Column < 1)
		{
			this.Column = 5;
		}
		else if (this.Column > 5)
		{
			this.Column = 1;
		}
		this.TopicHighlight.localPosition = new Vector3((float)(-375 + 125 * this.Column), (float)(375 - 125 * this.Row), this.TopicHighlight.localPosition.z);
		this.TopicSelected = (this.Row - 1) * 5 + this.Column;
		this.DetermineOpinion();
		if (this.Socializing)
		{
			this.LoveHate = (this.Positive ? "love" : "hate");
			this.Statement = string.Concat(new string[]
			{
				"Hi, ",
				this.Student.Name,
				"! Gosh, I just really ",
				this.LoveHate,
				" ",
				this.TopicNames[this.TopicSelected],
				". Can you relate to that at all?"
			});
			if ((this.Positive && this.Opinion == 2) || (!this.Positive && this.Opinion == 1))
			{
				this.Success = true;
			}
		}
		else
		{
			this.LoveHate = (this.Positive ? "loves" : "hates");
			this.Statement = string.Concat(new string[]
			{
				"Hey, ",
				this.Student.Name,
				"! Did you know that ",
				this.StudentManager.JSON.Students[this.TargetStudentID].Name,
				" really ",
				this.LoveHate,
				" ",
				this.TopicNames[this.TopicSelected],
				"?"
			});
			if ((this.Positive && this.Opinion == 1) || (!this.Positive && this.Opinion == 2))
			{
				this.Success = true;
			}
		}
		this.Label.text = this.Statement;
		this.EmbarassingSecret.SetActive(false);
		if (!this.Socializing && this.TargetStudentID == this.StudentManager.RivalID && this.StudentManager.EmbarassingSecret)
		{
			this.EmbarassingSecret.SetActive(true);
		}
		if (this.Positive)
		{
			this.NegativeRemark.SetActive(false);
			this.PositiveRemark.SetActive(true);
			return;
		}
		this.PositiveRemark.SetActive(false);
		this.NegativeRemark.SetActive(true);
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x001B75CC File Offset: 0x001B57CC
	public void UpdateOpinions()
	{
		for (int i = 1; i <= 25; i++)
		{
			UISprite uisprite = this.OpinionIcons[i];
			if (!ConversationGlobals.GetTopicLearnedByStudent(i, this.StudentID))
			{
				uisprite.spriteName = "Unknown";
			}
			else
			{
				int[] topics = this.JSON.Topics[this.StudentID].Topics;
				uisprite.spriteName = this.OpinionSpriteNames[topics[i]];
			}
		}
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x001B7634 File Offset: 0x001B5834
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x040040CE RID: 16590
	public StudentManagerScript StudentManager;

	// Token: 0x040040CF RID: 16591
	public InputManagerScript InputManager;

	// Token: 0x040040D0 RID: 16592
	public StudentScript TargetStudent;

	// Token: 0x040040D1 RID: 16593
	public StudentScript Student;

	// Token: 0x040040D2 RID: 16594
	public YandereScript Yandere;

	// Token: 0x040040D3 RID: 16595
	public JsonScript JSON;

	// Token: 0x040040D4 RID: 16596
	public GameObject NegativeRemark;

	// Token: 0x040040D5 RID: 16597
	public GameObject PositiveRemark;

	// Token: 0x040040D6 RID: 16598
	public GameObject EmbarassingSecret;

	// Token: 0x040040D7 RID: 16599
	public Transform TopicHighlight;

	// Token: 0x040040D8 RID: 16600
	public UISprite[] OpinionIcons;

	// Token: 0x040040D9 RID: 16601
	public UILabel EmbarassingLabel;

	// Token: 0x040040DA RID: 16602
	public UILabel Label;

	// Token: 0x040040DB RID: 16603
	public int TopicSelected;

	// Token: 0x040040DC RID: 16604
	public int Opinion;

	// Token: 0x040040DD RID: 16605
	public int Column;

	// Token: 0x040040DE RID: 16606
	public int Row;

	// Token: 0x040040DF RID: 16607
	public bool Socializing;

	// Token: 0x040040E0 RID: 16608
	public bool Positive;

	// Token: 0x040040E1 RID: 16609
	public bool Success;

	// Token: 0x040040E2 RID: 16610
	public string[] OpinionSpriteNames;

	// Token: 0x040040E3 RID: 16611
	public string[] TopicNames;

	// Token: 0x040040E4 RID: 16612
	public string Statement;

	// Token: 0x040040E5 RID: 16613
	public string LoveHate;

	// Token: 0x040040E6 RID: 16614
	public int TargetStudentID = 1;

	// Token: 0x040040E7 RID: 16615
	public int StudentID = 1;
}
