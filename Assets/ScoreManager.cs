using UnityEngine;
using System.Collections;
using UnityEngine.UI; // <---- 追加1

public class ***: MonoBehaviour
{
    private Text targetText; // <---- 追加2

void hoge()
{

    this.targetText = this.GetComponent<Text>(); // <---- 追加3
    this.targetText.text = "ChangeText"; // <---- 追加4

	}
}
