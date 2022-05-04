using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class YandereController : AIMover
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002472 RID: 9330 RVA: 0x002007F4 File Offset: 0x001FE9F4
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

		// Token: 0x06002473 RID: 9331 RVA: 0x00200814 File Offset: 0x001FEA14
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

		// Token: 0x06002474 RID: 9332 RVA: 0x0020087E File Offset: 0x001FEA7E
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x002008A0 File Offset: 0x001FEAA0
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x002008C2 File Offset: 0x001FEAC2
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
			}
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x002008FC File Offset: 0x001FEAFC
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

		// Token: 0x06002478 RID: 9336 RVA: 0x00200B74 File Offset: 0x001FED74
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

		// Token: 0x06002479 RID: 9337 RVA: 0x00200C70 File Offset: 0x001FEE70
		public void PickUpTray(Food plate)
		{
			this.animator.SetTrigger("GetTray");
			this.heldItem = plate;
			this.plateTransform.gameObject.SetActive(false);
			this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
			this.plateTransform.gameObject.SetActive(true);
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x00200CD1 File Offset: 0x001FEED1
		public void DropTray()
		{
			this.plateTransform.gameObject.SetActive(false);
			this.animator.SetTrigger("DropTray");
			this.heldItem = null;
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x00200CFC File Offset: 0x001FEEFC
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

		// Token: 0x0600247C RID: 9340 RVA: 0x00200D54 File Offset: 0x001FEF54
		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == this.aiTarget)
			{
				this.aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x00200D8C File Offset: 0x001FEF8C
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x00200D98 File Offset: 0x001FEF98
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

		// Token: 0x04004CDD RID: 19677
		private static YandereController instance;

		// Token: 0x04004CDE RID: 19678
		public static bool leftButton;

		// Token: 0x04004CDF RID: 19679
		public static bool rightButton;

		// Token: 0x04004CE0 RID: 19680
		public Transform leftBounds;

		// Token: 0x04004CE1 RID: 19681
		public Transform rightBounds;

		// Token: 0x04004CE2 RID: 19682
		public Transform interactionIndicator;

		// Token: 0x04004CE3 RID: 19683
		public Transform plateTransform;

		// Token: 0x04004CE4 RID: 19684
		public Food heldItem;

		// Token: 0x04004CE5 RID: 19685
		public RuntimeAnimatorController EightiesAnimator;

		// Token: 0x04004CE6 RID: 19686
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004CE7 RID: 19687
		private Animator animator;

		// Token: 0x04004CE8 RID: 19688
		private AIController aiTarget;

		// Token: 0x04004CE9 RID: 19689
		public bool leftButtonPast;

		// Token: 0x04004CEA RID: 19690
		public bool rightButtonPast;

		// Token: 0x04004CEB RID: 19691
		private bool isPaused;

		// Token: 0x04004CEC RID: 19692
		private bool LastKnownFlip;

		// Token: 0x04004CED RID: 19693
		public string LastKnownPoints;
	}
}
