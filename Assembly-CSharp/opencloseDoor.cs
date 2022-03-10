using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020FF RID: 8447 RVA: 0x001E6D2F File Offset: 0x001E4F2F
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E6D38 File Offset: 0x001E4F38
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

	// Token: 0x06002101 RID: 8449 RVA: 0x001E6DAF File Offset: 0x001E4FAF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x001E6DBE File Offset: 0x001E4FBE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048C4 RID: 18628
	public Animator openandclose;

	// Token: 0x040048C5 RID: 18629
	public bool open;

	// Token: 0x040048C6 RID: 18630
	public Transform Player;
}
