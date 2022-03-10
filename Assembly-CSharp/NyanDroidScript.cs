using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NyanDroidScript : MonoBehaviour
{
	// Token: 0x06001A26 RID: 6694 RVA: 0x001138F8 File Offset: 0x00111AF8
	private void Start()
	{
		this.OriginalPosition = base.transform.position;
	}

	// Token: 0x06001A27 RID: 6695 RVA: 0x0011390C File Offset: 0x00111B0C
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

	// Token: 0x04002AA6 RID: 10918
	public Animation Character;

	// Token: 0x04002AA7 RID: 10919
	public PromptScript Prompt;

	// Token: 0x04002AA8 RID: 10920
	public AIPath Pathfinding;

	// Token: 0x04002AA9 RID: 10921
	public Vector3 OriginalPosition;

	// Token: 0x04002AAA RID: 10922
	public string Prefix;

	// Token: 0x04002AAB RID: 10923
	public float Timer;
}
