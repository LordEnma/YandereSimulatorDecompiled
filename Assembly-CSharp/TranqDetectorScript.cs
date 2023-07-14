using UnityEngine;

public class TranqDetectorScript : MonoBehaviour
{
	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public DoorScript Door;

	public UIPanel Checklist;

	public Collider MyCollider;

	public UILabel KidnappingLabel;

	public UISprite TranquilizerIcon;

	public UISprite FollowerIcon;

	public UISprite BiologyIcon;

	public UISprite SyringeIcon;

	public UISprite DoorIcon;

	public bool StopChecking;

	public bool CannotKidnap;

	public int BasementPrisoners;

	public AudioClip[] TranqClips;

	public AudioClip[] FemaleGarroteClips;

	public AudioClip[] MaleGarroteClips;

	public AudioSource MyAudioSource;

	public bool DisableAfterwards;

	private void Start()
	{
		Checklist.alpha = 0f;
		BasementPrisoners = StudentGlobals.Prisoners;
	}

	private void Update()
	{
		if (!StopChecking)
		{
			if (MyCollider.bounds.Contains(Yandere.transform.position))
			{
				if (BasementPrisoners > 9)
				{
					KidnappingLabel.text = "There is no room for another prisoner in your basement.";
					CannotKidnap = true;
				}
				else
				{
					if (Yandere.Inventory.SedativePoisons > 0)
					{
						TranquilizerIcon.spriteName = "Yes";
					}
					else
					{
						TranquilizerIcon.spriteName = "No";
					}
					if (Yandere.Followers != 1)
					{
						FollowerIcon.spriteName = "No";
					}
					else if (Yandere.Follower.Male)
					{
						KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
						FollowerIcon.spriteName = "No";
						CannotKidnap = true;
					}
					else
					{
						KidnappingLabel.text = "Kidnapping Checklist";
						FollowerIcon.spriteName = "Yes";
						CannotKidnap = false;
					}
					BiologyIcon.spriteName = ((Yandere.Class.BiologyGrade + Yandere.Class.BiologyBonus != 0) ? "Yes" : "No");
					if (!Yandere.Armed)
					{
						SyringeIcon.spriteName = "No";
					}
					else if (Yandere.EquippedWeapon.WeaponID != 3)
					{
						SyringeIcon.spriteName = "No";
					}
					else
					{
						SyringeIcon.spriteName = "Yes";
					}
					if (Door.Open || Door.Timer < 1f)
					{
						DoorIcon.spriteName = "No";
					}
					else
					{
						DoorIcon.spriteName = "Yes";
					}
				}
				Checklist.alpha = Mathf.MoveTowards(Checklist.alpha, 1f, Time.deltaTime);
			}
			else if (Checklist.alpha != 0f)
			{
				Checklist.alpha = Mathf.MoveTowards(Checklist.alpha, 0f, Time.deltaTime);
			}
		}
		else
		{
			Checklist.alpha = Mathf.MoveTowards(Checklist.alpha, 0f, Time.deltaTime);
			if (Checklist.alpha == 0f)
			{
				base.enabled = false;
			}
		}
	}

	public void TranqCheck()
	{
		if (!StopChecking && !CannotKidnap && TranquilizerIcon.spriteName == "Yes" && FollowerIcon.spriteName == "Yes" && BiologyIcon.spriteName == "Yes" && SyringeIcon.spriteName == "Yes" && DoorIcon.spriteName == "Yes")
		{
			AudioSource component = GetComponent<AudioSource>();
			component.clip = TranqClips[Random.Range(0, TranqClips.Length)];
			component.Play();
			Door.Prompt.Hide();
			Door.Prompt.enabled = false;
			Door.enabled = false;
			Door.DoorColliders[0].isTrigger = false;
			Door.DoorColliders[1].isTrigger = false;
			Yandere.Inventory.SedativePoisons--;
			if (!Yandere.Follower.Male)
			{
				Yandere.CanTranq = true;
			}
			Yandere.EquippedWeapon.Type = WeaponType.Syringe;
			Yandere.AttackManager.Stealth = true;
			StopChecking = true;
			TranquilizerIcon.spriteName = "No";
			FollowerIcon.spriteName = "No";
			BiologyIcon.spriteName = "No";
			SyringeIcon.spriteName = "No";
			DoorIcon.spriteName = "No";
			TranqCase.StudentToCheckFor = Yandere.Follower;
		}
	}

	public void GarroteAttack()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			base.gameObject.SetActive(value: true);
			DisableAfterwards = true;
		}
		Debug.Log("Performing garrote attack.");
		Yandere.AttackManager.Stealth = true;
		if (Yandere.TargetStudent.Male)
		{
			MyAudioSource.clip = MaleGarroteClips[Random.Range(0, MaleGarroteClips.Length)];
		}
		else
		{
			MyAudioSource.clip = FemaleGarroteClips[Random.Range(0, FemaleGarroteClips.Length)];
		}
		MyAudioSource.Play();
		base.enabled = true;
	}

	public void LateUpdate()
	{
		if (MyAudioSource.isPlaying)
		{
			MyAudioSource.pitch = Time.timeScale;
		}
		else if (DisableAfterwards)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
