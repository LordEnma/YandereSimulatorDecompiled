using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020E5 RID: 8421 RVA: 0x001E5580 File Offset: 0x001E3780
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

	// Token: 0x0400488E RID: 18574
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400488F RID: 18575
	private RenderTexture renderTexture;

	// Token: 0x04004890 RID: 18576
	private Camera camera;
}
