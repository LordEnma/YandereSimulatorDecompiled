using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A7 RID: 1447
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002490 RID: 9360 RVA: 0x001FBC3B File Offset: 0x001F9E3B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x001FBC49 File Offset: 0x001F9E49
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001FBC5C File Offset: 0x001F9E5C
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

		// Token: 0x04004C6A RID: 19562
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C6B RID: 19563
		public SceneObject targetScene;

		// Token: 0x04004C6C RID: 19564
		[HideInInspector]
		public int index;

		// Token: 0x04004C6D RID: 19565
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C6E RID: 19566
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E1 RID: 1761
		public enum ButtonType
		{
			// Token: 0x040051DE RID: 20958
			Start,
			// Token: 0x040051DF RID: 20959
			Controls,
			// Token: 0x040051E0 RID: 20960
			Credits,
			// Token: 0x040051E1 RID: 20961
			Exit,
			// Token: 0x040051E2 RID: 20962
			Easy,
			// Token: 0x040051E3 RID: 20963
			Medium,
			// Token: 0x040051E4 RID: 20964
			Hard
		}
	}
}
