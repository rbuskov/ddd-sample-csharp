using System;
using ShippingContext.LocationAggregate;

namespace ShippingContext.VoyageAggregate
{
public class SampleVoyages 
{
    public static readonly Voyage V100 = 
        new VoyageBuilder(new VoyageNumber("V100"), SampleLocations.HongKong)
        .AddMovement(SampleLocations.Tokyo, DateTimeOffset.Parse("2009-03-03"), DateTimeOffset.Parse("2009-03-05"))
        .AddMovement(SampleLocations.NewYork, DateTimeOffset.Parse("2009-03-06"), DateTimeOffset.Parse("2009-03-09"))
        .Build();
    
    public static readonly Voyage V200 = 
        new VoyageBuilder(new VoyageNumber("V200"), SampleLocations.Tokyo)
            .AddMovement(SampleLocations.NewYork,  DateTimeOffset.Parse("2009-03-06"),  DateTimeOffset.Parse("2009-03-08"))
            .AddMovement(SampleLocations.Chicago,  DateTimeOffset.Parse("2009-03-10"),  DateTimeOffset.Parse("2009-03-14"))
            .AddMovement(SampleLocations.Stockholm,  DateTimeOffset.Parse("2009-03-14"),  DateTimeOffset.Parse("2009-03-16"))
            .Build();
    
    public static readonly Voyage V300 = 
        new VoyageBuilder(new VoyageNumber("V300"), SampleLocations.Tokyo)
            .AddMovement(SampleLocations.Rotterdam, DateTimeOffset.Parse("2009-03-08"), DateTimeOffset.Parse("2009-03-11"))
            .AddMovement(SampleLocations.Hamburg, DateTimeOffset.Parse("2009-03-11"), DateTimeOffset.Parse("2009-03-12"))
            .AddMovement(SampleLocations.Melbourne, DateTimeOffset.Parse("2009-03-14"), DateTimeOffset.Parse("2009-03-18"))
            .AddMovement(SampleLocations.Tokyo, DateTimeOffset.Parse("2009-03-19"), DateTimeOffset.Parse("2009-03-21"))
            .Build();
   
    public static readonly Voyage V400 = 
        new VoyageBuilder(new VoyageNumber("V400"), SampleLocations.Hamburg)
            .AddMovement(SampleLocations.Stockholm,  DateTimeOffset.Parse("2009-03-14"),  DateTimeOffset.Parse("2009-03-15"))
            .AddMovement(SampleLocations.Helsinki,  DateTimeOffset.Parse("2009-03-15"),  DateTimeOffset.Parse("2009-03-16"))
            .AddMovement(SampleLocations.Hamburg,  DateTimeOffset.Parse("2009-03-20"),  DateTimeOffset.Parse("2009-03-22"))
            .Build();

    /// <summary>
    /// Voyage number 0100S (by ship)
    /// <para />
    /// Hongkong - Hangzou - Tokyo - Melbourne - New York
    /// </summary>
    public static readonly Voyage HongKongToNewYork =
        new VoyageBuilder(new VoyageNumber("0100S"), SampleLocations.HongKong)
            .AddMovement(SampleLocations.Hangzou, DateTimeOffset.Parse("2008-10-01 12:00"), DateTimeOffset.Parse("2008-10-03 14:30"))
            .AddMovement(SampleLocations.Tokyo, DateTimeOffset.Parse("2008-10-03 21:00"), DateTimeOffset.Parse("2008-10-06 06:15"))
            .AddMovement(SampleLocations.Melbourne, DateTimeOffset.Parse("2008-10-06 11:00"), DateTimeOffset.Parse("2008-10-12 11:30"))
            .AddMovement(SampleLocations.NewYork, DateTimeOffset.Parse("2008-10-14 12:00"), DateTimeOffset.Parse("2008-10-23 23:10"))
            .Build();

    /// <summary>
    /// Voyage number 0200T (by train)
    /// <para />
    /// New York - Chicago - Dallas
    /// </summary>
    public static readonly Voyage NewYorkToDallas =
        new VoyageBuilder(new VoyageNumber("0200T"), SampleLocations.NewYork)
            .AddMovement(SampleLocations.Chicago, DateTimeOffset.Parse("2008-10-24 07:00"), DateTimeOffset.Parse("2008-10-24 17:45"))
            .AddMovement(SampleLocations.Dallas, DateTimeOffset.Parse("2008-10-24 21:25"), DateTimeOffset.Parse("2008-10-25 19:30"))
            .Build();

    /// <summary>
    /// Voyage number 0300A (by airplane)
    /// <para />
    /// Dallas - Hamburg - Stockholm - Helsinki
    /// </summary>
    public static readonly Voyage DallasToHelsinki =
        new VoyageBuilder(new VoyageNumber("0300A"), SampleLocations.Dallas)
            .AddMovement(SampleLocations.Hamburg, DateTimeOffset.Parse("2008-10-29 03:30"), DateTimeOffset.Parse("2008-10-31 14:00"))
            .AddMovement(SampleLocations.Stockholm, DateTimeOffset.Parse("2008-11-01 15:20"), DateTimeOffset.Parse("2008-11-01 18:40"))
            .AddMovement(SampleLocations.Helsinki, DateTimeOffset.Parse("2008-11-02 09:00"), DateTimeOffset.Parse("2008-11-02 11:15"))
            .Build();

    /// <summary>
    ///  Voyage number 0301S (by ship)
    /// <para />
    /// Dallas - Helsinki, alternate route
    /// </summary>
    public static readonly Voyage DallasToHelsinkiAlternate =
        new VoyageBuilder(new VoyageNumber("0301S"), SampleLocations.Dallas)
            .AddMovement(SampleLocations.Helsinki, DateTimeOffset.Parse("2008-10-29 03:30"), DateTimeOffset.Parse("2008-11-05 15:45"))
            .Build();

    /// <summary>
    ///  Voyage number 0400S (by ship)
    /// <para />
    /// Helsinki - Rotterdam - Shanghai - Hongkong
    /// </summary>
    public static readonly Voyage HelsinkiToHongKong =
        new VoyageBuilder(new VoyageNumber("0400S"), SampleLocations.Helsinki)
            .AddMovement(SampleLocations.Rotterdam, DateTimeOffset.Parse("2008-11-04 05:50"), DateTimeOffset.Parse("2008-11-06 14:10"))
            .AddMovement(SampleLocations.Shanghai, DateTimeOffset.Parse("2008-11-10 21:45"), DateTimeOffset.Parse("2008-11-22 16:40"))
            .AddMovement(SampleLocations.HongKong, DateTimeOffset.Parse("2008-11-24 07:00"), DateTimeOffset.Parse("2008-11-28 13:37"))
            .Build();

//    public static final Map<VoyageNumber, Voyage> ALL = new HashMap<>();
//
//    static {
//        for (Field field : SampleVoyages.class.getDeclaredFields()) {
//            if (field.getType().equals(Voyage.class)) {
//                try {
//                    Voyage voyage = (Voyage) field.get(null);
//                    ALL.put(voyage.voyageNumber(), voyage);
//                } catch (IllegalAccessException e) {
//                    throw new RuntimeException(e);
//                }
//            }
//        }
//    }
//
//    public static List<Voyage> getAll() {
//        return new ArrayList<>(ALL.values());
//    }
//
//    public static Voyage lookup(VoyageNumber voyageNumber) {
//        return ALL.get(voyageNumber);
//    }

}
}