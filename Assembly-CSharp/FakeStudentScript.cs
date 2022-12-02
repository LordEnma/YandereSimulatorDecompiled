using UnityEngine;

public class FakeStudentScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public DialogueWheelScript DialogueWheel;

	public SubtitleScript Subtitle;

	public YandereScript Yandere;

	public StudentScript Student;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public float RotationTimer;

	public bool Rotate;

	public ClubType Club;

	public string LeaderAnim;

	private void Start()
	{
		targetRotation = base.transform.rotation;
		Student.Club = Club;
	}

	private void Update()
	{
		if (!Student.Talking)
		{
			if (LeaderAnim != "")
			{
				GetComponent<Animation>().CrossFade(LeaderAnim);
			}
			if (Rotate)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, 10f * Time.deltaTime);
				RotationTimer += Time.deltaTime;
				if (RotationTimer > 1f)
				{
					RotationTimer = 0f;
					Rotate = false;
				}
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f && !Yandere.Chased && Yandere.Chasers == 0)
		{
			Yandere.TargetStudent = Student;
			Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)Student.Club, 4f);
			DialogueWheel.ClubLeader = true;
			StudentManager.DisablePrompts();
			DialogueWheel.HideShadows();
			DialogueWheel.Show = true;
			DialogueWheel.Panel.enabled = true;
			Student.Talking = true;
			Student.TalkTimer = 0f;
			Yandere.ShoulderCamera.OverShoulder = true;
			Yandere.WeaponMenu.KeyboardShow = false;
			Yandere.WeaponMenu.Show = false;
			Yandere.YandereVision = false;
			Yandere.CanMove = false;
			Yandere.Talking = true;
			RotationTimer = 0f;
			Rotate = true;
		}
	}
}
