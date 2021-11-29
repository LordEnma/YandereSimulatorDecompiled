using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DumpsterHandleScript : MonoBehaviour
{
	// Token: 0x060013B3 RID: 5043 RVA: 0x000BA227 File Offset: 0x000B8427
	private void Start()
	{
		this.Panel.SetActive(false);
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x000BA238 File Offset: 0x000B8438
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

	// Token: 0x060013B5 RID: 5045 RVA: 0x000BA7FC File Offset: 0x000B89FC
	private void StopGrabbing()
	{
		this.Prompt.Yandere.DumpsterGrabbing = false;
		this.Prompt.Yandere.CanMove = true;
		this.PromptBar.ClearButtons();
		this.PromptBar.Show = false;
		this.Panel.SetActive(false);
		this.Grabbed = false;
	}

	// Token: 0x04001D3F RID: 7487
	public DumpsterLidScript DumpsterLid;

	// Token: 0x04001D40 RID: 7488
	public PromptBarScript PromptBar;

	// Token: 0x04001D41 RID: 7489
	public PromptScript Prompt;

	// Token: 0x04001D42 RID: 7490
	public Transform GrabSpot;

	// Token: 0x04001D43 RID: 7491
	public GameObject Panel;

	// Token: 0x04001D44 RID: 7492
	public bool Grabbed;

	// Token: 0x04001D45 RID: 7493
	public float Direction;

	// Token: 0x04001D46 RID: 7494
	public float PullLimit;

	// Token: 0x04001D47 RID: 7495
	public float PushLimit;
}
