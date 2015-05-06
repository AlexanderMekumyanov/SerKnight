using UnityEngine;
using System.Collections;

public class ScriptSystem
{

    static ScriptSystem instance;

    public ScriptSystem()
    {

    }

    public static ScriptSystem GetInstance()
    {
        if (instance != null)
        {
            return instance;
        }
        return instance = new ScriptSystem();
    }

    public void SetScriptCommand(GameObject doingObject, string scriptCommand, string[] arrayOfParameter)
    {
        ScriptParameter scriptParameter;
        scriptParameter.ScriptCommand = scriptCommand;
        scriptParameter.ArrayOfParameter = arrayOfParameter;
        doingObject.SendMessage("ReceiveScriptFlag", scriptParameter);
    }
}
