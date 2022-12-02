using UnityEngine;

public class TranqCaseScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RagdollScript Ragdoll;

	public PromptScript Prompt;

	public DoorScript Door;

	public Transform Hinge;

	public bool Occupied;

	public bool Open;

	public int VictimID;

	public ClubType VictimClubType;

	public float Rotation;

	public bool Animate;

	private void Start()
	{
		Prompt.enabled = false;
	}

	private void Update()
	{
		if (Yandere.transform.position.x > base.transform.position.x && Vector3.Distance(base.transform.position, Yandere.transform.position) < 1f)
		{
			if (Yandere.Dragging)
			{
				if (Ragdoll == null)
				{
					Ragdoll = Yandere.Ragdoll.GetComponent<RagdollScript>();
				}
				if (Ragdoll.Tranquil)
				{
					if (!Prompt.enabled)
					{
						Prompt.enabled = true;
					}
				}
				else if (Prompt.enabled)
				{
					Prompt.Hide();
					Prompt.enabled = false;
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
		if (Prompt.enabled && Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Yandere.Chased && Yandere.Chasers == 0)
			{
				Yandere.TranquilHiding = true;
				Yandere.CanMove = false;
				Prompt.enabled = false;
				Prompt.Hide();
				Ragdoll.TranqCase = this;
				VictimClubType = Ragdoll.Student.Club;
				VictimID = Ragdoll.StudentID;
				Door.Prompt.enabled = true;
				Door.enabled = true;
				Occupied = true;
				Animate = true;
				Open = true;
				if (Ragdoll.Student.Club == ClubType.LightMusic && Ragdoll.Student.InstrumentBag[Ragdoll.Student.ClubMemberID] != null)
				{
					Ragdoll.Student.InstrumentBag[Ragdoll.Student.ClubMemberID].gameObject.SetActive(false);
				}
			}
		}
		if (!Animate)
		{
			return;
		}
		if (Open)
		{
			Rotation = Mathf.Lerp(Rotation, 105f, Time.deltaTime * 10f);
		}
		else
		{
			Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 10f);
			Ragdoll.Student.OsanaHairL.transform.localScale = Vector3.MoveTowards(Ragdoll.Student.OsanaHairL.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			Ragdoll.Student.OsanaHairR.transform.localScale = Vector3.MoveTowards(Ragdoll.Student.OsanaHairR.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			if (Rotation < 1f)
			{
				Animate = false;
				Rotation = 0f;
			}
		}
		Hinge.localEulerAngles = new Vector3(0f, 0f, Rotation);
	}
}
