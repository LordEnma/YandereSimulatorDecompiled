using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020D5 RID: 8405 RVA: 0x001E4310 File Offset: 0x001E2510
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

	// Token: 0x04004871 RID: 18545
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x04004872 RID: 18546
	private RenderTexture renderTexture;

	// Token: 0x04004873 RID: 18547
	private Camera camera;
}
