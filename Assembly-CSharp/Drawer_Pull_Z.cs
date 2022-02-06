using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x060020F8 RID: 8440 RVA: 0x001E54C3 File Offset: 0x001E36C3
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x001E54CC File Offset: 0x001E36CC
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

	// Token: 0x060020FA RID: 8442 RVA: 0x001E554D File Offset: 0x001E374D
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E555C File Offset: 0x001E375C
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004897 RID: 18583
	public Animator pull;

	// Token: 0x04004898 RID: 18584
	public bool open;

	// Token: 0x04004899 RID: 18585
	public Transform Player;
}
