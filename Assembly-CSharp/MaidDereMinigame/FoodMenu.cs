using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024A5 RID: 9381 RVA: 0x001FBFF0 File Offset: 0x001FA1F0
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

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FC010 File Offset: 0x001FA210
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FC06C File Offset: 0x001FA26C
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

		// Token: 0x060024A8 RID: 9384 RVA: 0x001FC0E3 File Offset: 0x001FA2E3
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x001FC113 File Offset: 0x001FA313
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x001FC148 File Offset: 0x001FA348
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x060024AB RID: 9387 RVA: 0x001FC190 File Offset: 0x001FA390
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

		// Token: 0x060024AC RID: 9388 RVA: 0x001FC246 File Offset: 0x001FA446
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x001FC269 File Offset: 0x001FA469
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

		// Token: 0x04004C77 RID: 19575
		private static FoodMenu instance;

		// Token: 0x04004C78 RID: 19576
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C79 RID: 19577
		public Transform menuSelector;

		// Token: 0x04004C7A RID: 19578
		public Transform menuSlotParent;

		// Token: 0x04004C7B RID: 19579
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C7C RID: 19580
		private List<Transform> menuSlots;

		// Token: 0x04004C7D RID: 19581
		private float menuSelectorTarget;

		// Token: 0x04004C7E RID: 19582
		private float startY;

		// Token: 0x04004C7F RID: 19583
		private float startZ;

		// Token: 0x04004C80 RID: 19584
		private float interpolator;

		// Token: 0x04004C81 RID: 19585
		private int activeIndex;
	}
}
