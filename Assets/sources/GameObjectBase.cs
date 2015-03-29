using UnityEngine;
using System.Collections;

public struct ScriptParameter
{
    public string   ScriptCommand;
    public string[] ArrayOfParameter;
}

public class GameObjectBase : MonoBehaviour
{
    protected bool     scriptFlag;
    protected string   scriptCommand;
    protected string[] arrayOfParameter;

    public void ReceiveScriptFlag(ScriptParameter scriptParameter)
    {
        scriptFlag            = true;
        this.scriptCommand    = scriptParameter.ScriptCommand;
        this.arrayOfParameter = scriptParameter.ArrayOfParameter;
    }
}
