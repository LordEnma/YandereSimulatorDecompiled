// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
  public class Menu : MonoBehaviour
  {
    public List<MenuButton> mainMenuButtons;
    [HideInInspector]
    public FlipBook flipBook;
    private MenuButton activeMenuButton;
    private bool prevVertical;
    private bool cancelInputs;
    private float PreviousFrameVertical;

    private void Start()
    {
      for (int index = 0; index < this.mainMenuButtons.Count; ++index)
      {
        int num = index;
        this.mainMenuButtons[index].Init();
        this.mainMenuButtons[index].index = num;
        this.mainMenuButtons[index].spriteRenderer.enabled = false;
        this.mainMenuButtons[index].menu = this;
      }
      this.flipBook = FlipBook.Instance;
      this.SetActiveMenuButton(0);
    }

    private void Update()
    {
      if (this.cancelInputs)
        return;
      if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("A")) && (Object) this.activeMenuButton != (Object) null)
        this.activeMenuButton.DoClick();
      float num1 = Input.GetAxisRaw("Vertical") * -1f;
      if (Input.GetKeyDown("up") || (double) Input.GetAxis("DpadY") > 0.5)
        num1 = -1f;
      else if (Input.GetKeyDown("down") || (double) Input.GetAxis("DpadY") < -0.5)
        num1 = 1f;
      if ((double) num1 != 0.0 && (double) this.PreviousFrameVertical == 0.0)
        SFXController.PlaySound(SFXController.Sounds.MenuSelect);
      this.PreviousFrameVertical = num1;
      if ((double) num1 != 0.0)
      {
        if (this.prevVertical)
          return;
        this.prevVertical = true;
        if ((double) num1 < 0.0)
        {
          int num2 = this.mainMenuButtons.IndexOf(this.activeMenuButton);
          if (num2 == 0)
            this.SetActiveMenuButton(this.mainMenuButtons.Count - 1);
          else
            this.SetActiveMenuButton(num2 - 1);
        }
        else
          this.SetActiveMenuButton((this.mainMenuButtons.IndexOf(this.activeMenuButton) + 1) % this.mainMenuButtons.Count);
      }
      else
        this.prevVertical = false;
    }

    public void SetActiveMenuButton(int index)
    {
      if ((Object) this.activeMenuButton != (Object) null)
        this.activeMenuButton.spriteRenderer.enabled = false;
      this.activeMenuButton = this.mainMenuButtons[index];
      this.activeMenuButton.spriteRenderer.enabled = true;
    }

    public void StopInputs()
    {
      this.cancelInputs = true;
      this.flipBook.StopInputs();
    }
  }
}
