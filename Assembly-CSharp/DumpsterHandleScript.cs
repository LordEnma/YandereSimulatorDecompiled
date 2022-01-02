using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DumpsterHandleScript : MonoBehaviour
{
	// Token: 0x060013BA RID: 5050 RVA: 0x000BAA0B File Offset: 0x000B8C0B
	private void Start()
	{
		this.Panel.SetActive(false);
	}

	// Token: 0x060013BB RID: 5051 RVA: 0x000BAA1C File Offset: 0x000B8C1C
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

	// Token: 0x060013BC RID: 5052 RVA: 0x000BAFE0 File Offset: 0x000B91E0
	private void StopGrabbing()
	{
		this.Prompt.Yandere.DumpsterGrabbing = false;
		this.Prompt.Yandere.CanMove = true;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Panel.SetActive(false);
		this.Grabbed = false;
	}

	// Token: 0x04001D62 RID: 7522
	public DumpsterLidScript DumpsterLid;

	// Token: 0x04001D63 RID: 7523
	public PromptBarScript PromptBar;

	// Token: 0x04001D64 RID: 7524
	public PromptScript Prompt;

	// Token: 0x04001D65 RID: 7525
	public Transform GrabSpot;

	// Token: 0x04001D66 RID: 7526
	public GameObject Panel;

	// Token: 0x04001D67 RID: 7527
	public bool Grabbed;

	// Token: 0x04001D68 RID: 7528
	public float Direction;

	// Token: 0x04001D69 RID: 7529
	public float PullLimit;

	// Token: 0x04001D6A RID: 7530
	public float PushLimit;
}
