using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B2E8C File Offset: 0x001B108C
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

	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B2ED8 File Offset: 0x001B10D8
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

	// Token: 0x06001EE6 RID: 7910 RVA: 0x001B3054 File Offset: 0x001B1254
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

	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B3300 File Offset: 0x001B1500
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

	// Token: 0x06001EE8 RID: 7912 RVA: 0x001B3368 File Offset: 0x001B1568
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x0400402C RID: 16428
	public StudentManagerScript StudentManager;

	// Token: 0x0400402D RID: 16429
	public InputManagerScript InputManager;

	// Token: 0x0400402E RID: 16430
	public StudentScript TargetStudent;

	// Token: 0x0400402F RID: 16431
	public StudentScript Student;

	// Token: 0x04004030 RID: 16432
	public YandereScript Yandere;

	// Token: 0x04004031 RID: 16433
	public JsonScript JSON;

	// Token: 0x04004032 RID: 16434
	public GameObject NegativeRemark;

	// Token: 0x04004033 RID: 16435
	public GameObject PositiveRemark;

	// Token: 0x04004034 RID: 16436
	public GameObject EmbarassingSecret;

	// Token: 0x04004035 RID: 16437
	public Transform TopicHighlight;

	// Token: 0x04004036 RID: 16438
	public UISprite[] OpinionIcons;

	// Token: 0x04004037 RID: 16439
	public UILabel EmbarassingLabel;

	// Token: 0x04004038 RID: 16440
	public UILabel Label;

	// Token: 0x04004039 RID: 16441
	public int TopicSelected;

	// Token: 0x0400403A RID: 16442
	public int Opinion;

	// Token: 0x0400403B RID: 16443
	public int Column;

	// Token: 0x0400403C RID: 16444
	public int Row;

	// Token: 0x0400403D RID: 16445
	public bool Socializing;

	// Token: 0x0400403E RID: 16446
	public bool Positive;

	// Token: 0x0400403F RID: 16447
	public bool Success;

	// Token: 0x04004040 RID: 16448
	public string[] OpinionSpriteNames;

	// Token: 0x04004041 RID: 16449
	public string[] TopicNames;

	// Token: 0x04004042 RID: 16450
	public string Statement;

	// Token: 0x04004043 RID: 16451
	public string LoveHate;

	// Token: 0x04004044 RID: 16452
	public int TargetStudentID = 1;

	// Token: 0x04004045 RID: 16453
	public int StudentID = 1;
}
