using UnityEngine;

public class BakeSaleScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public StudentScript CurrentCustomer;

	public SkinnedMeshRenderer MoneyRenderer;

	public GameObject AmaiSuccess;

	public GameObject AmaiFail;

	public GameObject Flowers;

	public UILabel ProfitLabel;

	public Transform MeetSpot;

	public Transform WaitSpot;

	public Texture AmaiPoster;

	public Texture Apology;

	public Renderer[] WallPoster;

	public Renderer[] WallPoster2;

	public Renderer[] Poster;

	public bool CustomerPresent;

	public bool Poisoned;

	public bool ShutDown;

	public int RepToSubtract;

	public int Money;

	public int ID = 2;

	public float Timer;

	public bool[] TrayPlaced;

	public void Start()
	{
		if (StudentManager.Students[71] == null || ClubGlobals.GetClubClosed(ClubType.Gardening))
		{
			Flowers.SetActive(value: false);
		}
	}

	public void UpdatePosters()
	{
		if (ClubGlobals.Club != ClubType.Cooking)
		{
			Poster[0].materials[1].mainTexture = AmaiPoster;
		}
		if (StudentManager.Students[21] == null)
		{
			Poster[1].materials[1].mainTexture = AmaiPoster;
			Poster[10].materials[1].mainTexture = AmaiPoster;
		}
		if (StudentManager.Students[22] == null)
		{
			Poster[2].materials[1].mainTexture = AmaiPoster;
		}
		if (StudentManager.Students[23] == null)
		{
			Poster[3].materials[1].mainTexture = AmaiPoster;
		}
		if (StudentManager.Students[24] == null)
		{
			Poster[4].materials[1].mainTexture = AmaiPoster;
		}
		if (StudentManager.Students[25] == null)
		{
			Poster[5].materials[1].mainTexture = AmaiPoster;
		}
		if (GameGlobals.BakeSalePoisoned)
		{
			for (int i = 0; i < Poster.Length; i++)
			{
				Poster[i].materials[1].mainTexture = Apology;
			}
		}
		for (int j = 0; j < WallPoster.Length; j++)
		{
			WallPoster[j].material.mainTexture = Poster[j].materials[1].mainTexture;
		}
		for (int k = 0; k < WallPoster2.Length; k++)
		{
			WallPoster2[k].material.mainTexture = Poster[k].materials[1].mainTexture;
		}
	}

	private void Update()
	{
		float hourTime = StudentManager.Clock.HourTime;
		if (!(hourTime < 8f) && (!(hourTime > 13f) || !((double)hourTime < 13.5)) && (!(hourTime > 16f) || !(hourTime < 17f)))
		{
			return;
		}
		if (CurrentCustomer != null && Vector3.Distance(new Vector3(0f, 0f, -4f), CurrentCustomer.transform.position) < 2f)
		{
			CustomerPresent = true;
		}
		else
		{
			CustomerPresent = false;
		}
		Timer += Time.deltaTime;
		if (!(Timer > 30f))
		{
			return;
		}
		if (StudentManager.Students[ID] != null && !StudentManager.Yandere.InClass)
		{
			while ((ID > 9 && ID < 26) || ID > 86 || StudentManager.Students[ID] == null)
			{
				IncreaseID();
			}
			if (StudentManager.Students[ID].Routine && StudentManager.Students[ID].Indoors && !StudentManager.Students[ID].Slave && !StudentManager.Students[ID].InEvent && !StudentManager.Students[ID].Bullied && !StudentManager.Students[ID].Meeting && !StudentManager.Students[ID].DressCode && !StudentManager.Students[ID].ClubAttire && !StudentManager.Students[ID].Distracted && !StudentManager.Students[ID].Investigating && StudentManager.Students[ID].Schoolwear == 1 && StudentManager.Students[ID].ClubActivityPhase < 16 && StudentManager.Students[ID].Club != ClubType.Delinquent && StudentManager.Students[ID].CurrentAction != StudentActionType.PrepareFoodForever)
			{
				Debug.Log(StudentManager.Students[ID].Name + " has decided to go to the bake sale.");
				Timer = 0f;
				StudentManager.Students[ID].Meeting = true;
				StudentManager.Students[ID].BakeSale = true;
				StudentManager.Students[ID].MeetTime = 0.0001f;
				StudentManager.Students[ID].MeetSpot = MeetSpot;
				IncreaseID();
			}
			else
			{
				IncreaseID();
			}
		}
		else
		{
			IncreaseID();
		}
	}

	private void IncreaseID()
	{
		ID++;
		if (ID > 89)
		{
			ID = 2;
		}
	}

	public void MakeSale()
	{
		Money++;
		MoneyRenderer.SetBlendShapeWeight(0, 94.7f - (float)Money);
		ProfitLabel.text = "$" + Money + ".00";
	}
}
