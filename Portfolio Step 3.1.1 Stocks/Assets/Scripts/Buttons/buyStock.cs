using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyStock : MonoBehaviour
//Script för när man väljer att köpa en aktie
{

	public int activeSector; //Kontrollera i scriptet chooseStockSector så sector-indexeringen är rätt när fler kategorier läggs till
	public int activeCompany;
	public int amountOrder;
	public float orderValue;
	public float moneyPlayer;
	public float stockPrice;

	public GameObject stockGO;
	public chooseStockSector ChooseStockSector;
	//public GameObject PortfolioStock;

	public InputField inputAmountOrder;

	//Innan Steg 3.1
	public GameObject PanelStockSector;
	public GameObject playerPanelGO;
	public GameObject BottomPanelGO;

	public Text priceUtiText;
	public Text priceFinText;
	public Text priceTechText;

	//Vad kostar en Utilities aktie?
	public float priceUti;

	//Vad kostar en Finance aktie?
	public float priceFin;

	//Vad kostar en Tech aktie?
	public float priceTech;

	//Vad kostar en Index aktie?
	public float indexNAV;
	public float amountOrderIndex;
	public float indexSharesAdd;

	//Har jag tillräckligt med pengar?
	public GameObject MainCanvas;
	public float moneyBeforeBuy;

	public InputField inputAmountIndex;

	//Addera en till aktie till portföljen. Scriptet "portfolio"

	//Ta bort kostnaden för aktien av mina pengar. Funktion i scriptet "totalCash".

	void Awake()
	{
		ChooseStockSector = GetComponent<chooseStockSector> ();
		//PortfolioStock = stockGO.GetComponent<portfolioStock> ();

	}

	public void buyStocks(){
		//Identifiera sektor
		activeSector = ChooseStockSector.activeSector;

		//Identifera vilket företag (nr)
		if (activeSector == 1) {
			activeCompany = stockGO.GetComponent<chooseUtiCompany> ().activeCompany;
			stockPrice = stockGO.GetComponent<chooseUtiCompany> ().activeCompanyPrice;

		}

		if (activeSector == 2) {
			activeCompany=stockGO.GetComponent<chooseTechCompany> ().activeCompany;
			stockPrice = stockGO.GetComponent<chooseTechCompany> ().activeCompanyPrice;
		}

		if (activeSector == 3) {
			activeCompany=stockGO.GetComponent<chooseMaterialCompany> ().activeCompany;
			stockPrice = stockGO.GetComponent<chooseMaterialCompany> ().activeCompanyPrice;
		}

		//Identifiera antalet spelaren vill köpa
		amountOrder = int.Parse (inputAmountOrder.text);	

		//Har spelaren tillräckligt med pengar?
		moneyPlayer = playerPanelGO.GetComponent<totalCash>().moneyNow;

		orderValue = amountOrder*stockPrice;

		if (moneyPlayer >= orderValue) 
		
		{
			//Subtrahera pengar
			playerPanelGO.GetComponent<totalCash>().moneyNow = moneyPlayer - orderValue;
			moneyPlayer = playerPanelGO.GetComponent<totalCash>().moneyNow;

			//Addera antalet aktier
			if (activeSector == 1) {
				stockGO.GetComponent<portfolioStock> ().addUtiShares (amountOrder, activeCompany);
				stockGO.GetComponent<portfolioStock> ().utiTotalInvest [activeCompany] += orderValue;

			}

			if (activeSector == 2) {
				stockGO.GetComponent<portfolioStock> ().addTechShares (amountOrder, activeCompany);
				stockGO.GetComponent<portfolioStock> ().techTotalInvest [activeCompany] += orderValue;
			}

			if (activeSector == 3) {
				stockGO.GetComponent<portfolioStock> ().addMaterialShares (amountOrder, activeCompany);
				stockGO.GetComponent<portfolioStock> ().materialsTotalInvest [activeCompany] += orderValue;
			}

			playerPanelGO.GetComponent<totalCash>().updateMoney();
		}
			
		stockGO.GetComponent<portfolioStock> ().valuePortfolio(); //Uppdaterar värdet av portfölj



	}
}
	/*

	//---------------------------------------------
	//INNAN STEG 3.1

	public void buyUtilitiesOne (){
		priceUti = PanelStockSector.GetComponent<priceChange>().utiStockPriceNow;
		priceUtiText.text = "Price: " + priceUti;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceUti) {
			playerPanelGO.GetComponent<portfolio>().addUtiAmount (1);
			playerPanelGO.GetComponent<totalCash>().buyStockUti (1);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyUtilitiesTen (){
		priceUti = PanelStockSector.GetComponent<priceChange>().utiStockPriceNow;
		priceUtiText.text = "Price: " + priceUti;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceUti*10) {
			playerPanelGO.GetComponent<portfolio>().addUtiAmount (10);
			playerPanelGO.GetComponent<totalCash>().buyStockUti (10);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyUtilitiesHundred (){
		priceUti = PanelStockSector.GetComponent<priceChange>().utiStockPriceNow;
		priceUtiText.text = "Price: " + priceUti;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceUti*100) {
			playerPanelGO.GetComponent<portfolio>().addUtiAmount (100);
			playerPanelGO.GetComponent<totalCash>().buyStockUti (100);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyFinanceOne (){
		priceFin= PanelStockSector.GetComponent<priceChange>().finStockPriceNow;
		priceFinText.text = "Price: " + priceFin;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceFin) {
			playerPanelGO.GetComponent<portfolio>().addFinAmount (1);
			playerPanelGO.GetComponent<totalCash>().buyStockFin (1);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyFinanceTen (){
		priceFin= PanelStockSector.GetComponent<priceChange>().finStockPriceNow;
		priceFinText.text = "Price: " + priceFin;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceFin*10) {
			playerPanelGO.GetComponent<portfolio>().addFinAmount (10);
			playerPanelGO.GetComponent<totalCash>().buyStockFin (10);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyFinanceHundred (){
		priceFin= PanelStockSector.GetComponent<priceChange>().finStockPriceNow;
		priceFinText.text = "Price: " + priceFin;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceFin*100) {
			playerPanelGO.GetComponent<portfolio>().addFinAmount (100);
			playerPanelGO.GetComponent<totalCash>().buyStockFin (100);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyTechOne (){
		priceTech= PanelStockSector.GetComponent<priceChange>().techStockPriceNow;
		priceTechText.text = "Price: " + priceTech;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceTech) {
			playerPanelGO.GetComponent<portfolio>().addTechAmount (1);
			playerPanelGO.GetComponent<totalCash>().buyStockTech (1);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyTechTen (){
		priceTech= PanelStockSector.GetComponent<priceChange>().techStockPriceNow;
		priceTechText.text = "Price: " + priceTech;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceTech*10) {
			playerPanelGO.GetComponent<portfolio>().addTechAmount (10);
			playerPanelGO.GetComponent<totalCash>().buyStockTech (10);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyTechHundred (){
		priceTech= PanelStockSector.GetComponent<priceChange>().techStockPriceNow;
		priceTechText.text = "Price: " + priceTech;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		if (moneyBeforeBuy >= priceTech*100) {
			playerPanelGO.GetComponent<portfolio>().addTechAmount (100);
			playerPanelGO.GetComponent<totalCash>().buyStockTech (100);
			playerPanelGO.GetComponent<portfolio>().GAV();
		}
	}

	public void buyIndex (){
		indexNAV = BottomPanelGO.GetComponent<indexFunds>().NAVIndexFund;
		moneyBeforeBuy = playerPanelGO.GetComponent<totalCash>().moneyNow;

		amountOrderIndex = float.Parse (inputAmountIndex.text);	

		indexSharesAdd = amountOrderIndex/indexNAV;

		if (moneyBeforeBuy >= amountOrderIndex) {
			playerPanelGO.GetComponent<portfolio>().addIndexAmount (indexSharesAdd, amountOrderIndex);
			playerPanelGO.GetComponent<totalCash>().buyStockIndex(amountOrderIndex);

		}
	}
}

*/