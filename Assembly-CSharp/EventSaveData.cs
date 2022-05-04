using System;

// Token: 0x02000401 RID: 1025
[Serializable]
public class EventSaveData
{
	// Token: 0x06001C31 RID: 7217 RVA: 0x00149AA3 File Offset: 0x00147CA3
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

	// Token: 0x06001C32 RID: 7218 RVA: 0x00149AE1 File Offset: 0x00147CE1
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x040031A5 RID: 12709
	public bool befriendConversation;

	// Token: 0x040031A6 RID: 12710
	public bool event1;

	// Token: 0x040031A7 RID: 12711
	public bool event2;

	// Token: 0x040031A8 RID: 12712
	public bool kidnapConversation;

	// Token: 0x040031A9 RID: 12713
	public bool livingRoom;
}
