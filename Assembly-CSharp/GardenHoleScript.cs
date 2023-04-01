using UnityEngine;

public class GardenHoleScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public Collider MyCollider;

	public MeshFilter MyMesh;

	public GameObject Carrots;

	public GameObject Pile;

	public Mesh MoundMesh;

	public Mesh HoleMesh;

	public bool Bury;

	public bool Dug;

	public int VictimID;

	public int ID;

	private void Start()
	{
		if (SchoolGlobals.GetGardenGraveOccupied(ID))
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.DistanceSqr < 10f)
		{
			if (Yandere.Armed)
			{
				if (Yandere.EquippedWeapon.WeaponID == 10)
				{
					Prompt.HideButton[0] = false;
				}
				else if (Prompt.enabled)
				{
					Prompt.HideButton[0] = true;
				}
			}
			else if (Prompt.enabled)
			{
				Prompt.HideButton[0] = true;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.HideButton[0] = true;
		}
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Yandere.Chased || Yandere.Chasers != 0)
		{
			return;
		}
		string[] armedAnims = Yandere.ArmedAnims;
		foreach (string text in armedAnims)
		{
			Yandere.CharacterAnimation[text].weight = 0f;
		}
		Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, Yandere.transform.position.y, base.transform.position.z) - Yandere.transform.position);
		Yandere.RPGCamera.transform.eulerAngles = Yandere.DigSpot.eulerAngles;
		Yandere.RPGCamera.transform.position = Yandere.DigSpot.position;
		Yandere.EquippedWeapon.gameObject.SetActive(value: false);
		Yandere.CharacterAnimation["f02_shovelBury_00"].time = 0f;
		Yandere.CharacterAnimation["f02_shovelDig_00"].time = 0f;
		Yandere.FloatingShovel.SetActive(value: true);
		Yandere.RPGCamera.enabled = false;
		Yandere.CanMove = false;
		Yandere.DigPhase = 1;
		Carrots.SetActive(value: false);
		Prompt.Circle[0].fillAmount = 1f;
		if (!Dug)
		{
			Yandere.FloatingShovel.GetComponent<Animation>()["Dig"].time = 0f;
			Yandere.FloatingShovel.GetComponent<Animation>().Play("Dig");
			Yandere.Character.GetComponent<Animation>().Play("f02_shovelDig_00");
			Yandere.Digging = true;
			Prompt.Label[0].text = "     Fill";
			MyCollider.isTrigger = true;
			MyMesh.mesh = HoleMesh;
			Pile.SetActive(value: true);
			Dug = true;
		}
		else
		{
			Yandere.FloatingShovel.GetComponent<Animation>()["Bury"].time = 0f;
			Yandere.FloatingShovel.GetComponent<Animation>().Play("Bury");
			Yandere.CharacterAnimation.Play("f02_shovelBury_00");
			Yandere.Burying = true;
			Prompt.Label[0].text = "     Dig";
			MyCollider.isTrigger = false;
			MyMesh.mesh = MoundMesh;
			Pile.SetActive(value: false);
			Dug = false;
		}
		if (Bury)
		{
			Yandere.Police.Corpses--;
			if (Yandere.Police.SuicideScene && Yandere.Police.Corpses == 1)
			{
				Yandere.Police.MurderScene = false;
			}
			if (Yandere.Police.Corpses == 0)
			{
				Yandere.Police.MurderScene = false;
			}
			VictimID = Corpse.StudentID;
			Corpse.Disposed = true;
			Corpse.Remove();
			Corpse.transform.parent = base.transform;
			if (Corpse.StudentID == Yandere.StudentManager.RivalID)
			{
				Debug.Log("Just buried Osana's corpse.");
				Yandere.Police.EndOfDay.RivalBuried = true;
			}
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
			Prompt.Yandere.StudentManager.UpdateStudents();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Dug && other.gameObject.layer == 11)
		{
			Prompt.Label[0].text = "     Bury";
			Corpse = other.transform.root.gameObject.GetComponent<RagdollScript>();
			Bury = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (Dug && other.gameObject.layer == 11)
		{
			Prompt.Label[0].text = "     Fill";
			Corpse = null;
			Bury = false;
		}
	}

	public void EndOfDayCheck()
	{
		if (VictimID > 0)
		{
			StudentGlobals.SetStudentMissing(VictimID, value: true);
			SchoolGlobals.SetGardenGraveOccupied(ID, value: true);
		}
	}
}
