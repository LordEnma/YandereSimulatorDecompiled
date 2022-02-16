using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020FF RID: 8447 RVA: 0x001E5977 File Offset: 0x001E3B77
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E5980 File Offset: 0x001E3B80
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

	// Token: 0x06002101 RID: 8449 RVA: 0x001E5A01 File Offset: 0x001E3C01
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x001E5A10 File Offset: 0x001E3C10
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048A0 RID: 18592
	public Animator pull;

	// Token: 0x040048A1 RID: 18593
	public bool open;

	// Token: 0x040048A2 RID: 18594
	public Transform Player;
}
