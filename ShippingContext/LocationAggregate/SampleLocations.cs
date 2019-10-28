using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShippingContext.LocationAggregate
{
    public class SampleLocations 
    {
        public static readonly Location HongKong = new Location(new UnLocode("CNHKG"), "Hongkong");
        public static readonly Location Melbourne = new Location(new UnLocode("AUMEL"), "Melbourne");
        public static readonly Location Stockholm = new Location(new UnLocode("SESTO"), "Stockholm");
        public static readonly Location Helsinki = new Location(new UnLocode("FIHEL"), "Helsinki");
        public static readonly Location Chicago = new Location(new UnLocode("USCHI"), "Chicago");
        public static readonly Location Tokyo = new Location(new UnLocode("JNTKO"), "Tokyo");
        public static readonly Location Hamburg = new Location(new UnLocode("DEHAM"), "Hamburg");
        public static readonly Location Shanghai = new Location(new UnLocode("CNSHA"), "Shanghai");
        public static readonly Location Rotterdam = new Location(new UnLocode("NLRTM"), "Rotterdam");
        public static readonly Location Gothenburg = new Location(new UnLocode("SEGOT"), "Göteborg");
        public static readonly Location Hangzou = new Location(new UnLocode("CNHGH"), "Hangzhou");
        public static readonly Location NewYork = new Location(new UnLocode("USNYC"), "New York");
        public static readonly Location Dallas = new Location(new UnLocode("USDAL"), "Dallas");
        
        private static readonly ReadOnlyDictionary<UnLocode, Location> all;

        static SampleLocations()
        {
            var dictionary = new Dictionary<UnLocode, Location>();

            typeof(SampleLocations)
                .GetFields()
                .Where(fieldInfo => fieldInfo.FieldType == typeof(Location))
                .Select(fieldInfo => fieldInfo.GetValue(null))
                .Cast<Location>()
                .ToList()
                .ForEach(location => dictionary.Add(location.UnLocode, location));
            
            all = new ReadOnlyDictionary<UnLocode, Location>(dictionary);
        }

        public IList<Location> getLocations()
        {
            return all.Values.ToList();
        }
        
        public IList<UnLocode> getUnLocodes()
        {
            return all.Keys.ToList();
        }

        public Location getLocationOrUnknown(UnLocode unLocode)
        {
            if (all.TryGetValue(unLocode, out var location))
                return location;
            
            return Location.Unknown;
        }
    }
}