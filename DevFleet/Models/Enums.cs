using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFleet.Models
{
    public enum Type
    {
        Bus,
        Truck,
        Luxirious_Single_Decker,
        Luxurious_Double_Decker,
        Car,
        SUV
    }

     public enum Commute_Origin
    {
        Yaba_Lagos, 
        Oyinbo_Lagos,
        Ketu_Lagos,
        Ikoyi_Lagos,
        Surulere_lagos
    }
    public enum Commute_Destination
    {
        Benin,
        Warri,
        Abuja,
        Port_Harcourt,
        Asaba,
        Onitsha,
        Kano,
        Minna,
        Calabar,
        Enugu,
        Lokoja,
        Akure,
        Ibadan,
        Abeokuta,
        Owerri
    }
    public enum Colors
    {
        White,
        Black,
        Brown,
        Blue
    }

    public enum Driver
    {
        David_Olatunde, Sola_Kutiyi,
        Segun_Adams, Olatunde_Ibukun,
        Spence_Woods
    }
}
