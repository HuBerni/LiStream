namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayable
    {
        string GetDisplayableName();
        IList<DisplayableInformation> GetAdditionalInformation();
        bool IsPlaying();
    }
}
