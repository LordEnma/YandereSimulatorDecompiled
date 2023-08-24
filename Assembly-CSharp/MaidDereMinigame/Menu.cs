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
			for (int i = 0; i < mainMenuButtons.Count; i++)
			{
				int index = i;
				mainMenuButtons[i].Init();
				mainMenuButtons[i].index = index;
				mainMenuButtons[i].spriteRenderer.enabled = false;
				mainMenuButtons[i].menu = this;
			}
			flipBook = FlipBook.Instance;
			SetActiveMenuButton(0);
		}

		private void Update()
		{
			if (cancelInputs)
			{
				return;
			}
			if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("A")) && activeMenuButton != null)
			{
				activeMenuButton.DoClick();
			}
			float num = Input.GetAxisRaw("Vertical") * -1f;
			if (Input.GetKeyDown("up") || Input.GetAxis(InputNames.Xbox_DpadY) > 0.5f)
			{
				num = -1f;
			}
			else if (Input.GetKeyDown("down") || Input.GetAxis(InputNames.Xbox_DpadY) < -0.5f)
			{
				num = 1f;
			}
			if (num != 0f && PreviousFrameVertical == 0f)
			{
				SFXController.PlaySound(SFXController.Sounds.MenuSelect);
			}
			PreviousFrameVertical = num;
			if (num != 0f)
			{
				if (prevVertical)
				{
					return;
				}
				prevVertical = true;
				if (num < 0f)
				{
					int num2 = mainMenuButtons.IndexOf(activeMenuButton);
					if (num2 == 0)
					{
						SetActiveMenuButton(mainMenuButtons.Count - 1);
					}
					else
					{
						SetActiveMenuButton(num2 - 1);
					}
				}
				else
				{
					int num3 = mainMenuButtons.IndexOf(activeMenuButton);
					SetActiveMenuButton((num3 + 1) % mainMenuButtons.Count);
				}
			}
			else
			{
				prevVertical = false;
			}
		}

		public void SetActiveMenuButton(int index)
		{
			if (activeMenuButton != null)
			{
				activeMenuButton.spriteRenderer.enabled = false;
			}
			activeMenuButton = mainMenuButtons[index];
			activeMenuButton.spriteRenderer.enabled = true;
		}

		public void StopInputs()
		{
			cancelInputs = true;
			flipBook.StopInputs();
		}
	}
}
