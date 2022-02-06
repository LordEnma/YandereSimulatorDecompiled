using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Animator))]
	public class YandereController : AIMover
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x0600241B RID: 9243 RVA: 0x001F909C File Offset: 0x001F729C
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

		// Token: 0x0600241C RID: 9244 RVA: 0x001F90BC File Offset: 0x001F72BC
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.animator = base.GetComponent<Animator>();
			this.plateTransform.gameObject.SetActive(false);
			this.moveSpeed = GameController.Instance.activeDifficultyVariables.playerMoveSpeed;
			this.isPaused = true;
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x001F910E File Offset: 0x001F730E
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x001F9130 File Offset: 0x001F7330
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600241F RID: 9247 RVA: 0x001F9152 File Offset: 0x001F7352
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			if (this.isPaused)
			{
				this.animator.SetBool("Moving", false);
			}
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002420 RID: 9248 RVA: 0x001F918C File Offset: 0x001F738C
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

		// Token: 0x06002421 RID: 9249 RVA: 0x001F9404 File Offset: 0x001F7604
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

		// Token: 0x06002422 RID: 9250 RVA: 0x001F94D0 File Offset: 0x001F76D0
		public void PickUpTray(Food plate)
		{
			this.animator.SetTrigger("GetTray");
			this.heldItem = plate;
			this.plateTransform.gameObject.SetActive(false);
			this.plateTransform.GetComponent<SpriteRenderer>().sprite = this.heldItem.smallSprite;
			this.plateTransform.gameObject.SetActive(true);
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x001F9531 File Offset: 0x001F7731
		public void DropTray()
		{
			this.plateTransform.gameObject.SetActive(false);
			this.animator.SetTrigger("DropTray");
			this.heldItem = null;
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x001F955C File Offset: 0x001F775C
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

		// Token: 0x06002425 RID: 9253 RVA: 0x001F95B4 File Offset: 0x001F77B4
		private void OnTriggerExit2D(Collider2D collision)
		{
			AIController component = collision.GetComponent<AIController>();
			if (component != null && component == this.aiTarget)
			{
				this.aiTarget = null;
				InteractionMenu.SetAButton(InteractionMenu.AButtonText.None);
			}
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x001F95EC File Offset: 0x001F77EC
		public void SetPause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x001F95F8 File Offset: 0x001F77F8
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

		// Token: 0x04004BEA RID: 19434
		private static YandereController instance;

		// Token: 0x04004BEB RID: 19435
		public static bool leftButton;

		// Token: 0x04004BEC RID: 19436
		public static bool rightButton;

		// Token: 0x04004BED RID: 19437
		public Transform leftBounds;

		// Token: 0x04004BEE RID: 19438
		public Transform rightBounds;

		// Token: 0x04004BEF RID: 19439
		public Transform interactionIndicator;

		// Token: 0x04004BF0 RID: 19440
		public Transform plateTransform;

		// Token: 0x04004BF1 RID: 19441
		public Food heldItem;

		// Token: 0x04004BF2 RID: 19442
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BF3 RID: 19443
		private Animator animator;

		// Token: 0x04004BF4 RID: 19444
		private AIController aiTarget;

		// Token: 0x04004BF5 RID: 19445
		public bool leftButtonPast;

		// Token: 0x04004BF6 RID: 19446
		public bool rightButtonPast;

		// Token: 0x04004BF7 RID: 19447
		private bool isPaused;
	}
}
