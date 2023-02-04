using UnityEngine;

public class ChangingBoothScript : MonoBehaviour
{
	public YandereScript Yandere;

	public StudentScript Student;

	public PromptScript Prompt;

	public SkinnedMeshRenderer Curtains;

	public Transform ExitSpot;

	public Transform[] WaitSpots;

	public bool YandereChanging;

	public bool CannotChange;

	public bool Occupied;

	public AudioSource MyAudioSource;

	public AudioClip CurtainSound;

	public AudioClip ClothSound;

	public float OccupyTimer;

	public float Weight;

	public ClubType ClubID;

	public int Phase;

	private void Start()
	{
		if (Curtains == null)
		{
			Debug.Log(base.gameObject.name);
		}
		Curtains.SetBlendShapeWeight(1, 100f);
		CheckYandereClub();
	}

	private void Update()
	{
		if (!Occupied && Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Yandere.ClubAttire && Yandere.PreviousSchoolwear == 0)
			{
				Yandere.NotificationManager.CustomText = "Change clothing elsewhere.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Yandere.NotificationManager.CustomText = "No outfit to change into.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Yandere.NotificationManager.CustomText = "Cannot remove club attire now.";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				Yandere.EmptyHands();
				Yandere.CanMove = false;
				YandereChanging = true;
				Occupied = true;
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		if (!Occupied)
		{
			return;
		}
		if (OccupyTimer == 0f)
		{
			if (Yandere.transform.position.y > base.transform.position.y - 1f && Yandere.transform.position.y < base.transform.position.y + 1f)
			{
				MyAudioSource.clip = CurtainSound;
				MyAudioSource.Play();
			}
		}
		else if (OccupyTimer > 1f && Phase == 0)
		{
			if (Yandere.transform.position.y > base.transform.position.y - 1f && Yandere.transform.position.y < base.transform.position.y + 1f)
			{
				MyAudioSource.clip = ClothSound;
				MyAudioSource.Play();
			}
			Phase++;
		}
		OccupyTimer += Time.deltaTime;
		if (YandereChanging)
		{
			if (OccupyTimer < 2f)
			{
				Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
				Weight = Mathf.Lerp(Weight, 0f, Time.deltaTime * 10f);
				Curtains.SetBlendShapeWeight(1, Weight);
				Yandere.MoveTowardsTarget(base.transform.position);
			}
			else if (OccupyTimer < 3f)
			{
				Weight = Mathf.Lerp(Weight, 100f, Time.deltaTime * 10f);
				Curtains.SetBlendShapeWeight(1, Weight);
				if (Phase < 2)
				{
					MyAudioSource.clip = CurtainSound;
					MyAudioSource.Play();
					if (!Yandere.ClubAttire)
					{
						Yandere.PreviousSchoolwear = Yandere.Schoolwear;
					}
					Yandere.ChangeClubwear();
					Phase++;
				}
				Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, base.transform.rotation, 10f * Time.deltaTime);
				Yandere.MoveTowardsTarget(ExitSpot.position);
			}
			else
			{
				YandereChanging = false;
				Yandere.CanMove = true;
				Prompt.enabled = true;
				Occupied = false;
				OccupyTimer = 0f;
				Phase = 0;
			}
		}
		else if (OccupyTimer < 2f)
		{
			Weight = Mathf.Lerp(Weight, 0f, Time.deltaTime * 10f);
			Curtains.SetBlendShapeWeight(1, Weight);
		}
		else if (OccupyTimer < 3f)
		{
			Weight = Mathf.Lerp(Weight, 100f, Time.deltaTime * 10f);
			Curtains.SetBlendShapeWeight(1, Weight);
			if (Phase < 2)
			{
				if (Yandere.transform.position.y > base.transform.position.y - 1f && Yandere.transform.position.y < base.transform.position.y + 1f)
				{
					MyAudioSource.clip = CurtainSound;
					MyAudioSource.Play();
				}
				Student.ChangeClubwear();
				Phase++;
			}
		}
		else
		{
			Student.WalkAnim = Student.OriginalWalkAnim;
			Occupied = false;
			OccupyTimer = 0f;
			Student = null;
			Phase = 0;
			CheckYandereClub();
		}
	}

	public void CheckYandereClub()
	{
		if (Yandere.Club != ClubID)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
		else if (Yandere.Bloodiness == 0f && !CannotChange && Yandere.Schoolwear > 0)
		{
			if (!Occupied)
			{
				Prompt.enabled = true;
				return;
			}
			Prompt.Hide();
			Prompt.enabled = false;
		}
		else
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
