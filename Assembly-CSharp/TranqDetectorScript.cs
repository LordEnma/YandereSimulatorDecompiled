using UnityEngine;

public class TranqDetectorScript : MonoBehaviour
{
	public TranqCaseScript TranqCase;

	public YandereScript Yandere;

	public DoorScript Door;

	public UIPanel Checklist;

	public Collider DoorBlocker;

	public Collider MyCollider;

	public UILabel KidnappingLabel;

	public UILabel[] KidnappingLabels;

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
						KidnappingLabels[1].color = Color.white;
					}
					else
					{
						TranquilizerIcon.spriteName = "No";
						KidnappingLabels[1].color = Color.red;
					}
					if (Yandere.Class.BiologyGrade + Yandere.Class.BiologyBonus != 0)
					{
						BiologyIcon.spriteName = "Yes";
						KidnappingLabels[2].color = Color.white;
					}
					else
					{
						BiologyIcon.spriteName = "No";
						KidnappingLabels[2].color = Color.red;
					}
					if (Yandere.Followers != 1)
					{
						FollowerIcon.spriteName = "No";
						KidnappingLabels[3].color = Color.red;
					}
					else if (Mathf.Abs(Vector3.Angle(-Yandere.Follower.transform.forward, Yandere.transform.position - Yandere.Follower.transform.position)) <= 45f)
					{
						KidnappingLabel.text = "Kidnapping Checklist";
						FollowerIcon.spriteName = "Yes";
						CannotKidnap = false;
						KidnappingLabels[3].color = Color.white;
					}
					else
					{
						FollowerIcon.spriteName = "No";
						KidnappingLabels[3].color = Color.red;
					}
					if (!Yandere.Armed)
					{
						SyringeIcon.spriteName = "No";
						KidnappingLabels[4].color = Color.red;
					}
					else if (Yandere.EquippedWeapon.WeaponID != 3)
					{
						SyringeIcon.spriteName = "No";
						KidnappingLabels[4].color = Color.red;
					}
					else
					{
						SyringeIcon.spriteName = "Yes";
						KidnappingLabels[4].color = Color.white;
					}
					if (Door.Open || Door.Timer < 1f)
					{
						DoorIcon.spriteName = "No";
						KidnappingLabels[5].color = Color.red;
					}
					else
					{
						DoorIcon.spriteName = "Yes";
						KidnappingLabels[5].color = Color.white;
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
		Debug.Log("Now performing TranqCheck().");
		if (StopChecking)
		{
			return;
		}
		Debug.Log("StopChecking is false.");
		if (!CannotKidnap)
		{
			Debug.Log("CannotKidnap is false.");
			bool flag = false;
			if (Mathf.Abs(Vector3.Angle(-Yandere.Follower.transform.forward, Yandere.transform.position - Yandere.Follower.transform.position)) > 45f)
			{
				Debug.Log("Not a stealth attack.");
			}
			else
			{
				Debug.Log("Performing a stealth attack.");
				flag = true;
			}
			if (flag && TranquilizerIcon.spriteName == "Yes" && FollowerIcon.spriteName == "Yes" && BiologyIcon.spriteName == "Yes" && SyringeIcon.spriteName == "Yes" && DoorIcon.spriteName == "Yes")
			{
				Debug.Log("All of the icons said ''Yes''.");
				AudioSource component = GetComponent<AudioSource>();
				component.clip = TranqClips[Random.Range(0, TranqClips.Length)];
				component.Play();
				Door.Prompt.Hide();
				Door.Prompt.enabled = false;
				Door.enabled = false;
				Door.DoorColliders[0].isTrigger = false;
				Door.DoorColliders[1].isTrigger = false;
				DoorBlocker.enabled = true;
				Yandere.Inventory.SedativePoisons--;
				Yandere.CanTranq = true;
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
