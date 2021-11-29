using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A0 RID: 1440
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002456 RID: 9302 RVA: 0x001F6A57 File Offset: 0x001F4C57
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x001F6A65 File Offset: 0x001F4C65
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x001F6A78 File Offset: 0x001F4C78
		public void DoClick()
		{
			switch (this.buttonType)
			{
			case MenuButton.ButtonType.Start:
				this.menu.flipBook.FlipToPage(2);
				return;
			case MenuButton.ButtonType.Controls:
				this.menu.flipBook.FlipToPage(3);
				return;
			case MenuButton.ButtonType.Credits:
				this.menu.flipBook.FlipToPage(4);
				return;
			case MenuButton.ButtonType.Exit:
				this.menu.StopInputs();
				GameController.GoToExitScene(true);
				return;
			case MenuButton.ButtonType.Easy:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.easyVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			case MenuButton.ButtonType.Medium:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.mediumVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			case MenuButton.ButtonType.Hard:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.hardVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			default:
				return;
			}
		}

		// Token: 0x04004BDA RID: 19418
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004BDB RID: 19419
		public SceneObject targetScene;

		// Token: 0x04004BDC RID: 19420
		[HideInInspector]
		public int index;

		// Token: 0x04004BDD RID: 19421
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004BDE RID: 19422
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006DD RID: 1757
		public enum ButtonType
		{
			// Token: 0x0400516B RID: 20843
			Start,
			// Token: 0x0400516C RID: 20844
			Controls,
			// Token: 0x0400516D RID: 20845
			Credits,
			// Token: 0x0400516E RID: 20846
			Exit,
			// Token: 0x0400516F RID: 20847
			Easy,
			// Token: 0x04005170 RID: 20848
			Medium,
			// Token: 0x04005171 RID: 20849
			Hard
		}
	}
}
