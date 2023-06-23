using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckingAnswer : MonoBehaviour
{
    public TMP_Text correctOrNot;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticVariable.statischRichtigFalsch == true)
            correctOrNot.text = "Richtig!";
        else
            correctOrNot.text = "Falsch!";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
