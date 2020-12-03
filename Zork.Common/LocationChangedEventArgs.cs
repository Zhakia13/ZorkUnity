namespace Zork
{
    public class LocationChangedEventArgs
    {
        public Room PreviousLocation { get; internal set; }

        public Room NewLocation {get; internal set;}

        public LocationChangedEventArgs(Room previousLocation = null, Room newLocation = null)
        {
            PreviousLocation = previousLocation;
            NewLocation = newLocation;
        }
    }
}
