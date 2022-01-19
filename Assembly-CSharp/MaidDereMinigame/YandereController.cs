using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class YandereController : AIMover
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06002412 RID: 9234 RVA: 0x001F82E0 File Offset: 0x001F64E0
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

		// Token: 0x06002413 RID: 9235 RVA: 0x001F8300 File Offset: 0x001F6500
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.plateTransform.gameObject.SetActive(false);
			this.moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
			this.isPaused = true;
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x001F8352 File Offset: 0x001F6552
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001F8374 File Offset: 0x001F6574
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x001F8396 File Offset: 0x001F6596
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
			}
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002417 RID: 9239 RVA: 0x001F83D0 File Offset: 0x001F65D0
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

		// Token: 0x06002418 RID: 9240 RVA: 0x001F8648 File Offset: 0x001F6848
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
				this.animator.SetBool("Moving", true);
			}
			else
			{
				this.animator.SetBool("Moving", false);
			}
			return controlInput;
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x001F8714 File Offset: 0x001F6914
		public void PickUpTray(Food plate)
		{
			this.animator.SetTrigger("GetTray");
			this.heldItem = plate;
			this.plateTransform.gameObject.SetActive(false);
			this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
			this.plateTransform.gameObject.SetActive(true);
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x001F8775 File Offset: 0x001F6975
		public void DropTray()
		{
			this.plateTransform.gameObject.SetActive(false);
			this.animator.SetTrigger("DropTray");
			this.heldItem = null;
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x001F87A0 File Offset: 0x001F69A0
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

		// Token: 0x0600241C RID: 9244 RVA: 0x001F87F8 File Offset: 0x001F69F8
		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == this.aiTarget)
			{
				this.aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x001F8830 File Offset: 0x001F6A30
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x001F883C File Offset: 0x001F6A3C
		public void PositionTray(string point)
		{
			string[] array = point.Split(new char[]
			{
				','
			});
			float num;
			float.TryParse(array[0], out num);
			float y;
			float.TryParse(array[1], out y);
			this.plateTransform.localPosition = new Vector3(this.spriteRenderer.flipX ? (-num) : num, y, 0f);
		}

		// Token: 0x04004BD6 RID: 19414
		private static YandereController instance;

		// Token: 0x04004BD7 RID: 19415
		public static bool leftButton;

		// Token: 0x04004BD8 RID: 19416
		public static bool rightButton;

		// Token: 0x04004BD9 RID: 19417
		public Transform leftBounds;

		// Token: 0x04004BDA RID: 19418
		public Transform rightBounds;

		// Token: 0x04004BDB RID: 19419
		public Transform interactionIndicator;

		// Token: 0x04004BDC RID: 19420
		public Transform plateTransform;

		// Token: 0x04004BDD RID: 19421
		public Food heldItem;

		// Token: 0x04004BDE RID: 19422
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BDF RID: 19423
		private Animator animator;

		// Token: 0x04004BE0 RID: 19424
		private AIController aiTarget;

		// Token: 0x04004BE1 RID: 19425
		public bool leftButtonPast;

		// Token: 0x04004BE2 RID: 19426
		public bool rightButtonPast;

		// Token: 0x04004BE3 RID: 19427
		private bool isPaused;
	}
}
