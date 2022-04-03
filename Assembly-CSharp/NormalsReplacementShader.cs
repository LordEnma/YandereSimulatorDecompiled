using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x0600211A RID: 8474 RVA: 0x001EA2DC File Offset: 0x001E84DC
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

	// Token: 0x0400494B RID: 18763
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400494C RID: 18764
	private RenderTexture renderTexture;

	// Token: 0x0400494D RID: 18765
	private Camera camera;
}
