using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B4 RID: 1460
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024E1 RID: 9441 RVA: 0x00203A63 File Offset: 0x00201C63
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024E2 RID: 9442 RVA: 0x00203A71 File Offset: 0x00201C71
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024E3 RID: 9443 RVA: 0x00203A84 File Offset: 0x00201C84
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

		// Token: 0x04004D73 RID: 19827
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004D74 RID: 19828
		public SceneObject targetScene;

		// Token: 0x04004D75 RID: 19829
		[HideInInspector]
		public int index;

		// Token: 0x04004D76 RID: 19830
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004D77 RID: 19831
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006EE RID: 1774
		public enum ButtonType
		{
			// Token: 0x040052E7 RID: 21223
			Start,
			// Token: 0x040052E8 RID: 21224
			Controls,
			// Token: 0x040052E9 RID: 21225
			Credits,
			// Token: 0x040052EA RID: 21226
			Exit,
			// Token: 0x040052EB RID: 21227
			Easy,
			// Token: 0x040052EC RID: 21228
			Medium,
			// Token: 0x040052ED RID: 21229
			Hard
		}
	}
}
