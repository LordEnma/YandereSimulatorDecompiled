using System;
using UnityEngine;

// Token: 0x02000295 RID: 661
public class DumpsterHandleScript : MonoBehaviour
{
	// Token: 0x060013D5 RID: 5077 RVA: 0x000BBDC3 File Offset: 0x000B9FC3
	private void Start()
	{
		this.Panel.SetActive(false);
	}

	// Token: 0x060013D6 RID: 5078 RVA: 0x000BBDD4 File Offset: 0x000B9FD4
	private void Update()
	{
		this.Prompt.HideButton[3] = (this.Prompt.Yandere.PickUp != null || this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying);
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Circle[3].fillAmount = 1f;
			if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
			{
				this.Prompt.Yandere.DumpsterGrabbing = true;
				this.Prompt.Yandere.DumpsterHandle = this;
				this.Prompt.Yandere.CanMove = false;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "STOP";
				this.PromptBar.Label[5].text = "PUSH / PULL";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Grabbed = true;
			}
		}
		if (this.Grabbed)
		{
			this.Prompt.Yandere.transform.rotation = Quaternion.Lerp(this.Prompt.Yandere.transform.rotation, this.GrabSpot.rotation, Time.deltaTime * 10f);
			if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.GrabSpot.position) > 0.1f)
			{
				this.Prompt.Yandere.MoveTowardsTarget(this.GrabSpot.position);
			}
			else
			{
				this.Prompt.Yandere.transform.position = this.GrabSpot.position;
			}
			if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetKey("right"))
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z - Time.deltaTime);
			}
			else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("left"))
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z + Time.deltaTime);
			}
			if (this.PullLimit < this.PushLimit)
			{
				if (base.transform.parent.transform.position.z < this.PullLimit)
				{
					base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PullLimit);
				}
				else if (base.transform.parent.transform.position.z > this.PushLimit)
				{
					base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PushLimit);
				}
			}
			else if (base.transform.parent.transform.position.z > this.PullLimit)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PullLimit);
			}
			else if (base.transform.parent.transform.position.z < this.PushLimit)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PushLimit);
			}
			this.Panel.SetActive(this.DumpsterLid.transform.position.z > this.DumpsterLid.DisposalSpot - 0.05f && this.DumpsterLid.transform.position.z < this.DumpsterLid.DisposalSpot + 0.05f);
			if (this.Prompt.Yandere.Chased || this.Prompt.Yandere.Chasers > 0 || Input.GetButtonDown("B"))
			{
				this.StopGrabbing();
			}
		}
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x000BC398 File Offset: 0x000BA598
	private void StopGrabbing()
	{
		this.Prompt.Yandere.DumpsterGrabbing = false;
		this.Prompt.Yandere.CanMove = true;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Panel.SetActive(false);
		this.Grabbed = false;
	}

	// Token: 0x04001D9B RID: 7579
	public DumpsterLidScript DumpsterLid;

	// Token: 0x04001D9C RID: 7580
	public PromptBarScript PromptBar;

	// Token: 0x04001D9D RID: 7581
	public PromptScript Prompt;

	// Token: 0x04001D9E RID: 7582
	public Transform GrabSpot;

	// Token: 0x04001D9F RID: 7583
	public GameObject Panel;

	// Token: 0x04001DA0 RID: 7584
	public bool Grabbed;

	// Token: 0x04001DA1 RID: 7585
	public float Direction;

	// Token: 0x04001DA2 RID: 7586
	public float PullLimit;

	// Token: 0x04001DA3 RID: 7587
	public float PushLimit;
}
