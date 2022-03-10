using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200033F RID: 831
public class InventoryScript : MonoBehaviour
{
	// Token: 0x060018FA RID: 6394 RVA: 0x000FA52C File Offset: 0x000F872C
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

	// Token: 0x060018FB RID: 6395 RVA: 0x000FA650 File Offset: 0x000F8850
	public void UpdateMoney()
	{
		this.MoneyLabel.text = "$" + this.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x040026DB RID: 9947
	public SchemesScript Schemes;

	// Token: 0x040026DC RID: 9948
	public GameObject ExplosiveDeviceSet;

	// Token: 0x040026DD RID: 9949
	public bool FinishedHomework;

	// Token: 0x040026DE RID: 9950
	public bool ModifiedUniform;

	// Token: 0x040026DF RID: 9951
	public bool DirectionalMic;

	// Token: 0x040026E0 RID: 9952
	public bool DuplicateSheet;

	// Token: 0x040026E1 RID: 9953
	public bool AnswerSheet;

	// Token: 0x040026E2 RID: 9954
	public bool MaskingTape;

	// Token: 0x040026E3 RID: 9955
	public bool RivalPhone;

	// Token: 0x040026E4 RID: 9956
	public bool Narcotics;

	// Token: 0x040026E5 RID: 9957
	public bool LockPick;

	// Token: 0x040026E6 RID: 9958
	public bool Condoms;

	// Token: 0x040026E7 RID: 9959
	public bool Headset;

	// Token: 0x040026E8 RID: 9960
	public bool FakeID;

	// Token: 0x040026E9 RID: 9961
	public bool IDCard;

	// Token: 0x040026EA RID: 9962
	public bool String;

	// Token: 0x040026EB RID: 9963
	public bool Book;

	// Token: 0x040026EC RID: 9964
	public bool Cigs;

	// Token: 0x040026ED RID: 9965
	public bool Ring;

	// Token: 0x040026EE RID: 9966
	public bool Rose;

	// Token: 0x040026EF RID: 9967
	public bool Sake;

	// Token: 0x040026F0 RID: 9968
	public bool Soda;

	// Token: 0x040026F1 RID: 9969
	public bool Bra;

	// Token: 0x040026F2 RID: 9970
	public bool AmnesiaBomb;

	// Token: 0x040026F3 RID: 9971
	public bool SmokeBomb;

	// Token: 0x040026F4 RID: 9972
	public bool StinkBomb;

	// Token: 0x040026F5 RID: 9973
	public bool LethalPoison;

	// Token: 0x040026F6 RID: 9974
	public bool ChemicalPoison;

	// Token: 0x040026F7 RID: 9975
	public bool EmeticPoison;

	// Token: 0x040026F8 RID: 9976
	public bool RatPoison;

	// Token: 0x040026F9 RID: 9977
	public bool HeadachePoison;

	// Token: 0x040026FA RID: 9978
	public bool Tranquilizer;

	// Token: 0x040026FB RID: 9979
	public bool Sedative;

	// Token: 0x040026FC RID: 9980
	public bool CabinetKey;

	// Token: 0x040026FD RID: 9981
	public bool CaseKey;

	// Token: 0x040026FE RID: 9982
	public bool SafeKey;

	// Token: 0x040026FF RID: 9983
	public bool ShedKey;

	// Token: 0x04002700 RID: 9984
	public bool Ammonium;

	// Token: 0x04002701 RID: 9985
	public bool Balloons;

	// Token: 0x04002702 RID: 9986
	public bool Bandages;

	// Token: 0x04002703 RID: 9987
	public bool Glass;

	// Token: 0x04002704 RID: 9988
	public bool Hairpins;

	// Token: 0x04002705 RID: 9989
	public bool Nails;

	// Token: 0x04002706 RID: 9990
	public bool Paper;

	// Token: 0x04002707 RID: 9991
	public bool PaperClips;

	// Token: 0x04002708 RID: 9992
	public bool SilverFulminate;

	// Token: 0x04002709 RID: 9993
	public bool WoodenSticks;

	// Token: 0x0400270A RID: 9994
	public int MysteriousKeys;

	// Token: 0x0400270B RID: 9995
	public int LethalPoisons;

	// Token: 0x0400270C RID: 9996
	public int RivalPhoneID;

	// Token: 0x0400270D RID: 9997
	public int SenpaiShots;

	// Token: 0x0400270E RID: 9998
	public int PantyShots;

	// Token: 0x0400270F RID: 9999
	public float Money;

	// Token: 0x04002710 RID: 10000
	public bool[] ShrineCollectibles;

	// Token: 0x04002711 RID: 10001
	public UILabel MoneyLabel;

	// Token: 0x04002712 RID: 10002
	public bool ArrivedWithRatPoison;

	// Token: 0x04002713 RID: 10003
	public bool ArrivedWithSake;

	// Token: 0x04002714 RID: 10004
	public bool ArrivedWithCigs;

	// Token: 0x04002715 RID: 10005
	public bool ArrivedWithCondoms;

	// Token: 0x04002716 RID: 10006
	public bool ArrivedWithSedative;

	// Token: 0x04002717 RID: 10007
	public bool ArrivedWithPoison;
}
