using UnityEngine;

public class BodyHidingLockerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public OutlineScript Outline;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioClip LockerClose;

	public AudioClip LockerOpen;

	public float Rotation;

	public float Speed;

	public Transform Door;

	public int StudentID;

	public bool ABC;

	private void Start()
	{
		Outline = GetComponentInChildren<OutlineScript>();
	}

	private void Update()
	{
		if (Rotation != 0f)
		{
			Speed += Time.deltaTime * 100f;
			Rotation = Mathf.MoveTowards(Rotation, 0f, Speed * Time.deltaTime);
			if (Rotation > -1f)
			{
				AudioSource.PlayClipAtPoint(LockerClose, Prompt.Yandere.MainCamera.transform.position);
				if (Corpse != null)
				{
					Corpse.gameObject.SetActive(value: false);
				}
				Prompt.enabled = true;
				Rotation = 0f;
				Speed = 0f;
				if (ABC)
				{
					Prompt.Hide();
					Prompt.enabled = false;
					base.enabled = false;
				}
			}
			Door.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
		}
		if (Corpse == null)
		{
			if (Prompt.Yandere.Carrying || Prompt.Yandere.Dragging)
			{
				Prompt.enabled = true;
				if (Prompt.Circle[0].fillAmount != 0f)
				{
					return;
				}
				Prompt.Circle[0].fillAmount = 1f;
				AudioSource.PlayClipAtPoint(LockerOpen, Prompt.Yandere.MainCamera.transform.position);
				if (Prompt.Yandere.Carrying)
				{
					Corpse = Prompt.Yandere.CurrentRagdoll;
				}
				else
				{
					Corpse = Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
				}
				Prompt.Label[0].text = "     Remove Corpse";
				Prompt.Hide();
				Prompt.enabled = false;
				Prompt.Yandere.EmptyHands();
				if (Corpse.AddingToCount)
				{
					Prompt.Yandere.NearBodies--;
					Corpse.AddingToCount = false;
				}
				Prompt.Yandere.NearestCorpseID = 0;
				Prompt.Yandere.CorpseWarning = false;
				Prompt.Yandere.StudentManager.UpdateStudents();
				Corpse.transform.parent = base.transform;
				Corpse.transform.position = base.transform.position + new Vector3(0f, 0.1f, 0f);
				Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				if (!Corpse.Concealed)
				{
					if (Corpse.Police == null)
					{
						Corpse.Police = Corpse.Student.Police;
					}
					Corpse.Police.HiddenCorpses++;
				}
				Corpse.enabled = false;
				Corpse.Hidden = true;
				StudentID = Corpse.StudentID;
				if (ABC)
				{
					Corpse.DestroyRigidbodies();
				}
				else
				{
					Corpse.BloodSpawnerCollider.enabled = false;
					Corpse.Prompt.MyCollider.enabled = false;
					Corpse.BloodPoolSpawner.enabled = false;
					Corpse.DisableRigidbodies();
				}
				Corpse.Student.CharacterAnimation.enabled = true;
				Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
				if (Corpse.Decapitated)
				{
					Corpse.Head.transform.localScale = Vector3.zero;
				}
				Rotation = -180f;
				Outline.color = new Color(1f, 0.5f, 0f, 1f);
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			Prompt.Label[0].text = "     Hide Corpse";
			AudioSource.PlayClipAtPoint(LockerOpen, Prompt.Yandere.MainCamera.transform.position);
			Corpse.enabled = true;
			Corpse.gameObject.SetActive(value: true);
			Corpse.CharacterAnimation.enabled = false;
			Corpse.transform.localPosition = new Vector3(0f, 0f, 0.5f);
			Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0.5f);
			Corpse.transform.parent = null;
			Corpse.BloodSpawnerCollider.enabled = true;
			Corpse.Prompt.MyCollider.enabled = true;
			Corpse.BloodPoolSpawner.NearbyBlood = 0;
			Corpse.AddingToCount = false;
			Corpse.EnableRigidbodies();
			if (!Corpse.Cauterized && !Corpse.Concealed)
			{
				Corpse.BloodPoolSpawner.enabled = true;
			}
			for (int i = 0; i < Corpse.Student.FireEmitters.Length; i++)
			{
				Corpse.Student.FireEmitters[i].gameObject.SetActive(value: false);
			}
			Corpse = null;
			Rotation = -180f;
			Outline.color = new Color(0f, 1f, 1f, 1f);
			StudentID = 0;
		}
	}

	public void LateUpdate()
	{
		if (Rotation != 0f && Corpse != null && Corpse.Decapitated)
		{
			Debug.Log("Trying to shrink Corpse head?");
			Corpse.Head.transform.localScale = Vector3.zero;
		}
	}

	public void UpdateCorpse()
	{
		Corpse = StudentManager.Students[StudentID].Ragdoll;
		Corpse.transform.parent = base.transform;
		Prompt.Label[0].text = "     Remove Corpse";
		Prompt.enabled = true;
	}
}
