using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter.BLL
{
    public interface ITemperatureService
    {
        Task<double> TemperatureConverter(double tempValue, string oldType, string currentType);
    }
}
