using System;
using UnityEngine;

// Token: 0x0200047C RID: 1148
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001ED4 RID: 7892 RVA: 0x001B1F10 File Offset: 0x001B0110
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

	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B1F5C File Offset: 0x001B015C
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

	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B20D8 File Offset: 0x001B02D8
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

	// Token: 0x06001ED7 RID: 7895 RVA: 0x001B2384 File Offset: 0x001B0584
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

	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B23EC File Offset: 0x001B05EC
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x04004013 RID: 16403
	public StudentManagerScript StudentManager;

	// Token: 0x04004014 RID: 16404
	public InputManagerScript InputManager;

	// Token: 0x04004015 RID: 16405
	public StudentScript TargetStudent;

	// Token: 0x04004016 RID: 16406
	public StudentScript Student;

	// Token: 0x04004017 RID: 16407
	public YandereScript Yandere;

	// Token: 0x04004018 RID: 16408
	public JsonScript JSON;

	// Token: 0x04004019 RID: 16409
	public GameObject NegativeRemark;

	// Token: 0x0400401A RID: 16410
	public GameObject PositiveRemark;

	// Token: 0x0400401B RID: 16411
	public GameObject EmbarassingSecret;

	// Token: 0x0400401C RID: 16412
	public Transform TopicHighlight;

	// Token: 0x0400401D RID: 16413
	public UISprite[] OpinionIcons;

	// Token: 0x0400401E RID: 16414
	public UILabel EmbarassingLabel;

	// Token: 0x0400401F RID: 16415
	public UILabel Label;

	// Token: 0x04004020 RID: 16416
	public int TopicSelected;

	// Token: 0x04004021 RID: 16417
	public int Opinion;

	// Token: 0x04004022 RID: 16418
	public int Column;

	// Token: 0x04004023 RID: 16419
	public int Row;

	// Token: 0x04004024 RID: 16420
	public bool Socializing;

	// Token: 0x04004025 RID: 16421
	public bool Positive;

	// Token: 0x04004026 RID: 16422
	public bool Success;

	// Token: 0x04004027 RID: 16423
	public string[] OpinionSpriteNames;

	// Token: 0x04004028 RID: 16424
	public string[] TopicNames;

	// Token: 0x04004029 RID: 16425
	public string Statement;

	// Token: 0x0400402A RID: 16426
	public string LoveHate;

	// Token: 0x0400402B RID: 16427
	public int TargetStudentID = 1;

	// Token: 0x0400402C RID: 16428
	public int StudentID = 1;
}
