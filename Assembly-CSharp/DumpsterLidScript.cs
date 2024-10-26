using UnityEngine;

public class DumpsterLidScript : MonoBehaviour
{
	public StudentScript Victim;

	public Transform SlideLocation;

	public Transform GarbageDebris;

	public Transform Hinge;

	public GameObject FallChecker;

	public GameObject Corpse;

	public PromptScript[] DragPrompts;

	public PromptScript Prompt;

	public float DisposalSpot;

	public float Rotation;

	public bool Slide;

	public bool Fill;

	public bool Open;

	public int StudentToGoMissing;

	private void Start()
	{
		FallChecker.SetActive(value: false);
		Prompt.HideButton[3] = true;
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Open)
			{
				Prompt.Label[0].text = "     Close";
				Open = true;
			}
			else
			{
				Prompt.Label[0].text = "     Open";
				Open = false;
			}
		}
		if (!Open)
		{
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
			Prompt.HideButton[3] = true;
		}
		else
		{
			Rotation = Mathf.Lerp(Rotation, -115f, Time.deltaTime * 10f);
			if (Corpse != null)
			{
				if (Prompt.Yandere.PickUp != null)
				{
					Prompt.HideButton[3] = !Prompt.Yandere.PickUp.Garbage;
				}
				else
				{
					Prompt.HideButton[3] = true;
				}
			}
			else
			{
				Prompt.HideButton[3] = true;
			}
			if (Prompt.Circle[3].fillAmount == 0f)
			{
				Object.Destroy(Prompt.Yandere.PickUp.gameObject);
				Prompt.Circle[3].fillAmount = 1f;
				Prompt.HideButton[3] = false;
				Fill = true;
			}
			if (base.transform.position.z > DisposalSpot - 0.05f && base.transform.position.z < DisposalSpot + 0.05f)
			{
				FallChecker.SetActive(Prompt.Yandere.RoofPush);
			}
			else
			{
				FallChecker.SetActive(value: false);
			}
			if (Slide)
			{
				base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, SlideLocation.eulerAngles, Time.deltaTime);
				base.transform.position = Vector3.Lerp(base.transform.position, SlideLocation.position, Time.deltaTime);
				Corpse.GetComponent<RagdollScript>().Student.Hips.position = base.transform.position + new Vector3(0f, 0.5f, 0f);
				Corpse.GetComponent<RagdollScript>().Student.Hips.localEulerAngles = new Vector3(-90f, -135f, 0f);
				Corpse.GetComponent<RagdollScript>().BloodPoolSpawner.enabled = false;
				Corpse.GetComponent<RagdollScript>().InDumpster = true;
				if (Vector3.Distance(base.transform.position, SlideLocation.position) < 0.01f)
				{
					DragPrompts[0].enabled = false;
					DragPrompts[1].enabled = false;
					FallChecker.SetActive(value: false);
					Slide = false;
				}
			}
		}
		Hinge.localEulerAngles = new Vector3(Rotation, 0f, 0f);
		if (!Fill)
		{
			return;
		}
		GarbageDebris.localPosition = new Vector3(GarbageDebris.localPosition.x, Mathf.Lerp(GarbageDebris.localPosition.y, 1f, Time.deltaTime * 10f), GarbageDebris.localPosition.z);
		if (GarbageDebris.localPosition.y > 0.99f)
		{
			Prompt.Yandere.Police.SuicideScene = false;
			Prompt.Yandere.Police.Suicide = false;
			if (!Corpse.GetComponent<RagdollScript>().Concealed)
			{
				Prompt.Yandere.Police.HiddenCorpses--;
			}
			Prompt.Yandere.Police.Corpses--;
			if (Corpse.GetComponent<RagdollScript>().AddingToCount)
			{
				Prompt.Yandere.NearBodies--;
			}
			GarbageDebris.localPosition = new Vector3(GarbageDebris.localPosition.x, 1f, GarbageDebris.localPosition.z);
			StudentToGoMissing = Corpse.GetComponent<StudentScript>().StudentID;
			Corpse.gameObject.SetActive(value: false);
			Fill = false;
			Prompt.Yandere.StudentManager.UpdateStudents();
		}
	}

	public void SetVictimMissing()
	{
		StudentGlobals.SetStudentMissing(StudentToGoMissing, value: true);
	}
}
