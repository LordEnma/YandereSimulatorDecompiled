using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B4B RID: 6987 RVA: 0x00132B18 File Offset: 0x00130D18
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

	// Token: 0x06001B4C RID: 6988 RVA: 0x00132B70 File Offset: 0x00130D70
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

	// Token: 0x04002EA1 RID: 11937
	public Renderer[] Renderers;
}
