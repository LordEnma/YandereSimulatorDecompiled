using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050F RID: 1295
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048DB RID: 18651
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048DC RID: 18652
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048DD RID: 18653
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
