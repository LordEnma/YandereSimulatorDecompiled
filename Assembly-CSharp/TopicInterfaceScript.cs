using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001F1A RID: 7962 RVA: 0x001B84C8 File Offset: 0x001B66C8
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

	// Token: 0x06001F1B RID: 7963 RVA: 0x001B8514 File Offset: 0x001B6714
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

	// Token: 0x06001F1C RID: 7964 RVA: 0x001B8690 File Offset: 0x001B6890
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

	// Token: 0x06001F1D RID: 7965 RVA: 0x001B893C File Offset: 0x001B6B3C
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

	// Token: 0x06001F1E RID: 7966 RVA: 0x001B89A4 File Offset: 0x001B6BA4
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x040040E4 RID: 16612
	public StudentManagerScript StudentManager;

	// Token: 0x040040E5 RID: 16613
	public InputManagerScript InputManager;

	// Token: 0x040040E6 RID: 16614
	public StudentScript TargetStudent;

	// Token: 0x040040E7 RID: 16615
	public StudentScript Student;

	// Token: 0x040040E8 RID: 16616
	public YandereScript Yandere;

	// Token: 0x040040E9 RID: 16617
	public JsonScript JSON;

	// Token: 0x040040EA RID: 16618
	public GameObject NegativeRemark;

	// Token: 0x040040EB RID: 16619
	public GameObject PositiveRemark;

	// Token: 0x040040EC RID: 16620
	public GameObject EmbarassingSecret;

	// Token: 0x040040ED RID: 16621
	public Transform TopicHighlight;

	// Token: 0x040040EE RID: 16622
	public UISprite[] OpinionIcons;

	// Token: 0x040040EF RID: 16623
	public UILabel EmbarassingLabel;

	// Token: 0x040040F0 RID: 16624
	public UILabel Label;

	// Token: 0x040040F1 RID: 16625
	public int TopicSelected;

	// Token: 0x040040F2 RID: 16626
	public int Opinion;

	// Token: 0x040040F3 RID: 16627
	public int Column;

	// Token: 0x040040F4 RID: 16628
	public int Row;

	// Token: 0x040040F5 RID: 16629
	public bool Socializing;

	// Token: 0x040040F6 RID: 16630
	public bool Positive;

	// Token: 0x040040F7 RID: 16631
	public bool Success;

	// Token: 0x040040F8 RID: 16632
	public string[] OpinionSpriteNames;

	// Token: 0x040040F9 RID: 16633
	public string[] TopicNames;

	// Token: 0x040040FA RID: 16634
	public string Statement;

	// Token: 0x040040FB RID: 16635
	public string LoveHate;

	// Token: 0x040040FC RID: 16636
	public int TargetStudentID = 1;

	// Token: 0x040040FD RID: 16637
	public int StudentID = 1;
}
