using UnityEngine;

public class TributeScript : MonoBehaviour
{
	public RiggedAccessoryAttacher RiggedAttacher;

	public StudentManagerScript StudentManager;

	public GameObject StudentFootageCamera;

	public HenshinScript Henshin;

	public YandereScript Yandere;

	public GameObject TitleBelt;

	public GameObject FunGirl;

	public GameObject Rainey;

	public string[] MinecraftLetters;

	public string[] ChessterLetters;

	public string[] MedibangLetters;

	public string[] PpStarrsLetters;

	public string[] FootageLetters;

	public string[] LacunaLetters;

	public string[] MiyukiLetters;

	public string[] SpookyLetters;

	public string[] LunarLetters;

	public string[] NurseLetters;

	public string[] MaidLetters;

	public string[] FunLetters;

	public string[] WWELetters;

	public string[] AzurLane;

	public string[] Letter;

	public int MinecraftID;

	public int ChessterID;

	public int MedibangID;

	public int PpStarrsID;

	public int FootageID;

	public int LacunaID;

	public int MiyukiID;

	public int SpookyID;

	public int LunarID;

	public int NurseID;

	public int AzurID;

	public int MaidID;

	public int FunID;

	public int WWEID;

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
			if (Input.GetKeyDown(PpStarrsLetters[PpStarrsID]))
			{
				PpStarrsID++;
				if (PpStarrsID == PpStarrsLetters.Length)
				{
					Yandere.PpStarrs();
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(LacunaLetters[LacunaID]))
			{
				LacunaID++;
				if (LacunaID == LacunaLetters.Length)
				{
					Yandere.Lacuna();
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(ChessterLetters[ChessterID]))
			{
				ChessterID++;
				if (ChessterID == ChessterLetters.Length)
				{
					StudentManager.Students[1].Cosmetic.MaleHair[StudentManager.Students[1].Cosmetic.Hairstyle].SetActive(value: false);
					StudentManager.Students[1].ChessterAttacher.enabled = true;
					StudentManager.Students[1].ChessterMask.SetActive(value: true);
					StudentManager.Students[1].MyRenderer.enabled = false;
					StudentManager.Students[1].Chesster = true;
					Yandere.Stance.Current = StanceType.Standing;
					Yandere.CrawlTimer = 0f;
					Yandere.Uncrouch();
					base.enabled = false;
				}
			}
			if (Yandere.LunaMode && Input.GetKeyDown(LunarLetters[LunarID]))
			{
				LunarID++;
				if (LunarID == LunarLetters.Length)
				{
					Yandere.LunaAttacher.GetComponent<RiggedAccessoryAttacher>().newRenderer.enabled = false;
					Yandere.PantyAttacher.newRenderer.enabled = false;
					Yandere.OriginalLuna.SetActive(value: true);
					Yandere.RightSleeve.SetActive(value: false);
					Yandere.LeftSleeve.SetActive(value: false);
					Yandere.BreastSize = 1.25f;
					Yandere.UpdateBust();
					Yandere.AccessoryID = 0;
					Yandere.UpdateAccessory();
					Yandere.Hairstyle = 215;
					Yandere.UpdateHair();
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
			if (Input.GetKeyDown(WWELetters[WWEID]))
			{
				WWEID++;
				if (WWEID == WWELetters.Length)
				{
					TitleBelt.SetActive(value: true);
					base.enabled = false;
				}
			}
			if (!Input.GetKeyDown(SpookyLetters[SpookyID]))
			{
				return;
			}
			SpookyID++;
			if (SpookyID != SpookyLetters.Length)
			{
				return;
			}
			for (int i = 1; i < 100; i++)
			{
				if (StudentManager.Students[i] != null)
				{
					StudentManager.Students[i].PumpkinHeads[Random.Range(0, StudentManager.Students[i].PumpkinHeads.Length)].SetActive(value: true);
					StudentManager.Students[i].Cosmetic.HairRenderer.enabled = false;
				}
			}
			base.enabled = false;
		}
	}
}
