using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class divPolicy : MonoBehaviour
{
    //Script för att uppdatera utifrån div policy

	public GameObject mainCanvasGO;

	public float utiDivPolMax;
	public float utiDivPolMin;
	public float utiDivPolDivIncrease;
	public float utiDivPayoutRatioBefore;
	public float utiDivPayoutBefore;
	public float utiDivPayoutRatioAfter;
	public float utiDivPayoutAfter;
	public float utiEPSNow;

	public float finDivPolMax;
	public float finDivPolMin;
	public float finDivPolDivIncrease;
	public float finDivPayoutRatioBefore;
	public float finDivPayoutBefore;
	public float finDivPayoutRatioAfter;
	public float finDivPayoutAfter;
	public float finEPSNow;

	public float techDivPolMax;
	public float techDivPolMin;
	public float techDivPolDivIncrease;
	public float techDivPayoutRatioBefore;
	public float techDivPayoutBefore;
	public float techDivPayoutRatioAfter;
	public float techDivPayoutAfter;
	public float techEPSNow;

	public void endOfYearUpdate ()
	{
		utiDivPayoutBefore = mainCanvasGO.GetComponent<infoStockSector>().divUtiNow;
		utiDivPayoutRatioBefore = mainCanvasGO.GetComponent<infoStockSector>().divUtiShare;
		utiDivPolDivIncrease = mainCanvasGO.GetComponent<infoStockSector>().divPolRaiseUti;
		utiEPSNow = mainCanvasGO.GetComponent<infoStockSector>().utiEPSNow;

		utiDivPolMax = mainCanvasGO.GetComponent<infoStockSector>().divPolMaxUti;
		utiDivPolMin = mainCanvasGO.GetComponent<infoStockSector>().divPolMinUti;

		utiDivPayoutRatioAfter = utiDivPayoutRatioBefore*(1+utiDivPolDivIncrease);

		finDivPayoutBefore = mainCanvasGO.GetComponent<infoStockSector>().divFinNow;
		finDivPayoutRatioBefore = mainCanvasGO.GetComponent<infoStockSector>().divFinShare;
		finDivPolDivIncrease = mainCanvasGO.GetComponent<infoStockSector>().divPolRaiseFin;
		finEPSNow = mainCanvasGO.GetComponent<infoStockSector>().finEPSNow;

		finDivPolMax = mainCanvasGO.GetComponent<infoStockSector>().divPolMaxFin;
		finDivPolMin = mainCanvasGO.GetComponent<infoStockSector>().divPolMinFin;

		finDivPayoutRatioAfter = finDivPayoutRatioBefore*(1+finDivPolDivIncrease);

		techDivPayoutBefore = mainCanvasGO.GetComponent<infoStockSector>().divTechNow;
		techDivPayoutRatioBefore = mainCanvasGO.GetComponent<infoStockSector>().divTechShare;
		techDivPolDivIncrease = mainCanvasGO.GetComponent<infoStockSector>().divPolRaiseTech;
		techEPSNow = mainCanvasGO.GetComponent<infoStockSector>().techEPSNow;

		techDivPolMax = mainCanvasGO.GetComponent<infoStockSector>().divPolMaxTech;
		techDivPolMin = mainCanvasGO.GetComponent<infoStockSector>().divPolMinTech;

		techDivPayoutRatioAfter = techDivPayoutRatioBefore*(1+techDivPolDivIncrease);


		//Utdelningstak
		if (utiDivPayoutRatioAfter <= utiDivPolMax*100 && utiDivPayoutRatioAfter >= utiDivPolMin*100) //Utrymme att höja utdelning
		{
		utiDivPayoutAfter = utiDivPayoutBefore*(1+utiDivPolDivIncrease);
	
		}

		if (finDivPayoutRatioAfter <= finDivPolMax*100 && finDivPayoutRatioAfter >= finDivPolMin*100) //Utrymme att höja utdelning
		{
			finDivPayoutAfter = finDivPayoutBefore*(1+finDivPolDivIncrease);
		}

		if (techDivPayoutRatioAfter <= techDivPolMax*100 && techDivPayoutRatioAfter >= techDivPolMin*100) //Utrymme att höja utdelning
		{
			techDivPayoutAfter = techDivPayoutBefore*(1+techDivPolDivIncrease);
	
		}

		if (utiDivPayoutRatioAfter > utiDivPolMax*100)
		{
			utiDivPayoutAfter = utiEPSNow*utiDivPolMax;

		}

		if (finDivPayoutRatioAfter > finDivPolMax*100)
		{
			finDivPayoutAfter = finEPSNow*finDivPolMax;
		}

		if (techDivPayoutRatioAfter > techDivPolMax*100)
		{
			techDivPayoutAfter = techEPSNow*techDivPolMax;
		}

		//Utdelningsgolv
		if (utiDivPayoutRatioAfter < utiDivPolMin*100)
		{
			utiDivPayoutAfter = utiEPSNow*utiDivPolMin;
		}

		if (finDivPayoutRatioAfter < finDivPolMin*100)
		{
			finDivPayoutAfter = finEPSNow*finDivPolMin;
		}

		if (techDivPayoutRatioAfter < techDivPolMin*100)
		{
			techDivPayoutAfter = techEPSNow*techDivPolMin;
		}

		mainCanvasGO.GetComponent<infoStockSector>().yearsOfDivRaise(utiDivPayoutBefore, utiDivPayoutAfter, 1);
		mainCanvasGO.GetComponent<infoStockSector>().yearsOfDivRaise(finDivPayoutBefore, finDivPayoutAfter, 2);
		mainCanvasGO.GetComponent<infoStockSector>().yearsOfDivRaise(techDivPayoutBefore, techDivPayoutAfter, 3);

		utiDivPayoutBefore = utiDivPayoutAfter;
		finDivPayoutBefore = finDivPayoutAfter;
		techDivPayoutBefore = techDivPayoutAfter;
	}


}
