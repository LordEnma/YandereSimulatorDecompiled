using System;
using System.Xml.Serialization;

// Token: 0x0200040A RID: 1034
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x040031E4 RID: 12772
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x040031E5 RID: 12773
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x040031E6 RID: 12774
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x040031E7 RID: 12775
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x040031E8 RID: 12776
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x040031E9 RID: 12777
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x040031EA RID: 12778
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x040031EB RID: 12779
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x040031EC RID: 12780
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x040031ED RID: 12781
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x040031EE RID: 12782
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x040031EF RID: 12783
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x040031F0 RID: 12784
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x040031F1 RID: 12785
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x040031F2 RID: 12786
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x040031F3 RID: 12787
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x040031F4 RID: 12788
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x040031F5 RID: 12789
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x040031F6 RID: 12790
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x040031F7 RID: 12791
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x040031F8 RID: 12792
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
