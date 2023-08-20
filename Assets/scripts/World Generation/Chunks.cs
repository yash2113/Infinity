using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{
    public float chunkLength;

    public Chunks ShowChunk()
    {
        transform.gameObject.BroadcastMessage("OnShowCHunks", SendMessageOptions.DontRequireReceiver);
        gameObject.SetActive(true);
        return this;
    }

    public Chunks HideChunk()
    {
        gameObject.SetActive(false);
        return this;
    }

}
