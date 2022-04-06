using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class NyanDroidScript : MonoBehaviour
{
	// Token: 0x06001A3C RID: 6716 RVA: 0x00114BCC File Offset: 0x00112DCC
	private void Start()
	{
		this.OriginalPosition = base.transform.position;
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x00114BE0 File Offset: 0x00112DE0
	private void Update()
	{
		if (!this.Pathfinding.canSearch)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Label[0].text = "     Stop";
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				return;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Timer = 0f;
				base.transform.position += new Vector3(0f, 0.0001f, 0f);
				if (base.transform.position.y < 0f)
				{
					base.transform.position = new Vector3(base.transform.position.x, 0.001f, base.transform.position.z);
				}
				Physics.SyncTransforms();
			}
			if (Input.GetButtonDown("RB"))
			{
				base.transform.position = this.OriginalPosition;
			}
			if (Vector3.Distance(base.transform.position, this.Pathfinding.target.position) <= 1f)
			{
				this.Character.CrossFade(this.Prefix + "_Idle");
				this.Pathfinding.speed = 0f;
			}
			else if (Vector3.Distance(base.transform.position, this.Pathfinding.target.position) <= 2f)
			{
				this.Character.CrossFade(this.Prefix + "_Walk");
				this.Pathfinding.speed = 0.5f;
			}
			else
			{
				this.Character.CrossFade(this.Prefix + "_Run");
				this.Pathfinding.speed = 5f;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Label[0].text = "     Follow";
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Character.CrossFade(this.Prefix + "_Idle");
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
			}
		}
	}

	// Token: 0x04002AE5 RID: 10981
	public Animation Character;

	// Token: 0x04002AE6 RID: 10982
	public PromptScript Prompt;

	// Token: 0x04002AE7 RID: 10983
	public AIPath Pathfinding;

	// Token: 0x04002AE8 RID: 10984
	public Vector3 OriginalPosition;

	// Token: 0x04002AE9 RID: 10985
	public string Prefix;

	// Token: 0x04002AEA RID: 10986
	public float Timer;
}
