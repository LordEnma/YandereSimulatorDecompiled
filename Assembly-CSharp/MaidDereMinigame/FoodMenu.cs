using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600246B RID: 9323 RVA: 0x001F6E0C File Offset: 0x001F500C
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

		// Token: 0x0600246C RID: 9324 RVA: 0x001F6E2C File Offset: 0x001F502C
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x001F6E88 File Offset: 0x001F5088
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

		// Token: 0x0600246E RID: 9326 RVA: 0x001F6EFF File Offset: 0x001F50FF
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x001F6F2F File Offset: 0x001F512F
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x06002470 RID: 9328 RVA: 0x001F6F64 File Offset: 0x001F5164
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x001F6FAC File Offset: 0x001F51AC
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

		// Token: 0x06002472 RID: 9330 RVA: 0x001F7062 File Offset: 0x001F5262
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x06002473 RID: 9331 RVA: 0x001F7085 File Offset: 0x001F5285
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

		// Token: 0x04004BE7 RID: 19431
		private static FoodMenu instance;

		// Token: 0x04004BE8 RID: 19432
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004BE9 RID: 19433
		public Transform menuSelector;

		// Token: 0x04004BEA RID: 19434
		public Transform menuSlotParent;

		// Token: 0x04004BEB RID: 19435
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004BEC RID: 19436
		private List<Transform> menuSlots;

		// Token: 0x04004BED RID: 19437
		private float menuSelectorTarget;

		// Token: 0x04004BEE RID: 19438
		private float startY;

		// Token: 0x04004BEF RID: 19439
		private float startZ;

		// Token: 0x04004BF0 RID: 19440
		private float interpolator;

		// Token: 0x04004BF1 RID: 19441
		private int activeIndex;
	}
}
