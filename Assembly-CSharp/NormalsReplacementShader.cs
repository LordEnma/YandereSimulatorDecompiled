using System;
using UnityEngine;

// Token: 0x020004EC RID: 1260
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020C5 RID: 8389 RVA: 0x001E26B0 File Offset: 0x001E08B0
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

	// Token: 0x0400484D RID: 18509
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400484E RID: 18510
	private RenderTexture renderTexture;

	// Token: 0x0400484F RID: 18511
	private Camera camera;
}
