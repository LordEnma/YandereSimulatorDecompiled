using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	public class FoodMenu : MonoBehaviour
	{
		private static FoodMenu instance;

		[Reorderable]
		public Foods foodItems;

		public Transform menuSelector;

		public Transform menuSlotParent;

		public float selectorMoveSpeed = 3f;

		private List<Transform> menuSlots;

		private float menuSelectorTarget;

		private float startY;

		private float startZ;

		private float interpolator;

		private int activeIndex;

		public static FoodMenu Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<FoodMenu>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			SetMenuIcons();
			menuSelectorTarget = menuSlots[0].position.x;
			startY = menuSelector.position.y;
			startZ = menuSelector.position.z;
		}

		public void SetMenuIcons()
		{
			menuSlots = new List<Transform>();
			for (int i = 0; i < menuSlotParent.childCount; i++)
			{
				Transform child = menuSlotParent.GetChild(i);
				menuSlots.Add(child);
				if (foodItems.Count >= i)
				{
					child.GetChild(0).GetComponent<SpriteRenderer>().sprite = foodItems[i].largeSprite;
				}
			}
		}

		public void SetActive(int index)
		{
			menuSelectorTarget = menuSlots[index].position.x;
			interpolator = 0f;
			activeIndex = index;
		}

		public Food GetActiveFood()
		{
			Food food = Object.Instantiate(foodItems[activeIndex]);
			food.name = foodItems[activeIndex].name;
			return food;
		}

		public Food GetRandomFood()
		{
			int index = Random.Range(0, foodItems.Count);
			Food food = Object.Instantiate(foodItems[index]);
			food.name = foodItems[index].name;
			return food;
		}

		private void Update()
		{
			if (interpolator < 1f)
			{
				float x = Mathf.Lerp(menuSelector.position.x, menuSelectorTarget, interpolator);
				menuSelector.position = new Vector3(x, startY, startZ);
				interpolator += Time.deltaTime * selectorMoveSpeed;
			}
			else
			{
				menuSelector.transform.position = new Vector3(menuSelectorTarget, startY, startZ);
			}
			if (YandereController.rightButton)
			{
				IncrementSelection();
			}
			else if (YandereController.leftButton)
			{
				DecrementSelection();
			}
		}

		private void IncrementSelection()
		{
			SetActive((activeIndex + 1) % menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		private void DecrementSelection()
		{
			if (activeIndex == 0)
			{
				SetActive(menuSlots.Count - 1);
			}
			else
			{
				SetActive(activeIndex - 1);
			}
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}
	}
}
