using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class Drawer_Pull_Z : MonoBehaviour
{
	// Token: 0x06002159 RID: 8537 RVA: 0x001EE26B File Offset: 0x001EC46B
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x001EE274 File Offset: 0x001EC474
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

	// Token: 0x0600215B RID: 8539 RVA: 0x001EE2F5 File Offset: 0x001EC4F5
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull.Play("openpull");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x001EE304 File Offset: 0x001EC504
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull.Play("closepush");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049B1 RID: 18865
	public Animator pull;

	// Token: 0x040049B2 RID: 18866
	public bool open;

	// Token: 0x040049B3 RID: 18867
	public Transform Player;
}
