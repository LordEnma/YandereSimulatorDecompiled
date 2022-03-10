using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x060020F4 RID: 8436 RVA: 0x001E6B38 File Offset: 0x001E4D38
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

	// Token: 0x040048BB RID: 18619
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x040048BC RID: 18620
	private RenderTexture renderTexture;

	// Token: 0x040048BD RID: 18621
	private Camera camera;
}
