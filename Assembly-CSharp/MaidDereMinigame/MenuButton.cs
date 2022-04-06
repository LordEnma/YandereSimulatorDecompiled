using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B2 RID: 1458
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024C6 RID: 9414 RVA: 0x0020031B File Offset: 0x001FE51B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x00200329 File Offset: 0x001FE529
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x0020033C File Offset: 0x001FE53C
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

		// Token: 0x04004D1C RID: 19740
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004D1D RID: 19741
		public SceneObject targetScene;

		// Token: 0x04004D1E RID: 19742
		[HideInInspector]
		public int index;

		// Token: 0x04004D1F RID: 19743
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004D20 RID: 19744
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006EC RID: 1772
		public enum ButtonType
		{
			// Token: 0x04005290 RID: 21136
			Start,
			// Token: 0x04005291 RID: 21137
			Controls,
			// Token: 0x04005292 RID: 21138
			Credits,
			// Token: 0x04005293 RID: 21139
			Exit,
			// Token: 0x04005294 RID: 21140
			Easy,
			// Token: 0x04005295 RID: 21141
			Medium,
			// Token: 0x04005296 RID: 21142
			Hard
		}
	}
}
