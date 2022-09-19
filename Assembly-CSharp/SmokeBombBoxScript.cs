// Decompiled with JetBrains decompiler
// Type: SmokeBombBoxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SmokeBombBoxScript : MonoBehaviour
{
  public AlphabetScript Alphabet;
  public UITexture BombTexture;
  public PromptScript Prompt;
  public AudioSource MyAudio;
  public bool Cheated;
  public bool Amnesia;
  public bool Stink;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if (!this.Cheated)
    {
      ++this.Alphabet.Cheats;
      this.Alphabet.UpdateDifficultyLabel();
      this.Cheated = true;
    }
    if (!this.Amnesia)
    {
      this.Alphabet.RemainingBombs = 5;
      this.Alphabet.BombLabel.text = 5.ToString() ?? "";
    }
    else
    {
      this.Alphabet.RemainingBombs = 1;
      this.Alphabet.BombLabel.text = 1.ToString() ?? "";
    }
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Stink)
    {
      this.BombTexture.color = new Color(0.0f, 0.5f, 0.0f, 1f);
      this.Prompt.Yandere.Inventory.AmnesiaBomb = false;
      this.Prompt.Yandere.Inventory.SmokeBomb = false;
      this.Prompt.Yandere.Inventory.StinkBomb = true;
    }
    else if (this.Amnesia)
    {
      this.BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
      this.Prompt.Yandere.Inventory.AmnesiaBomb = true;
      this.Prompt.Yandere.Inventory.SmokeBomb = false;
      this.Prompt.Yandere.Inventory.StinkBomb = false;
    }
    else
    {
      this.BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.Prompt.Yandere.Inventory.AmnesiaBomb = false;
      this.Prompt.Yandere.Inventory.StinkBomb = false;
      this.Prompt.Yandere.Inventory.SmokeBomb = true;
    }
    this.MyAudio.Play();
  }
}
