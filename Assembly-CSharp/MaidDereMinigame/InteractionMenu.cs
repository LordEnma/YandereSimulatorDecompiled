using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class InteractionMenu : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06002489 RID: 9353 RVA: 0x001F8DF0 File Offset: 0x001F6FF0
		public static InteractionMenu Instance
		{
			get
			{
				if (InteractionMenu.instance == null)
				{
					InteractionMenu.instance = UnityEngine.Object.FindObjectOfType<InteractionMenu>();
				}
				return InteractionMenu.instance;
			}
		}

		// Token: 0x0600248A RID: 9354 RVA: 0x001F8E0E File Offset: 0x001F700E
		private void Awake()
		{
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			InteractionMenu.SetBButton(false);
			InteractionMenu.SetADButton(true);
		}

		// Token: 0x0600248B RID: 9355 RVA: 0x001F8E24 File Offset: 0x001F7024
		public static void SetAButton(InteractionMenu.AButtonText text)
		{
			for (int i = 0; i < InteractionMenu.Instance.aButtonSprites.Length; i++)
			{
				if (i == (int)text)
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(true);
				}
				else
				{
					InteractionMenu.Instance.aButtonSprites[i].gameObject.SetActive(false);
				}
			}
			SpriteRenderer[] array = InteractionMenu.Instance.aButtons;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].gameObject.SetActive(text != InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x001F8EAC File Offset: 0x001F70AC
		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001F8EE0 File Offset: 0x001F70E0
		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = InteractionMenu.Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		// Token: 0x04004C3A RID: 19514
		private static InteractionMenu instance;

		// Token: 0x04004C3B RID: 19515
		public GameObject interactObject;

		// Token: 0x04004C3C RID: 19516
		public GameObject backObject;

		// Token: 0x04004C3D RID: 19517
		public GameObject moveObject;

		// Token: 0x04004C3E RID: 19518
		public SpriteRenderer[] aButtons;

		// Token: 0x04004C3F RID: 19519
		public SpriteRenderer[] aButtonSprites;

		// Token: 0x04004C40 RID: 19520
		public SpriteRenderer[] backButtons;

		// Token: 0x04004C41 RID: 19521
		public SpriteRenderer[] moveButtons;

		// Token: 0x020006E3 RID: 1763
		public enum AButtonText
		{
			// Token: 0x040051CE RID: 20942
			ChoosePlate,
			// Token: 0x040051CF RID: 20943
			GrabPlate,
			// Token: 0x040051D0 RID: 20944
			KitchenMenu,
			// Token: 0x040051D1 RID: 20945
			PlaceOrder,
			// Token: 0x040051D2 RID: 20946
			TakeOrder,
			// Token: 0x040051D3 RID: 20947
			TossPlate,
			// Token: 0x040051D4 RID: 20948
			GiveFood,
			// Token: 0x040051D5 RID: 20949
			None
		}
	}
}
