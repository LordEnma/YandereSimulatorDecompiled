using UnityEngine;

public class TributeScript : MonoBehaviour
{
	public RiggedAccessoryAttacher RiggedAttacher;

	public StudentManagerScript StudentManager;

	public GameObject StudentFootageCamera;

	public HenshinScript Henshin;

	public YandereScript Yandere;

	public GameObject FunGirl;

	public GameObject Rainey;

	public string[] MinecraftLetters;

	public string[] MedibangLetters;

	public string[] FootageLetters;

	public string[] MiyukiLetters;

	public string[] NurseLetters;

	public string[] MaidLetters;

	public string[] FunLetters;

	public string[] AzurLane;

	public string[] Letter;

	public int MinecraftID;

	public int MedibangID;

	public int FootageID;

	public int MiyukiID;

	public int NurseID;

	public int AzurID;

	public int MaidID;

	public int FunID;

	public int ID;

	public Mesh ThiccMesh;

	public bool TransformNurse;

	public Material MinecraftMaterial;

	private void Start()
	{
		if (GameGlobals.LoveSick || MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.EightiesTutorial || DateGlobals.Week > 10)
		{
			base.enabled = false;
		}
		_ = GameGlobals.Eighties;
		Rainey.SetActive(value: false);
	}

	private void Update()
	{
		if (RiggedAttacher.gameObject.activeInHierarchy)
		{
			RiggedAttacher.newRenderer.SetBlendShapeWeight(0, 100f);
			RiggedAttacher.newRenderer.SetBlendShapeWeight(1, 100f);
			base.enabled = false;
		}
		else
		{
			if (Yandere.PauseScreen.Show || !Yandere.CanMove || Yandere.NoDebug)
			{
				return;
			}
			if (Input.GetKeyDown(Letter[ID]))
			{
				ID++;
				if (ID == Letter.Length)
				{
					Rainey.SetActive(value: true);
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(AzurLane[AzurID]))
			{
				AzurID++;
				if (AzurID == AzurLane.Length)
				{
					Yandere.AzurLane();
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(NurseLetters[NurseID]) || TransformNurse)
			{
				NurseID++;
				if (NurseID == NurseLetters.Length)
				{
					RiggedAttacher.root = StudentManager.Students[90].Hips.parent.gameObject;
					RiggedAttacher.Student = StudentManager.Students[90];
					RiggedAttacher.gameObject.SetActive(value: true);
					StudentManager.Students[90].MyRenderer.enabled = false;
				}
			}
			if (Input.GetKeyDown(MedibangLetters[MedibangID]))
			{
				MedibangID++;
				if (MedibangID == MedibangLetters.Length)
				{
					Yandere.Medibang();
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(MaidLetters[MaidID]))
			{
				MaidID++;
				if (MaidID == MaidLetters.Length)
				{
					Yandere.Maid();
					base.enabled = false;
				}
			}
			if (Yandere.Armed && Yandere.EquippedWeapon.WeaponID == 14 && !Yandere.StudentManager.Eighties && Input.GetKeyDown(MiyukiLetters[MiyukiID]))
			{
				MiyukiID++;
				if (MiyukiID == MiyukiLetters.Length)
				{
					Henshin.TransformYandere();
					Yandere.CanMove = false;
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(FootageLetters[FootageID]))
			{
				FootageID++;
				if (FootageID == FootageLetters.Length)
				{
					StudentFootageCamera.SetActive(value: true);
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(FunLetters[FunID]))
			{
				FunID++;
				if (FunID == FunLetters.Length)
				{
					StudentManager.DespawnAllStudents();
					FunGirl.SetActive(value: true);
					base.enabled = false;
				}
			}
		}
	}
}
