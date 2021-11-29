using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001EB5 RID: 7861 RVA: 0x001AEC38 File Offset: 0x001ACE38
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

	// Token: 0x06001EB6 RID: 7862 RVA: 0x001AEC84 File Offset: 0x001ACE84
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

	// Token: 0x06001EB7 RID: 7863 RVA: 0x001AEE00 File Offset: 0x001AD000
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

	// Token: 0x06001EB8 RID: 7864 RVA: 0x001AF0AC File Offset: 0x001AD2AC
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

	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AF114 File Offset: 0x001AD314
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x04003FB0 RID: 16304
	public StudentManagerScript StudentManager;

	// Token: 0x04003FB1 RID: 16305
	public InputManagerScript InputManager;

	// Token: 0x04003FB2 RID: 16306
	public StudentScript TargetStudent;

	// Token: 0x04003FB3 RID: 16307
	public StudentScript Student;

	// Token: 0x04003FB4 RID: 16308
	public YandereScript Yandere;

	// Token: 0x04003FB5 RID: 16309
	public JsonScript JSON;

	// Token: 0x04003FB6 RID: 16310
	public GameObject NegativeRemark;

	// Token: 0x04003FB7 RID: 16311
	public GameObject PositiveRemark;

	// Token: 0x04003FB8 RID: 16312
	public GameObject EmbarassingSecret;

	// Token: 0x04003FB9 RID: 16313
	public Transform TopicHighlight;

	// Token: 0x04003FBA RID: 16314
	public UISprite[] OpinionIcons;

	// Token: 0x04003FBB RID: 16315
	public UILabel EmbarassingLabel;

	// Token: 0x04003FBC RID: 16316
	public UILabel Label;

	// Token: 0x04003FBD RID: 16317
	public int TopicSelected;

	// Token: 0x04003FBE RID: 16318
	public int Opinion;

	// Token: 0x04003FBF RID: 16319
	public int Column;

	// Token: 0x04003FC0 RID: 16320
	public int Row;

	// Token: 0x04003FC1 RID: 16321
	public bool Socializing;

	// Token: 0x04003FC2 RID: 16322
	public bool Positive;

	// Token: 0x04003FC3 RID: 16323
	public bool Success;

	// Token: 0x04003FC4 RID: 16324
	public string[] OpinionSpriteNames;

	// Token: 0x04003FC5 RID: 16325
	public string[] TopicNames;

	// Token: 0x04003FC6 RID: 16326
	public string Statement;

	// Token: 0x04003FC7 RID: 16327
	public string LoveHate;

	// Token: 0x04003FC8 RID: 16328
	public int TargetStudentID = 1;

	// Token: 0x04003FC9 RID: 16329
	public int StudentID = 1;
}
