using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020EF RID: 8431 RVA: 0x001E4707 File Offset: 0x001E2907
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x001E4710 File Offset: 0x001E2910
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

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E4791 File Offset: 0x001E2991
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E47A0 File Offset: 0x001E29A0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004883 RID: 18563
	public Animator pull;

	// Token: 0x04004884 RID: 18564
	public bool open;

	// Token: 0x04004885 RID: 18565
	public Transform Player;
}
