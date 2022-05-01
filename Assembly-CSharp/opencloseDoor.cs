using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x0600213F RID: 8511 RVA: 0x001EC91F File Offset: 0x001EAB1F
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002140 RID: 8512 RVA: 0x001EC928 File Offset: 0x001EAB28
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

	// Token: 0x06002141 RID: 8513 RVA: 0x001EC99F File Offset: 0x001EAB9F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002142 RID: 8514 RVA: 0x001EC9AE File Offset: 0x001EABAE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004981 RID: 18817
	public Animator openandclose;

	// Token: 0x04004982 RID: 18818
	public bool open;

	// Token: 0x04004983 RID: 18819
	public Transform Player;
}
