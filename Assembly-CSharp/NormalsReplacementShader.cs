using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020B4 RID: 8372 RVA: 0x001E0F7C File Offset: 0x001DF17C
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

	// Token: 0x0400480E RID: 18446
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400480F RID: 18447
	private RenderTexture renderTexture;

	// Token: 0x04004810 RID: 18448
	private Camera camera;
}
