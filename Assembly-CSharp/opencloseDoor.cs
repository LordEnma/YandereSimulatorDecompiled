using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x06002127 RID: 8487 RVA: 0x001EA507 File Offset: 0x001E8707
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x001EA510 File Offset: 0x001E8710
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

	// Token: 0x06002129 RID: 8489 RVA: 0x001EA587 File Offset: 0x001E8787
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600212A RID: 8490 RVA: 0x001EA596 File Offset: 0x001E8796
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004955 RID: 18773
	public Animator openandclose;

	// Token: 0x04004956 RID: 18774
	public bool open;

	// Token: 0x04004957 RID: 18775
	public Transform Player;
}
