// Decompiled with JetBrains decompiler
// Type: CollectibleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
  public PromptScript Prompt;
  public string Name = string.Empty;
  public int Type;
  public int ID;

  private void Start()
  {
    if ((this.CollectibleType == CollectibleType.HeadmasterTape && CollectibleGlobals.GetHeadmasterTapeCollected(this.ID) || this.CollectibleType == CollectibleType.BasementTape && CollectibleGlobals.GetBasementTapeCollected(this.ID) || this.CollectibleType == CollectibleType.Manga && CollectibleGlobals.GetMangaCollected(this.ID) || this.CollectibleType == CollectibleType.Tape && CollectibleGlobals.GetTapeCollected(this.ID) ? 1 : (this.CollectibleType != CollectibleType.Panty ? 0 : (CollectibleGlobals.GetPantyPurchased(11) ? 1 : 0))) != 0)
    {
      int collectibleType = (int) this.CollectibleType;
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      int collectibleType1 = (int) this.CollectibleType;
    }
    if (!GameGlobals.LoveSick && !MissionModeGlobals.MissionMode && (!GameGlobals.Eighties || this.CollectibleType != CollectibleType.Manga) && (!GameGlobals.Eighties || this.CollectibleType != CollectibleType.Tape))
      return;
    Object.Destroy((Object) this.gameObject);
  }

  public CollectibleType CollectibleType
  {
    get
    {
      if (this.Name == "HeadmasterTape")
        return CollectibleType.HeadmasterTape;
      if (this.Name == "BasementTape")
        return CollectibleType.BasementTape;
      if (this.Name == "Manga")
        return CollectibleType.Manga;
      if (this.Name == "Tape")
        return CollectibleType.Tape;
      if (this.Type == 5)
        return CollectibleType.Key;
      if (this.Type == 6)
        return CollectibleType.Panty;
      Debug.LogError((object) ("Unrecognized collectible \"" + this.Name + "\"."), (Object) this.gameObject);
      return CollectibleType.Tape;
    }
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if (this.CollectibleType == CollectibleType.HeadmasterTape)
      this.Prompt.Yandere.StudentManager.HeadmasterTapesCollected[this.ID] = true;
    else if (this.CollectibleType == CollectibleType.BasementTape)
      CollectibleGlobals.SetBasementTapeCollected(this.ID, true);
    else if (this.CollectibleType == CollectibleType.Manga)
      this.Prompt.Yandere.StudentManager.MangaCollected[this.ID] = true;
    else if (this.CollectibleType == CollectibleType.Tape)
      this.Prompt.Yandere.StudentManager.TapesCollected[this.ID] = true;
    else if (this.CollectibleType == CollectibleType.Key)
      ++this.Prompt.Yandere.Inventory.MysteriousKeys;
    else if (this.CollectibleType == CollectibleType.Panty)
    {
      Debug.Log((object) "Informing the StudentManager that the player picked up the fundoshi.");
      this.Prompt.Yandere.StudentManager.PantiesCollected[11] = true;
      this.CountPanties();
    }
    else
      Debug.LogError((object) ("Collectible \"" + this.Name + "\" not implemented."), (Object) this.gameObject);
    Object.Destroy((Object) this.gameObject);
  }

  private void CountPanties()
  {
    int num = 1;
    for (int giftID = 1; giftID < 11; ++giftID)
    {
      if (CollectibleGlobals.GetPantyPurchased(giftID))
        ++num;
    }
    if (num != 10)
      return;
    if (!GameGlobals.Debug)
      PlayerPrefs.SetInt("PantyQueen", 1);
    if (GameGlobals.Debug)
      return;
    PlayerPrefs.SetInt("a", 1);
  }
}
