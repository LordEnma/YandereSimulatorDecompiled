using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B35B4 File Offset: 0x001B17B4
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

	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B3600 File Offset: 0x001B1800
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

	// Token: 0x06001EE9 RID: 7913 RVA: 0x001B377C File Offset: 0x001B197C
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

	// Token: 0x06001EEA RID: 7914 RVA: 0x001B3A28 File Offset: 0x001B1C28
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

	// Token: 0x06001EEB RID: 7915 RVA: 0x001B3A90 File Offset: 0x001B1C90
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x04004043 RID: 16451
	public StudentManagerScript StudentManager;

	// Token: 0x04004044 RID: 16452
	public InputManagerScript InputManager;

	// Token: 0x04004045 RID: 16453
	public StudentScript TargetStudent;

	// Token: 0x04004046 RID: 16454
	public StudentScript Student;

	// Token: 0x04004047 RID: 16455
	public YandereScript Yandere;

	// Token: 0x04004048 RID: 16456
	public JsonScript JSON;

	// Token: 0x04004049 RID: 16457
	public GameObject NegativeRemark;

	// Token: 0x0400404A RID: 16458
	public GameObject PositiveRemark;

	// Token: 0x0400404B RID: 16459
	public GameObject EmbarassingSecret;

	// Token: 0x0400404C RID: 16460
	public Transform TopicHighlight;

	// Token: 0x0400404D RID: 16461
	public UISprite[] OpinionIcons;

	// Token: 0x0400404E RID: 16462
	public UILabel EmbarassingLabel;

	// Token: 0x0400404F RID: 16463
	public UILabel Label;

	// Token: 0x04004050 RID: 16464
	public int TopicSelected;

	// Token: 0x04004051 RID: 16465
	public int Opinion;

	// Token: 0x04004052 RID: 16466
	public int Column;

	// Token: 0x04004053 RID: 16467
	public int Row;

	// Token: 0x04004054 RID: 16468
	public bool Socializing;

	// Token: 0x04004055 RID: 16469
	public bool Positive;

	// Token: 0x04004056 RID: 16470
	public bool Success;

	// Token: 0x04004057 RID: 16471
	public string[] OpinionSpriteNames;

	// Token: 0x04004058 RID: 16472
	public string[] TopicNames;

	// Token: 0x04004059 RID: 16473
	public string Statement;

	// Token: 0x0400405A RID: 16474
	public string LoveHate;

	// Token: 0x0400405B RID: 16475
	public int TargetStudentID = 1;

	// Token: 0x0400405C RID: 16476
	public int StudentID = 1;
}
