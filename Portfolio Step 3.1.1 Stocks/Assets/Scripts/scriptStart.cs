using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptStart : MonoBehaviour
{

	public GameObject MainCanvas; //Object where the main scripts are
	public GameObject StockPanelGO;
	public GameObject playerPanelGO;

	public Text cashflowRealEstateText;
	public Text cashflowBondsText;

    // Start is called before the first frame update
    void Start()
    {
		MainCanvas.GetComponent<infoStockSector>();
		playerPanelGO.GetComponent<portfolio>().sectorSharePortfolio();
		cashflowRealEstateText.text = "Real Estate/Month: " + 0;
		cashflowBondsText.text = "Bonds/Year: " + 0;
    }

    
}
