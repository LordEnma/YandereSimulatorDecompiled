using UnityEngine;

public class WoodChipperScript : MonoBehaviour
{
	public ParticleSystem BloodSpray;

	public PromptScript BucketPrompt;

	public YandereScript Yandere;

	public PickUpScript Bucket;

	public PromptScript Prompt;

	public AudioClip CloseAudio;

	public AudioClip ShredAudio;

	public AudioClip OpenAudio;

	public Transform BucketPoint;

	public Transform DumpPoint;

	public Transform Lid;

	public float Rotation;

	public float Timer;

	public bool Shredding;

	public bool Occupied;

	public bool Acid;

	public bool Open;

	public int HiddenCorpses;

	public int VictimID;

	public int Victims;

	public int ID;

	public int[] VictimList;

	public AudioSource MyAudio;

	private void Start()
	{
		MyAudio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!Acid)
		{
			if (Yandere.PickUp != null)
			{
				if (Yandere.PickUp.Bucket != null)
				{
					if (!Yandere.PickUp.Bucket.Full)
					{
						if (Bucket == null)
						{
							BucketPrompt.HideButton[0] = false;
							if (BucketPrompt.Circle[0].fillAmount == 0f)
							{
								Bucket = Yandere.PickUp;
								Yandere.EmptyHands();
								Bucket.transform.eulerAngles = BucketPoint.eulerAngles;
								Bucket.transform.position = BucketPoint.position;
								Bucket.MyRigidbody.useGravity = false;
								Bucket.MyCollider.enabled = false;
							}
						}
						else
						{
							BucketPrompt.HideButton[0] = true;
						}
					}
					else
					{
						BucketPrompt.HideButton[0] = true;
					}
				}
				else
				{
					BucketPrompt.HideButton[0] = true;
				}
			}
			else
			{
				BucketPrompt.HideButton[0] = true;
			}
			if (!BloodSpray.isPlaying)
			{
				if (!Occupied)
				{
					if (Yandere.Ragdoll == null)
					{
						Prompt.HideButton[3] = true;
					}
					else
					{
						Prompt.HideButton[3] = false;
					}
				}
				else if (Bucket == null)
				{
					Prompt.HideButton[0] = true;
				}
				else if (Bucket.Bucket.Full)
				{
					Prompt.HideButton[0] = true;
				}
				else
				{
					Prompt.HideButton[0] = false;
				}
			}
		}
		else if (Prompt.enabled)
		{
			if (Yandere.Ragdoll == null)
			{
				Prompt.HideButton[3] = true;
			}
			else
			{
				Prompt.HideButton[3] = false;
			}
			if ((Yandere.Armed && Yandere.EquippedWeapon.Evidence) || (Yandere.PickUp != null && Yandere.PickUp.Evidence) || (Yandere.PickUp != null && Yandere.PickUp.ConcealedBodyPart))
			{
				Prompt.HideButton[1] = false;
			}
			else
			{
				Prompt.HideButton[1] = true;
			}
		}
		if (!Open)
		{
			Rotation = Mathf.MoveTowards(Rotation, 0f, Time.deltaTime * 360f);
			if (Rotation > -36f)
			{
				if (Rotation < 0f)
				{
					MyAudio.clip = CloseAudio;
					MyAudio.Play();
				}
				Rotation = 0f;
			}
			Lid.transform.localEulerAngles = new Vector3(Rotation, Lid.transform.localEulerAngles.y, Lid.transform.localEulerAngles.z);
		}
		else
		{
			if (Lid.transform.localEulerAngles.x == 0f)
			{
				MyAudio.clip = OpenAudio;
				MyAudio.Play();
			}
			Rotation = Mathf.MoveTowards(Rotation, -90f, Time.deltaTime * 360f);
			Lid.transform.localEulerAngles = new Vector3(Rotation, Lid.transform.localEulerAngles.y, Lid.transform.localEulerAngles.z);
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Debug.Log("As of now, Yandere-chan's ''Woodchipper'' is being set to: " + base.gameObject.name);
			Yandere.WoodChipper = this;
			Time.timeScale = 1f;
			if (Yandere.Ragdoll != null)
			{
				if (!Yandere.Carrying)
				{
					Yandere.CharacterAnimation.CrossFade("f02_dragIdle_00");
				}
				else
				{
					Yandere.CharacterAnimation.CrossFade("f02_carryIdleA_00");
				}
				Yandere.YandereVision = false;
				Yandere.Chipping = true;
				Yandere.CanMove = false;
				Victims++;
				VictimList[Victims] = Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
				Open = true;
				_ = Acid;
			}
		}
		if (Acid && Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[1].fillAmount = 1f;
			if (Yandere.Armed)
			{
				WeaponScript equippedWeapon = Yandere.EquippedWeapon;
				Yandere.EmptyHands();
				Yandere.Police.MurderWeapons--;
				Object.Destroy(equippedWeapon.gameObject);
			}
			else
			{
				PickUpScript pickUp = Yandere.PickUp;
				Yandere.EmptyHands();
				if (pickUp.Clothing)
				{
					Yandere.Police.BloodyClothing--;
				}
				if (pickUp.ConcealedBodyPart)
				{
					Yandere.Police.BodyParts--;
				}
				Object.Destroy(pickUp.gameObject);
			}
			MyAudio.clip = ShredAudio;
			MyAudio.Play();
		}
		if ((Acid && Occupied && VictimID > 0) || Prompt.Circle[0].fillAmount == 0f)
		{
			Debug.Log(base.gameObject.name + " is now disposing of a corpse.");
			if (!Acid)
			{
				MyAudio.clip = ShredAudio;
				MyAudio.Play();
				Prompt.HideButton[3] = false;
				Prompt.HideButton[0] = true;
				Prompt.Hide();
				Prompt.enabled = false;
			}
			Yandere.Police.HiddenCorpses -= HiddenCorpses;
			Yandere.Police.Corpses--;
			if (Yandere.Police.SuicideScene && Yandere.Police.Corpses == 1)
			{
				Yandere.Police.MurderScene = false;
			}
			if (Yandere.Police.Corpses == 0)
			{
				Yandere.Police.MurderScene = false;
			}
			Debug.Log("The Student ID of the victim is: " + VictimID);
			if (Yandere.StudentManager == null)
			{
				Debug.Log("StudentManager is null?!");
			}
			if (Yandere.StudentManager.Students[VictimID] == null)
			{
				Debug.Log("Student #" + VictimID + " is null?!");
			}
			if (!Acid)
			{
				Shredding = true;
			}
			else
			{
				Occupied = false;
			}
			if (Yandere.StudentManager.Students[VictimID] != null)
			{
				if (Yandere.StudentManager.Students[VictimID].Drowned)
				{
					Yandere.Police.DrownVictims--;
				}
				Yandere.StudentManager.Students[VictimID].Ragdoll.Disposed = true;
			}
			if (Yandere.StudentManager.Students[Yandere.StudentManager.RivalID] != null && Yandere.StudentManager.Students[Yandere.StudentManager.RivalID].Ragdoll.Disposed)
			{
				Debug.Log("Just shredded or dissolved the current rival's corpse.");
				Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
			}
			Yandere.StudentManager.UpdateStudents();
			HiddenCorpses = 0;
			VictimID = 0;
		}
		if (!Shredding)
		{
			return;
		}
		if (Bucket != null)
		{
			Bucket.Bucket.UpdateAppearance = true;
		}
		Timer += Time.deltaTime;
		if (Timer >= 10f)
		{
			Prompt.enabled = true;
			Shredding = false;
			Occupied = false;
			Timer = 0f;
		}
		else if (Timer >= 9f)
		{
			if (Bucket != null)
			{
				Bucket.MyCollider.enabled = true;
				Bucket.Bucket.FillSpeed = 1f;
				Bucket = null;
				BloodSpray.Stop();
			}
		}
		else if (Timer >= 0.33333f && Bucket != null && !Bucket.Bucket.Full)
		{
			BloodSpray.GetComponent<AudioSource>().Play();
			BloodSpray.Play();
			Bucket.Bucket.Bloodiness = 100f;
			Bucket.Bucket.FillSpeed = 0.066666f;
			Bucket.Bucket.Blood.material.color = new Color(1f, 1f, 1f, 1f);
			Bucket.Bucket.Blood.gameObject.SetActive(value: true);
			Bucket.Bucket.UpdateAppearance = true;
			Bucket.Bucket.Full = true;
			Bucket.Outline[0].color = new Color(1f, 0.5f, 0f, 1f);
		}
	}

	public void SetVictimsMissing()
	{
		int[] victimList = VictimList;
		for (int i = 0; i < victimList.Length; i++)
		{
			StudentGlobals.SetStudentMissing(victimList[i], value: true);
		}
	}
}
