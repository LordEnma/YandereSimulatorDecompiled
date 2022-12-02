using UnityEngine;

namespace MaidDereMinigame
{
	public class InteractionMenu : MonoBehaviour
	{
		public enum AButtonText
		{
			ChoosePlate = 0,
			GrabPlate = 1,
			KitchenMenu = 2,
			PlaceOrder = 3,
			TakeOrder = 4,
			TossPlate = 5,
			GiveFood = 6,
			None = 7
		}

		private static InteractionMenu instance;

		public GameObject interactObject;

		public GameObject backObject;

		public GameObject moveObject;

		public SpriteRenderer[] aButtons;

		public SpriteRenderer[] aButtonSprites;

		public SpriteRenderer[] backButtons;

		public SpriteRenderer[] moveButtons;

		public static InteractionMenu Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<InteractionMenu>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			SetAButton(AButtonText.None);
			SetBButton(false);
			SetADButton(true);
		}

		public static void SetAButton(AButtonText text)
		{
			for (int i = 0; i < Instance.aButtonSprites.Length; i++)
			{
				if (i == (int)text)
				{
					Instance.aButtonSprites[i].gameObject.SetActive(true);
				}
				else
				{
					Instance.aButtonSprites[i].gameObject.SetActive(false);
				}
			}
			SpriteRenderer[] array = Instance.aButtons;
			for (int j = 0; j < array.Length; j++)
			{
				array[j].gameObject.SetActive(text != AButtonText.None);
			}
		}

		public static void SetBButton(bool on)
		{
			SpriteRenderer[] array = Instance.backButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}

		public static void SetADButton(bool on)
		{
			SpriteRenderer[] array = Instance.moveButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(on);
			}
		}
	}
}
