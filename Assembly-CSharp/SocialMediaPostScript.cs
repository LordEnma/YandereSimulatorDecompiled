using UnityEngine;

public class SocialMediaPostScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public SocialMediaScript SocialMedia;

	public YandereScript Yandere;

	public UITexture Image;

	public UILabel Title;

	public UILabel Date;

	public UILabel Text;

	public int[] Topics;

	public int Type;

	public int ID;

	public bool Notified;

	private void Start()
	{
		StudentManager = SocialMedia.PauseScreen.Yandere.StudentManager;
		Yandere = SocialMedia.PauseScreen.Yandere;
		if (Type == 1)
		{
			Title.text = SocialMedia.Titles[ID];
			Date.text = SocialMedia.Dates[ID];
			Text.text = SocialMedia.Texts[ID];
		}
		else if (Type == 2)
		{
			Image.mainTexture = SocialMedia.TraitImages[SocialMedia.TraitIDs[ID]];
			Text.text = "It seems that your rival is attracted to boys who have [c][008000]" + SocialMedia.TraitNames[SocialMedia.TraitIDs[ID]] + "[-][/c]";
		}
	}

	private void Update()
	{
		if (Type == 1 && base.transform.parent.localPosition.y > (float)((ID - 2) * 525) + 262.5f && !Notified)
		{
			Debug.Log("Notification is happening now.");
			Yandere.NotificationManager.TopicName = StudentManager.InterestManager.TopicNames[Topics[1]];
			StudentManager.SetTopicLearnedByStudent(Topics[1], StudentManager.RivalID, boolean: true);
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			Yandere.NotificationManager.TopicName = StudentManager.InterestManager.TopicNames[Topics[2]];
			StudentManager.SetTopicLearnedByStudent(Topics[2], StudentManager.RivalID, boolean: true);
			Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
			Notified = true;
		}
	}
}
