// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.MenuButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (SpriteRenderer))]
  public class MenuButton : MonoBehaviour
  {
    public MenuButton.ButtonType buttonType;
    public SceneObject targetScene;
    [HideInInspector]
    public int index;
    [HideInInspector]
    public Menu menu;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    public void Init() => this.spriteRenderer = this.GetComponent<SpriteRenderer>();

    private void OnMouseEnter() => this.menu.SetActiveMenuButton(this.index);

    public void DoClick()
    {
      switch (this.buttonType)
      {
        case MenuButton.ButtonType.Start:
          this.menu.flipBook.FlipToPage(2);
          break;
        case MenuButton.ButtonType.Controls:
          this.menu.flipBook.FlipToPage(3);
          break;
        case MenuButton.ButtonType.Credits:
          this.menu.flipBook.FlipToPage(4);
          break;
        case MenuButton.ButtonType.Exit:
          this.menu.StopInputs();
          GameController.GoToExitScene();
          break;
        case MenuButton.ButtonType.Easy:
          this.menu.StopInputs();
          GameController.Instance.activeDifficultyVariables = GameController.Instance.easyVariables;
          GameController.Instance.LoadScene(this.targetScene);
          SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
          break;
        case MenuButton.ButtonType.Medium:
          this.menu.StopInputs();
          GameController.Instance.activeDifficultyVariables = GameController.Instance.mediumVariables;
          GameController.Instance.LoadScene(this.targetScene);
          SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
          break;
        case MenuButton.ButtonType.Hard:
          this.menu.StopInputs();
          GameController.Instance.activeDifficultyVariables = GameController.Instance.hardVariables;
          GameController.Instance.LoadScene(this.targetScene);
          SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
          break;
      }
    }

    public enum ButtonType
    {
      Start,
      Controls,
      Credits,
      Exit,
      Easy,
      Medium,
      Hard,
    }
  }
}
