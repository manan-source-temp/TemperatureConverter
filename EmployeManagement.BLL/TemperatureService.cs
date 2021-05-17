using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace TemperatureConverter.BLL
{
    public class TemperatureService : ITemperatureService
    {



        public async Task<double> TemperatureConverter(double temperatureValue, string oldTemperatureType, string currenTemperatureType)
        {
            double result = 0.0;

            

            if (string.IsNullOrEmpty(oldTemperatureType) || string.IsNullOrEmpty(currenTemperatureType))
            {
                return 1;
            }

            if ((oldTemperatureType.ToLower() != "k" && oldTemperatureType.ToLower() != "c" && oldTemperatureType.ToLower() != "f")
                || (currenTemperatureType.ToLower() != "k" && currenTemperatureType.ToLower() != "c" && currenTemperatureType.ToLower() != "f"))
            {
                return 2;
            }


            result = TemperatureConverterCalculation(temperatureValue, oldTemperatureType, currenTemperatureType);
            return result;
        }

        private double TemperatureConverterCalculation(double tempValue, string oldTemperatureType, string currenTemperatureType)
        {
            double cal = 0.0;


            if (oldTemperatureType.ToLower() == "c" && currenTemperatureType.ToLower() == "f")
            {
                cal = (((0.9 / 0.5) * tempValue) + 32);
            }
            else if (oldTemperatureType.ToLower() == "f" && currenTemperatureType.ToLower() == "c")
            {
                cal = ((0.5 / 0.9) * (tempValue - 32));
            }
            else if (oldTemperatureType.ToLower() == "f" && currenTemperatureType.ToLower() == "k")
            {
                cal = ((tempValue - 32) / 1.8) + 273.15;
            }
            else if (oldTemperatureType.ToLower() == "k" && currenTemperatureType.ToLower() == "f")
            {
                cal = ((tempValue - 273.15) * 1.8) + 32;
            }
            else if (oldTemperatureType.ToLower() == "k" && currenTemperatureType.ToLower() == "c")
            {
                cal = tempValue - 273.15;
            }
            else if (oldTemperatureType.ToLower() == "c" && currenTemperatureType.ToLower() == "k")
            {
                cal = tempValue + 273.15; ;
            }

            return cal;
        }
    }
}
