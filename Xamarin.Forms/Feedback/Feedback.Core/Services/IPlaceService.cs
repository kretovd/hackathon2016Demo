﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Feedback.Core.Entities;

namespace Feedback.Core.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetPlacesAsync(int skip = 0, int take = 100);
        Task<Place> GetPlaceByBeaconAsync(BeaconModel beaconModel);
    }
}