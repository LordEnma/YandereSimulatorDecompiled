using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058C RID: 1420
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class YandereController : AIMover
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06002402 RID: 9218 RVA: 0x001F6680 File Offset: 0x001F4880
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

		// Token: 0x06002403 RID: 9219 RVA: 0x001F66A0 File Offset: 0x001F48A0
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.plateTransform.gameObject.SetActive(false);
			this.moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
			this.isPaused = true;
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x001F66F2 File Offset: 0x001F48F2
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x001F6714 File Offset: 0x001F4914
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x001F6736 File Offset: 0x001F4936
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
			}
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x001F6770 File Offset: 0x001F4970
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

		// Token: 0x06002408 RID: 9224 RVA: 0x001F69E8 File Offset: 0x001F4BE8
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

		// Token: 0x06002409 RID: 9225 RVA: 0x001F6AB4 File Offset: 0x001F4CB4
		public void PickUpTray(Food plate)
		{
			this.animator.SetTrigger("GetTray");
			this.heldItem = plate;
			this.plateTransform.gameObject.SetActive(false);
			this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
			this.plateTransform.gameObject.SetActive(true);
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001F6B15 File Offset: 0x001F4D15
		public void DropTray()
		{
			this.plateTransform.gameObject.SetActive(false);
			this.animator.SetTrigger("DropTray");
			this.heldItem = null;
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001F6B40 File Offset: 0x001F4D40
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

		// Token: 0x0600240C RID: 9228 RVA: 0x001F6B98 File Offset: 0x001F4D98
		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == this.aiTarget)
			{
				this.aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x001F6BD0 File Offset: 0x001F4DD0
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x001F6BDC File Offset: 0x001F4DDC
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

		// Token: 0x04004BB2 RID: 19378
		private static YandereController instance;

		// Token: 0x04004BB3 RID: 19379
		public static bool leftButton;

		// Token: 0x04004BB4 RID: 19380
		public static bool rightButton;

		// Token: 0x04004BB5 RID: 19381
		public Transform leftBounds;

		// Token: 0x04004BB6 RID: 19382
		public Transform rightBounds;

		// Token: 0x04004BB7 RID: 19383
		public Transform interactionIndicator;

		// Token: 0x04004BB8 RID: 19384
		public Transform plateTransform;

		// Token: 0x04004BB9 RID: 19385
		public Food heldItem;

		// Token: 0x04004BBA RID: 19386
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BBB RID: 19387
		private Animator animator;

		// Token: 0x04004BBC RID: 19388
		private AIController aiTarget;

		// Token: 0x04004BBD RID: 19389
		public bool leftButtonPast;

		// Token: 0x04004BBE RID: 19390
		public bool rightButtonPast;

		// Token: 0x04004BBF RID: 19391
		private bool isPaused;
	}
}
