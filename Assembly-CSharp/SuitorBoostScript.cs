using UnityEngine;

public class SuitorBoostScript : MonoBehaviour
{
	public LoveManagerScript LoveManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public UISprite Darkness;

	public UILabel Label;

	public Transform YandereSitSpot;

	public Transform SuitorSitSpot;

	public Transform YandereChair;

	public Transform SuitorChair;

	public Transform YandereSpot;

	public Transform SuitorSpot;

	public Transform LookTarget;

	public Transform TextBox;

	public Transform BoostSpot;

	public bool TaughtSuitor;

	public bool TimeSkipping;

	public bool Boosting;

	public bool FadeOut;

	public float Timer;

	public string BoostText;

	public int TraitID = 2;

	public int Phase = 1;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				if (!TaughtSuitor)
				{
					if (Yandere.Followers > 0 && Yandere.Follower.StudentID == LoveManager.SuitorID && Yandere.Follower.DistanceToPlayer < 2f)
					{
						Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
						Yandere.RPGCamera.enabled = false;
						Yandere.CanMove = false;
						Yandere.Follower.CharacterAnimation.CrossFade(Yandere.Follower.IdleAnim);
						Yandere.Follower.Pathfinding.canSearch = false;
						Yandere.Follower.Pathfinding.canMove = false;
						Yandere.Follower.enabled = false;
						Darkness.enabled = true;
						Boosting = true;
						FadeOut = true;
						Label.text = BoostText;
					}
					else
					{
						Yandere.NotificationManager.CustomText = "your rival and bring him here.";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Yandere.NotificationManager.CustomText = "Find a boy who has a crush on";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					Yandere.NotificationManager.CustomText = "Can't! You already did that today!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else
			{
				Yandere.NotificationManager.CustomText = "Can't! You're being chased!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (!Boosting)
		{
			return;
		}
		if (FadeOut)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
			if (!(Darkness.color.a > 0.999f))
			{
				return;
			}
			Timer += Time.deltaTime;
			if (!(Timer > 1f))
			{
				return;
			}
			if (Phase == 1)
			{
				Yandere.MainCamera.transform.position = BoostSpot.position;
				Yandere.MainCamera.transform.eulerAngles = BoostSpot.eulerAngles;
				Yandere.Follower.Character.transform.localScale = new Vector3(1f, 1f, 1f);
				if (TraitID == 1)
				{
					Yandere.Follower.CharacterAnimation.Play("paranoidIdle_00");
					Yandere.transform.position = YandereSpot.position;
					Yandere.transform.eulerAngles = YandereSpot.eulerAngles;
					Yandere.Follower.transform.position = SuitorSpot.position;
					Yandere.Follower.transform.eulerAngles = SuitorSpot.eulerAngles;
				}
				else if (TraitID == 2)
				{
					YandereChair.transform.localPosition = new Vector3(YandereChair.transform.localPosition.x, YandereChair.transform.localPosition.y, -0.6f);
					SuitorChair.transform.localPosition = new Vector3(SuitorChair.transform.localPosition.x, SuitorChair.transform.localPosition.y, -0.6f);
					Yandere.CharacterAnimation.Play("f02_sit_01");
					Yandere.Follower.CharacterAnimation.Play("sit_01");
					Yandere.transform.eulerAngles = Vector3.zero;
					Yandere.Follower.transform.eulerAngles = Vector3.zero;
					Yandere.transform.position = YandereSitSpot.position;
					Yandere.Follower.transform.position = SuitorSitSpot.position;
				}
				else if (TraitID == 3)
				{
					Yandere.Follower.CharacterAnimation.Play("stretch_00_loop");
					Yandere.transform.position = YandereSpot.position;
					Yandere.transform.eulerAngles = YandereSpot.eulerAngles;
					Yandere.Follower.transform.position = SuitorSpot.position;
					Yandere.Follower.transform.eulerAngles = SuitorSpot.eulerAngles;
				}
			}
			else
			{
				Yandere.FixCamera();
				Yandere.Follower.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
				if (TraitID == 2)
				{
					YandereChair.transform.localPosition = new Vector3(YandereChair.transform.localPosition.x, YandereChair.transform.localPosition.y, -1f / 3f);
					SuitorChair.transform.localPosition = new Vector3(SuitorChair.transform.localPosition.x, SuitorChair.transform.localPosition.y, -1f / 3f);
				}
				Yandere.CharacterAnimation.Play(Yandere.IdleAnim);
				Yandere.Follower.CharacterAnimation.Play(Yandere.Follower.IdleAnim);
				Yandere.transform.position = YandereSpot.position;
				Yandere.Follower.transform.position = SuitorSpot.position;
			}
			PromptBar.ClearButtons();
			FadeOut = false;
			Phase++;
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime));
		if (!(Darkness.color.a < 0.001f))
		{
			return;
		}
		if (Phase == 2)
		{
			TextBox.gameObject.SetActive(true);
			TextBox.localScale = Vector3.Lerp(TextBox.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (TextBox.localScale.x > 0.9f)
			{
				if (!PromptBar.Show)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Continue";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
				if (Input.GetButtonDown("A"))
				{
					PromptBar.Show = false;
					Phase++;
				}
			}
		}
		else if (Phase == 3)
		{
			if (TextBox.localScale.x > 0.1f)
			{
				TextBox.localScale = Vector3.Lerp(TextBox.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			TextBox.gameObject.SetActive(false);
			FadeOut = true;
			Phase++;
		}
		else if (Phase == 5)
		{
			Yandere.StudentManager.DatingMinigame.DataNeedsSaving = true;
			Yandere.StudentManager.DatingMinigame.Trait[TraitID]++;
			if (TraitID == 1)
			{
				Yandere.StudentManager.DatingMinigame.CourageTrait++;
			}
			else if (TraitID == 2)
			{
				Yandere.StudentManager.DatingMinigame.WisdomTrait++;
			}
			else if (TraitID == 3)
			{
				Yandere.StudentManager.DatingMinigame.StrengthTrait++;
			}
			Yandere.RPGCamera.enabled = true;
			Darkness.enabled = false;
			Yandere.CanMove = true;
			Boosting = false;
			Yandere.Follower.Pathfinding.canSearch = true;
			Yandere.Follower.Pathfinding.canMove = true;
			Yandere.Follower.enabled = true;
			TaughtSuitor = true;
		}
	}

	private void LateUpdate()
	{
		if (TraitID == 2 && Boosting && Phase > 1 && Phase < 5)
		{
			Yandere.Head.LookAt(LookTarget);
			Yandere.Follower.Head.LookAt(LookTarget);
		}
	}
}
