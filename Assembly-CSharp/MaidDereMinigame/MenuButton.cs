using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B3 RID: 1459
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024D7 RID: 9431 RVA: 0x00202413 File Offset: 0x00200613
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x00202421 File Offset: 0x00200621
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x00202434 File Offset: 0x00200634
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

		// Token: 0x04004D4C RID: 19788
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004D4D RID: 19789
		public SceneObject targetScene;

		// Token: 0x04004D4E RID: 19790
		[HideInInspector]
		public int index;

		// Token: 0x04004D4F RID: 19791
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004D50 RID: 19792
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006ED RID: 1773
		public enum ButtonType
		{
			// Token: 0x040052C0 RID: 21184
			Start,
			// Token: 0x040052C1 RID: 21185
			Controls,
			// Token: 0x040052C2 RID: 21186
			Credits,
			// Token: 0x040052C3 RID: 21187
			Exit,
			// Token: 0x040052C4 RID: 21188
			Easy,
			// Token: 0x040052C5 RID: 21189
			Medium,
			// Token: 0x040052C6 RID: 21190
			Hard
		}
	}
}
