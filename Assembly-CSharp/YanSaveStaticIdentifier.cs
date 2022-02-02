using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000510 RID: 1296
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048ED RID: 18669
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040048EE RID: 18670
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040048EF RID: 18671
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
