using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    // [SerializeField]
    public static int[] logWeightArray = new int[4];

    public static int[] AssignWeight(int logNum, int weight) {
        logWeightArray[logNum]=weight;
        foreach(var item in logWeightArray)
{
        print(item.ToString()+" ,");
}
        Debug.Log(logWeightArray);
        return logWeightArray;
    }

}
