using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A8 RID: 1192
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F63 RID: 8035 RVA: 0x001B93A4 File Offset: 0x001B75A4
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x001B93B8 File Offset: 0x001B75B8
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x001B9418 File Offset: 0x001B7618
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x001B9454 File Offset: 0x001B7654
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x001B9458 File Offset: 0x001B7658
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x001B94BC File Offset: 0x001B76BC
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004175 RID: 16757
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004176 RID: 16758
	private const string XML_Element = "Element";
}
