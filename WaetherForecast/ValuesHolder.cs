using System;
using System.Collections.Generic;
using System.Linq;
using WaetherForecast.Interfaces;

namespace WaetherForecast
{
    public class ValuesHolder : IValuesHolder
    {
        private readonly SortedList<DateTime, int> _weatherHolder = new SortedList<DateTime, int>();
        public ValuesHolder()
        {
            int startTemperature = 25;

            for (int i = 0; i < 10; i++)
            {
                _weatherHolder.Add(DateTime.Parse(DateTime.Now.AddDays(i).ToShortDateString()), (startTemperature + i));
            }
        }

        public void CreateTemperature(DateTime dateTime, int temperature)
        {
            _weatherHolder.Add(dateTime, temperature);
        }

        public int[] ReadTemperature(DateTime startTime, DateTime endTime)
        {
            var startIndex = _weatherHolder.IndexOfKey(startTime);
            var endIndex = _weatherHolder.IndexOfKey(endTime);
            var temperatureList = new List<int>();
            foreach (var index in Enumerable.Range(startIndex, endIndex))
            {
                temperatureList.Add(_weatherHolder.Values[index]);
            }
            return temperatureList.ToArray();
        }

        public void UpdateTemperature(DateTime dateTime, int newTemperature)
        {
            if (_weatherHolder.ContainsKey(dateTime))
            {
                _weatherHolder[dateTime] = newTemperature;
            }
            else
            {
                return;
            }
        }

        public void DeleteTemperature(DateTime startTime, DateTime endTime)
        {
            if (_weatherHolder.ContainsKey(startTime))
            {
                var startIndex = _weatherHolder.IndexOfKey(startTime);
                var endIndex = _weatherHolder.IndexOfKey(endTime);
                int nextDay = 0;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    _weatherHolder.Remove(startTime.AddDays(nextDay));
                    nextDay++;
                }
            }
            else
            {
                return;
            }
        }
    }
}
