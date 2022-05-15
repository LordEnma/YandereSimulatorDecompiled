using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x0600213D RID: 8509 RVA: 0x001EDE40 File Offset: 0x001EC040
	private void Start()
	{
		Camera component = base.GetComponent<Camera>();
		this.renderTexture = new RenderTexture(component.pixelWidth, component.pixelHeight, 24);
		Shader.SetGlobalTexture("_CameraNormalsTexture", this.renderTexture);
		GameObject gameObject = new GameObject("Normals camera");
		this.camera = gameObject.AddComponent<Camera>();
		this.camera.CopyFrom(component);
		this.camera.transform.SetParent(base.transform);
		this.camera.targetTexture = this.renderTexture;
		this.camera.SetReplacementShader(this.normalsShader, "RenderType");
		this.camera.depth = component.depth - 1f;
	}

	// Token: 0x0400499E RID: 18846
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400499F RID: 18847
	private RenderTexture renderTexture;

	// Token: 0x040049A0 RID: 18848
	private Camera camera;
}
