using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200051E RID: 1310
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040049E9 RID: 18921
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x040049EA RID: 18922
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x040049EB RID: 18923
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
