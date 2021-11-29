using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020BF RID: 8383 RVA: 0x001E1173 File Offset: 0x001DF373
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020C0 RID: 8384 RVA: 0x001E117C File Offset: 0x001DF37C
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 15f)
		{
			if (!this.open)
			{
				if (Input.GetMouseButtonDown(0))
				{
					base.StartCoroutine(this.opening());
					return;
				}
			}
			else if (this.open && Input.GetMouseButtonDown(0))
			{
				base.StartCoroutine(this.closing());
			}
		}
	}

	// Token: 0x060020C1 RID: 8385 RVA: 0x001E11F3 File Offset: 0x001DF3F3
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020C2 RID: 8386 RVA: 0x001E1202 File Offset: 0x001DF402
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004817 RID: 18455
	public Animator openandclose;

	// Token: 0x04004818 RID: 18456
	public bool open;

	// Token: 0x04004819 RID: 18457
	public Transform Player;
}
