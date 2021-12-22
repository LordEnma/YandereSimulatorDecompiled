using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B49 RID: 6985 RVA: 0x0013271C File Offset: 0x0013091C
	private void Start()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		int num = 0;
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.gameObject.GetComponent<Renderer>() != null)
			{
				this.Renderers[num] = transform.gameObject.GetComponent<Renderer>();
				num++;
			}
		}
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x00132774 File Offset: 0x00130974
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			foreach (Renderer renderer in this.Renderers)
			{
				renderer.enabled = !renderer.enabled;
			}
		}
	}

	// Token: 0x04002E9A RID: 11930
	public Renderer[] Renderers;
}
