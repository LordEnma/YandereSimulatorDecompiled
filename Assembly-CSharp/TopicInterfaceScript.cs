using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001F23 RID: 7971 RVA: 0x001B973C File Offset: 0x001B793C
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

	// Token: 0x06001F24 RID: 7972 RVA: 0x001B9788 File Offset: 0x001B7988
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

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B9904 File Offset: 0x001B7B04
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

	// Token: 0x06001F26 RID: 7974 RVA: 0x001B9BB0 File Offset: 0x001B7DB0
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

	// Token: 0x06001F27 RID: 7975 RVA: 0x001B9C18 File Offset: 0x001B7E18
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x04004102 RID: 16642
	public StudentManagerScript StudentManager;

	// Token: 0x04004103 RID: 16643
	public InputManagerScript InputManager;

	// Token: 0x04004104 RID: 16644
	public StudentScript TargetStudent;

	// Token: 0x04004105 RID: 16645
	public StudentScript Student;

	// Token: 0x04004106 RID: 16646
	public YandereScript Yandere;

	// Token: 0x04004107 RID: 16647
	public JsonScript JSON;

	// Token: 0x04004108 RID: 16648
	public GameObject NegativeRemark;

	// Token: 0x04004109 RID: 16649
	public GameObject PositiveRemark;

	// Token: 0x0400410A RID: 16650
	public GameObject EmbarassingSecret;

	// Token: 0x0400410B RID: 16651
	public Transform TopicHighlight;

	// Token: 0x0400410C RID: 16652
	public UISprite[] OpinionIcons;

	// Token: 0x0400410D RID: 16653
	public UILabel EmbarassingLabel;

	// Token: 0x0400410E RID: 16654
	public UILabel Label;

	// Token: 0x0400410F RID: 16655
	public int TopicSelected;

	// Token: 0x04004110 RID: 16656
	public int Opinion;

	// Token: 0x04004111 RID: 16657
	public int Column;

	// Token: 0x04004112 RID: 16658
	public int Row;

	// Token: 0x04004113 RID: 16659
	public bool Socializing;

	// Token: 0x04004114 RID: 16660
	public bool Positive;

	// Token: 0x04004115 RID: 16661
	public bool Success;

	// Token: 0x04004116 RID: 16662
	public string[] OpinionSpriteNames;

	// Token: 0x04004117 RID: 16663
	public string[] TopicNames;

	// Token: 0x04004118 RID: 16664
	public string Statement;

	// Token: 0x04004119 RID: 16665
	public string LoveHate;

	// Token: 0x0400411A RID: 16666
	public int TargetStudentID = 1;

	// Token: 0x0400411B RID: 16667
	public int StudentID = 1;
}
