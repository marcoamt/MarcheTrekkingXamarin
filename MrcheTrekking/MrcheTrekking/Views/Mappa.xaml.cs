using System;
using System.Collections.Generic;
using MrcheTrekking.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MrcheTrekking.Views
{
    public partial class Mappa : ContentPage
    {
        public Mappa(string m)
        {
            InitializeComponent();

            customMap.IsShowingUser = true;

            //split della stringa che contiene le coordinate che con la , funziona in emulatore e con ; nel dispositivo
            //quando fa lo split con l'emulatore mette le coordinate come 43.555
            string[] c = m.Split(',');
            List<double> latitudine = new List<double>();
            List<double> longitudine = new List<double>();

            for (int i = 0; i < c.Length; i++)
            {
                if (i % 2 == 0)
                {
                    latitudine.Add(Double.Parse(c[i]));
                }
                else
                {
                    longitudine.Add(Double.Parse(c[i]));
                }
            }

            //inserimento di un pin all'inizio del percorso
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(latitudine[0], longitudine[0]),
                Label = "Start",
                Address = "custom detail info"
            };
            customMap.Pins.Add(pin);

            //creazione del percorso collegando ogni punto con una linea polyline
            for (int i = 0; i < latitudine.Count; i++)
            {
                customMap.RouteCoordinates.Add(new Position(latitudine[i], longitudine[i]));
            }

            //inserimento di un pin alla fine del percorso
            var pinF = new Pin
            {
                Type = PinType.Place,
                Position = new Position(latitudine[latitudine.Count-1], longitudine[latitudine.Count-1]),
                Label = "End",
                Address = "custom detail info"
            };
            customMap.Pins.Add(pinF);

            //centro la mappa all'inizio del percorso
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitudine[0], longitudine[0]), Distance.FromMiles(1.0)));
            
        }


    }
}
