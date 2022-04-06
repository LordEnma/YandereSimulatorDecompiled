using System;

// Token: 0x02000400 RID: 1024
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C26 RID: 7206 RVA: 0x00148E8B File Offset: 0x0014708B
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x00148EC9 File Offset: 0x001470C9
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x0400318B RID: 12683
	public bool befriendConversation;

	// Token: 0x0400318C RID: 12684
	public bool event1;

	// Token: 0x0400318D RID: 12685
	public bool event2;

	// Token: 0x0400318E RID: 12686
	public bool kidnapConversation;

	// Token: 0x0400318F RID: 12687
	public bool livingRoom;
}
