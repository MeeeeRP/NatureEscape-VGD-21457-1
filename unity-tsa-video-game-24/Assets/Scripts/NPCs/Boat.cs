using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    // [SerializeField]
    public int[] logWeightArray = new int[4];

    public int[] AssignWeight(int logNum, int weight) {
        logWeightArray[logNum]=weight;
        Debug.Log(logWeightArray.ToString());
        return logWeightArray;
    }

}
