using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200033F RID: 831
public class InventoryScript : MonoBehaviour
{
	// Token: 0x06001901 RID: 6401 RVA: 0x000FACE8 File Offset: 0x000F8EE8
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

	// Token: 0x06001902 RID: 6402 RVA: 0x000FAE0C File Offset: 0x000F900C
	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + this.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x040026F8 RID: 9976
	public SchemesScript Schemes;

	// Token: 0x040026F9 RID: 9977
	public GameObject ExplosiveDeviceSet;

	// Token: 0x040026FA RID: 9978
	public bool FinishedHomework;

	// Token: 0x040026FB RID: 9979
	public bool ModifiedUniform;

	// Token: 0x040026FC RID: 9980
	public bool DirectionalMic;

	// Token: 0x040026FD RID: 9981
	public bool DuplicateSheet;

	// Token: 0x040026FE RID: 9982
	public bool AnswerSheet;

	// Token: 0x040026FF RID: 9983
	public bool MaskingTape;

	// Token: 0x04002700 RID: 9984
	public bool RivalPhone;

	// Token: 0x04002701 RID: 9985
	public bool Narcotics;

	// Token: 0x04002702 RID: 9986
	public bool LockPick;

	// Token: 0x04002703 RID: 9987
	public bool Condoms;

	// Token: 0x04002704 RID: 9988
	public bool Headset;

	// Token: 0x04002705 RID: 9989
	public bool FakeID;

	// Token: 0x04002706 RID: 9990
	public bool IDCard;

	// Token: 0x04002707 RID: 9991
	public bool String;

	// Token: 0x04002708 RID: 9992
	public bool Book;

	// Token: 0x04002709 RID: 9993
	public bool Cigs;

	// Token: 0x0400270A RID: 9994
	public bool Ring;

	// Token: 0x0400270B RID: 9995
	public bool Rose;

	// Token: 0x0400270C RID: 9996
	public bool Sake;

	// Token: 0x0400270D RID: 9997
	public bool Soda;

	// Token: 0x0400270E RID: 9998
	public bool Bra;

	// Token: 0x0400270F RID: 9999
	public bool AmnesiaBomb;

	// Token: 0x04002710 RID: 10000
	public bool SmokeBomb;

	// Token: 0x04002711 RID: 10001
	public bool StinkBomb;

	// Token: 0x04002712 RID: 10002
	public bool LethalPoison;

	// Token: 0x04002713 RID: 10003
	public bool ChemicalPoison;

	// Token: 0x04002714 RID: 10004
	public bool EmeticPoison;

	// Token: 0x04002715 RID: 10005
	public bool RatPoison;

	// Token: 0x04002716 RID: 10006
	public bool HeadachePoison;

	// Token: 0x04002717 RID: 10007
	public bool Tranquilizer;

	// Token: 0x04002718 RID: 10008
	public bool Sedative;

	// Token: 0x04002719 RID: 10009
	public bool CabinetKey;

	// Token: 0x0400271A RID: 10010
	public bool CaseKey;

	// Token: 0x0400271B RID: 10011
	public bool SafeKey;

	// Token: 0x0400271C RID: 10012
	public bool ShedKey;

	// Token: 0x0400271D RID: 10013
	public bool Ammonium;

	// Token: 0x0400271E RID: 10014
	public bool Balloons;

	// Token: 0x0400271F RID: 10015
	public bool Bandages;

	// Token: 0x04002720 RID: 10016
	public bool Glass;

	// Token: 0x04002721 RID: 10017
	public bool Hairpins;

	// Token: 0x04002722 RID: 10018
	public bool Nails;

	// Token: 0x04002723 RID: 10019
	public bool Paper;

	// Token: 0x04002724 RID: 10020
	public bool PaperClips;

	// Token: 0x04002725 RID: 10021
	public bool SilverFulminate;

	// Token: 0x04002726 RID: 10022
	public bool WoodenSticks;

	// Token: 0x04002727 RID: 10023
	public int MysteriousKeys;

	// Token: 0x04002728 RID: 10024
	public int LethalPoisons;

	// Token: 0x04002729 RID: 10025
	public int RivalPhoneID;

	// Token: 0x0400272A RID: 10026
	public int SenpaiShots;

	// Token: 0x0400272B RID: 10027
	public int PantyShots;

	// Token: 0x0400272C RID: 10028
	public float Money;

	// Token: 0x0400272D RID: 10029
	public bool[] ShrineCollectibles;

	// Token: 0x0400272E RID: 10030
	public UILabel MoneyLabel;

	// Token: 0x0400272F RID: 10031
	public bool ArrivedWithRatPoison;

	// Token: 0x04002730 RID: 10032
	public bool ArrivedWithSake;

	// Token: 0x04002731 RID: 10033
	public bool ArrivedWithCigs;

	// Token: 0x04002732 RID: 10034
	public bool ArrivedWithCondoms;

	// Token: 0x04002733 RID: 10035
	public bool ArrivedWithSedative;

	// Token: 0x04002734 RID: 10036
	public bool ArrivedWithPoison;
}
