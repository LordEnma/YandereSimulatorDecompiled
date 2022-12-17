using UnityEngine;

public class CounselorDoorScript : MonoBehaviour
{
	public CounselorScript Counselor;

	public PromptScript Prompt;

	public UISprite Darkness;

	public bool FadeOut;

	public bool FadeIn;

	public bool Exit;

	private void Start()
	{
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			bool flag = false;
			for (int i = 1; i < Counselor.StudentManager.Students.Length; i++)
			{
				StudentScript studentScript = Counselor.StudentManager.Students[i];
				if (studentScript != null)
				{
					if (studentScript.Hunting)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Not while a murder is taking place!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						flag = true;
					}
					else if (studentScript.Fleeing)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Not now - wait a minute!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						flag = true;
					}
				}
			}
			if (!flag && !Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0 && !FadeIn && Prompt.Yandere.Bloodiness == 0f && Prompt.Yandere.Sanity > 66.66666f && !Prompt.Yandere.Carrying && !Prompt.Yandere.Dragging)
			{
				if (!Counselor.Busy)
				{
					Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.IdleAnim);
					Prompt.Yandere.Police.Darkness.enabled = true;
					Prompt.Yandere.CanMove = false;
					FadeOut = true;
				}
				else
				{
					Counselor.CounselorSubtitle.text = Counselor.CounselorBusyText;
					Counselor.MyAudio.clip = Counselor.CounselorBusyClip;
					Counselor.MyAudio.Play();
				}
			}
		}
		if (FadeOut)
		{
			float a = Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime);
			Darkness.color = new Color(0f, 0f, 0f, a);
			if (Darkness.color.a > 0.9f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 1f);
				if (!Exit)
				{
					Prompt.Yandere.CharacterAnimation.Play("f02_sit_00");
					Prompt.Yandere.transform.position = new Vector3(-27.51f, 0f, 12f);
					Prompt.Yandere.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					Counselor.Talk();
					FadeOut = false;
					FadeIn = true;
				}
				else
				{
					if (Counselor.Yandere.VtuberID > 0)
					{
						Counselor.Yandere.VtuberFace();
					}
					else if (Counselor.Eighties)
					{
						Counselor.Yandere.RestoreGentleEyes();
					}
					Darkness.color = new Color(0f, 0f, 0f, 2f);
					Debug.Log("Darkness.color.a just became 2.");
					Counselor.Quit();
					FadeOut = false;
					FadeIn = true;
					Exit = false;
				}
			}
		}
		if (FadeIn)
		{
			float a2 = Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime);
			Darkness.color = new Color(0f, 0f, 0f, a2);
			if (Darkness.color.a < 0.1f)
			{
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				FadeIn = false;
			}
		}
	}
}
