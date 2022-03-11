using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI shipCodeText;
    public TMP_InputField searchCodeField;
    public Button searchCodeButton;
    public Button nextButton;
    public Button previousButton;
    public Button showCodesButton;

    public List<Material> capsuleColors;
    public List<Material> metalColors;
    public List<Material> neonColors;

    public ColourShip ship;

    int permutationCode = 0;

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
        int value = int.Parse(searchCodeField.text);
        Debug.Log(value);

        int lucesIndex = value % neonColors.Count;
        int soporteIndex = Mathf.FloorToInt(value / neonColors.Count) % metalColors.Count;
        int naveIndex = Mathf.FloorToInt(value / (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsulaIndex = Mathf.FloorToInt(value / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsulaIndex];
        ship.shipMaterial = metalColors[naveIndex];
        ship.holderMaterial = metalColors[soporteIndex];
        ship.lightsMaterial = neonColors[lucesIndex];
        ship.ColourShipNow();
    }

    void NextCombination()
    {

    }

    void PreviousCombination()
    { 
    
    }

    void ShowCodes()
    {
        ship.capsuleMaterial = capsuleColors[0];
        ship.shipMaterial = metalColors[0];
        ship.holderMaterial = metalColors[0];
        ship.lightsMaterial = neonColors[1];
        ship.ColourShipNow();
        StartCoroutine(NextColor());
    }

    IEnumerator NextColor()
    {
        yield return new WaitForSeconds(0.05f);
        int lightsIndex = permutationCode % neonColors.Count;
        int holderIndex = Mathf.FloorToInt(permutationCode / neonColors.Count) % metalColors.Count;
        int shipIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsuleIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        permutationCode++ ;
        shipCodeText.text = permutationCode.ToString();
        StartCoroutine(NextColor());
    }

    
}
