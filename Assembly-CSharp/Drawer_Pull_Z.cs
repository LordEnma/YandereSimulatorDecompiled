using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x0600213E RID: 8510 RVA: 0x001EAC37 File Offset: 0x001E8E37
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600213F RID: 8511 RVA: 0x001EAC40 File Offset: 0x001E8E40
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 10f)
		{
			MonoBehaviour.print("object name");
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

	// Token: 0x06002140 RID: 8512 RVA: 0x001EACC1 File Offset: 0x001E8EC1
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x001EACD0 File Offset: 0x001E8ED0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004962 RID: 18786
	public Animator pull;

	// Token: 0x04004963 RID: 18787
	public bool open;

	// Token: 0x04004964 RID: 18788
	public Transform Player;
}
