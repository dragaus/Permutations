using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI shipCodeText;
    public TMP_InputField shearchCodeField;
    public Button searchCodeButton;
    public Button nextButton;
    public Button previousButton;
    public Button showCodesButton;

    // Start is called before the first frame update
    void Start()
    {
        searchCodeButton.onClick.AddListener(SearchCode);
        nextButton.onClick.AddListener(NextCombination);
        previousButton.onClick.AddListener(PreviousCombination);
        showCodesButton.onClick.AddListener(ShowCodes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SearchCode()
    { 
    
    }

    void NextCombination()
    {

    }

    void PreviousCombination()
    { 
    
    }

    void ShowCodes()
    { 
        
    }
}
