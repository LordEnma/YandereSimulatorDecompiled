using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public class ServingCounter : MonoBehaviour
	{
		// Token: 0x06002404 RID: 9220 RVA: 0x001F5608 File Offset: 0x001F3808
		private void Awake()
		{
			this.plates = new List<FoodInstance>();
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionIndicatorStartingPos = this.interactionIndicator.transform.position;
			this.platePositions = new List<Transform>();
			this.kitchenModeHide.gameObject.SetActive(false);
			FoodMenu.Instance.gameObject.SetActive(false);
			for (int i = 0; i < this.maxPlates; i++)
			{
				Transform transform = new GameObject("Position " + i.ToString()).transform;
				transform.parent = base.transform;
				transform.position = new Vector3(this.xPosStart - this.plateSeparation * (float)i, this.yPos, 0f);
				this.platePositions.Add(transform);
			}
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x001F56DE File Offset: 0x001F38DE
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x001F5700 File Offset: 0x001F3900
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x001F5724 File Offset: 0x001F3924
		private void Update()
		{
			switch (this.state)
			{
			case ServingCounter.KitchenState.None:
				if (this.isPaused)
				{
					return;
				}
				if (this.interactionRange && Input.GetButtonDown("A"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					this.selectedIndex = ((this.plates.Count == 0) ? 2 : 0);
					this.kitchenModeHide.gameObject.SetActive(true);
					this.SetMask(this.selectedIndex);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					if (this.plates.Count == 0 && YandereController.Instance.heldItem == null)
					{
						this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						this.state = ServingCounter.KitchenState.Chef;
						FoodMenu.Instance.gameObject.SetActive(true);
					}
					GameController.SetPause(true);
					InteractionMenu.SetBButton(true);
					return;
				}
				break;
			case ServingCounter.KitchenState.SelectingInteraction:
				switch (this.selectedIndex)
				{
				case 0:
					this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.ChoosePlate);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Plates;
						this.selectedIndex = 0;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.GrabPlate);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 1:
					this.interactionIndicator.transform.position = this.trash.transform.position + Vector3.up * 0.5f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.TossPlate);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Trash;
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				case 2:
					this.interactionIndicator.transform.position = Chef.Instance.transform.position + Vector3.up * 0.8f;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
					this.SetMask(this.selectedIndex);
					if (Input.GetButtonDown("A"))
					{
						this.state = ServingCounter.KitchenState.Chef;
						InteractionMenu.SetAButton(InteractionMenu.AButtonText.PlaceOrder);
						FoodMenu.Instance.gameObject.SetActive(true);
						SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					}
					break;
				}
				if (Input.GetButtonDown("B"))
				{
					InteractionMenu.SetBButton(false);
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
					this.state = ServingCounter.KitchenState.None;
					GameController.SetPause(false);
					this.kitchenModeHide.gameObject.SetActive(false);
					this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (YandereController.rightButton)
				{
					this.selectedIndex = (this.selectedIndex + 1) % 3;
					if (this.selectedIndex == 0 && this.plates.Count == 0)
					{
						this.selectedIndex = (this.selectedIndex + 1) % 3;
					}
					if (this.selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						this.selectedIndex = (this.selectedIndex + 1) % 3;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (YandereController.leftButton)
				{
					if (this.selectedIndex == 0)
					{
						this.selectedIndex = 2;
					}
					else
					{
						this.selectedIndex--;
					}
					if (this.selectedIndex == 1 && YandereController.Instance.heldItem == null)
					{
						this.selectedIndex--;
					}
					if (this.selectedIndex == 0 && this.plates.Count == 0)
					{
						this.selectedIndex = 2;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
					return;
				}
				break;
			case ServingCounter.KitchenState.Plates:
				this.interactionIndicator.gameObject.SetActive(true);
				this.interactionIndicator.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.25f;
				this.SetMask(3);
				this.plateMask.transform.position = this.plates[this.selectedIndex].transform.position + Vector3.up * 0.05f;
				if (YandereController.rightButton)
				{
					if (this.selectedIndex == 0)
					{
						this.selectedIndex = this.plates.Count - 1;
					}
					else
					{
						this.selectedIndex--;
					}
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				else if (YandereController.leftButton)
				{
					this.selectedIndex = (this.selectedIndex + 1) % this.plates.Count;
					SFXController.PlaySound(SFXController.Sounds.MenuSelect);
				}
				if (Input.GetButtonDown("A") && YandereController.Instance.heldItem == null)
				{
					YandereController.Instance.PickUpTray(this.plates[this.selectedIndex].food);
					this.RemovePlate(this.selectedIndex);
					this.selectedIndex = 2;
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
				}
				if (Input.GetButtonDown("B"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
					return;
				}
				break;
			case ServingCounter.KitchenState.Chef:
				if (Input.GetButtonDown("B"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					FoodMenu.Instance.gameObject.SetActive(false);
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					SFXController.PlaySound(SFXController.Sounds.MenuBack);
				}
				if (Input.GetButtonDown("A"))
				{
					this.state = ServingCounter.KitchenState.SelectingInteraction;
					Chef.AddToQueue(FoodMenu.Instance.GetActiveFood());
					FoodMenu.Instance.gameObject.SetActive(false);
					SFXController.PlaySound(SFXController.Sounds.MenuOpen);
					return;
				}
				break;
			case ServingCounter.KitchenState.Trash:
				YandereController.Instance.DropTray();
				this.state = ServingCounter.KitchenState.SelectingInteraction;
				this.selectedIndex = 2;
				break;
			default:
				return;
			}
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x001F5CB0 File Offset: 0x001F3EB0
		public void SetMask(int position)
		{
			this.counterMask.gameObject.SetActive(position == 0);
			this.trashMask.gameObject.SetActive(position == 1);
			this.chefMask.gameObject.SetActive(position == 2);
			this.plateMask.gameObject.SetActive(position == 3);
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x001F5D10 File Offset: 0x001F3F10
		public void AddPlate(Food food)
		{
			if (this.plates.Count >= this.maxPlates)
			{
				this.RemovePlate(this.maxPlates - 1);
				this.selectedIndex--;
			}
			for (int i = 0; i < this.plates.Count; i++)
			{
				FoodInstance foodInstance = this.plates[i];
				foodInstance.transform.parent = this.platePositions[i + 1];
				foodInstance.transform.localPosition = Vector3.zero;
			}
			SFXController.PlaySound(SFXController.Sounds.Plate);
			FoodInstance foodInstance2 = UnityEngine.Object.Instantiate<FoodInstance>(this.platePrefab);
			foodInstance2.transform.parent = this.platePositions[0];
			foodInstance2.transform.localPosition = Vector3.zero;
			foodInstance2.food = food;
			this.plates.Insert(0, foodInstance2);
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001F5DE4 File Offset: 0x001F3FE4
		public void RemovePlate(int index)
		{
			Component component = this.plates[index];
			this.plates.RemoveAt(index);
			UnityEngine.Object.Destroy(component.gameObject);
			for (int i = index; i < this.plates.Count; i++)
			{
				FoodInstance foodInstance = this.plates[i];
				foodInstance.transform.parent = this.platePositions[i];
				foodInstance.transform.localPosition = Vector3.zero;
			}
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001F5E5B File Offset: 0x001F405B
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x001F5E64 File Offset: 0x001F4064
		private void OnTriggerEnter2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(true);
			this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
			this.interactionRange = true;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x001F5E9A File Offset: 0x001F409A
		private void OnTriggerExit2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionRange = false;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
		}

		// Token: 0x04004B83 RID: 19331
		public FoodInstance platePrefab;

		// Token: 0x04004B84 RID: 19332
		public GameObject trash;

		// Token: 0x04004B85 RID: 19333
		public SpriteRenderer interactionIndicator;

		// Token: 0x04004B86 RID: 19334
		public SpriteRenderer kitchenModeHide;

		// Token: 0x04004B87 RID: 19335
		public SpriteMask chefMask;

		// Token: 0x04004B88 RID: 19336
		public SpriteMask trashMask;

		// Token: 0x04004B89 RID: 19337
		public SpriteMask counterMask;

		// Token: 0x04004B8A RID: 19338
		public SpriteMask plateMask;

		// Token: 0x04004B8B RID: 19339
		public int maxPlates = 7;

		// Token: 0x04004B8C RID: 19340
		public float plateSeparation = 0.214f;

		// Token: 0x04004B8D RID: 19341
		public float yPos = -1.328f;

		// Token: 0x04004B8E RID: 19342
		public float xPosStart = 2.812f;

		// Token: 0x04004B8F RID: 19343
		private ServingCounter.KitchenState state;

		// Token: 0x04004B90 RID: 19344
		private List<FoodInstance> plates;

		// Token: 0x04004B91 RID: 19345
		private List<Transform> platePositions;

		// Token: 0x04004B92 RID: 19346
		private Vector3 interactionIndicatorStartingPos;

		// Token: 0x04004B93 RID: 19347
		private int selectedIndex;

		// Token: 0x04004B94 RID: 19348
		private bool interactionRange;

		// Token: 0x04004B95 RID: 19349
		private bool interacting;

		// Token: 0x04004B96 RID: 19350
		private bool isPaused;

		// Token: 0x020006D5 RID: 1749
		public enum KitchenState
		{
			// Token: 0x0400513C RID: 20796
			None,
			// Token: 0x0400513D RID: 20797
			SelectingInteraction,
			// Token: 0x0400513E RID: 20798
			Plates,
			// Token: 0x0400513F RID: 20799
			Chef,
			// Token: 0x04005140 RID: 20800
			Trash
		}
	}
}
