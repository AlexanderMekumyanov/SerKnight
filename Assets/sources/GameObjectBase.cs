using UnityEngine;
using System.Collections;

public class GameObjectBase : MonoBehaviour
{
    protected bool scriptFlag;

    public void ReceiveScriptFlag()
    {
        scriptFlag = true;
    }
}
