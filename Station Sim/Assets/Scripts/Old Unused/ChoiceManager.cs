using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceManager : MonoBehaviour
{

    //Houdt keuzes/properties zoals tijd, kosten etc bij, zodat deze aan het ''einde'' gedisplayed kunnen worden
    private int _waarde1;
    private int _waarde2;
   
    [SerializeField] private TextMeshProUGUI _waarde1Value;
    [SerializeField] private TextMeshProUGUI _waarde2Value;

    // Start is called before the first frame update
    void Start()
    {
        _waarde1 = 0;
        _waarde2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResultsPanel()
    {
        //misschien weer fadeout to black, waarden tonen op panel, panel activeren
        
    }


    public void Choice1()
    {
        _waarde1 += 200;
        _waarde2 -= 20;
        Debug.Log("values updated");
    }

    public void Choice2()
    {
        _waarde1 -= 400;
        _waarde2 += 2000;
    }

    public void FinalChoice()
    {
        //set ints to text
        //activate results panel
        _waarde1Value.text = _waarde1.ToString();
        //_waarde1Value.text = "test";
        _waarde2Value.text = _waarde2.ToString();
        Debug.Log("values displayed SYKE");

    }
}
