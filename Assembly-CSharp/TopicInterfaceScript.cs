using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001EC1 RID: 7873 RVA: 0x001AFEBC File Offset: 0x001AE0BC
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

	// Token: 0x06001EC2 RID: 7874 RVA: 0x001AFF08 File Offset: 0x001AE108
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

	// Token: 0x06001EC3 RID: 7875 RVA: 0x001B0084 File Offset: 0x001AE284
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

	// Token: 0x06001EC4 RID: 7876 RVA: 0x001B0330 File Offset: 0x001AE530
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

	// Token: 0x06001EC5 RID: 7877 RVA: 0x001B0398 File Offset: 0x001AE598
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x04003FE7 RID: 16359
	public StudentManagerScript StudentManager;

	// Token: 0x04003FE8 RID: 16360
	public InputManagerScript InputManager;

	// Token: 0x04003FE9 RID: 16361
	public StudentScript TargetStudent;

	// Token: 0x04003FEA RID: 16362
	public StudentScript Student;

	// Token: 0x04003FEB RID: 16363
	public YandereScript Yandere;

	// Token: 0x04003FEC RID: 16364
	public JsonScript JSON;

	// Token: 0x04003FED RID: 16365
	public GameObject NegativeRemark;

	// Token: 0x04003FEE RID: 16366
	public GameObject PositiveRemark;

	// Token: 0x04003FEF RID: 16367
	public GameObject EmbarassingSecret;

	// Token: 0x04003FF0 RID: 16368
	public Transform TopicHighlight;

	// Token: 0x04003FF1 RID: 16369
	public UISprite[] OpinionIcons;

	// Token: 0x04003FF2 RID: 16370
	public UILabel EmbarassingLabel;

	// Token: 0x04003FF3 RID: 16371
	public UILabel Label;

	// Token: 0x04003FF4 RID: 16372
	public int TopicSelected;

	// Token: 0x04003FF5 RID: 16373
	public int Opinion;

	// Token: 0x04003FF6 RID: 16374
	public int Column;

	// Token: 0x04003FF7 RID: 16375
	public int Row;

	// Token: 0x04003FF8 RID: 16376
	public bool Socializing;

	// Token: 0x04003FF9 RID: 16377
	public bool Positive;

	// Token: 0x04003FFA RID: 16378
	public bool Success;

	// Token: 0x04003FFB RID: 16379
	public string[] OpinionSpriteNames;

	// Token: 0x04003FFC RID: 16380
	public string[] TopicNames;

	// Token: 0x04003FFD RID: 16381
	public string Statement;

	// Token: 0x04003FFE RID: 16382
	public string LoveHate;

	// Token: 0x04003FFF RID: 16383
	public int TargetStudentID = 1;

	// Token: 0x04004000 RID: 16384
	public int StudentID = 1;
}
