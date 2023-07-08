using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceChoice : MonoBehaviour
{
    private OptionShower optionShower;

    public string text1;
    public string text2;
    public string load1;
    public string load2;

    // Start is called before the first frame update
    void Start()
    {
        optionShower = GameObject.FindObjectOfType<OptionShower>();

        optionShower.OpenNav(text1, text2, load1, load2);
    }
}
