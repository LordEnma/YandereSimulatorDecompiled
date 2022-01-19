using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000547 RID: 1351
	[ExecuteInEditMode]
	public class CombineMeshes : MonoBehaviour
	{
		// Token: 0x06002280 RID: 8832 RVA: 0x001EDC22 File Offset: 0x001EBE22
		private void CombineButtonHandler()
		{
			this.CombineChildMeshes();
		}

		// Token: 0x06002281 RID: 8833 RVA: 0x001EDC2C File Offset: 0x001EBE2C
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

		// Token: 0x04004A6F RID: 19055
		[InspectorButton("CombineButtonHandler")]
		public bool combineChildMeshes;
	}
}
