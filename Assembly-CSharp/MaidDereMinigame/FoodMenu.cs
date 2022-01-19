using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600248C RID: 9356 RVA: 0x001FA1A0 File Offset: 0x001F83A0
		public static FoodMenu Instance
		{
			get
			{
				if (FoodMenu.instance == null)
				{
					FoodMenu.instance = UnityEngine.Object.FindObjectOfType<FoodMenu>();
				}
				return FoodMenu.instance;
			}
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001FA1C0 File Offset: 0x001F83C0
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x001FA21C File Offset: 0x001F841C
		public void SetMenuIcons()
		{
			this.menuSlots = new List<Transform>();
			for (int i = 0; i < this.menuSlotParent.childCount; i++)
			{
				Transform child = this.menuSlotParent.GetChild(i);
				this.menuSlots.Add(child);
				if (this.foodItems.Count >= i)
				{
					child.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.foodItems[i].largeSprite;
				}
			}
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x001FA293 File Offset: 0x001F8493
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x001FA2C3 File Offset: 0x001F84C3
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x001FA2F8 File Offset: 0x001F84F8
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001FA340 File Offset: 0x001F8540
		private void Update()
		{
			if (this.interpolator < 1f)
			{
				float x = Mathf.Lerp(this.menuSelector.position.x, this.menuSelectorTarget, this.interpolator);
				this.menuSelector.position = new Vector3(x, this.startY, this.startZ);
				this.interpolator += Time.deltaTime * this.selectorMoveSpeed;
			}
			else
			{
				this.menuSelector.transform.position = new Vector3(this.menuSelectorTarget, this.startY, this.startZ);
			}
			if (YandereController.rightButton)
			{
				this.IncrementSelection();
				return;
			}
			if (YandereController.leftButton)
			{
				this.DecrementSelection();
			}
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x001FA3F6 File Offset: 0x001F85F6
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x001FA419 File Offset: 0x001F8619
		private void DecrementSelection()
		{
			if (this.activeIndex == 0)
			{
				this.SetActive(this.menuSlots.Count - 1);
			}
			else
			{
				this.SetActive(this.activeIndex - 1);
			}
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x04004C4A RID: 19530
		private static FoodMenu instance;

		// Token: 0x04004C4B RID: 19531
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C4C RID: 19532
		public Transform menuSelector;

		// Token: 0x04004C4D RID: 19533
		public Transform menuSlotParent;

		// Token: 0x04004C4E RID: 19534
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C4F RID: 19535
		private List<Transform> menuSlots;

		// Token: 0x04004C50 RID: 19536
		private float menuSelectorTarget;

		// Token: 0x04004C51 RID: 19537
		private float startY;

		// Token: 0x04004C52 RID: 19538
		private float startZ;

		// Token: 0x04004C53 RID: 19539
		private float interpolator;

		// Token: 0x04004C54 RID: 19540
		private int activeIndex;
	}
}
