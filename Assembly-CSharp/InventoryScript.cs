using System.Globalization;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
	public MoneyLabelScript TheMoneyLabelScript;

	public YandereScript Yandere;

	public SchemesScript Schemes;

	public GameObject ExplosiveDeviceSet;

	public bool FinishedHomework;

	public bool ModifiedUniform;

	public bool DirectionalMic;

	public bool DuplicateSheet;

	public bool AnswerSheet;

	public bool MaskingTape;

	public bool RivalPhone;

	public bool TapePlayer;

	public bool Narcotics;

	public bool PinkCloth;

	public bool PinkSocks;

	public bool LockPick;

	public bool Condoms;

	public bool Headset;

	public bool Bikini;

	public bool FakeID;

	public bool IDCard;

	public bool String;

	public bool Book;

	public bool Cigs;

	public bool Ring;

	public bool Rose;

	public bool Sake;

	public bool Soda;

	public bool Bra;

	public bool AmnesiaBomb;

	public bool SmokeBomb;

	public bool StinkBomb;

	public bool CabinetKey;

	public bool CaseKey;

	public bool SafeKey;

	public bool ShedKey;

	public bool Ammonium;

	public bool Balloons;

	public bool Bandages;

	public bool Glass;

	public bool Hairpins;

	public bool Nails;

	public bool Paper;

	public bool PaperClips;

	public bool SilverFulminate;

	public bool WoodenSticks;

	public bool Mustard;

	public bool Salt;

	public bool Tyramine;

	public bool Phenylethylamine;

	public bool Acetone;

	public bool Chloroform;

	public bool AceticAcid;

	public bool BariumCarbonate;

	public bool PotassiumNitrate;

	public bool Sugar;

	public bool EmeticChemical;

	public bool HeadacheChemical;

	public bool SedativeChemical;

	public bool LethalChemical;

	public int EmeticPoisons;

	public int SedativePoisons;

	public int HeadachePoisons;

	public int LethalPoisons;

	public int MysteriousKeys;

	public int RivalPhoneID;

	public int SenpaiShots;

	public int PantyShots;

	public int Flyers;

	public int Books;

	public int[] ItemsRequested;

	public int[] ItemsCollected;

	public int Cloth;

	public float Money;

	public bool[] ShrineCollectibles;

	public UILabel MoneyLabel;

	public bool ArrivedWithNarcotics;

	public bool ArrivedWithRatPoison;

	public bool ArrivedWithSake;

	public bool ArrivedWithCigs;

	public bool ArrivedWithCondoms;

	public bool ArrivedWithSedative;

	public bool ArrivedWithPoison;

	private void Start()
	{
		DirectionalMic = PlayerGlobals.DirectionalMic;
		Headset = PlayerGlobals.Headset;
		SenpaiShots = PlayerGlobals.SenpaiShots;
		PantyShots = PlayerGlobals.PantyShots;
		Money = PlayerGlobals.Money;
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0)
		{
			Debug.Log("The player brought an item. ID is: " + bringingItem);
		}
		switch (bringingItem)
		{
		case 4:
			ArrivedWithRatPoison = true;
			EmeticPoisons++;
			break;
		case 5:
			ArrivedWithSake = true;
			Sake = true;
			break;
		case 6:
			ArrivedWithCigs = true;
			Cigs = true;
			break;
		case 7:
			ArrivedWithCondoms = true;
			Condoms = true;
			break;
		case 8:
			LockPick = true;
			break;
		case 9:
			ArrivedWithSedative = true;
			SedativePoisons++;
			break;
		case 10:
			ArrivedWithNarcotics = true;
			Narcotics = true;
			break;
		case 11:
			ArrivedWithPoison = true;
			LethalPoisons++;
			break;
		case 12:
			ExplosiveDeviceSet.SetActive(value: true);
			break;
		}
		UpdateMoney();
		Yandere.PauseScreen.PhotoGallery.Start();
		for (int i = 1; i < 26; i++)
		{
			if (Yandere.PauseScreen.PhotoGallery.SenpaiPhoto[i])
			{
				SenpaiShots++;
			}
		}
	}

	public void UpdateMoney()
	{
		MoneyLabel.text = "$" + Money.ToString("F2", NumberFormatInfo.InvariantInfo);
		TheMoneyLabelScript.UpdateTimer = 5f;
	}
}
