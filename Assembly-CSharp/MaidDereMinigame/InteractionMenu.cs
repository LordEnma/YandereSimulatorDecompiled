// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.InteractionMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class InteractionMenu : MonoBehaviour
  {
    private static InteractionMenu instance;
    public GameObject interactObject;
    public GameObject backObject;
    public GameObject moveObject;
    public SpriteRenderer[] aButtons;
    public SpriteRenderer[] aButtonSprites;
    public SpriteRenderer[] backButtons;
    public SpriteRenderer[] moveButtons;

    public static InteractionMenu Instance
    {
      get
      {
        if ((Object) InteractionMenu.instance == (Object) null)
          InteractionMenu.instance = Object.FindObjectOfType<InteractionMenu>();
        return InteractionMenu.instance;
      }
    }

    private void Awake()
    {
      InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
      InteractionMenu.SetBButton(false);
      InteractionMenu.SetADButton(true);
    }

    public static void SetAButton(InteractionMenu.AButtonText text)
    {
      for (int index = 0; index < InteractionMenu.Instance.aButtonSprites.Length; ++index)
      {
        if ((InteractionMenu.AButtonText) index == text)
          InteractionMenu.Instance.aButtonSprites[index].gameObject.SetActive(true);
        else
          InteractionMenu.Instance.aButtonSprites[index].gameObject.SetActive(false);
      }
      foreach (Component aButton in InteractionMenu.Instance.aButtons)
        aButton.gameObject.SetActive(text != InteractionMenu.AButtonText.None);
    }

    public static void SetBButton(bool on)
    {
      foreach (Component backButton in InteractionMenu.Instance.backButtons)
        backButton.gameObject.SetActive(on);
    }

    public static void SetADButton(bool on)
    {
      foreach (Component moveButton in InteractionMenu.Instance.moveButtons)
        moveButton.gameObject.SetActive(on);
    }

    public enum AButtonText
    {
      ChoosePlate,
      GrabPlate,
      KitchenMenu,
      PlaceOrder,
      TakeOrder,
      TossPlate,
      GiveFood,
      None,
    }
  }
}
