using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アニメーション再生用スクリプト
public class Wood : MonoBehaviour
{
    public void CutWood()
    {
        woodAnim.SetTrigger("Cut");
    }
}
