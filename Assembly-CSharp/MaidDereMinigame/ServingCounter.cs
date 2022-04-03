using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	public class ServingCounter : MonoBehaviour
	{
		// Token: 0x0600246C RID: 9324 RVA: 0x001FE99C File Offset: 0x001FCB9C
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

		// Token: 0x0600246D RID: 9325 RVA: 0x001FEA72 File Offset: 0x001FCC72
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600246E RID: 9326 RVA: 0x001FEA94 File Offset: 0x001FCC94
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.SetPause));
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x001FEAB8 File Offset: 0x001FCCB8
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

		// Token: 0x06002470 RID: 9328 RVA: 0x001FF044 File Offset: 0x001FD244
		public void SetMask(int position)
		{
			this.counterMask.gameObject.SetActive(position == 0);
			this.trashMask.gameObject.SetActive(position == 1);
			this.chefMask.gameObject.SetActive(position == 2);
			this.plateMask.gameObject.SetActive(position == 3);
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x001FF0A4 File Offset: 0x001FD2A4
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

		// Token: 0x06002472 RID: 9330 RVA: 0x001FF178 File Offset: 0x001FD378
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

		// Token: 0x06002473 RID: 9331 RVA: 0x001FF1EF File Offset: 0x001FD3EF
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x001FF1F8 File Offset: 0x001FD3F8
		private void OnTriggerEnter2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(true);
			this.interactionIndicator.transform.position = this.interactionIndicatorStartingPos;
			this.interactionRange = true;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.KitchenMenu);
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x001FF22E File Offset: 0x001FD42E
		private void OnTriggerExit2D(Collider2D collision)
		{
			this.interactionIndicator.gameObject.SetActive(false);
			this.interactionRange = false;
			InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
		}

		// Token: 0x04004CC1 RID: 19649
		public FoodInstance platePrefab;

		// Token: 0x04004CC2 RID: 19650
		public GameObject trash;

		// Token: 0x04004CC3 RID: 19651
		public SpriteRenderer interactionIndicator;

		// Token: 0x04004CC4 RID: 19652
		public SpriteRenderer kitchenModeHide;

		// Token: 0x04004CC5 RID: 19653
		public SpriteMask chefMask;

		// Token: 0x04004CC6 RID: 19654
		public SpriteMask trashMask;

		// Token: 0x04004CC7 RID: 19655
		public SpriteMask counterMask;

		// Token: 0x04004CC8 RID: 19656
		public SpriteMask plateMask;

		// Token: 0x04004CC9 RID: 19657
		public int maxPlates = 7;

		// Token: 0x04004CCA RID: 19658
		public float plateSeparation = 0.214f;

		// Token: 0x04004CCB RID: 19659
		public float yPos = -1.328f;

		// Token: 0x04004CCC RID: 19660
		public float xPosStart = 2.812f;

		// Token: 0x04004CCD RID: 19661
		private ServingCounter.KitchenState state;

		// Token: 0x04004CCE RID: 19662
		private List<FoodInstance> plates;

		// Token: 0x04004CCF RID: 19663
		private List<Transform> platePositions;

		// Token: 0x04004CD0 RID: 19664
		private Vector3 interactionIndicatorStartingPos;

		// Token: 0x04004CD1 RID: 19665
		private int selectedIndex;

		// Token: 0x04004CD2 RID: 19666
		private bool interactionRange;

		// Token: 0x04004CD3 RID: 19667
		private bool interacting;

		// Token: 0x04004CD4 RID: 19668
		private bool isPaused;

		// Token: 0x020006E3 RID: 1763
		public enum KitchenState
		{
			// Token: 0x0400525D RID: 21085
			None,
			// Token: 0x0400525E RID: 21086
			SelectingInteraction,
			// Token: 0x0400525F RID: 21087
			Plates,
			// Token: 0x04005260 RID: 21088
			Chef,
			// Token: 0x04005261 RID: 21089
			Trash
		}
	}
}
