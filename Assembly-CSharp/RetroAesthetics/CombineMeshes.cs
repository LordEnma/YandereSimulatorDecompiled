using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000547 RID: 1351
	[ExecuteInEditMode]
	public class CombineMeshes : MonoBehaviour
	{
		// Token: 0x06002289 RID: 8841 RVA: 0x001EE9DE File Offset: 0x001ECBDE
		private void CombineButtonHandler()
		{
			this.CombineChildMeshes();
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001EE9E8 File Offset: 0x001ECBE8
		public virtual void CombineChildMeshes()
		{
			Vector3 position = base.transform.position;
			base.transform.position = Vector3.zero;
			MeshFilter[] componentsInChildren = base.GetComponentsInChildren<MeshFilter>();
			CombineInstance[] array = new CombineInstance[componentsInChildren.Length];
			Material material = null;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				array[i].mesh = componentsInChildren[i].sharedMesh;
				array[i].transform = componentsInChildren[i].transform.localToWorldMatrix;
				Renderer component = componentsInChildren[i].gameObject.GetComponent<Renderer>();
				if (component != null)
				{
					component.enabled = false;
				}
				if (material == null && component.sharedMaterial != null)
				{
					material = component.sharedMaterial;
				}
			}
			MeshFilter meshFilter = base.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			meshFilter.mesh = new Mesh();
			meshFilter.sharedMesh.CombineMeshes(array, true, true);
			if (base.GetComponent<MeshRenderer>() == null)
			{
				base.gameObject.AddComponent<MeshRenderer>().sharedMaterial = material;
			}
			base.transform.position = position;
		}

		// Token: 0x04004A83 RID: 19075
		[InspectorButton("CombineButtonHandler")]
		public bool combineChildMeshes;
	}
}
