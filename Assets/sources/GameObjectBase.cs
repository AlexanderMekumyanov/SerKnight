using UnityEngine;
using System.Collections;

public struct ScriptParameter
{
    public string ScriptCommand;
    public int[]  ArrayOfParameter;
}

public class GameObjectBase : MonoBehaviour
{
    protected bool   scriptFlag;
    protected string scriptCommand;
    protected int[]  arrayOfParameter;

    public void ReceiveScriptFlag(ScriptParameter scriptParameter)
    {
        scriptFlag            = true;
        this.scriptCommand    = scriptParameter.ScriptCommand;
        this.arrayOfParameter = scriptParameter.ArrayOfParameter;
    }
}
