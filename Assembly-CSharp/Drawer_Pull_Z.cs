using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x06002145 RID: 8517 RVA: 0x001EB693 File Offset: 0x001E9893
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002146 RID: 8518 RVA: 0x001EB69C File Offset: 0x001E989C
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

	// Token: 0x06002147 RID: 8519 RVA: 0x001EB71D File Offset: 0x001E991D
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002148 RID: 8520 RVA: 0x001EB72C File Offset: 0x001E992C
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004974 RID: 18804
	public Animator pull;

	// Token: 0x04004975 RID: 18805
	public bool open;

	// Token: 0x04004976 RID: 18806
	public Transform Player;
}
