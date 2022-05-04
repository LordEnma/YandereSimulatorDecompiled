using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x0600214F RID: 8527 RVA: 0x001ECC1B File Offset: 0x001EAE1B
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x001ECC24 File Offset: 0x001EAE24
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

	// Token: 0x06002151 RID: 8529 RVA: 0x001ECCA5 File Offset: 0x001EAEA5
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x001ECCB4 File Offset: 0x001EAEB4
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400498A RID: 18826
	public Animator pull;

	// Token: 0x0400498B RID: 18827
	public bool open;

	// Token: 0x0400498C RID: 18828
	public Transform Player;
}
