using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class SimpleWeather : MonoBehaviour
{
    public TMPro.TextMeshProUGUI temperatureText;
    public TMPro.TextMeshProUGUI forecastText;
    public GameObject sun;
    public GameObject snow;

    void Start()
    {
        StartCoroutine(GetWeather());
    }

    IEnumerator GetWeather()
    {
        string url = "https://api.open-meteo.com/v1/forecast?" +
            "latitude=48.43&longitude=-71.07" +
            "&current_weather=true" +
            "&daily=temperature_2m_max,temperature_2m_min,weathercode" +
            "&timezone=America%2FToronto" +
            "&forecast_days=6";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            WeatherData data = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);

            float temp = data.current_weather.temperature;
            float wind = data.current_weather.windspeed;
            int code = data.current_weather.weathercode;

            temperatureText.text =
                "=== METEO SAGUENAY ===\n\n" +
                "Aujourd'hui: " + temp + "C\n" +
                GetWeatherDescription(code) + "\n" +
                "Vent: " + wind + " km/h";

            string forecast = "-- Previsions --\n";
            for (int i = 1; i <= 5; i++)
            {
                DateTime date = DateTime.Parse(data.daily.time[i]);
                string dayName = GetDayName(date.DayOfWeek);
                string dateStr = date.Day + "/" + date.Month;
                forecast += dayName + " " + dateStr + "  " +
                    data.daily.temperature_2m_max[i] + "C / " +
                    data.daily.temperature_2m_min[i] + "C  " +
                    GetWeatherDescription(data.daily.weathercode[i]) + "\n";
            }
            forecastText.text = forecast;

            snow.SetActive(code >= 71 && code <= 77);
            sun.SetActive(code == 0);
        }
        else
        {
            Debug.LogError("Erreur meteo: " + request.error);
            temperatureText.text = "Donnees indisponibles";
        }
    }

    string GetWeatherDescription(int code)
    {
        if (code == 0) return "Ensoleille";
        if (code <= 2) return "Partiellement nuageux";
        if (code == 3) return "Couvert";
        if (code <= 49) return "Brouillard";
        if (code <= 57) return "Bruine";
        if (code <= 67) return "Pluie";
        if (code <= 77) return "Neige";
        if (code <= 82) return "Averses";
        if (code <= 99) return "Orage";
        return "Inconnu";
    }

    string GetDayName(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return "Lun";
            case DayOfWeek.Tuesday: return "Mar";
            case DayOfWeek.Wednesday: return "Mer";
            case DayOfWeek.Thursday: return "Jeu";
            case DayOfWeek.Friday: return "Ven";
            case DayOfWeek.Saturday: return "Sam";
            case DayOfWeek.Sunday: return "Dim";
            default: return "";
        }
    }
}

[System.Serializable]
public class WeatherData
{
    public CurrentWeather current_weather;
    public DailyWeather daily;
}

[System.Serializable]
public class CurrentWeather
{
    public float temperature;
    public float windspeed;
    public int weathercode;
}

[System.Serializable]
public class DailyWeather
{
    public string[] time;
    public float[] temperature_2m_max;
    public float[] temperature_2m_min;
    public int[] weathercode;
}