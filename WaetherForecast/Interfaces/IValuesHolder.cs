using System;

namespace WaetherForecast.Interfaces
{
    public interface IValuesHolder
    {
        public void CreateTemperature(DateTime dateTime, int temp);
        public int[] ReadTemperature(DateTime startTime, DateTime endTime);
        public void UpdateTemperature(DateTime dateTime, int temp);
        public void DeleteTemperature(DateTime startTime, DateTime endTime);
    }
}
