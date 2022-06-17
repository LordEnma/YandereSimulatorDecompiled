// Decompiled with JetBrains decompiler
// Type: CreepyCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreepyCutsceneScript : MonoBehaviour
{
  public StreetShopInterfaceScript ShopInterface;
  public TypewriterEffect Typewriter;
  public GameObject Jukebox;
  public UILabel Label;
  public string[] Lines;
  public int ID;

  private void Update()
  {
    if (Input.GetButtonDown("A"))
    {
      if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
      {
        this.Typewriter.Finish();
      }
      else
      {
        ++this.ID;
        if (this.ID < this.Lines.Length)
        {
          this.Typewriter.ResetToBeginning();
          this.Label.text = "";
          this.Typewriter.mFullText = this.Lines[this.ID];
        }
        else
        {
          GameGlobals.MetBarber = true;
          this.gameObject.SetActive(false);
          this.Jukebox.SetActive(true);
          this.ShopInterface.TransitionToCreepyCutscene = false;
          this.ShopInterface.Salon.EightiesBarber();
          this.ShopInterface.TransitionTimer = 0.0f;
          this.ShopInterface.Jukebox.Play();
          this.ShopInterface.Shopkeeper.transform.localPosition = new Vector3((float) this.ShopInterface.ShopkeeperPosition, 0.0f, 0.0f);
          this.ShopInterface.Shopkeeper.transform.localScale = new Vector3(1.128f, 1.128f, 1.128f);
        }
      }
    }
    this.Label.alpha = 1f;
  }
}
