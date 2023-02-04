using UnityEngine;

public class AudioSoftwareScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Quaternion targetRotation;

	public Collider ChairCollider;

	public UILabel EventSubtitle;

	public GameObject Screen;

	public Transform SitSpot;

	public bool ConversationRecorded;

	public bool AudioDoctored;

	public bool Editing;

	public float Timer;

	private void Start()
	{
		Screen.SetActive(value: false);
	}

	private void Update()
	{
		if (ConversationRecorded && Yandere.Inventory.RivalPhone)
		{
			if (!Prompt.enabled)
			{
				Prompt.enabled = true;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Yandere.CharacterAnimation.CrossFade("f02_onComputer_00");
			Yandere.MyController.radius = 0.1f;
			Yandere.CanMove = false;
			GetComponent<AudioSource>().Play();
			ChairCollider.enabled = false;
			Screen.SetActive(value: true);
			Editing = true;
		}
		if (Editing)
		{
			Yandere.CharacterAnimation.CrossFade("f02_onComputer_00");
			targetRotation = Quaternion.LookRotation(new Vector3(Screen.transform.position.x, Yandere.transform.position.y, Screen.transform.position.z) - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(SitSpot.position);
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				EventSubtitle.text = "Okay, how 'bout that boy from class 3-2? What do you think of him?";
			}
			if (Timer > 7f)
			{
				EventSubtitle.text = "He's just my childhood friend.";
			}
			if (Timer > 9f)
			{
				EventSubtitle.text = "Is he your boyfriend?";
			}
			if (Timer > 11f)
			{
				EventSubtitle.text = "What? HIM? Ugh, no way! That guy's a total creep! I wouldn't date him if he was the last man alive on earth! He can go jump off a cliff for all I care!";
			}
			if (Timer > 22f)
			{
				Yandere.MyController.radius = 0.2f;
				Yandere.CanMove = true;
				ChairCollider.enabled = true;
				EventSubtitle.text = "";
				Screen.SetActive(value: false);
				AudioDoctored = true;
				Editing = false;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
			}
		}
	}
}
