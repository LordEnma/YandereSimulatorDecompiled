using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000341 RID: 833
public class InventoryScript : MonoBehaviour
{
	// Token: 0x0600190D RID: 6413 RVA: 0x000FB474 File Offset: 0x000F9674
	private void Start()
	{
		this.DirectionalMic = PlayerGlobals.DirectionalMic;
		this.Headset = PlayerGlobals.Headset;
		this.SenpaiShots = PlayerGlobals.SenpaiShots;
		this.PantyShots = PlayerGlobals.PantyShots;
		this.Money = PlayerGlobals.Money;
		int bringingItem = PlayerGlobals.BringingItem;
		if (bringingItem > 0)
		{
			Debug.Log("The player brought an item. ID is: " + bringingItem.ToString());
		}
		if (bringingItem == 4)
		{
			this.ArrivedWithRatPoison = true;
			this.RatPoison = true;
		}
		else if (bringingItem == 5)
		{
			this.ArrivedWithSake = true;
			this.Sake = true;
		}
		else if (bringingItem == 6)
		{
			this.ArrivedWithCigs = true;
			this.Cigs = true;
		}
		else if (bringingItem == 7)
		{
			this.ArrivedWithCondoms = true;
			this.Condoms = true;
		}
		else if (bringingItem == 8)
		{
			this.LockPick = true;
		}
		else if (bringingItem == 9)
		{
			this.ArrivedWithSedative = true;
			this.Sedative = true;
		}
		else if (bringingItem == 10)
		{
			this.Narcotics = true;
		}
		else if (bringingItem == 11)
		{
			this.ArrivedWithPoison = true;
			this.LethalPoison = true;
			this.LethalPoisons++;
		}
		else if (bringingItem == 12)
		{
			this.ExplosiveDeviceSet.SetActive(true);
		}
		this.UpdateMoney();
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x000FB598 File Offset: 0x000F9798
	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + this.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0400270E RID: 9998
	public SchemesScript Schemes;

	// Token: 0x0400270F RID: 9999
	public GameObject ExplosiveDeviceSet;

	// Token: 0x04002710 RID: 10000
	public bool FinishedHomework;

	// Token: 0x04002711 RID: 10001
	public bool ModifiedUniform;

	// Token: 0x04002712 RID: 10002
	public bool DirectionalMic;

	// Token: 0x04002713 RID: 10003
	public bool DuplicateSheet;

	// Token: 0x04002714 RID: 10004
	public bool AnswerSheet;

	// Token: 0x04002715 RID: 10005
	public bool MaskingTape;

	// Token: 0x04002716 RID: 10006
	public bool RivalPhone;

	// Token: 0x04002717 RID: 10007
	public bool Narcotics;

	// Token: 0x04002718 RID: 10008
	public bool LockPick;

	// Token: 0x04002719 RID: 10009
	public bool Condoms;

	// Token: 0x0400271A RID: 10010
	public bool Headset;

	// Token: 0x0400271B RID: 10011
	public bool FakeID;

	// Token: 0x0400271C RID: 10012
	public bool IDCard;

	// Token: 0x0400271D RID: 10013
	public bool String;

	// Token: 0x0400271E RID: 10014
	public bool Book;

	// Token: 0x0400271F RID: 10015
	public bool Cigs;

	// Token: 0x04002720 RID: 10016
	public bool Ring;

	// Token: 0x04002721 RID: 10017
	public bool Rose;

	// Token: 0x04002722 RID: 10018
	public bool Sake;

	// Token: 0x04002723 RID: 10019
	public bool Soda;

	// Token: 0x04002724 RID: 10020
	public bool Bra;

	// Token: 0x04002725 RID: 10021
	public bool AmnesiaBomb;

	// Token: 0x04002726 RID: 10022
	public bool SmokeBomb;

	// Token: 0x04002727 RID: 10023
	public bool StinkBomb;

	// Token: 0x04002728 RID: 10024
	public bool LethalPoison;

	// Token: 0x04002729 RID: 10025
	public bool ChemicalPoison;

	// Token: 0x0400272A RID: 10026
	public bool EmeticPoison;

	// Token: 0x0400272B RID: 10027
	public bool RatPoison;

	// Token: 0x0400272C RID: 10028
	public bool HeadachePoison;

	// Token: 0x0400272D RID: 10029
	public bool Tranquilizer;

	// Token: 0x0400272E RID: 10030
	public bool Sedative;

	// Token: 0x0400272F RID: 10031
	public bool CabinetKey;

	// Token: 0x04002730 RID: 10032
	public bool CaseKey;

	// Token: 0x04002731 RID: 10033
	public bool SafeKey;

	// Token: 0x04002732 RID: 10034
	public bool ShedKey;

	// Token: 0x04002733 RID: 10035
	public bool Ammonium;

	// Token: 0x04002734 RID: 10036
	public bool Balloons;

	// Token: 0x04002735 RID: 10037
	public bool Bandages;

	// Token: 0x04002736 RID: 10038
	public bool Glass;

	// Token: 0x04002737 RID: 10039
	public bool Hairpins;

	// Token: 0x04002738 RID: 10040
	public bool Nails;

	// Token: 0x04002739 RID: 10041
	public bool Paper;

	// Token: 0x0400273A RID: 10042
	public bool PaperClips;

	// Token: 0x0400273B RID: 10043
	public bool SilverFulminate;

	// Token: 0x0400273C RID: 10044
	public bool WoodenSticks;

	// Token: 0x0400273D RID: 10045
	public int MysteriousKeys;

	// Token: 0x0400273E RID: 10046
	public int LethalPoisons;

	// Token: 0x0400273F RID: 10047
	public int RivalPhoneID;

	// Token: 0x04002740 RID: 10048
	public int SenpaiShots;

	// Token: 0x04002741 RID: 10049
	public int PantyShots;

	// Token: 0x04002742 RID: 10050
	public float Money;

	// Token: 0x04002743 RID: 10051
	public bool[] ShrineCollectibles;

	// Token: 0x04002744 RID: 10052
	public UILabel MoneyLabel;

	// Token: 0x04002745 RID: 10053
	public bool ArrivedWithRatPoison;

	// Token: 0x04002746 RID: 10054
	public bool ArrivedWithSake;

	// Token: 0x04002747 RID: 10055
	public bool ArrivedWithCigs;

	// Token: 0x04002748 RID: 10056
	public bool ArrivedWithCondoms;

	// Token: 0x04002749 RID: 10057
	public bool ArrivedWithSedative;

	// Token: 0x0400274A RID: 10058
	public bool ArrivedWithPoison;
}
