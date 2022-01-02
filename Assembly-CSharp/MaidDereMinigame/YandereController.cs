using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058C RID: 1420
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class YandereController : AIMover
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06002405 RID: 9221 RVA: 0x001F6C70 File Offset: 0x001F4E70
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

		// Token: 0x06002406 RID: 9222 RVA: 0x001F6C90 File Offset: 0x001F4E90
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.plateTransform.gameObject.SetActive(false);
			this.moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
			this.isPaused = true;
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x001F6CE2 File Offset: 0x001F4EE2
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x001F6D04 File Offset: 0x001F4F04
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x001F6D26 File Offset: 0x001F4F26
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
			}
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001F6D60 File Offset: 0x001F4F60
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

		// Token: 0x0600240B RID: 9227 RVA: 0x001F6FD8 File Offset: 0x001F51D8
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

		// Token: 0x0600240C RID: 9228 RVA: 0x001F70A4 File Offset: 0x001F52A4
		public void PickUpTray(Food plate)
		{
			this.animator.SetTrigger("GetTray");
			this.heldItem = plate;
			this.plateTransform.gameObject.SetActive(false);
			this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
			this.plateTransform.gameObject.SetActive(true);
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x001F7105 File Offset: 0x001F5305
		public void DropTray()
		{
			this.plateTransform.gameObject.SetActive(false);
			this.animator.SetTrigger("DropTray");
			this.heldItem = null;
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x001F7130 File Offset: 0x001F5330
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

		// Token: 0x0600240F RID: 9231 RVA: 0x001F7188 File Offset: 0x001F5388
		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == this.aiTarget)
			{
				this.aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x06002410 RID: 9232 RVA: 0x001F71C0 File Offset: 0x001F53C0
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x001F71CC File Offset: 0x001F53CC
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

		// Token: 0x04004BBB RID: 19387
		private static YandereController instance;

		// Token: 0x04004BBC RID: 19388
		public static bool leftButton;

		// Token: 0x04004BBD RID: 19389
		public static bool rightButton;

		// Token: 0x04004BBE RID: 19390
		public Transform leftBounds;

		// Token: 0x04004BBF RID: 19391
		public Transform rightBounds;

		// Token: 0x04004BC0 RID: 19392
		public Transform interactionIndicator;

		// Token: 0x04004BC1 RID: 19393
		public Transform plateTransform;

		// Token: 0x04004BC2 RID: 19394
		public Food heldItem;

		// Token: 0x04004BC3 RID: 19395
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BC4 RID: 19396
		private Animator animator;

		// Token: 0x04004BC5 RID: 19397
		private AIController aiTarget;

		// Token: 0x04004BC6 RID: 19398
		public bool leftButtonPast;

		// Token: 0x04004BC7 RID: 19399
		public bool rightButtonPast;

		// Token: 0x04004BC8 RID: 19400
		private bool isPaused;
	}
}
