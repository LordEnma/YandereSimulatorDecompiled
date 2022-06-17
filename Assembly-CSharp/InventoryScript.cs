// Decompiled with JetBrains decompiler
// Type: InventoryScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
  public SchemesScript Schemes;
  public GameObject ExplosiveDeviceSet;
  public bool FinishedHomework;
  public bool ModifiedUniform;
  public bool DirectionalMic;
  public bool DuplicateSheet;
  public bool AnswerSheet;
  public bool MaskingTape;
  public bool RivalPhone;
  public bool Narcotics;
  public bool LockPick;
  public bool Condoms;
  public bool Headset;
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
  public float Money;
  public bool[] ShrineCollectibles;
  public UILabel MoneyLabel;
  public bool ArrivedWithRatPoison;
  public bool ArrivedWithSake;
  public bool ArrivedWithCigs;
  public bool ArrivedWithCondoms;
  public bool ArrivedWithSedative;
  public bool ArrivedWithPoison;

  private void Start()
  {
    this.DirectionalMic = PlayerGlobals.DirectionalMic;
    this.Headset = PlayerGlobals.Headset;
    this.SenpaiShots = PlayerGlobals.SenpaiShots;
    this.PantyShots = PlayerGlobals.PantyShots;
    this.Money = PlayerGlobals.Money;
    int bringingItem = PlayerGlobals.BringingItem;
    if (bringingItem > 0)
      Debug.Log((object) ("The player brought an item. ID is: " + bringingItem.ToString()));
    switch (bringingItem)
    {
      case 4:
        this.ArrivedWithRatPoison = true;
        ++this.EmeticPoisons;
        break;
      case 5:
        this.ArrivedWithSake = true;
        this.Sake = true;
        break;
      case 6:
        this.ArrivedWithCigs = true;
        this.Cigs = true;
        break;
      case 7:
        this.ArrivedWithCondoms = true;
        this.Condoms = true;
        break;
      case 8:
        this.LockPick = true;
        break;
      case 9:
        this.ArrivedWithSedative = true;
        ++this.SedativePoisons;
        break;
      case 10:
        this.Narcotics = true;
        break;
      case 11:
        this.ArrivedWithPoison = true;
        ++this.LethalPoisons;
        break;
      case 12:
        this.ExplosiveDeviceSet.SetActive(true);
        break;
    }
    this.UpdateMoney();
  }

  public void UpdateMoney() => this.MoneyLabel.text = "$" + this.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);
}
