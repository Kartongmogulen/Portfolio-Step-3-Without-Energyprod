using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stock : MonoBehaviour
{

	public string sectorName;

	public float divPolicyChangeDiv;
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float divPayout;


	public float EPSnow;
	public float EPSGrowthMin;
	public float EPSGrowthMax;

	public List<float> StockPrice;
	public float priceNow;

	public void updatePriceNow(float priceNow)
	{
		StockPrice.Add(priceNow);
	}

}
