using GTA;
using GTA.Native;
using System;

namespace AdvancedWeatherForecast
{
    public class AdvancedWeatherForecast : Script
    {
        private Weather currentWeather;

        public AdvancedWeatherForecast()
        {
            Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, "news_weazelnews", true);
            currentWeather = World.Weather;
            Interval = 10000;
            Tick += OnTick;
        }

        private void OnTick(Object sender, EventArgs e)
        {
            if (!currentWeather.Equals(World.NextWeather))
            {
                currentWeather = World.NextWeather;
                NotifyWeather("Weather Forecast", "Weazel News", GetWeatherForecast(currentWeather));
            }
        }

        private void NotifyWeather(string s, string t, string m)
        {
            Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, m);
            Function.Call(Hash._SET_NOTIFICATION_MESSAGE, "news_weazelnews", "news_weazelnews", true, 0, t, "~b~" + s);
        }

        private string GetWeatherForecast(Weather w)
        {
            switch (w)
            {
                case Weather.Blizzard:
                    return "A big blizzard is expected.";

                case Weather.Clearing:
                    return "Skies will clear in the next hours.";

                case Weather.Clear:
                    return "The skies will be clear for the next couple of hours.";

                case Weather.Foggy:
                    return "It's going to be foggy for a while.";

                case Weather.Smog:
                    return "Clear skies accompanied by little fog are expected.";

                case Weather.Raining:
                    return "Rain is expected to feature the following hours.";

                case Weather.Neutral:
                    return "Strange things happening on the skies soon. Beware.";

                case Weather.ThunderStorm:
                    return "Heavy rain accompanied by thunder is expected.";

                case Weather.Snowlight:
                    return "Light snow is expected.";

                case Weather.Snowing:
                    return "Copious ammounts of snow for the next hours.";

                case Weather.Christmas:
                    return "Christmas itself is expected. Ho ho ho!";

                case Weather.ExtraSunny:
                    return "Skies will be extra sunny for a few hours.";

                case Weather.Overcast:
                    return "It's going to be overcast for some time.";

                case Weather.Clouds:
                    return "Clouds will cover the sky for some hours.";

                case Weather.Halloween:
                    return "Halloween is coming.";

                case Weather.Unknown:
                    return "Unknown.";

                default:
                    return "No idea.";
            }
        }
    }
}