using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;
using System.Xml.Serialization;

public class DialogSystem
{
    static DialogSystem dialogSystem;

    private String XMLFileName;
    private bool isDialogStarting = false;

    public DialogSystem ()
    {
        XMLFileName = "Assets/resources/files/text.xml";
    }

    public static DialogSystem GetDialogSystem()
    {
        if (dialogSystem == null)
        {
            dialogSystem = new DialogSystem();
            return dialogSystem;
        }
        else
        {
            return dialogSystem;
        }
    }

    public List<string> GetDialogById(string id)
    {
        XmlTextReader reader = new XmlTextReader(XMLFileName);
        List<string> texts   = new List<string>();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == id)
            {
                int i = 0;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == id)
                    {
                        break;
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == ("text_" + i))
                    {
                        texts.Add(reader.ReadElementContentAsString());
                        i++;
                    }
                }
            }
        }
        reader.Close();

        return texts;
    }

    public bool GetSetDialogStart
    {
        get
        {
            return isDialogStarting;
        }
        set
        {
            isDialogStarting = value;
        }
        
    }
}
