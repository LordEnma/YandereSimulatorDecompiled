using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001EF9 RID: 7929 RVA: 0x001B4D04 File Offset: 0x001B2F04
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

	// Token: 0x06001EFA RID: 7930 RVA: 0x001B4D50 File Offset: 0x001B2F50
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

	// Token: 0x06001EFB RID: 7931 RVA: 0x001B4ECC File Offset: 0x001B30CC
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

	// Token: 0x06001EFC RID: 7932 RVA: 0x001B5178 File Offset: 0x001B3378
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

	// Token: 0x06001EFD RID: 7933 RVA: 0x001B51E0 File Offset: 0x001B33E0
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x0400408E RID: 16526
	public StudentManagerScript StudentManager;

	// Token: 0x0400408F RID: 16527
	public InputManagerScript InputManager;

	// Token: 0x04004090 RID: 16528
	public StudentScript TargetStudent;

	// Token: 0x04004091 RID: 16529
	public StudentScript Student;

	// Token: 0x04004092 RID: 16530
	public YandereScript Yandere;

	// Token: 0x04004093 RID: 16531
	public JsonScript JSON;

	// Token: 0x04004094 RID: 16532
	public GameObject NegativeRemark;

	// Token: 0x04004095 RID: 16533
	public GameObject PositiveRemark;

	// Token: 0x04004096 RID: 16534
	public GameObject EmbarassingSecret;

	// Token: 0x04004097 RID: 16535
	public Transform TopicHighlight;

	// Token: 0x04004098 RID: 16536
	public UISprite[] OpinionIcons;

	// Token: 0x04004099 RID: 16537
	public UILabel EmbarassingLabel;

	// Token: 0x0400409A RID: 16538
	public UILabel Label;

	// Token: 0x0400409B RID: 16539
	public int TopicSelected;

	// Token: 0x0400409C RID: 16540
	public int Opinion;

	// Token: 0x0400409D RID: 16541
	public int Column;

	// Token: 0x0400409E RID: 16542
	public int Row;

	// Token: 0x0400409F RID: 16543
	public bool Socializing;

	// Token: 0x040040A0 RID: 16544
	public bool Positive;

	// Token: 0x040040A1 RID: 16545
	public bool Success;

	// Token: 0x040040A2 RID: 16546
	public string[] OpinionSpriteNames;

	// Token: 0x040040A3 RID: 16547
	public string[] TopicNames;

	// Token: 0x040040A4 RID: 16548
	public string Statement;

	// Token: 0x040040A5 RID: 16549
	public string LoveHate;

	// Token: 0x040040A6 RID: 16550
	public int TargetStudentID = 1;

	// Token: 0x040040A7 RID: 16551
	public int StudentID = 1;
}
