using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600248A RID: 9354 RVA: 0x001F94D0 File Offset: 0x001F76D0
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

		// Token: 0x0600248B RID: 9355 RVA: 0x001F94F0 File Offset: 0x001F76F0
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x001F954C File Offset: 0x001F774C
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

		// Token: 0x0600248D RID: 9357 RVA: 0x001F95C3 File Offset: 0x001F77C3
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x001F95F3 File Offset: 0x001F77F3
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x001F9628 File Offset: 0x001F7828
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x001F9670 File Offset: 0x001F7870
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

		// Token: 0x06002491 RID: 9361 RVA: 0x001F9726 File Offset: 0x001F7926
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001F9749 File Offset: 0x001F7949
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

		// Token: 0x04004C43 RID: 19523
		private static FoodMenu instance;

		// Token: 0x04004C44 RID: 19524
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C45 RID: 19525
		public Transform menuSelector;

		// Token: 0x04004C46 RID: 19526
		public Transform menuSlotParent;

		// Token: 0x04004C47 RID: 19527
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C48 RID: 19528
		private List<Transform> menuSlots;

		// Token: 0x04004C49 RID: 19529
		private float menuSelectorTarget;

		// Token: 0x04004C4A RID: 19530
		private float startY;

		// Token: 0x04004C4B RID: 19531
		private float startZ;

		// Token: 0x04004C4C RID: 19532
		private float interpolator;

		// Token: 0x04004C4D RID: 19533
		private int activeIndex;
	}
}
