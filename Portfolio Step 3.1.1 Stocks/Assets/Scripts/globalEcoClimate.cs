using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalEcoClimate : MonoBehaviour
{
	public GameObject MainCanvasGO;

	//Script that describes the general global economical climate

	public int globalEcoClimateValueNow;
	public int StartglobalEcoClimateValue;
	public float[] probGlobalEcoClimate;
	public float[] bnpIncrease; //Hur ekonomin utvecklas beronde på ekonomiska klimatet;

	public Text globalEcoClimateText;
	public Text probDiffEcoClimateText;
	//public Text Test;

	//variables for globalEcoChange function
	float probEcoBear;
	float probEcoSame;
	float probEcoBull;
	float randomNum;
	public float changeProbEcoClimate;

	// Start is called before the first frame update
	void Start()
	{
		globalEcoClimateValueNow = StartglobalEcoClimateValue;
		globalEcoClimateText.text = "Global Economical Climate: " + StartglobalEcoClimateValue;

	}

	public void globalEcoChangeZero()
	{
		//GLobalClimate = 3;
		{
			probEcoBear = probGlobalEcoClimate[0] + probGlobalEcoClimate[1] + probGlobalEcoClimate[2]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[3]; //prob for same Eco-climate. 
			probEcoBull = probGlobalEcoClimate[4] + probGlobalEcoClimate[5] + probGlobalEcoClimate[6]; //prob for Eco downturn

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[3]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}
			if(randomNum>(probEcoBear+probEcoSame)){
				globalEcoClimateValueNow++;

			}

		}

		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}

	public void globalEcoChangePlusOne()
	{
		//GLobalClimate = 4;
		{

			//STEP 1
			probEcoBear = probGlobalEcoClimate[0] + probGlobalEcoClimate[1] + probGlobalEcoClimate[2] + probGlobalEcoClimate[3]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[4]; //prob for same Eco-climate. 
			probEcoBull = probGlobalEcoClimate[5] + probGlobalEcoClimate[6]; //prob for Eco downturn

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[4]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}
			if(randomNum>(probEcoBear+probEcoSame)){
				globalEcoClimateValueNow++;

			}

		}

		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}

	public void globalEcoChangePlusTwo()
	{
		//GLobalClimate = 5;
		{
			//STEP 2
			probGlobalEcoClimate[0] = probGlobalEcoClimate[0] + changeProbEcoClimate/2; //Adjust prob for a negative downturn
			probGlobalEcoClimate[6] = probGlobalEcoClimate[6] - changeProbEcoClimate/2; //Adjust prob for a positive downturn

			probEcoBear = probGlobalEcoClimate[0] + probGlobalEcoClimate[1] + probGlobalEcoClimate[2] + probGlobalEcoClimate[3] + probGlobalEcoClimate[4]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[5]; //prob for same Eco-climate. 
			probEcoBull = probGlobalEcoClimate[6]; //prob for Eco downturn

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[5]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}
			if(randomNum>(probEcoBear+probEcoSame)){
				globalEcoClimateValueNow++;

			}

		}

		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}

	public void globalEcoChangePlusThree()
	{
		//GLobalClimate = 6;
		{

			//STEP 2
			probGlobalEcoClimate[0] = probGlobalEcoClimate[0] - changeProbEcoClimate; //Adjust prob for a negative downturn
			probGlobalEcoClimate[6] = probGlobalEcoClimate[6] + changeProbEcoClimate; //Adjust prob for a positive downturn

			probEcoBear = probGlobalEcoClimate[0] + probGlobalEcoClimate[1] + probGlobalEcoClimate[2] + probGlobalEcoClimate[3] + probGlobalEcoClimate[4] + probGlobalEcoClimate[5]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[6]; //prob for same Eco-climate. 
			probEcoBull = 0;

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[6]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}

		}

		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}

	public void globalEcoChangeNegOne()
	{
		//GLobalClimate = 2;
		{

			probEcoBear = probGlobalEcoClimate[0] + probGlobalEcoClimate[1]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[2] ; //prob for same Eco-climate. 
			probEcoBull = probGlobalEcoClimate[3] + probGlobalEcoClimate[4] +probGlobalEcoClimate[5] + probGlobalEcoClimate[6]; //prob for Eco downturn

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[2]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}
			if(randomNum>(probEcoBear+probEcoSame)){
				globalEcoClimateValueNow++;

			}

		}
		//Test.text = "Bear: " + randomNum;
		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}

	public void globalEcoChangeNegTwo()
	{
		//GLobalClimate = 1;
		{
			//STEP 2
			probGlobalEcoClimate[0] = probGlobalEcoClimate[0] - changeProbEcoClimate/2; //Adjust prob for a negative downturn
			probGlobalEcoClimate[6] = probGlobalEcoClimate[6] + changeProbEcoClimate/2; //Adjust prob for a positive downturn

			probEcoBear = probGlobalEcoClimate[0]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[1] ; //prob for same Eco-climate. 
			probEcoBull = probGlobalEcoClimate[2] + probGlobalEcoClimate[3] + probGlobalEcoClimate[4] +probGlobalEcoClimate[5] + probGlobalEcoClimate[6]; //prob for Eco downturn

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[1]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}
			if(randomNum>(probEcoBear+probEcoSame)){
				globalEcoClimateValueNow++;

			}

		}
		//Test.text = "Bear: " + randomNum;
		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}

	public void globalEcoChangeNegThree()
	{
		//GLobalClimate = 0;
		{
			//STEP 2
			probGlobalEcoClimate[0] = probGlobalEcoClimate[0] - changeProbEcoClimate; //Adjust prob for a negative downturn
			probGlobalEcoClimate[6] = probGlobalEcoClimate[6] + changeProbEcoClimate; //Adjust prob for a positive downturn

			//probEcoBear = propGlobalEcoClimate[0]; //prob for Eco downturn
			probEcoSame = probGlobalEcoClimate[0] ; //prob for same Eco-climate. 
			probEcoBull = probGlobalEcoClimate[1] + probGlobalEcoClimate[2] + probGlobalEcoClimate[3] + probGlobalEcoClimate[4] +probGlobalEcoClimate[5] + probGlobalEcoClimate[6]; //prob for Eco downturn
			probEcoBear = 0;

			//MainCanvasGO.GetComponent<Index>().indexChange (bnpIncrease[0]);

			randomNum = Random.value;

			if(randomNum<probEcoBear){
				globalEcoClimateValueNow--;

			}
			if(randomNum>(probEcoBear+probEcoSame)){
				globalEcoClimateValueNow++;

			}

		}
		//Test.text = "Bear: " + randomNum;
		globalEcoClimateText.text = "Global Economical Climate: " + globalEcoClimateValueNow;
		probDiffEcoClimateText.text = "Bear: " + probEcoBear*100 + "%" + "     " + "Same: " + probEcoSame*100 + "%" + "     " + "Bull: " + probEcoBull*100 + "%";

	}


}
