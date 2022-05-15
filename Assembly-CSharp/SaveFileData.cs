using System;
using System.Xml.Serialization;

// Token: 0x02000410 RID: 1040
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400322F RID: 12847
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x04003230 RID: 12848
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x04003231 RID: 12849
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x04003232 RID: 12850
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x04003233 RID: 12851
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x04003234 RID: 12852
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003235 RID: 12853
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003236 RID: 12854
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003237 RID: 12855
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003238 RID: 12856
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003239 RID: 12857
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x0400323A RID: 12858
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x0400323B RID: 12859
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x0400323C RID: 12860
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x0400323D RID: 12861
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x0400323E RID: 12862
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x0400323F RID: 12863
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x04003240 RID: 12864
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x04003241 RID: 12865
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x04003242 RID: 12866
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x04003243 RID: 12867
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
