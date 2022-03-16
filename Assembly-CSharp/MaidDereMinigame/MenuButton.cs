using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024AE RID: 9390 RVA: 0x001FE57B File Offset: 0x001FC77B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024AF RID: 9391 RVA: 0x001FE589 File Offset: 0x001FC789
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x001FE59C File Offset: 0x001FC79C
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

		// Token: 0x04004CE6 RID: 19686
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004CE7 RID: 19687
		public SceneObject targetScene;

		// Token: 0x04004CE8 RID: 19688
		[HideInInspector]
		public int index;

		// Token: 0x04004CE9 RID: 19689
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004CEA RID: 19690
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E6 RID: 1766
		public enum ButtonType
		{
			// Token: 0x0400525A RID: 21082
			Start,
			// Token: 0x0400525B RID: 21083
			Controls,
			// Token: 0x0400525C RID: 21084
			Credits,
			// Token: 0x0400525D RID: 21085
			Exit,
			// Token: 0x0400525E RID: 21086
			Easy,
			// Token: 0x0400525F RID: 21087
			Medium,
			// Token: 0x04005260 RID: 21088
			Hard
		}
	}
}
