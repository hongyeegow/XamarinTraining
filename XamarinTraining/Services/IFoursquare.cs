using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinTraining.Model;

namespace XamarinTraining.Services
{
    public interface IFoursquare
    {
        Task<Place> getvenue(double lat, double lon);
    }
}
