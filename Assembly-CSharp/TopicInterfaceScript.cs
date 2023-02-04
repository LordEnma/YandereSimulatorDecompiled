using UnityEngine;

public class TopicInterfaceScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public StudentScript TargetStudent;

	public StudentScript Student;

	public YandereScript Yandere;

	public JsonScript JSON;

	public GameObject NegativeRemark;

	public GameObject PositiveRemark;

	public GameObject EmbarassingSecret;

	public GameObject TutorialShadow;

	public Transform TopicHighlight;

	public UISprite[] OpinionIcons;

	public UILabel EmbarassingLabel;

	public UILabel Label;

	public int TopicSelected;

	public int Opinion;

	public int Column;

	public int Row;

	public bool Socializing;

	public bool Positive;

	public bool Success;

	public string[] OpinionSpriteNames;

	public string[] TopicNames;

	public string Statement;

	public string LoveHate;

	public int TargetStudentID = 1;

	public int StudentID = 1;

	private void Start()
	{
		if (Student == null)
		{
			base.gameObject.SetActive(value: false);
		}
		if (GameGlobals.Eighties)
		{
			EmbarassingLabel.text = "(You will also mention the embarassing information you found in her diary.)";
			TopicNames[14] = "jokes";
		}
		if (GameGlobals.KokonaTutorial)
		{
			TutorialShadow.SetActive(value: true);
		}
	}

	private void Update()
	{
		if (InputManager.TappedUp)
		{
			Row--;
			UpdateTopicHighlight();
		}
		else if (InputManager.TappedDown)
		{
			Row++;
			UpdateTopicHighlight();
		}
		if (InputManager.TappedLeft)
		{
			Column--;
			UpdateTopicHighlight();
		}
		else if (InputManager.TappedRight)
		{
			Column++;
			UpdateTopicHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			bool flag = false;
			if (Yandere.StudentManager.KokonaTutorial && TopicSelected != 2)
			{
				flag = true;
			}
			if (!flag)
			{
				if (Socializing)
				{
					Yandere.Interaction = YandereInteractionType.Compliment;
					Yandere.TalkTimer = 5f;
				}
				else
				{
					Yandere.Interaction = YandereInteractionType.Gossip;
					Yandere.TalkTimer = 5f;
				}
				Yandere.PromptBar.Show = false;
				base.gameObject.SetActive(value: false);
				Time.timeScale = 1f;
			}
		}
		else if (Input.GetButtonDown("X"))
		{
			if (!Yandere.StudentManager.KokonaTutorial)
			{
				Positive = !Positive;
				UpdateTopicHighlight();
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			Yandere.Interaction = YandereInteractionType.Bye;
			Yandere.TalkTimer = 2f;
			Yandere.PromptBar.Show = false;
			base.gameObject.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}

	public void UpdateTopicHighlight()
	{
		if (Row < 1)
		{
			Row = 5;
		}
		else if (Row > 5)
		{
			Row = 1;
		}
		if (Column < 1)
		{
			Column = 5;
		}
		else if (Column > 5)
		{
			Column = 1;
		}
		TopicHighlight.localPosition = new Vector3(-375 + 125 * Column, 375 - 125 * Row, TopicHighlight.localPosition.z);
		TopicSelected = (Row - 1) * 5 + Column;
		DetermineOpinion();
		if (Socializing)
		{
			LoveHate = (Positive ? "love" : "hate");
			Statement = "Hi, " + Student.Name + "! Gosh, I just really " + LoveHate + " " + TopicNames[TopicSelected] + ". Can you relate to that at all?";
			if ((Positive && Opinion == 2) || (!Positive && Opinion == 1))
			{
				Success = true;
			}
		}
		else
		{
			LoveHate = (Positive ? "loves" : "hates");
			Statement = "Hey, " + Student.Name + "! Did you know that " + StudentManager.JSON.Students[TargetStudentID].Name + " really " + LoveHate + " " + TopicNames[TopicSelected] + "?";
			if ((Positive && Opinion == 1) || (!Positive && Opinion == 2))
			{
				Success = true;
			}
		}
		Label.text = Statement;
		EmbarassingSecret.SetActive(value: false);
		if (!Socializing && TargetStudentID == StudentManager.RivalID && StudentManager.EmbarassingSecret)
		{
			EmbarassingSecret.SetActive(value: true);
		}
		if (Positive)
		{
			NegativeRemark.SetActive(value: false);
			PositiveRemark.SetActive(value: true);
		}
		else
		{
			PositiveRemark.SetActive(value: false);
			NegativeRemark.SetActive(value: true);
		}
	}

	public void UpdateOpinions()
	{
		for (int i = 1; i <= 25; i++)
		{
			UISprite uISprite = OpinionIcons[i];
			if (!StudentManager.GetTopicLearnedByStudent(i, StudentID))
			{
				uISprite.spriteName = "Unknown";
				continue;
			}
			int[] topics = JSON.Topics[StudentID].Topics;
			uISprite.spriteName = OpinionSpriteNames[topics[i]];
		}
	}

	private void DetermineOpinion()
	{
		int[] topics = JSON.Topics[StudentID].Topics;
		Opinion = topics[TopicSelected];
		Success = false;
	}
}
