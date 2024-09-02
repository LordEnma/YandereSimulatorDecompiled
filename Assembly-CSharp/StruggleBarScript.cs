using UnityEngine;

public class StruggleBarScript : MonoBehaviour
{
	public ShoulderCameraScript ShoulderCamera;

	public PromptSwapScript ButtonPrompt;

	public UISprite[] ButtonPrompts;

	public YandereScript Yandere;

	public StudentScript Student;

	public Transform Spikes;

	public string CurrentButton = string.Empty;

	public bool Struggling;

	public bool Invincible;

	public bool Tutorial;

	public float AttackTimer;

	public float ButtonTimer;

	public float OriginalDOF;

	public float Intensity;

	public float Strength = 1f;

	public float Struggle;

	public float Victory;

	public int ButtonID;

	private void Start()
	{
		if (GameGlobals.KokonaTutorial)
		{
			Invincible = true;
		}
		base.transform.localScale = Vector3.zero;
		ChooseButton();
	}

	private void Update()
	{
		if (Struggling)
		{
			Intensity = Mathf.MoveTowards(Intensity, 1f, Time.deltaTime);
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			Spikes.localEulerAngles = new Vector3(Spikes.localEulerAngles.x, Spikes.localEulerAngles.y, Spikes.localEulerAngles.z - Time.deltaTime * 360f);
			Victory -= Time.deltaTime * 5f * Strength;
			if (Yandere.TargetStudent == null && Student != null)
			{
				Yandere.TargetStudent = Student;
			}
			if (Yandere.Club == ClubType.MartialArts || (Yandere.TargetStudent != null && Yandere.TargetStudent.Strength == 0))
			{
				Debug.Log("Either player is in the martial arts club, or player's target has a Strength of 0.");
				Victory = 100f;
			}
			bool flag = false;
			if ((Input.GetButtonDown(InputNames.Xbox_A) && CurrentButton != InputNames.Xbox_A) || (Input.GetButtonDown(InputNames.Xbox_B) && CurrentButton != InputNames.Xbox_B) || (Input.GetButtonDown(InputNames.Xbox_X) && CurrentButton != InputNames.Xbox_X) || (Input.GetButtonDown(InputNames.Xbox_Y) && CurrentButton != InputNames.Xbox_Y))
			{
				flag = true;
			}
			if (!flag && Input.GetButtonDown(CurrentButton))
			{
				Victory += Time.deltaTime * (500f + (float)(Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus) * 150f);
			}
			if (Victory >= 100f)
			{
				Victory = 100f;
			}
			if (Victory <= -100f)
			{
				Victory = -100f;
			}
			UISprite uISprite = ButtonPrompts[ButtonID];
			uISprite.transform.localPosition = new Vector3(Mathf.Lerp(uISprite.transform.localPosition.x, Victory * 6.5f, Time.deltaTime * 10f), uISprite.transform.localPosition.y, uISprite.transform.localPosition.z);
			Spikes.localPosition = new Vector3(uISprite.transform.localPosition.x, Spikes.localPosition.y, Spikes.localPosition.z);
			if (Victory == 100f)
			{
				Debug.Log("Yandere-chan just won a struggle against " + Student.Name + ".");
				if (Yandere.Hips != null)
				{
					Yandere.Hips.gameObject.GetComponent<Collider>().enabled = false;
				}
				Yandere.StruggleIminent = false;
				Yandere.Won = true;
				Student.Lost = true;
				Struggling = false;
				Victory = 0f;
				if (Yandere.Chasers > 0 && Yandere.Pursuer != null && Yandere.Pursuer == Student)
				{
					Yandere.Chasers--;
				}
			}
			else if (Victory == -100f)
			{
				if (!Invincible)
				{
					HeroWins();
				}
			}
			else
			{
				ButtonTimer += Time.deltaTime;
				if (ButtonTimer >= 2f)
				{
					ChooseButton();
					ButtonTimer = 0f;
					Intensity = 0f;
				}
			}
			if (!(Student != null) || !(Student.Yandere != null))
			{
				return;
			}
			Student.transform.rotation = Quaternion.Slerp(Student.transform.rotation, Student.Yandere.transform.rotation, 10f * Time.deltaTime);
			Student.MoveTowardsTarget(Student.Yandere.transform.position + Student.Yandere.transform.forward * 0.425f);
			Student.TooCloseToWall = false;
			Student.CheckForWallToLeft();
			if (Student.TooCloseToWall)
			{
				Debug.Log("The character that Yandere-chan is struggling with is way too close to a wall. Let's push them away.");
				if (Student.MyController != null)
				{
					Student.MyController.Move(Student.transform.right * Time.deltaTime * -1f);
				}
			}
			return;
		}
		if (base.transform.localScale.x > 0.1f)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			return;
		}
		base.transform.localScale = Vector3.zero;
		if (!Yandere.AttackManager.Censor)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (AttackTimer == 0f)
		{
			Yandere.Blur.enabled = true;
			Yandere.Blur.Size = 1f;
		}
		AttackTimer += Time.deltaTime;
		if (AttackTimer < 2.5f)
		{
			Yandere.Blur.Size = Mathf.MoveTowards(Yandere.Blur.Size, 16f, Time.deltaTime * 10f);
			return;
		}
		Yandere.Blur.Size = Mathf.Lerp(Yandere.Blur.Size, 1f, Time.deltaTime * 32f);
		if (AttackTimer >= 3f)
		{
			base.gameObject.SetActive(value: false);
			Yandere.Blur.enabled = false;
			Yandere.Blur.Size = 1f;
			AttackTimer = 0f;
		}
	}

	public void HeroWins()
	{
		Debug.Log("StruggleBar fired HeroWins()");
		if (Yandere.enabled && Yandere.Armed)
		{
			Yandere.EquippedWeapon.Drop();
		}
		Yandere.Lost = true;
		if (Student != null)
		{
			Student.Won = true;
		}
		Struggling = false;
		Victory = 0f;
		if (Yandere.StudentManager.enabled)
		{
			Yandere.StudentManager.StopMoving();
		}
		base.gameObject.SetActive(value: false);
		base.enabled = false;
	}

	private void ChooseButton()
	{
		int buttonID = ButtonID;
		for (int i = 1; i < 5; i++)
		{
			ButtonPrompts[i].enabled = false;
			ButtonPrompts[i].transform.localPosition = ButtonPrompts[buttonID].transform.localPosition;
		}
		while (ButtonID == buttonID)
		{
			ButtonID = Random.Range(1, 5);
		}
		if (ButtonID == 1)
		{
			CurrentButton = InputNames.Xbox_A;
		}
		else if (ButtonID == 2)
		{
			CurrentButton = InputNames.Xbox_B;
		}
		else if (ButtonID == 3)
		{
			CurrentButton = InputNames.Xbox_X;
		}
		else if (ButtonID == 4)
		{
			CurrentButton = InputNames.Xbox_Y;
		}
		ButtonPrompts[ButtonID].enabled = true;
	}
}
