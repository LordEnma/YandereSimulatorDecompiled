using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class YandereController : AIMover
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600247D RID: 9341 RVA: 0x002023AC File Offset: 0x002005AC
		public static YandereController Instance
		{
			get
			{
				if (YandereController.instance == null)
				{
					YandereController.instance = UnityEngine.Object.FindObjectOfType<YandereController>();
				}
				return YandereController.instance;
			}
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x002023CC File Offset: 0x002005CC
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.plateTransform.gameObject.SetActive(false);
			this.moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
			this.isPaused = true;
			if (GameGlobals.Eighties)
			{
				this.animator.runtimeAnimatorController = this.EightiesAnimator;
			}
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x00202436 File Offset: 0x00200636
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x00202458 File Offset: 0x00200658
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x0020247A File Offset: 0x0020067A
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
			}
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x002024B4 File Offset: 0x002006B4
		private void Update()
		{
			YandereController.rightButton = false;
			YandereController.leftButton = false;
			if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetKey("right") || Input.GetAxis("DpadX") > 0.5f)
			{
				if (!this.rightButtonPast)
				{
					this.rightButtonPast = true;
					YandereController.rightButton = true;
				}
			}
			else if (Input.GetAxisRaw("Horizontal") < 0f || Input.GetKey("left") || Input.GetAxis("DpadX") < -0.5f)
			{
				if (!this.leftButtonPast)
				{
					this.leftButtonPast = true;
					YandereController.leftButton = true;
				}
			}
			else
			{
				this.leftButtonPast = false;
				this.rightButtonPast = false;
			}
			if (base.transform.position.x < this.leftBounds.position.x)
			{
				base.transform.position = new Vector3(this.leftBounds.position.x, base.transform.position.y, base.transform.position.z);
			}
			if (base.transform.position.x > this.rightBounds.position.x)
			{
				base.transform.position = new Vector3(this.rightBounds.position.x, base.transform.position.y, base.transform.position.z);
			}
			if (Input.GetButtonDown("A") && this.aiTarget != null)
			{
				if (this.aiTarget.state == AIController.AIState.Menu)
				{
					this.aiTarget.TakeOrder();
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
				}
				else if (this.aiTarget.state == AIController.AIState.Waiting && this.heldItem != null)
				{
					this.aiTarget.DeliverFood(this.heldItem);
					SFXController.PlaySound(SFXController.Sounds.Plate);
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
					this.DropTray();
				}
			}
			if (this.aiTarget != null)
			{
				this.interactionIndicator.gameObject.SetActive(true);
				this.interactionIndicator.position = new Vector3(this.aiTarget.transform.position.x, this.aiTarget.transform.position.y + 0.6f, this.aiTarget.transform.position.z);
				return;
			}
			this.interactionIndicator.gameObject.SetActive(false);
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x0020272C File Offset: 0x0020092C
		public override ControlInput GetInput()
		{
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
				return default(ControlInput);
			}
			float horizontal = 0f;
			if (this.rightButtonPast)
			{
				horizontal = 1f;
			}
			else if (this.leftButtonPast)
			{
				horizontal = -1f;
			}
			ControlInput controlInput = new ControlInput
			{
				horizontal = horizontal
			};
			if (controlInput.horizontal != 0f)
			{
				if (controlInput.horizontal < 0f)
				{
					this.spriteRenderer.flipX = true;
				}
				else if (controlInput.horizontal > 0f)
				{
					this.spriteRenderer.flipX = false;
				}
				if (this.spriteRenderer.flipX != this.LastKnownFlip)
				{
					this.PositionTray(this.LastKnownPoints);
				}
				this.LastKnownFlip = this.spriteRenderer.flipX;
				this.animator.SetBool("Moving", true);
			}
			else
			{
				this.animator.SetBool("Moving", false);
			}
			return controlInput;
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x00202828 File Offset: 0x00200A28
		public void PickUpTray(Food plate)
		{
			this.animator.SetTrigger("GetTray");
			this.heldItem = plate;
			this.plateTransform.gameObject.SetActive(false);
			this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
			this.plateTransform.gameObject.SetActive(true);
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x00202889 File Offset: 0x00200A89
		public void DropTray()
		{
			this.plateTransform.gameObject.SetActive(false);
			this.animator.SetTrigger("DropTray");
			this.heldItem = null;
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x002028B4 File Offset: 0x00200AB4
		private void OnTriggerEnter2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null)
			{
				if (component.state == AIController.AIState.Menu)
				{
					this.aiTarget = component;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.TakeOrder);
				}
				if (component.state == AIController.AIState.Waiting && this.heldItem != null)
				{
					this.aiTarget = component;
					InteractionMenu.SetAButton(InteractionMenu.AButtonText.GiveFood);
				}
			}
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x0020290C File Offset: 0x00200B0C
		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == this.aiTarget)
			{
				this.aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x00202944 File Offset: 0x00200B44
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x00202950 File Offset: 0x00200B50
		public void PositionTray(string point)
		{
			string[] array = point.Split(new char[]
			{
				','
			});
			this.LastKnownPoints = point;
			float num;
			float.TryParse(array[0], out num);
			float y;
			float.TryParse(array[1], out y);
			this.plateTransform.localPosition = new Vector3(this.spriteRenderer.flipX ? (-num) : num, y, 0f);
		}

		// Token: 0x04004D0D RID: 19725
		private static YandereController instance;

		// Token: 0x04004D0E RID: 19726
		public static bool leftButton;

		// Token: 0x04004D0F RID: 19727
		public static bool rightButton;

		// Token: 0x04004D10 RID: 19728
		public Transform leftBounds;

		// Token: 0x04004D11 RID: 19729
		public Transform rightBounds;

		// Token: 0x04004D12 RID: 19730
		public Transform interactionIndicator;

		// Token: 0x04004D13 RID: 19731
		public Transform plateTransform;

		// Token: 0x04004D14 RID: 19732
		public Food heldItem;

		// Token: 0x04004D15 RID: 19733
		public RuntimeAnimatorController EightiesAnimator;

		// Token: 0x04004D16 RID: 19734
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D17 RID: 19735
		private Animator animator;

		// Token: 0x04004D18 RID: 19736
		private AIController aiTarget;

		// Token: 0x04004D19 RID: 19737
		public bool leftButtonPast;

		// Token: 0x04004D1A RID: 19738
		public bool rightButtonPast;

		// Token: 0x04004D1B RID: 19739
		private bool isPaused;

		// Token: 0x04004D1C RID: 19740
		private bool LastKnownFlip;

		// Token: 0x04004D1D RID: 19741
		public string LastKnownPoints;
	}
}
